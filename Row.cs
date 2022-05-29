public class Row
{
    private readonly string _separtor;
    private readonly Column[] _columns;

    public int Width { get => Value.Length - 1; }
    public string Value { get; }

    public Row(params Column[] columns)
    {
        _separtor = "| ";
        _columns = columns;
        Value = _separtor + string.Join<Column>(_separtor, _columns) + _separtor;
    }

    public Column this[int index]
    {
        get => _columns[index];
    }

    public override string ToString()
    {
        var rowBaseBorder = new string('-', Width);
        return Value + "\n" + rowBaseBorder;
    }
}
