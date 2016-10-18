using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaVerity.Excecoes
{
    public class BaseException
        : Exception
    {
        public BaseException()
        {

        }

        public BaseException(int codigoErro, string mensagem)
            : base(mensagem)
        {
            this.CodigoErro = codigoErro;
        }

        public int CodigoErro { get; set; }
    }
}
