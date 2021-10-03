using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.InterfaceServicos
{
    public interface IDespesaServico
    {
        void AdicionarDespesa(Despesa despesa);
        void AtualizarDespesa(Despesa despesa);
    }
}
