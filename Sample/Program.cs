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
            
            var grid = new Grid("lista de produtos", 4, 20, 10, 12);
            grid.ColumnsName("Id", "Descricao", "Valor", "Data");
            grid.ColumnsFormat(string.Empty, string.Empty, "{0:c2}", "{0:dd/MM/yyyy}");
            grid.DataSource(produtos);

            Sample1(produtos, grid);
            Console.WriteLine("\n");

            Sample2(produtos, grid);
            Console.WriteLine("\n");
            
            Sample3(produtos, grid);
            Console.WriteLine("\n");
            
            Sample4(produtos, grid);
        }

        static void Sample1(List<Produto> produtos, Grid grid)
        {   
            grid.Footer("Total: " + produtos.Sum(p => p.Valor).ToString("c2"));
            grid.Print();
        }

        static void Sample2(List<Produto> produtos, Grid grid)
        {
            var col1 = "Qtde: " + produtos.Count;
            var col2 = "Total: " + produtos.Sum(p => p.Valor).ToString("c2");

            grid.Footer(col1, col2);
            grid.Print();
        }

        static void Sample3(List<Produto> produtos, Grid grid)
        {
            var col1 = "Qtde: " + produtos.Count;
            var col2 = "Total: " + produtos.Sum(p => p.Valor).ToString("c2");
            var col3 = "Média: " + produtos.Average(p => p.Valor).ToString("c2");

            grid.Footer(col1, col2, col3);
            grid.Print();
        }

        static void Sample4(List<Produto> produtos, Grid grid)
        {
            var col1 = "Col1: 123";
            var col2 = "Col2: 456";
            var col3 = "Col3: 789";
            var col4 = "Col4: 147";

            grid.Footer(col1, col2, col3, col4);
            grid.Print();
        }
    }
}