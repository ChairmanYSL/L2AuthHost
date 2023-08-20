using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace AuthHost
{
    public class TcpServer
    {
        private TcpListener listener;
        private TcpClient client;
        private bool continueListening = true;

        public event Action<string> OnMessage; // 事件，用于向外部发送消息
        private readonly Queue<string> receivedDataQueue = new Queue<string>();  // 用队列存储接收到的数据
        public void Start(string ipAddressString, int port)
        {
            IPAddress localAddr;
            if (!IPAddress.TryParse(ipAddressString, out localAddr))
            {
                OnMessage?.Invoke("Invalid IP Address!");
                return;
            }

            listener = new TcpListener(localAddr, port);
            listener.Start();

            OnMessage?.Invoke($"Listening on {localAddr}:{port}...");

            while (continueListening)
            {
                client = listener.AcceptTcpClient();
                OnMessage?.Invoke("Client connected!");
                HandleClient(client);
            }
        }

        public void Stop()
        {
            continueListening = false;
            client?.Close();
            listener?.Stop();
        }
        public void SendData(string data)
        {
            if (client != null && client.Connected)
            {
                Tool tool = new Tool();
                byte[] bytesToSend = tool.StringToBCD(data);
                client.GetStream().Write(bytesToSend, 0, bytesToSend.Length);
                OnMessage?.Invoke($"Sent: {data}");
            }
            else
            {
                OnMessage?.Invoke("No client connected or connection lost.");
            }
        }

        // 提供的外部方法，检查是否有数据可读
        public bool HasDataAvailable()
        {
            return receivedDataQueue.Count > 0;
        }

        public string RetrieveReceivedData()
        {
            if (receivedDataQueue.Count > 0)
            {
                return receivedDataQueue.Dequeue();
            }
            else
            {
                return null; // 如果队列为空，返回null
            }
        }

        // 提供的外部方法，用于一次性读取所有数据并清空队列
        public List<string> RetrieveAllReceivedData()
        {
            List<string> allData = new List<string>(receivedDataQueue);
            receivedDataQueue.Clear();  // 清空队列
            return allData;
        }

        private void HandleClient(TcpClient client)
        {
            using (var stream = client.GetStream())
            {
                byte[] buffer = new byte[1024];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string dataReceived = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                receivedDataQueue.Enqueue(dataReceived); // 将数据加入队列

                OnMessage?.Invoke($"Received: {dataReceived}");
            }
            //client.Close();
        }
    }
}
