using System;
using System.Net;
using System.Net.Sockets;

namespace WebServer.Core
{
    public class TcpServer
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
            
        }
    }
}