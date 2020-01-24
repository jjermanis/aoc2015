namespace AoC2015
{
    public abstract class DaySingleLineText : DayBase
    {
        private readonly string _data;

        public DaySingleLineText(string filename)
        {
            _data = TextFile(filename);
        }

        protected string Data { get => _data; }
    }
}
