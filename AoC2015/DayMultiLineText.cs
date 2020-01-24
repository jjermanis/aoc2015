using System.Collections.Generic;

namespace AoC2015
{
    public abstract class DayMultiLineText : DayBase
    {
        private readonly IEnumerable<string> _data;

        public DayMultiLineText(string filename)
        {
            _data = TextFileLines(filename);
        }

        protected IEnumerable<string> Data { get => _data; }
    }
}
