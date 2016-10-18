using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;

namespace LojaVerity.UI.Models
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

        public Produto(ProdutosServico.Produto produto)
            : this(produto.ID, produto.Nome, produto.Descricao, produto.Preco)
        {

        }

        public long ID { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        [BindNever]
        public decimal Preco { get; set; }
    }
}