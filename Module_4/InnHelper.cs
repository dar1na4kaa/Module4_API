using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Module_4
{
    public static class InnHelper
    {
        public static bool IsCorrect(string inn)
        {
            if(string.IsNullOrWhiteSpace(inn)) return false;

            string pattern = @"^[1-9]";

            if(inn.Trim().Length == 10)
            {
                return Regex.IsMatch(inn,pattern); 
            }
            else
            {
                return false;
            }
        }
        public static string Convert(string inn)
        {
            if (string.IsNullOrWhiteSpace(inn)) return "";

            string pattern = @"^[1-9]";
            string result = Regex.Replace(inn, pattern, "");

            return result.Trim();

        }
    }
}
