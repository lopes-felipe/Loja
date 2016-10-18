using LojaVerity.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LojaVerity.Negocio
{
    public class GerenciadorProduto
    {
        #region Produto

        public List<Produto> BuscarProdutos()
        {
            List<Produto> listaProduto = new List<Produto>();

            using (Modelo.VerityEntidades contexto = new Modelo.VerityEntidades())
            {
                foreach (Modelo.Produto produto in contexto.Produtos)
                    listaProduto.Add(new Produto(produto));
            }

            return listaProduto;
        }

        public Produto BuscarProduto(long id)
        {
            using (Modelo.VerityEntidades contexto = new Modelo.VerityEntidades())
            {
                Modelo.Produto produtoEncontrado = contexto.Produtos.FirstOrDefault(prod => prod.ID == id);

                if (produtoEncontrado == null)
                    return null;

                return new Produto(produtoEncontrado);
            }
        }

        public Produto CadastrarProduto(string nome, string descricao, decimal preco)
        {
            Modelo.Produto produto = new Modelo.Produto() { Nome = nome, Descricao = descricao, Preco = preco };

            using (Modelo.VerityEntidades contexto = new Modelo.VerityEntidades())
            {
                contexto.Produtos.Add(produto);
                contexto.SaveChanges();
            }

            Produto novoProduto = new Produto(produto.ID, produto.Nome, produto.Descricao, produto.Preco);
            return novoProduto;
        }

        public void ExcluirProduto(long id)
        {
            using (Modelo.VerityEntidades contexto = new Modelo.VerityEntidades())
            {
                Modelo.Produto produto = new Modelo.Produto() { ID = id };
                contexto.Produtos.Attach(produto);
                contexto.Produtos.Remove(produto);

                contexto.SaveChanges();
            }
        }

        #endregion
    }
}
