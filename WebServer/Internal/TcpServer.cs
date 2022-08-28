using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace WebServer.Internal
{
    internal class TcpServer
    {
        private TcpListener _tcpListener;

        private byte[] _incomingStream = new byte[256];
        
        public TcpServer(int port, string ip)
        {
            _tcpListener = new TcpListener(IPAddress.Parse(ip), port);
        }

        public void StartServer()
        {
            _tcpListener.Start();
            while (true)
            {
                Console.Write("Waiting for a connection... ");

                // Perform a blocking call to accept requests.
                // You could also use server.AcceptSocket() here.
                TcpClient client = _tcpListener.AcceptTcpClient();
                Console.WriteLine("Connected!");
                HandleTcpConnection(client);

            }
        }


        void HandleTcpConnection(TcpClient client)
        {
            var thread = new Thread(() =>
            {
                NetworkStream stream = client.GetStream();

                int i = stream.Read(_incomingStream, 0, _incomingStream.Length);



                string data = System.Text.Encoding.ASCII.GetString(_incomingStream, 0, i);
                Console.WriteLine("Received: {0}", data);


                var result = "<h1>Hello, world!</h1>";
                var sendBuf = Encoding.UTF8.GetBytes(
                    "HTTP/1.0 200 OK" + Environment.NewLine
                                      + "Content-Length: " + result.Length + Environment.NewLine
                                      + "Content-Type: " + "text/plain" + Environment.NewLine
                                      + Environment.NewLine
                                      + result
                                      + Environment.NewLine + Environment.NewLine);
                stream.Write(sendBuf, 0, sendBuf.Length);



                Console.WriteLine($"Buffer Length: {_incomingStream.Length}");
                client.Close();
            });
            thread.Start();
        }
    }
}