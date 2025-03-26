﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PatternChaser
{
    internal class Program
    {   
        static string str = "sskfssbbb9bbb";
        static void Main(string[] args)
        {
            Console.WriteLine(PatternChaser(str));
        }


        public static string PatternChaser(string str)
        {
            string result = "no";

            List<string> rptStrList = new List<string>();

            var reg = new Regex(@"(.)\1{1,}");

            var s = reg.Matches(str);

            if (s.Count != 0)
            {
                foreach (var match in reg.Matches(str))
                {
                    rptStrList.Add(match.ToString());
                }

                string patternStr = rptStrList.Distinct().OrderByDescending(w => w.Length).First();

                result = $"yes {patternStr}";
            }

            return result;
        }
    }
}
