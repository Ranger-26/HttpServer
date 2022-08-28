using System.Collections.Generic;
using System.Reflection;
using WebServer.Structs;

namespace WebServer.Core
{
    public static class HttpMessageHandler
    {
        private static Dictionary<MethodIdentifier, MethodInfo> _allMethods =
            new Dictionary<MethodIdentifier, MethodInfo>();

        
    }
}