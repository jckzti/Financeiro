using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Applications.Interfaces
{
    public interface InterfaceAppCompra : InterfaceGenericaApp<Compra>
    {
        void AdicionarCompra(Compra compra);
        void AtualizarCompra(Compra compra);
        IList<Compra> ListarComprasUsuario(string emailUsuario);
    }
}
