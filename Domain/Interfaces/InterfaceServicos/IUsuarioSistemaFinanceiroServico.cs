using Domain.Interfaces.Generics;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.InterfaceServicos
{
    public interface IUsuarioSistemaFinanceiroServico
    {
        void CadastrarUsuarioNoSistema(UsuarioSistemaFinanceiro usuarioSistemaFinanceiro);


    }
}
