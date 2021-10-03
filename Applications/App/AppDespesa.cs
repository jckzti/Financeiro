using Applications.Interfaces;
using Domain.Interfaces.IDespesa;
using Domain.Interfaces.InterfaceServicos;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Applications.App
{
    public class AppDespesa : InterfaceAppDespesa
    {
        InterfaceDespesa _InterfaceDespesa;

        IDespesaServico _IDespesaServico;

        public AppDespesa(InterfaceDespesa InterfaceDespesa, IDespesaServico IDespesaServico)
        {
            _InterfaceDespesa = InterfaceDespesa;
            _IDespesaServico = IDespesaServico;
        }

        public void Add(Despesa Objeto)
        {
            _InterfaceDespesa.Add(Objeto);
        }

        public void AdicionarDespesa(Despesa despesa)
        {
            _IDespesaServico.AdicionarDespesa(despesa);
        }

        public void AtualizarDespesa(Despesa despesa)
        {
            _IDespesaServico.AtualizarDespesa(despesa);
        }

        public void Delete(Despesa Objeto)
        {
            _InterfaceDespesa.Delete(Objeto);
        }

        public Despesa GetEntityById(int Id)
        {
            return _InterfaceDespesa.GetEntityById(Id);
        }

        public List<Despesa> List()
        {
            return _InterfaceDespesa.List();
        }

        public void Update(Despesa Objeto)
        {
            _InterfaceDespesa.Update(Objeto);
        }


        #region Cusromizações 
        public IList<Despesa> ListarDespesasUsuario(string emailUsuario)
        {
            return _InterfaceDespesa.ListarDespesasUsuario(emailUsuario);
        }

        public IList<Despesa> ListarDespesasUsuarioNaoPagasMesesAnterior(string emailUsuario)
        {
            return _InterfaceDespesa.ListarDespesasUsuarioNaoPagasMesesAnterior(emailUsuario);
        }
        #endregion
    }
}
