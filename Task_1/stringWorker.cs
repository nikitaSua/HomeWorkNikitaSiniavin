using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task_1
{
    public static class stringWorker
    {
        public static string SizeSearcher(string str)
        {
            string pattern = @"\(\w*\)";
            string pattern_brackets = @"\(|\)";
            var temp = Regex.Match(str, pattern);
            string val = temp.Value;
            val = new Regex(pattern_brackets).Replace(val, "");
            return val;
        }

        
        public static string SizeFormatSearcher(string str)
        {
            string pattern = @"\D+";
            var temp = Regex.Match(str, pattern);
            string val = temp.Value;
            return val;
        }
        public static string SizeIntSearcher(string str)
        {
            string pattern = @"\d*";
            var temp = Regex.Match(str, pattern);
            string val = temp.Value;
            return val;
        }


        public static string NameSearcher(string str)//NameSearcher
        {
            string pattern = @":.*\(";
            string pattern2 = @":|\(";
            var temp = Regex.Match(str, pattern);
            string val = temp.Value;
            val = new Regex(pattern2).Replace(val, "");
            return val;
        }
        public static string ExtensionSearcher(string str)
        {
            
            string pattern = @"\.\w*\(";
            string pattern2 = @"\.|\(";
            var temp = Regex.Match(str, pattern);
            string val = temp.Value;
            val = new Regex(pattern2).Replace(val, "");
            return val;
        }
        public static string ResolutionSearcher(string str)
        {
            string pattern = @";\d*\w\d*";
            string pattern2 = @";";
            var temp = Regex.Match(str, pattern);
            string val = temp.Value;
            val = new Regex(pattern2).Replace(val, "");
            return val;
        }
        public static string DurationSearcher(string str)//DurationSearcher
        {
            string pattern = @"\w*$";
            string pattern2 = @";";
            var temp = Regex.Match(str, pattern);
            string val = temp.Value;
            val = new Regex(pattern2).Replace(val, "");
            return val;
        }
        public static string ContentSearcher(string str)
        {
            string pattern = @";.*$";
            string pattern2 = @";";
            var temp = Regex.Match(str, pattern);
            string val = temp.Value;
            val = new Regex(pattern2).Replace(val, "");
            return val;
        }

    }
}
