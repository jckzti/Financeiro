using Domain.Interfaces.ICategoria;
using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.IUsuarioSistemaFinanceiro;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Servicos
{
    public class CategoriaServico : ICategoriaServico
    {

        private readonly InterfaceUsuarioSistemaFinanceiro _interfaceUsuarioSistemaFinanceiro;
        private readonly InterfaceCategoria _interfaceCategoria;

        public CategoriaServico(InterfaceUsuarioSistemaFinanceiro interfaceUsuarioSistemaFinanceiro, InterfaceCategoria interfaceCategoria)
        {
            _interfaceUsuarioSistemaFinanceiro = interfaceUsuarioSistemaFinanceiro;
            _interfaceCategoria = interfaceCategoria;
        }

        public void AdicionarCategoria(Categoria categoria)
        {
            var valido = categoria.ValidarPropriedadeString(categoria.Nome, "Nome");

            if (valido)
                _interfaceCategoria.Add(categoria);

        }

        public void AtualizarCategoria(Categoria categoria)
        {
            var valido = categoria.ValidarPropriedadeString(categoria.Nome, "Nome");

            if (valido)
                _interfaceCategoria.Update(categoria);
        }
    }
}
