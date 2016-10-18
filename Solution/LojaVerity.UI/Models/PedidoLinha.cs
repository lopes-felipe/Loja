using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaVerity.UI.Models
{
    public class PedidoLinha
    {
        public PedidoLinha()
        {

        }

        public PedidoLinha(Produto produto, int quantidade)
        {
            this.Produto = produto;
            this.Quantidade = quantidade;
        }

        public Produto Produto { get; set; }

        public int Quantidade { get; set; }
    }
}