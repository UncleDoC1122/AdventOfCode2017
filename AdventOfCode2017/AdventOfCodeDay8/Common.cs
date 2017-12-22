using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeDay8
{
    class Common
    {
    }

    public class Register
    {
        string name { get; set; }
        int value { get; set; }

        public Register(string name)
        {
            this.name = name;
            this.value = 0;
        }

        public string GetName()
        {
            return this.name;
        }

        public int GetValue()
        {
            return this.value;
        }

        public void SetValue(int num, changingOperator oper)
        {
            if (oper == changingOperator.dec)
                this.value = this.value - num;
            else
                this.value = this.value + num;
        }
    }

    public class Operation
    {
        Register changingRegister { get; set; }

        int changingNum { get; set; }

        Register lookupRegister { get; set; }

        lookupOperator lookupOperator { get; set; }

        int lookupNum { get; set; }

        changingOperator changingOperator { get; set; }

        public Operation(string input, ref List<Register> registers)
        {
            var splittedInput = input.Split(' ');
            var exists = false;

            foreach (var register in registers)
            {
                if (register.GetName().Equals(splittedInput[0]))
                {
                    changingRegister = register;
                    exists = true;
                    break;
                }
            }

            if (!exists)
            {
                registers.Add(new Register(splittedInput[0]));
                changingRegister = registers.Last();
            }

            if (splittedInput[1].Equals("inc"))
                this.changingOperator = changingOperator.inc;
            else
                this.changingOperator = changingOperator.dec;

            this.changingNum = int.Parse(splittedInput[2]);

            exists = false;

            foreach (var register in registers)
            {
                if (register.GetName().Equals(splittedInput[4]))
                {
                    lookupRegister = register;
                    exists = true;
                    break;
                }
            }

            if (!exists)
            {
                registers.Add(new Register(splittedInput[4]));
                lookupRegister = registers.Last();
            }

            switch (splittedInput[5])
            {
                case ">":
                    this.lookupOperator = lookupOperator.more;
                    break;
                case "<":
                    this.lookupOperator = lookupOperator.less;
                    break;
                case "<=":
                    this.lookupOperator = lookupOperator.lessEqual;
                    break;
                case ">=":
                    this.lookupOperator = lookupOperator.moreEqual;
                    break;
                case "==":
                    this.lookupOperator = lookupOperator.equal;
                    break;
                case "!=":
                    this.lookupOperator = lookupOperator.notEqual;
                    break;
            }

            this.lookupNum = int.Parse(splittedInput[6]);



        }

        public static void completeOperation(Operation operation)
        {
            if (compare(operation.lookupOperator, operation.lookupRegister, operation.lookupNum))
                operation.changingRegister.SetValue(operation.changingNum, operation.changingOperator);
        }

        public static bool compare(lookupOperator lookupOperator, Register register, int num)
        {
            bool result = false;
            switch (lookupOperator)
            {
                case lookupOperator.equal:
                    result = register.GetValue() == num;
                    break;
                case lookupOperator.notEqual:
                    result = register.GetValue() != num;
                    break;
                case lookupOperator.less:
                    result = register.GetValue() < num;
                    break;
                case lookupOperator.lessEqual:
                    result = register.GetValue() <= num;
                    break;
                case lookupOperator.more:
                    result = register.GetValue() > num;
                    break;
                case lookupOperator.moreEqual:
                    result = register.GetValue() >= num;
                    break;
            }

            return result;
        }
    }

    public enum changingOperator
    {
        inc,
        dec
    }

    public enum lookupOperator
    {
        more,
        less,
        moreEqual,
        lessEqual,
        equal,
        notEqual
    }
}
