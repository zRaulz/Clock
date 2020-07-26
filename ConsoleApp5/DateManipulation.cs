using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConsoleApp5
{
    public class DateManipulation : FormatCheck
    {
        private int _seconds;
        private int _minutes;
        private int _hours;

        private int _years;
        private int _months;
        private int _days;

        private readonly string _date;
        private string furtherDate="";

        public DateManipulation(string date) : base(date)
        {
            _date = date;
            if (checkFormat(_date) && checkDate(_date))
            {
                getTime();

            }
        }

        protected void getTime()
        {
            for (int i = 0; i < _date.Length; i++)
            {
                if (_date[i] == 'T')
                {
                    this._hours = int.Parse(_date[i + 1].ToString() + _date[i + 2]);
                    this._minutes = int.Parse(_date[i + 4].ToString() + _date[i + 5]);
                    this._seconds = int.Parse(_date[i + 7].ToString() + _date[i + 8]);

                    this._years = int.Parse(_date[i - 10].ToString() + _date[i - 9] +
                                            _date[i - 8] + _date[i - 7]);
                    this._months = int.Parse(_date[i - 5].ToString() + _date[i - 4]);
                    this._days = int.Parse(_date[i - 2].ToString() + _date[i - 1]);
                }
            }

            Console.WriteLine($"year is: {_years}, month is:{_months}, day is : {_days}, hour is: {_hours}, minutes are {_minutes}, seconds are {_seconds}");
            Console.WriteLine("For how much time you want to wait(seconds)?");

            int number = Convert.ToInt32(Console.ReadLine());
            increaseTime(number,ref _years,ref _months,ref _days, ref _hours, ref _minutes, ref _seconds);

        }
        protected string increaseTime(int numberOfSeconds, ref int _years, ref int _months, ref int _days, ref int _hours, ref int _minutes, ref int _seconds)
        {
            var x = 0;
            while (x < numberOfSeconds)
            {
                Thread.Sleep(1000);
                x++;
                
                if (_seconds < 59)
                {
                    _seconds++;
                }
                else
                {
                    _seconds = 0;
                    _minutes++;
                    if (_minutes <= 59) continue;
                    _minutes = 0;
                    _hours++;

                    if (_hours <= 23) continue;
                    _hours = 0;
                    _days++;
                    if (_days <= 30) continue;
                    _days = 1;
                    _months++;
                    if (_months <= 12) continue;
                    _months = 1;
                    _years++;
                }
            }
            furtherDate = furtherDate + addZeroes(_years.ToString()) +_years+ 
                          '-'+ addZeroes(_months.ToString()) + _months+
                          '-'+ addZeroes(_days.ToString()) + _days+
                          'T'+ addZeroes(_hours.ToString()) + _hours + 
                          ':'+ addZeroes(_minutes.ToString()) + _minutes + 
                          ':'+ addZeroes(_seconds.ToString()) + _seconds+'Z';

           
            writeTextRightCorner( furtherDate);
            return furtherDate;
        }

        protected string addZeroes(string numberLessThan10)
        {
            var number=int.Parse(numberLessThan10);
            
            return number < 10 ? "0" : "";
        }

        protected void writeTextRightCorner(string furtherDate)
        {

            Console.CursorLeft = Console.BufferWidth - 35;
            Console.WriteLine(furtherDate);
            Console.WriteLine("This is some extra text");
        }
    }
}
