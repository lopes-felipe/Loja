using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaVerity.Excecoes
{
    public class MaRequisicaoException
        : BaseException
    {
        public MaRequisicaoException()
            : base()
        {

        }

        public MaRequisicaoException(int codigoErro, string mensagemErro)
            : base(codigoErro, mensagemErro)
        {

        }
    }
}
