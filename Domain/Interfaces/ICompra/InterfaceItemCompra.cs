using Domain.Interfaces.Generics;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.ICompra
{
    public interface InterfaceItemCompra : InterfaceGeneric<ItemCompra>
    {
        void AtualizarItemCompra(ItemCompra ItemCompra);

        void DeletarItemPorId(int Id);

        IList<ItemCompra> ListarItensDaCompra(int IdCompra);
    }
}
