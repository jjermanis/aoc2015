using System;
using System.Linq;

namespace AoC2015
{
    public class Day23 : DayMultiLineText, IDay
    {
        public Day23(string filename) : base(filename)
        {
        }

        public Day23() : this("Day23.txt")
        {
        }

        public void Do()
        {
            (var a, var b) = RunProgram();
            Console.WriteLine($"Register b={b}");
        }

        public (int, int) RunProgram()
        {
            var program = Data.ToList();
            var pc = 0;
            var regs = new int[2];

            while (pc < program.Count)
            {
                (var op, var reg, var offset) = ParseInstruction(program[pc]);
                var index = reg - 'a';

                switch (op)
                {
                    case "hlf":
                        regs[index] /= 2;
                        pc++;
                        break;
                    case "tpl":
                        regs[index] *= 3;
                        pc++;
                        break;
                    case "inc":
                        regs[index]++;
                        pc++;
                        break;
                    case "jmp":
                        pc += offset.Value;
                        break;
                    case "jie":
                        pc += regs[index] % 2 == 0 ? offset.Value : 1;
                        break;
                    case "jio":
                        pc += regs[index] == 1 ? offset.Value : 1;
                        break;
                    default:
                        throw new Exception($"Unknown operation: {op}");
                }
            }
            return (regs[0], regs[1]);
        }

        private (string, char, int?) ParseInstruction(string inst)
        {
            var tokens = inst.Split(' ');
            var op = tokens[0];
            char reg;
            int? offset = null;
            if (!op.Equals("jmp"))
            {
                reg = tokens[1][0];
                if (tokens.Length > 2)
                    offset = int.Parse(tokens[2]);
            }
            else
            {
                reg = 'z';
                offset = int.Parse(tokens[1]);
            }
            return (op, reg, offset);
        }
    }
}
