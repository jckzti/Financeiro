using Domain.Interfaces.ICompra;
using Domain.Interfaces.InterfaceServicos;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Servicos
{
    public class ItemCompraServico : IItemCompraServico
    {

        private readonly InterfaceItemCompra _InterfaceItemCompra;

        public ItemCompraServico(InterfaceItemCompra InterfaceItemCompra)
        {
            _InterfaceItemCompra = InterfaceItemCompra;
        }


        public void AdicionarItemCompra(ItemCompra itemCompra)
        {
            var data = DateTime.Now;
            itemCompra.DataCadastro = data;
            itemCompra.DataAlteracao = DateTime.MinValue;
            itemCompra.DataCompra = DateTime.MinValue;
            var valido = itemCompra.ValidarPropriedadeString(itemCompra.Nome, "Nome");

            if (valido)
                _InterfaceItemCompra.Add(itemCompra);
        }

        public void AtualizarItemCompra(ItemCompra itemCompra)
        {
            var data = DateTime.Now;
            itemCompra.DataAlteracao = data;

            if (itemCompra.Comprado)
            {
                itemCompra.DataCompra = data;
            }

            var valido = itemCompra.ValidarPropriedadeString(itemCompra.Nome, "Nome");

            if (valido)
                _InterfaceItemCompra.Update(itemCompra);
        }
    }
}
