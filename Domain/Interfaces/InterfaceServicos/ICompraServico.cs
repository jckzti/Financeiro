using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.InterfaceServicos
{
    public interface ICompraServico 
    {
        void AdicionarCompra(Compra compra);
        void AtualizarCompra(Compra compra);
    }
}
