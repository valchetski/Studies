using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace _3.Readers.ipc
{
    public class ClientIPC : IPC
    {
        private string fileName;

        protected Socket clientSocket;

        protected IPAddress ipAddr;
        protected IPEndPoint ipEndPoint;

        private int? id;

        protected int? Id
        {
            get
            {
                if (id == null)
                {
                    string answer = CommunicationWithServer("sayMyId");
                    if (answer != null)
                    {
                        id = int.Parse(answer);
                    }
                }
                return id;
            }
        }

        public ClientIPC()
        {
            IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
            ipAddr = ipHost.AddressList[0];

            ipEndPoint = new IPEndPoint(ipAddr, 11000);
            clientSocket = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        }

        public override void Enqueue()
        {
            CommunicationWithServer(RequestMessage("enqueue"));
        }

        public override void Dequeue()
        {
            CommunicationWithServer(RequestMessage("dequeue"));
        }

        public override void SetFileName(string newFileName)
        {
            //fileName = GetFullPathOfFile(newFileName);
            fileName = newFileName;
        }

        public override bool DidISaveFile()
        {
            bool result;
            bool.TryParse(CommunicationWithServer(RequestMessage("didISaveFile")), out result);
            return result;
        }

        public override bool CanIEdit()
        {
            bool result;
            bool.TryParse(CommunicationWithServer(RequestMessage("canIEdit")), out result);
            return result;
        }

        public override void Reset()
        {
            base.Reset();
            
            CommunicationWithServer("exit");
            if (clientSocket.Connected)
            {
                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Close();
            }
        }

        public override void FileWasSaved()
        {
            CommunicationWithServer(RequestMessage("save"));
        }

        private string RequestMessage(string message)
        {
            return message + "-" + Id;
        }

        public override bool IsOk()
        {
            return CheckServer();
        }

        protected string CommunicationWithServer(string message)
        {
            //? -- это просто разделитель
            message = String.Format("{0}?{1}", fileName ?? "", message);
            SendMessageToServer(message);

            string result;
            // Получаем ответ от сервера
            var bytes = new byte[1024];
            try
            {
                int bytesReceived = clientSocket.Receive(bytes);
                result = Encoding.UTF8.GetString(bytes, 0, bytesReceived);
            }
            catch (SocketException)
            {
                result = null;
            }
            return result;
        }

        protected void SendMessageToServer(string message)
        {
            if (ConnectWithServer())
            {
                byte[] msg = Encoding.UTF8.GetBytes(message);
                try
                {
                    clientSocket.Send(msg);
                }
                catch (SocketException)
                {
                    if (message.Contains("dequeue"))
                    {
                        clientSocket = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                        clientSocket.Connect(ipEndPoint);
                        clientSocket.Send(msg);
                    }
                }
            }
        }

        public bool CheckServer()
        {
            byte[] msg = Encoding.UTF8.GetBytes("");
            bool result;
            try
            {
                ConnectWithServer();
                clientSocket.Send(msg);
                result = true;
            }
            catch (SocketException)
            {
                result = false;
            }
            return result;
        }

        protected bool ConnectWithServer()
        {
            try
            {
                if (clientSocket.Connected == false)
                {
                    // Соединяем сокет с удаленной точкой
                    clientSocket.Connect(ipEndPoint);
                }
                return true;
            }
            catch (SocketException)
            {
                return false;
            }
            catch (InvalidOperationException)
            {
                clientSocket = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    clientSocket.Connect(ipEndPoint);
                    return true;
                }
                catch (SocketException)
                {
                    return false;
                }
            }
        }
    }
}
