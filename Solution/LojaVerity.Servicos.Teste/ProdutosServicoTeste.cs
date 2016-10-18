using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.IO;

namespace LojaVerity.Servicos.Teste
{
    [TestClass]
    public class ProdutosServicoTeste
    {
        [TestMethod]
        public void BuscarProdutosTeste()
        {
            //----------------------------------------------------------------------------------------------------------------------------
            // Setup
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost/LojaVerityServicos/Produtos");
            request.ContentType = "application/json";
            request.Method = "GET";
            request.Timeout = 240000;
            request.KeepAlive = true;

            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();

            //----------------------------------------------------------------------------------------------------------------------------
            // Execute
            string responseString = string.Empty;

            using (StreamReader sr = new StreamReader(stream))
            {
                responseString = sr.ReadToEnd();
            }

            //----------------------------------------------------------------------------------------------------------------------------
            // Assert
            Assert.IsTrue(!string.IsNullOrEmpty(responseString));
        }
    }
}
