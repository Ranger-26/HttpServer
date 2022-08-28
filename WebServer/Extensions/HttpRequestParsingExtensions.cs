using System;
using WebServer.Attributes;
using WebServer.Enums;
using WebServer.Structs;

namespace WebServer.Extensions
{
    public static class HttpRequestParsingExtensions
    {
        public static HttpRequestInfo GetHttpRequestInfo(this string str)
        {
            return new HttpRequestInfo();
        }

        public static HttpRequestLine GetHttpRequestLine(this string str)
        {
            string[] split = str.Split(' ');
            foreach (var s in split)
            {
                Console.WriteLine(s);
            }
            HttpMethodType method;
            if (!Enum.TryParse(split[0], true, out method))
            {
                Console.WriteLine($"Invalid request received: {split[0]}");
            }

            return new HttpRequestLine()
            {
                HttpMethodType = method,
                Endpoint = split[1]
            };
        }
    }
}
/*
GET /fff HTTP/1.1
user-agent: Thunder Client (https://www.thunderclient.com)
accept: /
content-type: application/json
content-length: 12
accept-encoding: gzip, deflate, br
Host: 127.0.0.1:13000
Connection: close

Testing body
*/