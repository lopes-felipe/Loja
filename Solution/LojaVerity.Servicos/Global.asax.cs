using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Activation;
using System.Text;
using System.Web;
using System.Web.Routing;

namespace LojaVerity.Servicos
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            RouteTable.Routes.Add(new ServiceRoute("Produtos", new WebServiceHostFactory(), typeof(ProdutosServico)));
            RouteTable.Routes.Add(new ServiceRoute("Pedidos", new WebServiceHostFactory(), typeof(PedidosServico)));
        }
    }
}
