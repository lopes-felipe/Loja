using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaVerity.UI.Models
{
    public class Pedido
    {
        public Pedido()
        {
            this.Linhas = new List<PedidoLinha>();
        }

        public void AdicionarProduto(Produto produto, int quantidade)
        {
            PedidoLinha linhaProduto = this.Linhas.FirstOrDefault(linha => linha.Produto.ID == produto.ID);

            if (linhaProduto == null)
            {
                linhaProduto = new PedidoLinha(produto, 0);
                this.Linhas.Add(linhaProduto);
            }

            linhaProduto.Quantidade += quantidade;
        }

        public void RemoverProduto(long produtoID)
        {
            PedidoLinha pedidoLinha = this.Linhas.FirstOrDefault(linha => linha.Produto.ID == produtoID);

            if (pedidoLinha != null)
                this.Linhas.Remove(pedidoLinha);
        }

        public decimal CalcularValorTotal()
        {
            decimal valorTotal = 0;

            foreach (PedidoLinha linha in this.Linhas)
                valorTotal += linha.Produto.Preco * linha.Quantidade;

            return valorTotal;
        }

        public List<PedidoLinha> Linhas { get; set; }
    }
}