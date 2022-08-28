using System;
using WebServer.Enums;

namespace WebServer.Attributes
{
    public class HttpMethod : Attribute
    {
        public string Endpoint;
        public HttpMethodType HttpMethodType;

        public HttpMethod(string endpoint, HttpMethodType methodType)
        {
            Endpoint = endpoint;
            HttpMethodType = methodType;
        }
    }
}