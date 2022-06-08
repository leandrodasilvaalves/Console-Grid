namespace ConsoleGrid
{
    public class Column
    {
        private readonly string _value;

        public int Length { get; private set; }

        public Column(string value, int length = 0, char paddingChar = ' ', string format = "", Align align = Align.LEFT)
        {
            if (value?.Length > length)
                if (align == Align.LEFT)
                    value = value.Substring(0, length - 3) + "...";
                else
                    value = "..." + value.Substring(0, length - 3);

            if (!string.IsNullOrEmpty(format))
                value = string.Format(format, value);

            if (align == Align.LEFT)
                _value = value?.PadRight(length, paddingChar) ?? string.Empty;
            else
                _value = value?.PadLeft(length, paddingChar) ?? string.Empty;

            Length = length;
        }

        public override string ToString()
        {
            return _value;
        }
    }
}