using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LojaVerity.Servicos.Entidades
{
    [DataContract(Namespace = "http://servicos.verity.com/1.0/Entidades")]
    public class Pedido
    {
        public Pedido()
        {
            this.Linhas = new List<PedidoLinha>();
        }

        public Pedido(long id, string cliente, decimal precoTotal, DateTime dataPedido, List<PedidoLinha> linhas)
        {
            this.ID = id;
            this.Cliente = cliente;
            this.PrecoTotal = precoTotal;
            this.DataPedido = dataPedido;
            this.Linhas = linhas;
        }

        public Pedido(LojaVerity.Entidades.Pedido pedido)
            : this()
        {
            if (pedido == null)
                return;

            this.ID = pedido.ID;
            this.Cliente = pedido.Cliente;
            this.PrecoTotal = pedido.PrecoTotal;
            this.DataPedido = pedido.DataPedido;

            if (pedido.Linhas != null)
            {
                foreach (LojaVerity.Entidades.PedidoLinha linha in pedido.Linhas)
                    this.Linhas.Add(new PedidoLinha(linha));
            }
        }

        [DataMember]
        public long ID { get; set; }

        [DataMember]
        public string Cliente { get; set; }

        [DataMember]
        public decimal PrecoTotal { get; set; }

        [DataMember]
        public DateTime DataPedido { get; set; }

        [DataMember]
        public List<PedidoLinha> Linhas { get; set; }
    }
}
