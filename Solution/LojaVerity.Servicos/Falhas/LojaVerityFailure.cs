using LojaVerity.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LojaVerity.Servicos.Falhas
{
    public class LojaVerityFailure
    {
        public LojaVerityFailure()
        {

        }

        public LojaVerityFailure(int codigoErro, string mensagemErro)
        {
            this.CodigoErro = codigoErro;
            this.MensagemErro = mensagemErro;
        }

        public LojaVerityFailure(BaseException exception)
        {
            this.CodigoErro = exception.CodigoErro;
            this.MensagemErro = exception.Message;
        }

        [DataMember]
        public int CodigoErro { get; set; }
        
        [DataMember]
        public string MensagemErro { get; set; }
    }
}
