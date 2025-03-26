using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PatternChaser
{
    internal class Program
    {   
        static string str = "sskfssbbb9bbb"; //yes bbb
        //static string str = "123224"; //no null
        //static string str = "da2kr32a2"; // incorrect result        

        static void Main(string[] args)
        {
            Console.WriteLine(PatternChaser(str));
        }


        public static string PatternChaser(string str)
        { 
            string result = "no null";

            List<string> rptStrList = new List<string>();
           
            var reg = new Regex(@"(\w+)\1+");

            var s = reg.Matches(str);

            if (s.Count > 1)
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
