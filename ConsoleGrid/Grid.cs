using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleGrid
{
    public class Grid
    {
        private readonly List<Row> _rows;
        private readonly int[] _columnsWidth;
        private readonly string[] _columnsFormat;
        private readonly string? _title;
        private int _maxWidth;
        private string? _footer;

        public Grid(string title, params int[] widthColumns)
            : this(widthColumns)
        {
            _title = title;
        }

        public Grid(params int[] columnsWidth)
        {
            _columnsWidth = columnsWidth;
            _rows = new List<Row>();
            _columnsFormat = new string[_columnsWidth.Length];
        }

        public void ColumnsTitle(params string[] titles)
        {
            _rows.Clear();
            var columns = new Column[titles.Length];

            for (var i = 0; i < titles.Length; i++)
                columns[i] = new Column(titles[i], _columnsWidth[i]);

            _rows.Add(new Row(columns));
            _maxWidth = _rows?.FirstOrDefault()?.Width ?? 25;
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
            _footer = footer;
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
            Console.WriteLine("| " + _title?.ToUpper().PadRight(_maxWidth - 3, ' ') + "|");
            PrintBorder();
        }

        private void PrintBorder()
        {
            Console.WriteLine(new string('-', _maxWidth));
        }

        private void PrintFooter()
        {
            Console.WriteLine("|" + _footer?.PadLeft(_maxWidth - 3, ' ') + " |");
            PrintBorder();
        }
    }

}