using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LojaVerity.Entidades
{
    public class PedidoLinha
    {
        public PedidoLinha()
        {

        }

        public PedidoLinha(long produtoID, int quantidade)
        {
            this.ProdutoID = produtoID;
            this.Quantidade = quantidade;
        }

        public PedidoLinha(long id, long pedidoID, long produtoID, int quantidade, decimal preco)
            : this(produtoID, quantidade)
        {
            this.ID = id;
            this.PedidoID = pedidoID;
            this.Preco = preco;
        }

        public PedidoLinha(Modelo.PedidoLinha linha)
        {
            if (linha == null)
                return;

            this.ID = linha.ID;
            this.PedidoID = linha.PedidoID;
            this.ProdutoID = linha.ProdutoID;
            this.Quantidade = linha.Quantidade;
            this.Preco = linha.Preco;
        }
        
        public long ID { get; set; }
        
        public long PedidoID { get; set; }
        
        public long ProdutoID { get; set; }
        
        public int Quantidade { get; set; }

        public decimal Preco { get; set; }
    }
}
