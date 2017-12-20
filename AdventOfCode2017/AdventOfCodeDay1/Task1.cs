using System;
using System.IO;

namespace AdventOfCodeDay1
{
    class Task1
    {
        public static void Solve(string pathToFile)
        {
            var input = File.ReadAllText(pathToFile);
            input += input;
            var sum = 0;
            for (int i = 0; i < (input.Length / 2); i++)
            {
                if (input[i].Equals(input[i + 1]))
                {
                    sum += Int32.Parse(input[i].ToString());
                }
            }

            Console.Write(sum);
            Console.ReadKey();
        }
    }
}
