using Domain.Interfaces.Generics;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.ICompra
{
    public interface InterfaceCompra : InterfaceGeneric<Compra>
    {
        IList<Compra> ListarComprasUsuario(string emailUsuario);
    }
}
