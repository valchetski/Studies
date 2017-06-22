using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace _4.Readers.Server
{
    class Server
    {
        private readonly Dictionary<string, FileEdit<Socket>> files;

        private int maxId;

        public Server()
        {
            files = new Dictionary<string, FileEdit<Socket>>();
        }

        public void Start()
        {
            // Устанавливаем для сокета локальную конечную точку
            IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddr = ipHost.AddressList[0];
            var ipEndPoint = new IPEndPoint(ipAddr, 11000);

            // Назначаем сокет локальной конечной точке и слушаем входящие сокеты
            // Создаем сокет Tcp/Ip
            var socketListener = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            socketListener.Bind(ipEndPoint);
            socketListener.Listen(10);

            Console.WriteLine("Server have started");
            // Начинаем слушать соединения
            while (true)
            {
                // Программа приостанавливается, ожидая входящее соединение
                Socket client = socketListener.Accept();

                var myThread = new Thread(CommunicationWithClient);
                myThread.Start(client); 
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

                Console.WriteLine(receivedMessage);

                //string[] list = receivedMessage.Split(new[] {receivedMessage.Contains("\n") ? "\n" : "?" }, StringSplitOptions.RemoveEmptyEntries);
                string[] list = receivedMessage.Split(receivedMessage.Contains("\n") ? '\n' : '?');
                string fileName = list.Length > 1 ? list[0] : "";
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
                    case "enqueue":
                        if (files.ContainsKey(fileName) == false)
                        {
                            files.Add(fileName, new FileEdit<Socket>());
                        }
                        files[fileName].Enqueue(client, clientId);
                        break;
                    case "dequeue":
                        if (files.ContainsKey(fileName))
                        {
                            files[fileName].Dequeue(client);
                        }
                        break;
                    case "canIEdit":
                        if (files.ContainsKey(fileName) == false)
                        {
                            files.Add(fileName, new FileEdit<Socket>());
                        }
                        result = files[fileName].CanIEdit(client, clientId, new List<string>(), fileName).ToString();
                        break;
                    case "save":
                        files[fileName].FileWasSaved(client);
                        break;
                    case "didISaveFile":
                        result = files[fileName].DidISaveFile(client).ToString();
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
                            fileEdit.Value.Dequeue(client);
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
    }
}