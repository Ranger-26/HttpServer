﻿using System.Collections.Generic;

namespace WebServer.Structs
{
    public struct HttpRequestInfo
    {
        public HttpRequestLine HttpRequestLine;
        public Dictionary<string, string> Headers;
        public string Body;

        public override string ToString()
        {
            return $"Line:{HttpRequestLine}, Headers: {Headers}, Body: {Body}";
        }
    }
}