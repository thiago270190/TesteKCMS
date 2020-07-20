using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProdutoAPI.Models
{
    public class Produto
    {
        public Guid Id { get; set; }

        [Required]
        [DisplayName("Nome do Produto")]
        public string Nome { get; set; }

        [Required]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        public string Categoria { get; set; }

    }
}
