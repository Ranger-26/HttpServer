using WebServer.Attributes;
using WebServer.Core;
using WebServer.Enums;

namespace WebServer
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            new TcpServer(13000, "127.0.0.1").StartServer();
        }
    }
}