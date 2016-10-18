using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace LojaVerity.Entidades
{
    public class Produto
    {
        public Produto()
        {

        }

        public Produto(long id, string nome, string descricao, decimal preco)
        {
            this.ID = id;
            this.Nome = nome;
            this.Descricao = descricao;
            this.Preco = preco;
        }

        public Produto(Modelo.Produto produto)
        {
            if (produto == null)
                return;

            this.ID = produto.ID;
            this.Nome = produto.Nome;
            this.Descricao = produto.Descricao;
            this.Preco = produto.Preco;
        }
        
        public long ID { get; set; }
        
        public string Nome { get; set; }
        
        public string Descricao { get; set; }
        
        public decimal Preco { get; set; }
    }
}
