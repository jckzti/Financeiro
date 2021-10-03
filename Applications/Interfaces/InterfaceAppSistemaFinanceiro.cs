using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Applications.Interfaces
{
    public interface InterfaceAppSistemaFinanceiro : InterfaceGenericaApp<SistemaFinanceiro>
    {
        IList<SistemaFinanceiro> ListaSistemasUsuario(string emailUsuario);

        void AdicionarSistemaFinanceiro(SistemaFinanceiro sistemaFinanceiro);
        void AtualizarSistemaFinanceiro(SistemaFinanceiro sistemaFinanceiro);
    }
}
