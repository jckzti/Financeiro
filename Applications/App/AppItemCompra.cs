using Applications.Interfaces;
using Domain.Interfaces.ICompra;
using Domain.Interfaces.InterfaceServicos;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Applications.App
{
    public class AppItemCompra : InterfaceAppItemCompra
    {

        InterfaceItemCompra _InterfaceItemCompra;
        IItemCompraServico _IItemCompraServico;

        public AppItemCompra(InterfaceItemCompra InterfaceItemCompra, IItemCompraServico IItemCompraServico)
        {
            _InterfaceItemCompra = InterfaceItemCompra;
            _IItemCompraServico = IItemCompraServico;
        }

        public void Add(ItemCompra Objeto)
        {
            _InterfaceItemCompra.Add(Objeto);
        }

        public void AdicionarItemCompra(ItemCompra ItemCompra)
        {
            _IItemCompraServico.AdicionarItemCompra(ItemCompra);
        }

        public void AtualizarItemCompraServico(ItemCompra ItemCompra)
        {
            _IItemCompraServico.AtualizarItemCompra(ItemCompra);
        }

        public void AtualizarItemCompra(ItemCompra ItemCompra)
        {
            _InterfaceItemCompra.AtualizarItemCompra(ItemCompra);
        }

        public void Delete(ItemCompra Objeto)
        {
            _InterfaceItemCompra.Delete(Objeto);
        }

        public ItemCompra GetEntityById(int Id)
        {
            return _InterfaceItemCompra.GetEntityById(Id);
        }

        public List<ItemCompra> List()
        {
            return _InterfaceItemCompra.List();
        }

        public void Update(ItemCompra Objeto)
        {
            _InterfaceItemCompra.Update(Objeto);
        }

        public IList<ItemCompra> ListarItensDaCompra(int IdCompra)
        {
            return _InterfaceItemCompra.ListarItensDaCompra(IdCompra);
        }

        public void DeletarItemPorId(int Id)
        {
            _InterfaceItemCompra.DeletarItemPorId(Id);
        }
    }
}
