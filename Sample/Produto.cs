using System;

namespace Sample
{
    public class Produto
    {
        public Produto(int id, string descricao, decimal valor, DateTime data)
        {
            Id = id;
            Descricao = descricao;
            Valor = valor;
            Data = data;
        }

        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
    }
}