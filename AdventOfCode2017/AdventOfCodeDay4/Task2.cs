using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeDay4
{
    public class Task2
    {
        public static void Solve(string pathToFile)
        {

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

            if (usedChars.Values.All(a => a == 0))
                return true;
            else
                return false;
        }
    }
}
