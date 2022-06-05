namespace ConsoleGrid
{
    public class Grid
    {
        private readonly List<Row> _rows;
        private readonly int[] _columnsWidth;
        private readonly string[] _columnsFormat;
        private string? _title;
        private string? _footer;
        public int MaxWidth { get; private set; }

        public Grid(string title, params int[] columnsWidth)
            : this(columnsWidth)
        {
            _title = title;
        }

        public Grid(params int[] columnsWidth)
        {
            _columnsWidth = columnsWidth;
            _rows = new List<Row>();
            _columnsFormat = new string[_columnsWidth.Length];
        }

        public void ColumnsName(params string[] titles)
        {
            _rows.Clear();
            var columns = new Column[titles.Length];

            for (var i = 0; i < titles.Length; i++)
                columns[i] = new Column(titles[i], _columnsWidth[i]);

            _rows.Add(new Row(columns));
            MaxWidth = _rows?.FirstOrDefault()?.Width ?? 25;
        }

        public void ColumnsFormat(params string[] formats)
        {
            for (var i = 0; i < _columnsFormat.Length; i++)
                _columnsFormat[i] = formats[i];
        }

        public void DataSource<T>(IEnumerable<T> dataSource)
        {
            foreach (var obj in dataSource)
            {
                if (obj is null)
                    continue;

                var columns = new Column[_columnsWidth.Length];
                var i = 0;

                foreach (var prop in obj.GetType().GetProperties())
                {
                    var fmt = _columnsFormat[i];
                    var value = string.IsNullOrEmpty(fmt) ? $"{prop.GetValue(obj)}" : string.Format(fmt, prop.GetValue(obj));
                    columns[i] = new Column(value, _columnsWidth[i], format: fmt);
                    i++;
                }
                _rows.Add(new Row(columns));
            }
        }

        public void Footer(string footer)
        {
            _footer = new Row(new Column(footer, MaxWidth - 6)).Value;
        }

        public void Footer(params string[] values)
        {
            var columns = new Column[values.Length];
            var width = (MaxWidth / values.Length) - 4;

            for (var i = 0; i < columns.Length; i++)
            {
                columns[i] = new Column(values[i], width);
            }

            _footer = new Row(columns).Rebalance(MaxWidth).Value;
        }

        public void Print()
        {
            if (!string.IsNullOrEmpty(_title))
                PrintTitle();
            else
                PrintBorder();

            foreach (var row in _rows)
                Console.WriteLine(row);

            if (!string.IsNullOrEmpty(_footer))
                PrintFooter();
        }

        private void PrintTitle()
        {
            PrintBorder();
            _title = _title?.ToUpper();
            Console.WriteLine(new Row(new Column(_title ?? string.Empty, MaxWidth - 6)));
        }

        private void PrintBorder()
        {
            Console.WriteLine(" " + new string('-', MaxWidth - 2));
        }

        private void PrintFooter()
        {
            Console.WriteLine(_footer);
            PrintBorder();
        }
    }

}