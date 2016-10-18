using LojaVerity.Servicos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace LojaVerity.Servicos
{
    [ServiceContract(Namespace = "http://servicos.verity.com/1.0")]
    public interface IProdutosServico
    {
        [OperationContract]
        [WebInvoke(UriTemplate = "", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        IEnumerable<Produto> BuscarProdutos();

        [OperationContract]
        [WebInvoke(UriTemplate = "{id}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        Produto BuscarProduto(string id);

        [OperationContract]
        [WebInvoke(UriTemplate = "{id}", Method = "DELETE")]
        void ExcluirProduto(string id);

        [OperationContract]
        [WebInvoke(UriTemplate = "", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        Produto CadastrarProduto(Produto produto);
    }
}
