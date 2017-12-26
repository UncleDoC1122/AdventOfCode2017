using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeDay11
{
    class Task1
    {
        public static void Solve(string pathToFile)
        {
            Stack<string> ne = new Stack<string>();
            Stack<string> se = new Stack<string>();
            Stack<string> nw = new Stack<string>();
            Stack<string> sw = new Stack<string>();
            Stack<string> n = new Stack<string>();
            Stack<string> s = new Stack<string>();

            var input = File.ReadAllText(pathToFile);

            var splittedInput = input.Split(',');

            foreach(var element in splittedInput)
            {
                switch (element)
                {
                    case "ne":
                        ne.Push(element);
                        break;
                    case "se":
                        se.Push(element);
                        break;
                    case "sw":
                        sw.Push(element);
                        break;
                    case "nw":
                        nw.Push(element);
                        break;
                    case "n":
                        n.Push(element);
                        break;
                    case "s":
                        s.Push(element);
                        break;
                }
            }

            while(true)
            {

            }

        }
    }
}
