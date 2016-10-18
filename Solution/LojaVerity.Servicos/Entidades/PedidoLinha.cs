using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LojaVerity.Servicos.Entidades
{
    [DataContract(Namespace = "http://servicos.verity.com/1.0/Entidades")]
    public class PedidoLinha
    {
        public PedidoLinha()
        {

        }

        public PedidoLinha(long id, long pedidoID, long produtoID, int quantidade, decimal preco)
        {
            this.ID = id;
            this.PedidoID = pedidoID;
            this.ProdutoID = produtoID;
            this.Quantidade = quantidade;
            this.Preco = preco;
        }

        public PedidoLinha(LojaVerity.Entidades.PedidoLinha linha)
        {
            if (linha == null)
                return;

            this.ID = linha.ID;
            this.PedidoID = linha.PedidoID;
            this.ProdutoID = linha.ProdutoID;
            this.Quantidade = linha.Quantidade;
            this.Preco = linha.Preco;
        }

        [DataMember]
        public long ID { get; set; }

        [DataMember]
        public long PedidoID { get; set; }

        [DataMember]
        public long ProdutoID { get; set; }

        [DataMember]
        public int Quantidade { get; set; }

        [DataMember]
        public decimal Preco { get; set; }
    }
}
