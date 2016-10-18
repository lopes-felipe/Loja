using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LojaVerity.Teste
{
    [TestClass]
    public class GerenciadorProdutoTeste
    {
        [TestMethod]
        public void BuscarProdutosTeste()
        {
            //-------------------------------------------------------------------------------------------------------
            // Configura
            Negocio.GerenciadorProduto gerenciador = new Negocio.GerenciadorProduto();

            //-------------------------------------------------------------------------------------------------------
            // Executa
            List<Entidades.Produto> produtos = gerenciador.BuscarProdutos();

            //-------------------------------------------------------------------------------------------------------
            // Valida
            Assert.IsTrue(produtos.Count > 0);
        }
    }
}
