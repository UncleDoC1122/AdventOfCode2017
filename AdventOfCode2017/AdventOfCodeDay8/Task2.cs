using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCodeDay8
{
    class Task2
    {
        public static void Solve(string pathToFile)
        {
            var input = File.ReadAllLines(pathToFile);

            var registers = new List<Register>();
            var operations = new List<Operation>();

            var max = int.MinValue;

            foreach (var line in input)
                operations.Add(new Operation(line, ref registers));

            foreach (var operation in operations)
            {
                foreach (var register in registers)
                    if (max < register.GetValue())
                        max = register.GetValue();
                Operation.completeOperation(operation);
            }

            Console.WriteLine(max);
            Console.ReadKey();

        }
    }
}
