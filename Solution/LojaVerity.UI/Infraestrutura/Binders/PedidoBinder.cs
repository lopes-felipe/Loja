using LojaVerity.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaVerity.UI.Infraestrutura.Binders
{
    public class PedidoBinder
        : IModelBinder
    {
        private const string chaveSession = "Pedido";

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            // Busca o pedido da sessão
            Pedido pedido = null;

            if (controllerContext.HttpContext.Session != null)
                pedido = (Pedido)controllerContext.HttpContext.Session[chaveSession];

            // Cria pedido, caso não haja na sessão
            if (pedido == null)
            {
                pedido = new Pedido();

                if (controllerContext.HttpContext.Session != null)
                    controllerContext.HttpContext.Session[chaveSession] = pedido;
            }

            // Retorna pedido
            return pedido;
        }
    }
}