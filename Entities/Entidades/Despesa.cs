using Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Entidades
{
    [Table("Despesa")]
    public class Despesa : Base
    {
        [Display(Name = "Valor")]
        public decimal Valor { get; set; }

        [Display(Name = "Mês")]
        public int Mes { get; set; }

        [Display(Name = "Ano")]
        public int Ano { get; set; }

        [Display(Name = "TipoDespesa")]
        public EnumTipoDespesa TipoDespesa { get; set; }

        [Display(Name = "Data de Cadastro")]
        public DateTime DataCadastro { get; set; }

        [Display(Name = "Data de Alteração")]
        public DateTime DataAlteracao { get; set; }

        [Display(Name = "Data de Pagamento")]
        public DateTime DataPagamento { get; set; }
        public string getDataPagamento()
        {
            if (DataPagamento == DateTime.ParseExact("0001-01-01", "yyyy-MM-dd",System.Globalization.CultureInfo.InvariantCulture))
            {
                return "";
    
            }
            return DataPagamento.ToString();            
        }

        [Display(Name = "Data de Vencimento")]
        public DateTime DataVencimento { get; set; }

        [Display(Name = "Pago")]
        public bool Pago { get; set; }

        [NotMapped]
        public bool DespesaAntrasada { get; set; }


        [Display(Name = "Categoria")]
        [ForeignKey("Categoria")]
        [Column(Order = 1)]
        public int IdCategoria { get; set; }
        public virtual Categoria Categoria { get; set; }

    }
}
