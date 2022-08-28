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
                if (par.GetType() == parameter)
                {
                    return true;
                }
            }

            return false;
        }
    }
}