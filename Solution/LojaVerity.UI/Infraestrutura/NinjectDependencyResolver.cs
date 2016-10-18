using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaVerity.UI.Infraestrutura
{
    public class NinjectDependencyResolver
         : IDependencyResolver
    {
        public NinjectDependencyResolver(IKernel kernel)
        {
            this.kernel = kernel;

            AddBindings();
        }

        private IKernel kernel;


        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<ProdutosServico.IProdutosServico>().To<ProdutosServico.ProdutosServicoClient>();
            kernel.Bind<PedidosServico.IPedidosServico>().To<PedidosServico.PedidosServicoClient>();
        }
    }
}