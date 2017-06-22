using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.IO;

namespace _3.Readers.ipc.ClientProIPC
{
    public class ClientProIPC : ClientIPC
    {
        private readonly Dictionary<string, FileEdit<int>> files;

        private Socket socketListener;

        private bool isWork;

        private int maxId;

        private const string ipFileName = @"\\VOLANDER-PC\sharedFolder\ipFile.txt";
        //private const string ipFileName = @"\\vmware-host\Shared Folders\sharedFolder\ipFile.txt";

        private bool amIServer;

        public ClientProIPC()
        {
            isWork = true;
            maxId = 0;
            files = new Dictionary<string, FileEdit<int>>();
            var checkServerThread = new Thread(BecomeServer);
            checkServerThread.Start();
        }

        private void InitializeClientSocket()
        {
            IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());

            if (File.Exists(ipFileName) == false)
            {
                IPAddress[] adressList = ipHost.AddressList;
                foreach (IPAddress ipAddress in adressList)
                {
                    if(ipAddress.ToString().Contains('.'))
                    {
                        ipAddr = ipAddress;
                        break;
                    }
                }

                File.WriteAllText(ipFileName, ipAddr.ToString());
            }
            else
            {
                ipAddr = IPAddress.Parse(File.ReadAllText(ipFileName));
            }

            ipEndPoint = new IPEndPoint(ipAddr, 11000);
            clientSocket = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            
        }

        private void BecomeServer()
        {
            bool isServerRun = true;
            InitializeClientSocket();

            // Назначаем сокет локальной конечной точке и слушаем входящие сокеты
            // Создаем сокет Tcp/Ip
            socketListener = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            amIServer = false;
            while (isServerRun)
            {
                try
                {
                    socketListener.Bind(ipEndPoint);
                    isServerRun = false;
                }
                catch (SocketException)
                {
                    isServerRun = true;
                    Thread.Sleep(500);
                }
                catch (ObjectDisposedException)
                {
                    return;
                }
            }
            amIServer = true;
            socketListener.Listen(10);
            while (isWork)
            {
                // Программа приостанавливается, ожидая входящее соединение
                try
                {
                    Socket client = socketListener.Accept();

                    var myThread = new Thread(CommunicationWithClient);
                    myThread.Start(client);
                }
                catch (SocketException)
                {
                }
                
            }
        }

        private void CommunicationWithClient(object o)
        {
            var client = (Socket)o;
            var bytes = new byte[1024];

            bool isExit = false;
            while (isExit == false)
            {
                int bytesReceived;
                try
                {
                    bytesReceived = client.Receive(bytes);
                }
                catch (SocketException)
                {
                    bytesReceived = 0;
                }
                string receivedMessage = Encoding.UTF8.GetString(bytes, 0, bytesReceived);

                string[] list = receivedMessage.Split(receivedMessage.Contains("\n") ? '\n' : '?' );
                string fileName = list.Length > 1 ? list[0] : "";

                fileName = Path.GetFileName(fileName) ?? fileName;
                
                //если abort -- то клиент неожиданно завершил работу
                string action = list.Length == 2 ? list[1] : "abort";

                if (receivedMessage.Contains("\n"))
                {
                    action = "changedServer";
                }

                int clientId = -1;
                if (action.Contains("-"))
                {
                    var a = action.Split('-');
                    action = a[0];
                    clientId = int.Parse(a[1]);
                }

                string result = "True";
                switch (action)
                {
                    case "changedServer":
                        //получаем максимальный id
                        List<string> previousQueue = list.ToList();
                        maxId = int.Parse(previousQueue.Last());
                        previousQueue.Remove(previousQueue.Last());

                        //записываем очередь, что передал предыдущий сервер в нашу очередь
                        foreach (string queueMember in previousQueue)
                        {
                            string[] fileNameAndId = queueMember.Split('?');
                            if (fileNameAndId.Length == 2)
                            {
                                fileName = fileNameAndId[0];
                                int id = int.Parse(fileNameAndId[1]);
                                if (files.ContainsKey(fileName) == false)
                                {
                                    files.Add(fileName, new FileEdit<int>());
                                }
                                files[fileName].Enqueue(id);
                            }
                        }
                        break;
                    case "enqueue":
                        if (files.ContainsKey(fileName) == false)
                        {
                            files.Add(fileName, new FileEdit<int>());
                        }
                        files[fileName].Enqueue(clientId);
                        break;
                    case "dequeue":
                        if (files.ContainsKey(fileName))
                        {
                            files[fileName].Dequeue(clientId);
                        }
                        break;
                    case "canIEdit":
                        if (files.ContainsKey(fileName) == false)
                        {
                            files.Add(fileName, new FileEdit<int>());
                        }
                        result = files[fileName].CanIEdit(clientId).ToString();
                        break;
                    case "save":
                        files[fileName].FileWasSaved(clientId);
                        break;
                    case "didISaveFile":
                        result = files.ContainsKey(fileName) == false ? "True" : files[fileName].DidISaveFile(clientId).ToString();
                        break;
                    case "sayMyId":
                        result = maxId++.ToString();
                        break;
                    case "exit":
                        isExit = true;
                        break;
                    case "abort":
                        foreach (var fileEdit in files)
                        {
                            fileEdit.Value.Dequeue(clientId);
                        }
                        isExit = true;
                        break;
                }

                byte[] msg = Encoding.UTF8.GetBytes(result);
                try
                {
                    client.Send(msg);
                }
                catch (SocketException)
                {
                }
                
            }
        }

        public override void Reset()
        {
            base.Reset();

            if (amIServer)
            {
                File.Delete(ipFileName);
            }

            isWork = false;
            socketListener.Close();

            DateTime start = DateTime.Now;
            while (IsServerRun() == false && (DateTime.Now - start) < new TimeSpan(0,0,0,0,500))
            {
                
            }

            if (IsServerRun())
            {
                string fileName;
                string sendingInfo = "";
                if (files != null)
                {
                    foreach (KeyValuePair<string, FileEdit<int>> fileEdit in files)
                    {
                        fileName = fileEdit.Key;
                        foreach (int client in fileEdit.Value.WriteQueue)
                        {
                            sendingInfo += String.Format("{0}?{1}\n", fileName, client);
                        }
                    }
                }

                sendingInfo += maxId;
                SendMessageToServer(sendingInfo);
            }
        }

        private bool IsServerRun()
        {
            if (ConnectWithServer())
            {
                bool part1 = clientSocket.Poll(1000, SelectMode.SelectRead);
                bool part2 = (clientSocket.Available == 0);
                if (part1 && part2)
                {
                    return false;
                }
                return true;
            }
            return false;
        }

        public override bool IsOk()
        {
            return true;
        }
    }
}
