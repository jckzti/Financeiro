using Applications.Interfaces;
using Domain.Interfaces.ICategoria;
using Domain.Interfaces.InterfaceServicos;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Applications.App
{
    public class AppCategoria : InterfaceAppCategoria
    {

        InterfaceCategoria _InterfaceCategoria;
        ICategoriaServico _ICategoriaServico;

        public AppCategoria(InterfaceCategoria InterfaceCategoria, ICategoriaServico ICategoriaServico)
        {
            _InterfaceCategoria = InterfaceCategoria;
            _ICategoriaServico = ICategoriaServico;
        }

        public void Add(Categoria Objeto)
        {
            _InterfaceCategoria.Add(Objeto);
        }

        public void Delete(Categoria Objeto)
        {
            _InterfaceCategoria.Delete(Objeto);
        }

        public Categoria GetEntityById(int Id)
        {
            return _InterfaceCategoria.GetEntityById(Id);
        }

        public List<Categoria> List()
        {
            return _InterfaceCategoria.List();
        }

        public void Update(Categoria Objeto)
        {
            _InterfaceCategoria.Update(Objeto);
        }

        #region Customizados 
        public IList<Categoria> ListarCategoriasUsuario(string emailUsuario)
        {
            return _InterfaceCategoria.ListarCategoriasUsuario(emailUsuario);
        }

        public void AdicionarCategoria(Categoria categoria)
        {
            _ICategoriaServico.AdicionarCategoria(categoria);
        }

        public void AtualizarCategoria(Categoria categoria)
        {
            _ICategoriaServico.AtualizarCategoria(categoria);
        }

        #endregion
    }
}
