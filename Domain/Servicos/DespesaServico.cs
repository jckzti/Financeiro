using Domain.Interfaces.IDespesa;
using Domain.Interfaces.InterfaceServicos;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Servicos
{
    public class DespesaServico : IDespesaServico
    {
        private readonly InterfaceDespesa _InterfaceDespesa;

        public DespesaServico(InterfaceDespesa InterfaceDespesa)
        {
            _InterfaceDespesa = InterfaceDespesa;
        }

        public void AdicionarDespesa(Despesa despesa)
        {

            var data = DateTime.Now;

            despesa.DataCadastro = data;
            despesa.Ano = data.Year;
            despesa.Mes = data.Month;

            var valido = despesa.ValidarPropriedadeString(despesa.Nome, "Nome");

            if (valido)
                _InterfaceDespesa.Add(despesa);
        }

        public void AtualizarDespesa(Despesa despesa)
        {
            var data = DateTime.Now;
            despesa.DataAlteracao = data;
            if (despesa.Pago)
            {
                despesa.DataPagamento = data;
            }

            var valido = despesa.ValidarPropriedadeString(despesa.Nome, "Nome");

            if (valido)
                _InterfaceDespesa.Update(despesa);
        }
    }
}
