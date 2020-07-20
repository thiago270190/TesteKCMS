using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ProdutoAPI.Models
{
    public class CategoriaProduto
    {
        [BsonId]
        public Guid Id { get; set; }

        [DisplayName("Descrição da Categoria")]
        public string DescricaoCategoria { get; set; }
    }
}
