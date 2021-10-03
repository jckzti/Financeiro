

using FinanceiroServico.Data.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;



namespace FinanceiroServico.Data.Configuracao
{
    public class Contexto : DbContext
    {


        public Contexto() : base("ConectionString")
        {
          //  Database.EnsureCreated();
        }

        public DbSet<Categoria> Categoria { set; get; }
        public DbSet<Despesa> Despesa { set; get; }
        public DbSet<SistemaFinanceiro> SistemaFinanceiro { set; get; }
        public DbSet<UsuarioSistemaFinanceiro> UsuarioSistemaFinanceiro { set; get; }

        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Configurations.Add(new ProcessoResumidoMap());
            //modelBuilder.Configurations.Add(new ProcessoMap());
            //modelBuilder.Configurations.Add(new ProcessoTrocaMap());
            //modelBuilder.Configurations.Add(new ClienteMap());

        }

      

    }
}
