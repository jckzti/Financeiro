using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Applications.Interfaces
{
    public interface InterfaceAppUsuarioSistemaFinanceiro : InterfaceGenericaApp<UsuarioSistemaFinanceiro>
    {
        void CadastrarUsuarioNoSistema(UsuarioSistemaFinanceiro usuarioSistemaFinanceiro);

        IList<UsuarioSistemaFinanceiro> ListarUsuariosSistema(int idSistema);

        void RemoveUsuarios(List<UsuarioSistemaFinanceiro> usuarios);

        UsuarioSistemaFinanceiro ObterUsuarioPorEmail(string EmailUsuario);

    }
}
