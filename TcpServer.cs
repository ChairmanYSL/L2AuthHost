using AuthHost;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class TCPServer
{
    private TcpListener _server;
    private TcpClient _clientSocket;
    private NetworkStream _networkStream;

    public event EventHandler<byte[]> DataReceived;
    public event EventHandler<string> ErrorOccurred;
    public delegate void LogDelegate(string message);
    public event LogDelegate LogNeeded;


    public TCPServer()
    {
        _clientSocket = null;
    }

    ~TCPServer()
    {
        Dispose(false);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            // Dispose managed resources
            _networkStream?.Dispose();
            _clientSocket?.Close();
            _server?.Stop();
        }
        // Dispose unmanaged resources if any
    }

    public void Listen(string hostAddress, int port)
    {
        Stop();  // 确保在开始新的监听前停止之前的监听
        _server = new TcpListener(IPAddress.Parse(hostAddress), port);
        _server.Start();
        LogNeeded.Invoke($"TCP server listening on {hostAddress} port {port}");

        _server.BeginAcceptTcpClient(new AsyncCallback(HandleNewConnection), null);
    }

    public int SendData(byte[] data)
    {
        if (_networkStream != null)
        {
            _networkStream.Write(data, 0, data.Length);
            return data.Length;
        }
        return 0;
    }

    public void CloseConnection()
    {
        _networkStream?.Close();
        _clientSocket?.Close();

        _networkStream = null;
        _clientSocket = null;
    }

    private void HandleNewConnection(IAsyncResult result)
    {
        try
        {
            if (_server == null || !_server.Server.IsBound)
            {
                return;
            }

            _clientSocket = _server.EndAcceptTcpClient(result);
            LogNeeded.Invoke("Client connected: ");

            _networkStream = _clientSocket.GetStream();

            byte[] buffer = new byte[_clientSocket.ReceiveBufferSize];
            _networkStream.BeginRead(buffer, 0, buffer.Length, HandleReadyRead, null);

            _server.BeginAcceptTcpClient(new AsyncCallback(HandleNewConnection), null);
        }
        catch (Exception ex)
        {
            ErrorOccurred?.Invoke(this, ex.Message);
            LogNeeded.Invoke($"Error in HandleNewConnection: {ex.Message}");
        }
    }


    private void HandleReadyRead(IAsyncResult result)
    {
        try
        {
            byte[] data = new byte[_clientSocket.ReceiveBufferSize];
            int bytesRead = _networkStream.Read(data, 0, data.Length);
            //LogNeeded.Invoke("Read TCP Data Len: " + bytesRead);
            Array.Resize(ref data, bytesRead);  //Resize the array to match the actual data length
            //LogNeeded.Invoke("Read TCP Data: " + Tool.ByteArrayToBcdString(data));
            DataReceived?.Invoke(this, data);

            _networkStream.BeginRead(new byte[] { 0 }, 0, 0, HandleReadyRead, null);
        }
        catch (Exception ex)
        {
            ErrorOccurred?.Invoke(this, ex.Message);
            Console.WriteLine($"TCP error occurred: {ex.Message}");
        }
    }

    public void ClearBuffer()
    {
        byte[] buffer = new byte[_clientSocket.ReceiveBufferSize];
        while (_networkStream.DataAvailable)
        {
            _networkStream.Read(buffer, 0, buffer.Length);
        }
    }

    public bool IsServerListening()
    {
        return _server.Pending();
    }

    public bool IsSocketOpen()
    {
        return _clientSocket?.Connected ?? false;
    }

    public void Stop()
    {
        CloseConnection();  // 关闭客户端连接
        _server?.Stop();  // 停止 TcpListener
    }

}
