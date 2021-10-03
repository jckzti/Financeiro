using Applications.Interfaces;
using Domain.Interfaces.ICompra;
using Domain.Interfaces.InterfaceServicos;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Applications.App
{
    public class AppCompra : InterfaceAppCompra
    {

        InterfaceCompra _InterfaceCompra;
        ICompraServico _ICompraServico;

        public AppCompra(InterfaceCompra InterfaceCompra, ICompraServico ICompraServico)
        {
            _InterfaceCompra = InterfaceCompra;
            _ICompraServico = ICompraServico;
        }

        public void Add(Compra Objeto)
        {
            _InterfaceCompra.Add(Objeto);
        }


        public void Delete(Compra Objeto)
        {
            _InterfaceCompra.Delete(Objeto);
        }

        public Compra GetEntityById(int Id)
        {
            return _InterfaceCompra.GetEntityById(Id);
        }

        public List<Compra> List()
        {
            return _InterfaceCompra.List();
        }

        public IList<Compra> ListarComprasUsuario(string emailUsuario)
        {
            return _InterfaceCompra.ListarComprasUsuario(emailUsuario);
        }

        public void Update(Compra Objeto)
        {
            _InterfaceCompra.Update(Objeto);
        }


        #region Métodos do Serviço
        public void AdicionarCompra(Compra compra)
        {
            _ICompraServico.AdicionarCompra(compra);
        }

        public void AtualizarCompra(Compra compra)
        {
            _ICompraServico.AtualizarCompra(compra);
        }
        #endregion

    }
}
