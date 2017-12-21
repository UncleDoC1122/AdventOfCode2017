using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeDay4
{
    public class Task2
    {
        public static void Solve(string pathToFile)
        {
            var input = File.ReadAllLines(pathToFile);
            var counter = input.Length;

            foreach (var line in input)
            {
                var splittedLine = line.Split(' ');
                bool broken = false;

                for (int i = 0; i < splittedLine.Length; i++)
                    for (int j = 0; j < splittedLine.Length; j++)
                        if (i != j && !broken)
                            if (AreEqual(splittedLine[i], splittedLine[j]))
                            {
                                counter--;
                                broken = true;
                            }     
            }

            Console.WriteLine(counter);
            Console.ReadKey();
        }

        public static bool AreEqual(string first, string second)
        {
            Dictionary<char, int> usedChars = new Dictionary<char, int>();

            foreach (var character in first)
                if (usedChars.ContainsKey(character))
                    usedChars[character]++;
                else
                    usedChars.Add(character, 1);

            foreach (var character in second)
                if (usedChars.ContainsKey(character))
                    usedChars[character]--;

            if (usedChars.Values.All(a => a == 0) && first.Length == second.Length)
                return true;
            else
                return false;
        }
    }
}
