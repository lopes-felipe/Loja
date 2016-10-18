using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LojaVerity.Entidades
{
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

        public Pedido(Modelo.Pedido pedido)
            : this()
        {
            if (pedido == null)
                return;

            this.ID = pedido.ID;
            this.Cliente = pedido.Cliente;
            this.PrecoTotal = pedido.PrecoTotal;
            this.DataPedido = pedido.DataPedido;

            if (pedido.PedidoLinhas != null)
            {
                foreach (Modelo.PedidoLinha linha in pedido.PedidoLinhas)
                    this.Linhas.Add(new PedidoLinha(linha));
            }
        }
        
        public long ID { get; set; }
        
        public string Cliente { get; set; }
        
        public decimal PrecoTotal { get; set; }

        public DateTime DataPedido { get; set; }
        
        public List<PedidoLinha> Linhas { get; set; }
    }
}
