using Domain.Interfaces.ISistemaFinanceiro;
using Domain.Servicos;
using Entities.Entidades;
using Infra.Configuracao;
using Infra.Repositorio.Genericos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infra.Repositorio
{
    public class RepositorioSistemaFinanceiro : RepositorioGenerico<SistemaFinanceiro>, InterfaceSistemaFinanceiro
    {
        private readonly DbContextOptions<Contexto> _OptionsBuilder;

        public RepositorioSistemaFinanceiro()
        {
            _OptionsBuilder = new DbContextOptions<Contexto>();
        }


        public IList<SistemaFinanceiro> ListaSistemasUsuario(string emailUsuario)
        {
            using (var banco = new Contexto(_OptionsBuilder))
            {

                var sistemasusuario = (from S in banco.SistemaFinanceiro
                                       join US in banco.UsuarioSistemaFinanceiro on
                                        S.Id equals US.IdSistema
                                       where US.EmailUsuario.Equals(emailUsuario)
                                       select S).ToList();

                return sistemasusuario;

            }
        }

      
    }
}
