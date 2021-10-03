using Domain.Interfaces.Generics;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.IDespesa
{
    public interface InterfaceDespesa : InterfaceGeneric<Despesa>
    {

        IList<Despesa> ListarDespesasUsuario(string emailUsuario);

        IList<Despesa> ListarDespesasUsuarioNaoPagasMesesAnterior(string emailUsuario);
    }
}
