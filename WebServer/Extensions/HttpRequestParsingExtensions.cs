using WebServer.Structs;

namespace WebServer.Extensions
{
    public static class HttpRequestParsingExtensions
    {
        public static HttpRequestInfo GetHttpRequestInfo(this string str)
        {
            return new HttpRequestInfo();
        }
    }
}