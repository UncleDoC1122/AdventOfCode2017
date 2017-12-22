using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeDay5
{
    class Task1
    {
        public static void Solve(string pathTOFile)
        {
            var input = File.ReadAllLines(pathTOFile);
            var listedInput = input.ToList<string>();
            List<int> convertedInput = new List<int>();

            foreach (var line in listedInput)
                convertedInput.Add(Int32.Parse(line));

            int steps = 0;
            var iter = 0;
            while (true)
            {
                if (iter >= convertedInput.Count)
                    break;
                else
                {

                    convertedInput[iter]++;
                    iter += convertedInput[iter] - 1;

                    steps++;
                }
            }

            Console.WriteLine(steps);
            Console.ReadKey();
        }
    }
}
