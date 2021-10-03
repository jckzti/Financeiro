using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Entidades
{

    [Table("Sugestao")]
    public class Sugestao : Base
    {

        [Display(Name = "Sugestão")]
        public string DescricaoSugestao { get; set; }

        [Display(Name = "E-mail do Usuário")]
        public string EmailUsuario { get; set; }
    }
}
