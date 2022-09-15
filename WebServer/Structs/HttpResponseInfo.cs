using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Structs
{
    public struct HttpResponseInfo
    {
        public int HttpCode;

        public Dictionary<string, string> Headers;

        public string Body;

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
