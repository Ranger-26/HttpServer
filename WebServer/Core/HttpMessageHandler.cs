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
        private static Dictionary<HttpRequestLine, MethodInfo> _allMethods =
            new Dictionary<HttpRequestLine, MethodInfo>();

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
                    var methodId = new HttpRequestLine()
                    {
                        Endpoint = httpAtr.Endpoint,
                        HttpMethodType = httpAtr.HttpMethodType
                    };
                    try
                    {
                        _allMethods.Add(methodId, method);
                        Console.WriteLine($"Succesfully added {methodId} with method name {method.Name} to dictionary!");
                    }
                    catch (Exception e)
                    {
                        throw new Exception($"Exception occured when registering method {methodId}:{e}");
                    }
                }
            }
        }

        internal static void TryInvokeMethod(HttpRequestInfo identifier)
        {
            if (!_allMethods.ContainsKey(identifier.HttpRequestLine))
            {
                Console.WriteLine($"Could not find method identifier {identifier} in dictionary, using default");
                return;
            }

            _allMethods[identifier.HttpRequestLine].Invoke(null, new object[] { identifier });
        }
    }
}