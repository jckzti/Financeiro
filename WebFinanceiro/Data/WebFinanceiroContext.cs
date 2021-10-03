using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Entities.Entidades;

namespace WebFinanceiro.Models
{
    public class WebFinanceiroContext : DbContext
    {
        public WebFinanceiroContext (DbContextOptions<WebFinanceiroContext> options)
            : base(options)
        {
        }

        public DbSet<Entities.Entidades.Despesa> Despesa { get; set; }
    }
}
