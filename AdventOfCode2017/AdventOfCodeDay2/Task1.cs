using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeDay2
{
    class Task1
    {
        public static void Solve(string pathToFile)
        {
            var input = File.ReadAllLines(pathToFile);

            var sum = 0;

            foreach(var line in input)
            {
                var max = Int32.MinValue;
                var min = Int32.MaxValue;

                var numsArray = line.Split('\t');

                foreach(var num in numsArray)
                {
                    if (int.Parse(num) > max)
                        max = int.Parse(num);
                    if (int.Parse(num) < min)
                        min = int.Parse(num);
                }

                sum += max - min;
            }

            Console.WriteLine(sum);
            Console.ReadKey();
        }

    }
}
