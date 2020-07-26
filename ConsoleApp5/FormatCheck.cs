using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ConsoleApp5
{
    public class FormatCheck
    { 
        private  readonly string _date;
       

        public FormatCheck(string date)
        {
            _date = date;
         ;
        }
        protected bool checkFormat(string date)
        {
           
            var match = Regex.Match(date, @"\b[0-9]{4}-[0-9]{2}-[0-9]{2}T[0-9]{2}:[0-9]{2}:[0-9]{2}Z\b");
            if (!match.Success)
            {  
                Console.WriteLine("This works only for the UTC date format");
                return false;
            }
           
            
                Console.WriteLine($"The format of this text is a valid UTC date string: {date}.");
            
            return true;

        }

        protected bool checkDate(string date)
        {
          var dateNumbers=date.Split(new char[] { '-', ':','T','Z' },
                StringSplitOptions.RemoveEmptyEntries);

            if (int.Parse(dateNumbers[1])>12)
            {
                Console.WriteLine("Invalid month. You can retry setting a date.");
                return false;
            }
            if (int.Parse(dateNumbers[2]) > 30)
            {
                Console.WriteLine("Invalid day. You can retry setting a date.");
                return false;
            }
            if (int.Parse(dateNumbers[3]) > 24)
            {
                Console.WriteLine("Invalid hour. You can retry setting a date.");
                return false;
            }
            if (int.Parse(dateNumbers[4]) > 60)
            {
                Console.WriteLine("Invalid minutes. You can retry setting a date.");
                return false;
            }
            if (int.Parse(dateNumbers[5]) > 60)
            {
                Console.WriteLine("Invalid seconds. You can retry setting a date.");
                return false;
            } 
            return true;
        }
    }
}


