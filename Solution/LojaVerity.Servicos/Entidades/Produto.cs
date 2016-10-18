using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace LojaVerity.Servicos.Entidades
{
    [DataContract(Namespace = "http://servicos.verity.com/1.0/Entidades")]
    public class Produto
    {
        public Produto()
        {

        }

        public Produto(long id, string nome, string descricao, decimal preco)
        {
            this.ID = id;
            this.Nome = nome;
            this.Descricao = descricao;
            this.Preco = preco;
        }

        public Produto(LojaVerity.Entidades.Produto produto)
        {
            if (produto == null)
                return;

            this.ID = produto.ID;
            this.Nome = produto.Nome;
            this.Descricao = produto.Descricao;
            this.Preco = produto.Preco;
        }

        [DataMember]
        public long ID { get; set; }

        [DataMember]
        public string Nome { get; set; }

        [DataMember]
        public string Descricao { get; set; }

        [DataMember]
        public decimal Preco { get; set; }
    }
}
