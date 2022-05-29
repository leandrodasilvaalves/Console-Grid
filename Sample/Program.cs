using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleGrid;

namespace Sample
{
    public class Program
    {
        public static void Main()
        {
            var produtos = new List<Produto>();
            produtos.Add(new Produto(1, "Arroz", 20.35m, DateTime.Now));
            produtos.Add(new Produto(2, "Feijao", 12.0m, DateTime.Now));
            produtos.Add(new Produto(3, "Oleo", 14.16m, DateTime.Now));
            produtos.Add(new Produto(4, "Ovo 30un", 18.0m, DateTime.Now));

            var grid = new Grid("lista de produtos", 4, 20, 10, 11);
            grid.ColumnsTitle("Id", "Descricao", "Valor", "Data");
            grid.ColumnsFormat(string.Empty, string.Empty, "{0:c2}", "{0:dd/MM/yyyy}");
            grid.DataSource(produtos);
            grid.Footer("Total: " + produtos.Sum(p => p.Valor).ToString("c2"));
            grid.Print();
        }
    }
}