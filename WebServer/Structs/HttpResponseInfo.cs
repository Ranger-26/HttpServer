using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Structs
{
    public struct HttpResponseInfo
    {
        public string HttpCodeLine;

        public Dictionary<string, string> Headers;

        public string Body;

        public override string ToString()
        {
            string s = $"{HttpCodeLine}"+Environment.NewLine;
            foreach (var val in Headers)
            {
                s += val.Key + ":" + val.Value + Environment.NewLine;
            }
            s += Environment.NewLine;
            s += Body;
            s += Environment.NewLine;
            s += Environment.NewLine;
            return s;
        }
    }
}
