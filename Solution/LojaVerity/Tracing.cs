using LojaVerity.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaVerity
{
    public class Tracing
    {
        public static string FormatarException(Exception ex)
        {
            StringBuilder sb = new StringBuilder(1024);

            sb.AppendFormat("Erro: {0}. \n", ex.Message);
            sb.AppendFormat("Callstack: {0}.\n", ex.StackTrace);

            ExplodirInnerException(ex, ref sb);

            return sb.ToString();
        }

        public static string FormatarException(BaseException ex)
        {
            StringBuilder sb = new StringBuilder(1024);

            sb.AppendFormat("Código: {0}. Erro: {1}. Callstack: {2}.\n", ex.CodigoErro, ex.Message, ex.StackTrace);
            ExplodirInnerException(ex, ref sb);

            return sb.ToString();
        }

        private static void ExplodirInnerException(Exception ex, ref StringBuilder sb)
        {
            if (ex.InnerException == null)
                return;

            sb.AppendLine("InnerException:");
            sb.AppendFormat("Erro: {0}.\n", ex.Message);
            sb.AppendFormat("Callstack: {0}.\n", ex.StackTrace);

            ExplodirInnerException(ex.InnerException, ref sb);
        }
    }
}
