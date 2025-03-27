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
           static string str = "sskfssbbb9bbb"; // yes bbb
        // static string str = "123224";        // no null
        // static string str = "da2kr32a2";     // incorrect result        

        static void Main(string[] args)
        {
            Console.WriteLine(PatternChaser(str));
        }
       
        public static string PatternChaser(string str)
        {
            StringBuilder sb = new StringBuilder(); 
            string result = "no null";

            Dictionary<string, int> rptDct = new Dictionary<string, int>();            

            for (int i = 0; i < str.Length; i++)            
            {
                sb.Clear();

                for (int j = i; j < str.Length; j++)
                {
                    char charStr = str[j];
                    sb.Append(charStr);

                    string sufStr = sb.ToString();

                    int ind = str.IndexOf(sufStr, j+1);

                    if (ind == -1 && !rptDct.ContainsKey(sufStr))
                    {
                        rptDct[sufStr] = 1;
                    }
                    else
                    {
                        rptDct[sufStr] = 2;
                    }
                }
            }

            var pattern = rptDct.Where(x => x.Value == 2).OrderByDescending(x => x.Key.Length).FirstOrDefault().Key;

            if(pattern.Length > 1)
            {                
                result = $"yes {pattern}";
            }
            return result;
        }
    }
}
