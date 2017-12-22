using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCodeDay8
{
    public class Task1
    {
        public static void Solve(string pathToFile)
        {
            var input = File.ReadAllLines(pathToFile);

            var registers = new List<Register>();
            var operations = new List<Operation>();

            foreach (var line in input)
                operations.Add(new Operation(line, ref registers));

            foreach (var operation in operations)
                Operation.completeOperation(operation);

            var max = int.MinValue;
            foreach (var register in registers)
                if (max < register.GetValue())
                    max = register.GetValue();

            Console.WriteLine(max);
            Console.ReadKey();
        }
    }

    
}
