using System.Collections.Generic;

namespace WebServer.Structs
{
    public struct HttpRequestInfo
    {
        public HttpRequestLine HttpRequestLine;
        public Dictionary<string, string> Headers;
        public string Body;
    }
}