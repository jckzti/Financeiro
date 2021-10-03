using Domain.Interfaces.IUsuarioSistemaFinanceiro;
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
    public class RepositorioUsuarioSistemaFinanceiro :
        RepositorioGenerico<UsuarioSistemaFinanceiro>,
        InterfaceUsuarioSistemaFinanceiro
    {

        private readonly DbContextOptions<Contexto> _OptionsBuilder;

        public RepositorioUsuarioSistemaFinanceiro()
        {
            _OptionsBuilder = new DbContextOptions<Contexto>();
        }

        public IList<UsuarioSistemaFinanceiro> ListarUsuariosSistema(int idSistema)
        {
            using (var banco = new Contexto(_OptionsBuilder))
            {

                var sistemasusuario = banco.UsuarioSistemaFinanceiro
                    .Where(s => s.IdSistema == idSistema)
                    .ToList();


                return sistemasusuario;

            }
        }

        public UsuarioSistemaFinanceiro ObterUsuarioPorEmail(string EmailUsuario)
        {
            using (var banco = new Contexto(_OptionsBuilder))
            {
                return banco.UsuarioSistemaFinanceiro.Where(u => u.EmailUsuario == EmailUsuario).FirstOrDefault();
            }
        }

        public void RemoveUsuarios(List<UsuarioSistemaFinanceiro> usuarios)
        {
            using (var banco = new Contexto(_OptionsBuilder))
            {

                banco.UsuarioSistemaFinanceiro
                   .RemoveRange(usuarios);
                banco.SaveChanges();

            }
        }
    }
}
