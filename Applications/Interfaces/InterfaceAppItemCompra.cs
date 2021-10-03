using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Applications.Interfaces
{
    public interface InterfaceAppItemCompra : InterfaceGenericaApp<ItemCompra>
    {
        void AdicionarItemCompra(ItemCompra ItemCompra);
        void AtualizarItemCompraServico(ItemCompra ItemCompra);
        void AtualizarItemCompra(ItemCompra ItemCompra);
        IList<ItemCompra> ListarItensDaCompra(int IdCompra);

        void DeletarItemPorId(int Id);

    }
}
