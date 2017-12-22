using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeDay9
{
    class Task1and2
    {
        public static void Solve(string pathToFile)
        {
            Stack<char> groups = new Stack<char>();
            int score = 0;
            int garbageCount = 0;
            bool ignoring = false;

            using (StreamReader sr = new StreamReader(pathToFile))
            {

                while (sr.Peek() >= 0)
                {
                    var character = (char)sr.Read();

                    if (character.Equals('!'))
                        sr.Read();
                    else if (character.Equals('{') && !ignoring)
                        groups.Push('{');
                    else if (character.Equals('}') && !ignoring)
                    {
                        score += groups.Count;
                        groups.Pop();
                    }
                    else if (character.Equals('<') && !ignoring)
                        ignoring = true;
                    else if (character.Equals('>') && ignoring)
                        ignoring = false;
                    else if (ignoring)
                        garbageCount++;
                }
            }

            Console.WriteLine("Score: " + score);
            Console.WriteLine("Garbage count: " + garbageCount);
            Console.ReadKey();
        }
    }
}
