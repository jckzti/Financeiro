using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Applications.Interfaces
{
    public interface InterfaceAppCategoria : InterfaceGenericaApp<Categoria>
    {
         IList<Categoria> ListarCategoriasUsuario(string emailUsuario);

        void AdicionarCategoria(Categoria categoria);
        void AtualizarCategoria(Categoria categoria);
    }
}
