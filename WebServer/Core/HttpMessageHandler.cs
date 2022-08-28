using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using WebServer.Attributes;
using WebServer.Extensions;
using WebServer.Structs;

namespace WebServer.Core
{
    internal static class HttpMessageHandler
    {
        private static Dictionary<MethodIdentifier, MethodInfo> _allMethods =
            new Dictionary<MethodIdentifier, MethodInfo>();

        internal static void RegisterEndpoints()
        {
            _allMethods.Clear();
            foreach (var method in ReflectionExtensions.GetMethodsWithAttribute<HttpMethod>())
            {
                if (!method.IsStaticMethod())
                {
                    throw new Exception("Found non-static method with HttpMethod attribute. This is not allowed");
                }
                foreach (var attribute in method.GetCustomAttributes())
                {
                    var httpAtr = (HttpMethod) attribute;
                    var methodId = new MethodIdentifier()
                    {
                        Endpoint = httpAtr.Endpoint,
                        HttpMethodType = httpAtr.HttpMethodType
                    };
                    try
                    {
                        _allMethods.Add(methodId, method);
                    }
                    catch (Exception e)
                    {
                        throw new Exception($"Exception occured when registering method {methodId}:{e}");
                    }
                }
            }
        }

        public static void TryInvokeMethod(MethodIdentifier identifier)
        {
            if (!_allMethods.ContainsKey(identifier))
            {
                Console.WriteLine($"Could not find method identifier {identifier} in dictionary, using default");
                return;
            }

            _allMethods[identifier].Invoke(null, Array.Empty<object>());
            Console.WriteLine($"Succesfully invoked method with identifier {identifier}");
        }
    }
}