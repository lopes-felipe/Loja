using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using LojaVerity.Servicos.Entidades;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Diagnostics;
using LojaVerity.Servicos.Falhas;
using LojaVerity.Excecoes;
using LojaVerity.Servicos.Infraestrutura;

namespace LojaVerity.Servicos
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(Namespace = "http://servicos.verity.com/1.0")]
    public class ProdutosServico 
        : IProdutosServico
    {
        public ProdutosServico()
        {
            this.traceSwitch = new TraceSwitch("LojaVerity.Servicos.ProdutosServico", "ProdutosServico - Padrão");
        }

        private TraceSwitch traceSwitch = null;

        public IEnumerable<Produto> BuscarProdutos()
        {
            try
            {
                //-----------------------------------------------------------------------------------------------------------------
                // Busca produtos
                Negocio.GerenciadorProduto gerenciador = new Negocio.GerenciadorProduto();
                IEnumerable<LojaVerity.Entidades.Produto> produtos = gerenciador.BuscarProdutos();

                //-----------------------------------------------------------------------------------------------------------------
                // Monta objeto de response e o retorna
                List<Produto> listaProdutos = new List<Produto>();

                foreach (LojaVerity.Entidades.Produto produto in produtos)
                    listaProdutos.Add(new Produto(produto));

                return listaProdutos;
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

        public Produto BuscarProduto(string id)
        {
            try
            {
                //-----------------------------------------------------------------------------------------------------------------
                // Valida parâmetro recebido
                if (string.IsNullOrEmpty(id))
                    throw new MaRequisicaoException(10001, "ID não fornecido.");

                long produtoID = long.MinValue;

                if (!long.TryParse(id, out produtoID))
                    throw new MaRequisicaoException(10002, "ID inválido.");

                //-----------------------------------------------------------------------------------------------------------------
                // Busca produto
                Negocio.GerenciadorProduto gerenciador = new Negocio.GerenciadorProduto();
                LojaVerity.Entidades.Produto produto = gerenciador.BuscarProduto(produtoID);

                if (produto == null)
                    return null;

                //-----------------------------------------------------------------------------------------------------------------
                // Monta objeto de response e o retorna
                return new Produto(produto);
            }
            catch (MaRequisicaoException ex)
            {
                Trace.WriteLineIf(this.traceSwitch.TraceVerbose, string.Format("ProdutosServico::BuscarProduto - ID: {0} - {1}.", id, Tracing.FormatarException((Exception)ex)));
                throw TratadorException.TratarException(ex, System.Net.HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                Trace.WriteLineIf(this.traceSwitch.TraceError, string.Format("ProdutosServico::BuscarProduto - ID: {0} - {1}.", id, Tracing.FormatarException(ex)));
                throw TratadorException.TratarException(ex, System.Net.HttpStatusCode.InternalServerError);
            }
        }

        public void ExcluirProduto(string id)
        {
            try
            {
                //-----------------------------------------------------------------------------------------------------------------
                // Valida parâmetro recebido
                if (string.IsNullOrEmpty(id))
                    throw new Exception(); // TODO: Especializar exception

                long produtoID = long.MinValue;

                if (!long.TryParse(id, out produtoID))
                    throw new Exception(); // TODO: Especializar Exception

                //-----------------------------------------------------------------------------------------------------------------
                // Exclui produto
                Negocio.GerenciadorProduto gerenciador = new Negocio.GerenciadorProduto();
                gerenciador.ExcluirProduto(produtoID);
            }
            catch (MaRequisicaoException ex)
            {
                Trace.WriteLineIf(this.traceSwitch.TraceVerbose, string.Format("ProdutosServico::ExcluirProduto - ID: {0} - {1}.", id, Tracing.FormatarException((Exception)ex)));
                throw TratadorException.TratarException(ex, System.Net.HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                Trace.WriteLineIf(this.traceSwitch.TraceError, string.Format("ProdutosServico::ExcluirProduto - ID: {0} - {1}.", id, Tracing.FormatarException(ex)));
                throw TratadorException.TratarException(ex, System.Net.HttpStatusCode.InternalServerError);
            }
        }

        public Produto CadastrarProduto(Produto produto)
        {
            try
            {
                //-----------------------------------------------------------------------------------------------------------------
                // Cadastra produto
                Negocio.GerenciadorProduto gerenciador = new Negocio.GerenciadorProduto();
                LojaVerity.Entidades.Produto novoProduto = gerenciador.CadastrarProduto(produto.Nome, produto.Descricao, produto.Preco);

                //-----------------------------------------------------------------------------------------------------------------
                // Monta objeto de response e o retorna
                return new Produto(novoProduto);
            }
            catch (MaRequisicaoException ex)
            {
                Trace.WriteLineIf(this.traceSwitch.TraceVerbose, string.Format("ProdutosServico::CadastrarProduto - {0}.", Tracing.FormatarException((Exception)ex)));
                throw TratadorException.TratarException(ex, System.Net.HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                Trace.WriteLineIf(this.traceSwitch.TraceError, string.Format("ProdutosServico::CadastrarProduto - {0}.", Tracing.FormatarException(ex)));
                throw TratadorException.TratarException(ex, System.Net.HttpStatusCode.InternalServerError);
            }
        }
    }
}
