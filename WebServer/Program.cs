using System;
using WebServer.Attributes;
using WebServer.Core;
using WebServer.Enums;
using WebServer.Extensions;

namespace WebServer
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var request = "GET / HTTP/1.1\r\nuser-agent: Thunder Client (https://www.thunderclient.com)\r\naccept: /\r\ncontent-type: application/json\r\ncontent-length: 12\r\naccept-encoding: gzip, deflate, br\r\nHost: 127.0.0.1:13000\r\nConnection: close\r\n\r\nTesting body";

            new TcpServer(7777, "0.0.0.0").StartServer();
        }
    }

    public static class Test
    {
        [HttpMethod("/favicon.ico", HttpMethodType.GET)]
        public static void TestGet()
        {
            Console.WriteLine("Recieved a get request!");
        }
    }
}