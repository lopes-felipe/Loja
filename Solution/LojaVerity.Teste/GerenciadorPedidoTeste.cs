using LojaVerity.Entidades;
using LojaVerity.Negocio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaVerity.Teste
{
    [TestClass]
    public class GerenciadorPedidoTeste
    {
        [TestMethod]
        public void CriarPedidoTeste()
        {
            //-------------------------------------------------------------------------------------------------------
            // Configura
            GerenciadorProduto gerenciadorProduto = new GerenciadorProduto();
            List<Produto> produtos = gerenciadorProduto.BuscarProdutos();
            long produtoID = produtos[0].ID;

            List<PedidoLinha> pedidoLinhasLista = new List<PedidoLinha>();
            pedidoLinhasLista.Add(new PedidoLinha(0, 0, produtoID, 5, 0));
            pedidoLinhasLista.Add(new PedidoLinha(0, 0, produtoID, 3, 0));
            pedidoLinhasLista.Add(new PedidoLinha(0, 0, produtoID, 1, 0));

            //-------------------------------------------------------------------------------------------------------
            // Executa
            GerenciadorPedido gerenciadorPedidos = new GerenciadorPedido();
            Pedido pedido = gerenciadorPedidos.CriarPedido("Felipe Lopes", pedidoLinhasLista);

            //-------------------------------------------------------------------------------------------------------
            // Valida
            Assert.IsTrue(pedido.ID > 0);
        }
    }
}
