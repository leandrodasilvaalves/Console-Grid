public class Column
{
    private readonly string _value;

    public int Length { get; private set; }

    public Column(string value, int length = 0, char paddingChar = ' ', string format = "")
    {
        if (value.Length > length)
            value = value.Substring(0, length - 3) + "...";

        if (!string.IsNullOrEmpty(format))
            value = string.Format(format, value);

        _value = value.PadRight(length, paddingChar);
        Length = length;
    }

    public override string ToString()
    {
        return _value;
    }
}
