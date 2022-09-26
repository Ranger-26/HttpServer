using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using WebServer.Extensions;
using WebServer.Structs;

namespace WebServer.Core
{
    internal class TcpServer
    {
        private TcpListener _tcpListener;

        private byte[] _incomingStream = new byte[256];
        
        public TcpServer(int port, string ip)
        {
            HttpMessageHandler.RegisterEndpoints();
            _tcpListener = new TcpListener(IPAddress.Parse(ip), port);
        }

        public void StartServer()
        {
            _tcpListener.Start();
            StartMainLoop();
        }


        private void StartMainLoop()
        {
            while (true)
            {
                Console.WriteLine("Waiting for a connection... ");
                TcpClient client = _tcpListener.AcceptTcpClient();
                Console.WriteLine("Found connection!");
                HandleTcpConnection(client);
            }
        }

        private void HandleTcpConnection(TcpClient client)
        {
            var thread = new Thread(() =>
            {
                NetworkStream stream = client.GetStream();

                int i = stream.Read(_incomingStream, 0, _incomingStream.Length);

                string data = Encoding.ASCII.GetString(_incomingStream, 0, i);
                Console.WriteLine("Received: " + Environment.NewLine + data);

                HttpMessageHandler.TryInvokeMethod(data.GetHttpRequestInfo());
                var sendBuf = Encoding.UTF8.GetBytes(HttpResponseInfo.GetDefault().ToString());
                stream.Write(sendBuf, 0, sendBuf.Length);



               Console.WriteLine($"Buffer Length: {_incomingStream.Length}");
                client.Close();
            });
            thread.Start();
        }
    }
}