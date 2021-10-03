using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.InterfaceServicos
{
    public interface ICategoriaServico
    {

        void AdicionarCategoria(Categoria categoria);
        void AtualizarCategoria(Categoria categoria);
    }
}
