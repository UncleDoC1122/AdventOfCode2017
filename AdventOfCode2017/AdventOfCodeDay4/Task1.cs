using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeDay4
{
    class Task1
    {
        public static void Solve(string pathToFile)
        {
            var input = File.ReadAllLines(pathToFile);
            int counter = 0;

            foreach(var line in input)
            {
                if (line.Split(' ').Count() == line.Split(' ').Distinct().Count())
                    counter++;
            }

            Console.WriteLine(counter);
            Console.ReadKey();
        }
    }
}
