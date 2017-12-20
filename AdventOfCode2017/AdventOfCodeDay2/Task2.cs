using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeDay2
{
    class Task2
    {
        public static void Solve(string pathToFile)
        {
            var input = File.ReadAllLines(pathToFile);

            var sum = 0;

            foreach (var line in input)
            {
                var max = Int32.MinValue;
                var min = Int32.MaxValue;

                var numsArray = line.Split('\t');

                foreach (var num in numsArray)
                {
                    for (int i = 0; i < numsArray.Length; i ++)
                    {
                        if (int.Parse(num) % int.Parse(numsArray[i]) == 0 && int.Parse(num) != int.Parse(numsArray[i]))
                            sum += int.Parse(num) / int.Parse(numsArray[i]);

                    }
                    
                }

                
            }

            Console.WriteLine(sum);
            Console.ReadKey();
        }
    }
}
