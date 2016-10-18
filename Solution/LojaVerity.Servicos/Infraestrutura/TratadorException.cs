using LojaVerity.Excecoes;
using LojaVerity.Servicos.Falhas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace LojaVerity.Servicos.Infraestrutura
{
    public class TratadorException
    {
        public static Exception TratarException(Exception ex, System.Net.HttpStatusCode statusCode)
        {
            LojaVerityFailure falha = null;

            if (ex is BaseException)
                falha = new LojaVerityFailure(((BaseException)ex).CodigoErro, ex.Message);
            else
                falha = new LojaVerityFailure((int)statusCode, ex.Message);

            string bindingName = OperationContext.Current.EndpointDispatcher.ChannelDispatcher.BindingName;

            if (bindingName.ToLower().Contains("webhttpbinding"))
                return new WebFaultException<LojaVerityFailure>(falha, statusCode);

            return new FaultException<LojaVerityFailure>(falha, falha.MensagemErro, new FaultCode("LojaVerityFailure", "http://servicos.verity.com/1.0/Falhas"));
        }
    }
}
