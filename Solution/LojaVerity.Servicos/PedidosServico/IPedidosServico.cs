using LojaVerity.Servicos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace LojaVerity.Servicos
{
    [ServiceContract(Namespace = "http://servicos.verity.com/1.0")]
    public interface IPedidosServico
    {
        [OperationContract]
        [WebInvoke(UriTemplate = "", Method = "POST", RequestFormat = WebMessageFormat.Json)]
        Pedido CriarPedido(Pedido pedido);

        [OperationContract]
        [WebInvoke(UriTemplate = "", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        IEnumerable<Pedido> BuscarPedidos();

        [OperationContract]
        [WebInvoke(UriTemplate = "{id}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        Pedido BuscarPedido(string id);
    }
}
