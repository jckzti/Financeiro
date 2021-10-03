using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FinanceiroServico.Data.Entidades
{
    [Table("UsuarioSistemaFinanceiro")]
    public class UsuarioSistemaFinanceiro
    {
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Display(Name = "E-mail do Usuário")]
        public string EmailUsuario { get; set; }

        [Display(Name = "Administrador")]
        public bool Administrador { get; set; }

        [Display(Name = "Sistema Atual")]
        public bool SistemaAtual { get; set; }

        [Display(Name = "Código do Sistema")]
        [ForeignKey("SistemaFinanceiro")]
        [Column(Order = 1)]
        public int IdSistema { get; set; }
        public virtual SistemaFinanceiro SistemaFinanceiro { get; set; }

    }
}
