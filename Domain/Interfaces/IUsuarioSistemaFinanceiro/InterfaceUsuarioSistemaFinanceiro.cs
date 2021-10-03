using Domain.Interfaces.Generics;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.IUsuarioSistemaFinanceiro
{
    public interface InterfaceUsuarioSistemaFinanceiro : InterfaceGeneric<UsuarioSistemaFinanceiro>
    {
        IList<UsuarioSistemaFinanceiro> ListarUsuariosSistema(int IdSistema);
        void RemoveUsuarios(List<UsuarioSistemaFinanceiro> usuarios);

        UsuarioSistemaFinanceiro ObterUsuarioPorEmail(string EmailUsuario);


    }
}
