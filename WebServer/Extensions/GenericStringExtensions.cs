﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Extensions
{
    internal static class GenericStringExtensions
    {
        public static string[] GetStringLines(this string str)
        {
            return str.Split(new string[] { Environment.NewLine },
    StringSplitOptions.None);
        }
    }
}
