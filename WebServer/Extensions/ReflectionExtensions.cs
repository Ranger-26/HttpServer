using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using WebServer.Attributes;

namespace WebServer.Extensions
{
    public static class ReflectionExtensions
    {
        public static bool ParameterCheck(this MethodInfo info, Type parameter)
        {
            foreach (var par in info.GetParameters())
            {
                Console.WriteLine($"{par.ParameterType}, {parameter}");
                if (par.ParameterType == parameter)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool IsStaticMethod(this MethodInfo info)
        {
            return info.IsStatic;
        }

        public static IEnumerable<MethodInfo> GetMethodsWithAttribute<T>() where T : Attribute
        {
            return Assembly.GetExecutingAssembly().GetTypes()
                .SelectMany(t => t.GetMethods())
                .Where(m => m.GetCustomAttributes(typeof(T), false).Length > 0)
                .ToArray();
        }
    }
}