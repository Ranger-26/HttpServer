using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
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
            new TcpServer(7777,"0.0.0.0").StartServer();
        }
    }

    public static class Test
    {
        [HttpMethod("/", HttpMethodType.GET)]
        public static void TestSlash(NetworkStream stream)
        {
            var result = "<h1>Hello, world!</h1>";
            var sendBuf = Encoding.UTF8.GetBytes(
                "HTTP/1.0 200 OK" + Environment.NewLine
                                  + "Content-Length: " + result.Length + Environment.NewLine
                                  + "Content-Type: " + "text/html" + Environment.NewLine
                                  + Environment.NewLine
                                  + result
                                  + Environment.NewLine + Environment.NewLine);
            stream.Write(sendBuf, 0, sendBuf.Length);
            Console.WriteLine("Recieved a get request!");
        }
        
        
        [HttpMethod("/favicon.ico", HttpMethodType.GET)]
        public static void TestGet(NetworkStream stream)
        {
            var result = "<h1>Hello, world!</h1>";
            var sendBuf = Encoding.UTF8.GetBytes(
                "HTTP/1.0 200 OK" + Environment.NewLine
                                  + "Content-Length: " + result.Length + Environment.NewLine
                                  + "Content-Type: " + "text/html" + Environment.NewLine
                                  + Environment.NewLine
                                  + result
                                  + Environment.NewLine + Environment.NewLine);
            stream.Write(sendBuf, 0, sendBuf.Length);
            Console.WriteLine("Recieved a get request!");
        }
        
        [HttpMethod("/XD", HttpMethodType.GET)]
        public static void TestFileTransfer(NetworkStream stream)
        {
            var buff2 = File.ReadAllBytes(@"C:\Users\siddh\Desktop\GameBulds\Beowulf\Beowulf_Data\Managed\Assembly-CSharp.dll");
            var sendBuf = Encoding.UTF8.GetBytes(
                                   "HTTP/1.0 200 OK" + Environment.NewLine
                                  + "Content-Length: " + buff2.Length + Environment.NewLine
                                  + "Content-Type: application/octet-stream" + Environment.NewLine
                                  + "Content-Disposition: attachment; filename='Assembly-CSharp.dll'" + Environment.NewLine + Environment.NewLine);

            var finalBuff = new List<byte>();
            
            finalBuff.AddRange(sendBuf);
            finalBuff.AddRange(buff2);
            
            stream.Write(finalBuff.ToArray(), 0, sendBuf.Length);


        }
    }
}