using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Entidades
{
    [Table("Compra")]
    public class Compra : Base
    {

        [Display(Name = "Data de Cadastro")]
        public DateTime DataCadastro { get; set; }

        [Display(Name = "Data de Alteração")]
        public DateTime DataAlteracao { get; set; }

        [Display(Name = "Categoria")]
        [ForeignKey("Categoria")]
        [Column(Order = 1)]
        public int IdCategoria { get; set; }
        public virtual Categoria Categoria { get; set; }

    }
}
