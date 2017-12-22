using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeDay6
{
    public class Task2
    {
        public static void Solve(string pathToFile)
        {
            var rawInput = File.ReadAllText(pathToFile).Split('\t');
            var input = rawInput.Select(int.Parse).ToList();


            var variants = new List<List<int>>();

            variants.Add(input);

            var cycle = 0;

            while (true)
            {
                var newCombo = Redistribute(variants.Last());
                variants.Add(newCombo);
                cycle++;
                for (int i = 0; i < variants.Count - 1; i++)
                {
                    if (Compare(variants.Last(), variants[i]))
                    {
                        Console.WriteLine(cycle - i);
                        Console.ReadLine();
                        return;
                    }
                }
            }

            Console.WriteLine(cycle);
            Console.ReadLine();
        }

        public static bool Compare(List<int> a, List<int> b)
        {
            for (int i = 0; i < a.Count; i++)
            {
                if (a[i] != b[i])
                    return false;
            }
            return true;
        }

        public static List<int> Redistribute(List<int> input)
        {
            var max = Int32.MinValue;
            int maxPos;

            List<int> internals = new List<int>();

            foreach (var elem in input)
                internals.Add(elem);

            for (int i = 0; i < internals.Count; i++)
            {
                if (internals[i] > max)
                {
                    max = internals[i];
                    maxPos = i;
                }
            }

            maxPos = internals.IndexOf(max);
            internals[maxPos] = 0;

            while (max > 0)
            {
                maxPos++;
                if (maxPos > internals.Count - 1)
                    maxPos = 0;
                internals[maxPos]++;
                max--;
            }

            return internals;

        }
    }
}
