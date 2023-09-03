using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AuthHost
{
    public class TcpServer
    {
        private TcpListener _tcpListener;
        private TcpClient _tcpClient;
        private Func<string> _uiDataGetter;

        public TcpServer(Func<string> uiDataGetter)
        {
            _uiDataGetter = uiDataGetter;
        }

        public async Task StartListeningAsync(string ipAddress, int port)
        {
            _tcpListener = new TcpListener(IPAddress.Parse(ipAddress), port);
            _tcpListener.Start();

            try
            {
                _tcpClient = await _tcpListener.AcceptTcpClientAsync();
                HandleClientAsync(_tcpClient);
            }
            catch (Exception ex)
            {
                // Handle exception here
                Console.WriteLine(ex.Message);
            }
        }

        private async void HandleClientAsync(TcpClient tcpClient)
        {
            using (var networkStream = tcpClient.GetStream())
            {
                byte[] buffer = new byte[1024];
                while (true)
                {
                    int bytesRead = await networkStream.ReadAsync(buffer, 0, buffer.Length);
                    if (bytesRead == 0)
                    {
                        // Connection closed
                        break;
                    }

                    string receivedData = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    string uiData = _uiDataGetter();  // Get UI data through delegate
                    // Do something with receivedData and uiData

                    byte[] sendData = Encoding.UTF8.GetBytes("Server response");
                    await networkStream.WriteAsync(sendData, 0, sendData.Length);
                }
            }
        }

        public void StopListening()
        {
            _tcpClient?.Close();
            _tcpListener?.Stop();
        }
    }
}
