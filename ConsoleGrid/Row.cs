namespace ConsoleGrid
{
    public class Row
    {
        private readonly string _separtor;
        private readonly Column[] _columns;

        public int Width { get => Value.Length; }
        public string Value => Join();

        public Column[] Columns => _columns;

        public Row(params Column[] columns)
        {
            _separtor = " | ";
            _columns = columns;
        }

        public Column this[int index]
        {
            get => _columns[index];
            set => _columns[index] = value;
        }

        public Row Rebalance(int MaxWidth)
        {
            if (this.Width < MaxWidth)
            {
                var diff = MaxWidth - this.Width;
                var indexLastCol = _columns.Length - 1;
                var lastColumn = this[indexLastCol].ToString();
                var newColumn = new Column(lastColumn, lastColumn.Length + diff);
                this[indexLastCol] = newColumn;
            }

            return this;
        }

        private string Join()
            => _separtor + string.Join<Column>(_separtor, _columns) + _separtor;

        public override string ToString()
        {
            var rowBaseBorder = " " + new string('-', Width - 2);
            return Value + "\n" + rowBaseBorder;
        }
    }
}