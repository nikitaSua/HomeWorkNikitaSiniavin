using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    static class Convertor
    {
        public static decimal MyConvert(string str)
        {
            int vul = Convert.ToInt32(stringWorker.SizeIntSearcher(str));
            string format = stringWorker.SizeFormatSearcher(str);
            if (format== "MB")
            {
                return (decimal)vul;
            }
            if (format == "B")
            {

                return vul * 0.000001m;
            }
            if (format == "GB")
            {
                return vul *1024;
            }
            else
            {
                return 0;
            }

            
        }
    }
}
