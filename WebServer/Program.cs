﻿using System;
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
            new TcpServer(8435, "0.0.0.0").StartServer();
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