using Domain.Interfaces.Generics;
using Domain.Servicos;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.ISistemaFinanceiro
{
    public interface InterfaceSistemaFinanceiro : InterfaceGeneric<SistemaFinanceiro>
    {
        IList<SistemaFinanceiro> ListaSistemasUsuario(string emailUsuario);

    
    }
}
