using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LojaVerity.Servicos.Entidades;
using System.ServiceModel;
using System.ServiceModel.Activation;
using LojaVerity.Negocio;
using LojaVerity.Excecoes;
using System.Diagnostics;
using LojaVerity.Servicos.Infraestrutura;

namespace LojaVerity.Servicos
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(Namespace = "http://servicos.verity.com/1.0")]
    public class PedidosServico
        : IPedidosServico
    {
        public PedidosServico()
        {
            this.traceSwitch = new TraceSwitch("LojaVerity.Servicos.PedidosServico", "PedidosServico - Padrão");
        }

        private TraceSwitch traceSwitch = null;

        public Pedido CriarPedido(Pedido pedido)
        {
            try
            {
                //-----------------------------------------------------------------------------------------------------------------
                // Monta objetos da camada de negócios
                List<LojaVerity.Entidades.PedidoLinha> linhasLista = new List<LojaVerity.Entidades.PedidoLinha>();

                foreach (PedidoLinha linha in pedido.Linhas)
                    linhasLista.Add(new LojaVerity.Entidades.PedidoLinha(linha.ProdutoID, linha.Quantidade));

                //-----------------------------------------------------------------------------------------------------------------
                // Cria novo pedido
                GerenciadorPedido gerenciadorPedido = new GerenciadorPedido();
                LojaVerity.Entidades.Pedido novoPedido = gerenciadorPedido.CriarPedido(pedido.Cliente, linhasLista);

                //-----------------------------------------------------------------------------------------------------------------
                // Atualiza pedido coom dados gerados e retorna
                pedido.ID = novoPedido.ID;
                pedido.PrecoTotal = novoPedido.PrecoTotal;
                pedido.DataPedido = novoPedido.DataPedido;

                return pedido;
            }
            catch (MaRequisicaoException ex)
            {
                Trace.WriteLineIf(this.traceSwitch.TraceVerbose, string.Format("ProdutosServico::BuscarProdutos - {0}.", Tracing.FormatarException((Exception)ex)));
                throw TratadorException.TratarException(ex, System.Net.HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                Trace.WriteLineIf(this.traceSwitch.TraceError, string.Format("ProdutosServico::BuscarProdutos - {0}.", Tracing.FormatarException(ex)));
                throw TratadorException.TratarException(ex, System.Net.HttpStatusCode.InternalServerError);
            }
        }

        public IEnumerable<Pedido> BuscarPedidos()
        {
            try
            {
                //-----------------------------------------------------------------------------------------------------------------
                // Busca pedidos
                GerenciadorPedido gerenciador = new GerenciadorPedido();
                IEnumerable<LojaVerity.Entidades.Pedido> pedidos = gerenciador.BuscarPedidos();

                List<Pedido> listaPedidos = new List<Pedido>();

                //-----------------------------------------------------------------------------------------------------------------
                // Monta objeto de response e o retorna
                foreach (LojaVerity.Entidades.Pedido pedido in pedidos)
                    listaPedidos.Add(new Pedido(pedido));

                return listaPedidos;
            }
            catch (MaRequisicaoException ex)
            {
                Trace.WriteLineIf(this.traceSwitch.TraceVerbose, string.Format("ProdutosServico::BuscarProdutos - {0}.", Tracing.FormatarException((Exception)ex)));
                throw TratadorException.TratarException(ex, System.Net.HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                Trace.WriteLineIf(this.traceSwitch.TraceError, string.Format("ProdutosServico::BuscarProdutos - {0}.", Tracing.FormatarException(ex)));
                throw TratadorException.TratarException(ex, System.Net.HttpStatusCode.InternalServerError);
            }
        }

        public Pedido BuscarPedido(string id)
        {
            try
            {
                //-----------------------------------------------------------------------------------------------------------------
                // Valida parâmetro recebido
                if (string.IsNullOrEmpty(id))
                    throw new MaRequisicaoException(20001, "ID não fornecido.");

                long pedidoID = long.MinValue;

                if (!long.TryParse(id, out pedidoID))
                    throw new MaRequisicaoException(20002, "ID inválido.");

                //-----------------------------------------------------------------------------------------------------------------
                // Busca pedidos
                GerenciadorPedido gerenciador = new GerenciadorPedido();
                LojaVerity.Entidades.Pedido pedido = gerenciador.BuscarPedido(pedidoID);

                if (pedido == null)
                    return null;

                //-----------------------------------------------------------------------------------------------------------------
                // Monta objeto de response e o retorna
                return new Pedido(pedido);
            }
            catch (MaRequisicaoException ex)
            {
                Trace.WriteLineIf(this.traceSwitch.TraceVerbose, string.Format("ProdutosServico::BuscarProdutos - ID: {0} - {1}.", id, Tracing.FormatarException(ex)));
                throw TratadorException.TratarException(ex, System.Net.HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                Trace.WriteLineIf(this.traceSwitch.TraceError, string.Format("ProdutosServico::BuscarProdutos - ID: {0} - {1}.", id, Tracing.FormatarException(ex)));
                throw TratadorException.TratarException(ex, System.Net.HttpStatusCode.InternalServerError);
            }
        }
    }
}
