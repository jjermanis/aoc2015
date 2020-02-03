using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2015
{
    public class Day07 : DayMultiLineText, IDay
    {
        private const string NOT = "NOT";
        private const string AND = "AND";
        private const string OR = "OR";
        private const string LSHIFT = "LSHIFT";
        private const string RSHIFT = "RSHIFT";

        private IDictionary<string, string> _wires;
        private IDictionary<string, ushort> _memo;

        public Day07(string filename) : base(filename)
        {
        }

        public Day07() : this("Day07.txt")
        {
        }

        public void Do()
        {
            var wire = "a";
            Console.WriteLine($"Wire {wire} signal: {GetSignal(wire)}");
            Console.WriteLine($"Remapped wire {wire} signal: {GetRemappedSignal(wire)}");
        }

        public ushort GetSignal(string wire)
        {
            InitWires();
            return GetSignalValue(wire);
        }

        public ushort GetRemappedSignal(string wire)
        {
            InitWires();
            var targetWireVal = GetSignalValue(wire);
            ClearMemo();
            _wires["b"] = targetWireVal.ToString();
            return GetSignalValue(wire);
        }

        private ushort GetSignalValue(string wire)
        {
            if (_memo.ContainsKey(wire))
                return _memo[wire];

            if (ushort.TryParse(wire, out ushort literal))
                return literal;

            ushort result;
            var expr = _wires[wire];

            var tokens = expr.Split(' ');

            if (tokens.Length == 1)
            {
                return GetSignalValue(tokens[0]);
            }
            if (tokens[0].Equals(NOT))
            {
                var num = GetSignalValue(tokens[1]);
                // No bitwise NOT operator for 16-bit values
                result = ToUshort(~num);
            }
            else if (tokens[1].Equals(AND))
            {
                var left = GetSignalValue(tokens[0]);
                var right = GetSignalValue(tokens[2]);
                result = ToUshort(left & right);
            }
            else if (tokens[1].Equals(OR))
            {
                var left = GetSignalValue(tokens[0]);
                var right = GetSignalValue(tokens[2]);
                result =  ToUshort(left | right);
            }
            else if (tokens[1].Equals(LSHIFT))
            {
                var left = GetSignalValue(tokens[0]);
                var right = ushort.Parse(tokens[2]);
                result = ToUshort(left << right);
            }
            else if (tokens[1].Equals(RSHIFT))
            {
                var left = GetSignalValue(tokens[0]);
                var right = ushort.Parse(tokens[2]);
                result = ToUshort(left >> right);
            }
            else
                throw new Exception($"Never gets here. Can't handle: {expr}");

            _memo[wire] = result;
            return result;
        }

        private void ClearMemo()
            => _memo = new Dictionary<string, ushort>();

        private void InitWires()
        {
            ClearMemo();
            _wires = new Dictionary<string, string>();
            foreach (var line in Data)
            {
                var values = line.Split("->").Select(v => v.Trim()).ToArray();
                _wires[values[1]] = values[0];
            }
        }

        private ushort ToUshort(int x)
            => (ushort)(0xFFFF & x);
    }
}
