using System;
using System.Diagnostics;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            Console.WriteLine("Enter UTC string");
            var date = new DateManipulation(Console.ReadLine());
            stopWatch.Stop();
            var elapsed = stopWatch.Elapsed;
            Console.WriteLine($"It took {elapsed}  for the entire application to be executed.");
        }
    }
}
