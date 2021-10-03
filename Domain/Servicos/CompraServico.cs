using Domain.Interfaces.ICompra;
using Domain.Interfaces.InterfaceServicos;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Servicos
{
    public class CompraServico : ICompraServico
    {

        private readonly InterfaceCompra _InterfaceCompra;

        public CompraServico(InterfaceCompra InterfaceCompra)
        {
            _InterfaceCompra = InterfaceCompra;
        }


        public void AdicionarCompra(Compra compra)
        {
            var data = DateTime.Now;
            compra.DataCadastro = data;
            var valido = compra.ValidarPropriedadeString(compra.Nome, "Nome");

            if (valido)
                _InterfaceCompra.Add(compra);
        }

        public void AtualizarCompra(Compra compra)
        {
            var data = DateTime.Now;
            compra.DataAlteracao = data;
            var valido = compra.ValidarPropriedadeString(compra.Nome, "Nome");

            if (valido)
                _InterfaceCompra.Update(compra);
        }
    }
}
