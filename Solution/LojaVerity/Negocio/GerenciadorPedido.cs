using LojaVerity.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaVerity.Negocio
{
    public class GerenciadorPedido
    {
        public Pedido CriarPedido(string cliente, List<PedidoLinha> linhas)
        {
            using (Modelo.VerityEntidades contexto = new Modelo.VerityEntidades())
            {
                // Busca todos os produtos do pedido de uma vez, para evitar de ir múltiplas vezes ao banco
                IEnumerable<long> produtoIDs = linhas.Select(linha => linha.ProdutoID);
                IQueryable<Modelo.Produto> produtos = contexto.Produtos.Where(prod => produtoIDs.Contains(prod.ID));

                //-------------------------------------------------------------------------------------------------------------------------------------
                // Monta linhas
                List<Modelo.PedidoLinha> linhasLista = new List<Modelo.PedidoLinha>();

                foreach (PedidoLinha linha in linhas)
                {
                    Modelo.PedidoLinha modeloLinha = new Modelo.PedidoLinha();
                    modeloLinha.ProdutoID = linha.ProdutoID;
                    modeloLinha.Quantidade = linha.Quantidade;
                    modeloLinha.Preco = produtos.First(produto => produto.ID == linha.ProdutoID).Preco * linha.Quantidade; // Busca produto e multiplica seu valor pela quantidade informada
                    linha.Preco = modeloLinha.Preco;

                    linhasLista.Add(modeloLinha);
                }

                //-------------------------------------------------------------------------------------------------------------------------------------
                // Monta pedidos
                Modelo.Pedido modeloPedido = new Modelo.Pedido();
                modeloPedido.Cliente = cliente;
                modeloPedido.PrecoTotal = linhasLista.Select(linha => linha.Preco).Sum();
                modeloPedido.PedidoLinhas = linhasLista;
                modeloPedido.DataPedido = DateTime.Now;

                //-------------------------------------------------------------------------------------------------------------------------------------
                // Persiste e retorna pedido
                contexto.Pedidos.Add(modeloPedido);
                contexto.SaveChanges();

                return new Pedido(modeloPedido);
            }
        }

        public List<Pedido> BuscarPedidos()
        {
            List<Pedido> listaPedidos = new List<Pedido>();

            using (Modelo.VerityEntidades contexto = new Modelo.VerityEntidades())
            {
                // Já que será necessário buscar todas as linhas dos pedidos retornados, eles são inclusos na busca, para evitar de ir múltiplas vezes ao banco
                System.Data.Entity.Infrastructure.DbQuery<Modelo.Pedido> pedidos = contexto.Pedidos.Include("PedidoLinhas");

                foreach (Modelo.Pedido pedido in pedidos)
                    listaPedidos.Add(new Pedido(pedido));
            }

            return listaPedidos;
        }

        public Pedido BuscarPedido(long id)
        {
            using (Modelo.VerityEntidades contexto = new Modelo.VerityEntidades())
            {
                Modelo.Pedido modeloPedido = contexto.Pedidos.FirstOrDefault(pedido => pedido.ID == id);

                if (modeloPedido == null)
                    return null;

                return new Pedido(modeloPedido);
            }
        }
    }
}
