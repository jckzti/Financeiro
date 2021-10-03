using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Entidades
{
    [Table("ItemCompra")]
    public class ItemCompra : Base
    {
        [Display(Name = "Valor")]
        public decimal Valor { get; set; }

        [Display(Name = "Comprado")]
        public bool Comprado { get; set; }

        [Display(Name = "Data de Cadastro")]
        public DateTime DataCadastro { get; set; }

        [Display(Name = "Data de Alteração")]
        public DateTime DataAlteracao { get; set; }

        [Display(Name = "Data de Compra")]
        public DateTime DataCompra { get; set; }

       
        [Display(Name = "Compra")]
        [ForeignKey("Compra")]
        [Column(Order = 1)]
        public int IdCompra { get; set; }
        public virtual Compra Compra { get; set; }

    }
}
