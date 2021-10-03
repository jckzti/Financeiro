using Domain.Servicos;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.InterfaceServicos
{
    public interface ISistemaFinanceiroServico
    {

        void AdicionarSistemaFinanceiro(SistemaFinanceiro sistemaFinanceiro);
        void AtualizarSistemaFinanceiro(SistemaFinanceiro sistemaFinanceiro);
    }
}
