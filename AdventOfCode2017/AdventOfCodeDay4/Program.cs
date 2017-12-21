using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeDay4
{
    class Program
    {
        static void Main(string[] args)
        {
            var test1 = Task2.AreEqual("aabbcc", "abcabc");
            var test2 = Task2.AreEqual("abcdef", "abcdfe");


            Task1.Solve(@"..\..\..\Input files\input - day 4.txt");
        }
    }
}
