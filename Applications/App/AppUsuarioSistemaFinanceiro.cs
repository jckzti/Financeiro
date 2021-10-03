using Applications.Interfaces;
using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.IUsuarioSistemaFinanceiro;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Applications.App
{
    public class AppUsuarioSistemaFinanceiro : InterfaceAppUsuarioSistemaFinanceiro
    {

        private readonly InterfaceUsuarioSistemaFinanceiro _InterfaceUsuarioSistemaFinanceiro;
        private readonly IUsuarioSistemaFinanceiroServico _IUsuarioSistemaFinanceiroServico;

        public AppUsuarioSistemaFinanceiro(InterfaceUsuarioSistemaFinanceiro InterfaceUsuarioSistemaFinanceiro, IUsuarioSistemaFinanceiroServico IUsuarioSistemaFinanceiroServico)
        {
            _InterfaceUsuarioSistemaFinanceiro = InterfaceUsuarioSistemaFinanceiro;
            _IUsuarioSistemaFinanceiroServico = IUsuarioSistemaFinanceiroServico;
        }

        public void Add(UsuarioSistemaFinanceiro Objeto)
        {
            _InterfaceUsuarioSistemaFinanceiro.Add(Objeto);
        }

        public void CadastrarUsuarioNoSistema(UsuarioSistemaFinanceiro usuarioSistemaFinanceiro)
        {
            _IUsuarioSistemaFinanceiroServico.CadastrarUsuarioNoSistema(usuarioSistemaFinanceiro);
        }

        public void Delete(UsuarioSistemaFinanceiro Objeto)
        {
            _InterfaceUsuarioSistemaFinanceiro.Delete(Objeto);
        }

        public UsuarioSistemaFinanceiro GetEntityById(int Id)
        {
            return _InterfaceUsuarioSistemaFinanceiro.GetEntityById(Id);
        }

        public List<UsuarioSistemaFinanceiro> List()
        {
            return _InterfaceUsuarioSistemaFinanceiro.List();
        }


        public void Update(UsuarioSistemaFinanceiro Objeto)
        {
            _InterfaceUsuarioSistemaFinanceiro.Update(Objeto);
        }

        #region Customizacao 

        public IList<UsuarioSistemaFinanceiro> ListarUsuariosSistema(int idSistema)
        {
            return _InterfaceUsuarioSistemaFinanceiro.ListarUsuariosSistema(idSistema);
        }

        public void RemoveUsuarios(List<UsuarioSistemaFinanceiro> usuarios)
        {
            _InterfaceUsuarioSistemaFinanceiro.RemoveUsuarios(usuarios);
        }

        public UsuarioSistemaFinanceiro ObterUsuarioPorEmail(string EmailUsuario)
        {
            return _InterfaceUsuarioSistemaFinanceiro.ObterUsuarioPorEmail(EmailUsuario);
        }

        #endregion
    }
}
