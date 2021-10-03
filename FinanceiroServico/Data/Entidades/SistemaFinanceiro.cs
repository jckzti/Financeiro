using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FinanceiroServico.Data.Entidades
{
    [Table("SistemaFinanceiro")]
    public class SistemaFinanceiro : Base
    {
        [Display(Name = "Mês Sistema")]
        public int Mes { get; set; }

        [Display(Name = "Ano Sistema")]
        public int Ano { get; set; }

        [Display(Name = "Dia de Fechamento")]
        public int DiaFechamento { get; set; }

        [Display(Name = "Gerar Copia das Despesas")]
        public bool GerarCopiaDespesa { get; set; }

        [Display(Name = "Mês Copia")]
        public int MesCopia { get; set; }

        [Display(Name = "Ano Sistema Copia")]
        public int AnoCopia { get; set; }
    }
}
