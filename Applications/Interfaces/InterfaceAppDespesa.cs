using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Applications.Interfaces
{
    public interface InterfaceAppDespesa : InterfaceGenericaApp<Despesa>
    {
        void AdicionarDespesa(Despesa despesa);
        void AtualizarDespesa(Despesa despesa);

        IList<Despesa> ListarDespesasUsuario(string emailUsuario);

        IList<Despesa> ListarDespesasUsuarioNaoPagasMesesAnterior(string emailUsuario);
    }
}
