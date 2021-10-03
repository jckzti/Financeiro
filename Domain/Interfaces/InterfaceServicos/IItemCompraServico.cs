using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.InterfaceServicos
{
    public interface IItemCompraServico
    {
        void AdicionarItemCompra(ItemCompra ItemCompra);
        void AtualizarItemCompra(ItemCompra ItemCompra);
    }
}
