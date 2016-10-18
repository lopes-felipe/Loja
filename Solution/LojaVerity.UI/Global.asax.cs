using LojaVerity.UI.Infraestrutura.Binders;
using LojaVerity.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LojaVerity.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // Lista de Binders customisados
            ModelBinders.Binders.Add(typeof(Pedido), new PedidoBinder());
        }
    }
}
