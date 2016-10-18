using LojaVerity.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaVerity.UI.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(ProdutosServico.IProdutosServico produtosServicoClient, PedidosServico.IPedidosServico pedidosServicoClient)
        {
            this.produtosServicoClient = produtosServicoClient;
            this.pedidosServicoClient = pedidosServicoClient;
        }

        private ProdutosServico.IProdutosServico produtosServicoClient = null;
        private PedidosServico.IPedidosServico pedidosServicoClient = null;

        public ViewResult Index()
        {
            ProdutosServico.Produto[] produtos = produtosServicoClient.BuscarProdutos();

            List<Produto> listaProdutos = new List<Produto>();

            foreach (ProdutosServico.Produto produto in produtos)
                listaProdutos.Add(new Produto(produto.ID, produto.Nome, produto.Descricao, produto.Preco));

            return View(listaProdutos);
        }

        public RedirectToRouteResult AdicionarCarrinho(long produtoID, Pedido pedido)
        {
            ProdutosServico.Produto[] produtos = produtosServicoClient.BuscarProdutos();
            ProdutosServico.Produto produtoServico = produtos.FirstOrDefault(produto => produto.ID == produtoID);

            if (produtoServico != null)
                pedido.AdicionarProduto(new Produto(produtoServico), 1);

            return RedirectToAction("Carrinho");
        }

        public RedirectToRouteResult RemoverCarrinho(long produtoID, Pedido pedido)
        {
            pedido.RemoverProduto(produtoID);

            return RedirectToAction("Carrinho");
        }

        public ViewResult Carrinho(Pedido pedido)
        {
            return View(pedido);
        }

        public ViewResult FecharPedido(string cliente, Pedido pedido)
        {
            if (string.IsNullOrEmpty(cliente))
                ModelState.AddModelError("Cliente", "Por favor informe nome do cliente.");

            if (pedido.Linhas.Count == 0)
                ModelState.AddModelError("Pedido", "Você não possui nenhum produto em seu carrinho.");

            if (!ModelState.IsValid)
                return View("Carrinho", pedido);

            PedidosServico.Pedido novoPedido = new PedidosServico.Pedido();
            novoPedido.Cliente = cliente;

            List<PedidosServico.PedidoLinha> pedidoLinhas = new List<PedidosServico.PedidoLinha>();

            foreach (PedidoLinha linha in pedido.Linhas)
                pedidoLinhas.Add(new PedidosServico.PedidoLinha() { ProdutoID = linha.Produto.ID, Quantidade = linha.Quantidade });

            novoPedido.Linhas = pedidoLinhas.ToArray();
            this.pedidosServicoClient.CriarPedido(novoPedido);

            return View("Fim", (object)cliente);
        }
    }
}