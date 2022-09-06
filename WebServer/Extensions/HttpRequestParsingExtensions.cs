using System;
using WebServer.Attributes;
using WebServer.Enums;
using WebServer.Structs;
using System.Collections.Generic;
namespace WebServer.Extensions
{
    public static class HttpRequestParsingExtensions
    {
        public static HttpRequestInfo GetHttpRequestInfo(this string str)
        {
            //get string lines
            string[] allLines = str.GetStringLines();
            //get request type and endpoint
            HttpRequestLine httpRequestLine = allLines[0].GetHttpRequestLine();

            //process headers
            int index = 1;
            var headers = new Dictionary<string, string>();
            while(index < allLines.Length && allLines[index] != string.Empty)
            {
                var curString = allLines[index];
                string[] stringArr = curString.Split(':');
                if (stringArr.Length > 1)
                {
                    headers.Add(stringArr[0], stringArr[1]);
                }
                index++;
            }

            //process request body
            string body = string.Empty;
            if (index + 1 < allLines.Length)
            {
                for (int i = index + 1; i < allLines.Length; i++)
                {
                    body += allLines[i];
                }
            }
            return new HttpRequestInfo()
            {
                HttpRequestLine = httpRequestLine,
                Headers = headers,
                Body = body
            };
        }

        public static HttpRequestLine GetHttpRequestLine(this string str)
        {
            string[] split = str.Split(' ');

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