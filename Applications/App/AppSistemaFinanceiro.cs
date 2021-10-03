using Applications.Interfaces;
using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.ISistemaFinanceiro;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Applications.App
{
    public class AppSistemaFinanceiro : InterfaceAppSistemaFinanceiro
    {

        private readonly InterfaceSistemaFinanceiro _InterfaceSistemaFinanceiro;
        private readonly ISistemaFinanceiroServico _ISistemaFinanceiroServico;

        public AppSistemaFinanceiro(InterfaceSistemaFinanceiro InterfaceSistemaFinanceiro, ISistemaFinanceiroServico ISistemaFinanceiroServico)
        {
            _InterfaceSistemaFinanceiro = InterfaceSistemaFinanceiro;
            _ISistemaFinanceiroServico = ISistemaFinanceiroServico;
        }

        public void Add(SistemaFinanceiro Objeto)
        {
            _InterfaceSistemaFinanceiro.Add(Objeto);
        }

        public void Delete(SistemaFinanceiro Objeto)
        {
            _InterfaceSistemaFinanceiro.Delete(Objeto);
        }

        public SistemaFinanceiro GetEntityById(int Id)
        {
            return _InterfaceSistemaFinanceiro.GetEntityById(Id);
        }

        public List<SistemaFinanceiro> List()
        {
            return _InterfaceSistemaFinanceiro.List();
        }


        public void Update(SistemaFinanceiro Objeto)
        {
            _InterfaceSistemaFinanceiro.Update(Objeto);
        }


        public IList<SistemaFinanceiro> ListaSistemasUsuario(string emailUsuario)
        {
            return _InterfaceSistemaFinanceiro.ListaSistemasUsuario(emailUsuario);
        }

        public void AdicionarSistemaFinanceiro(SistemaFinanceiro sistemaFinanceiro)
        {
            _ISistemaFinanceiroServico.AdicionarSistemaFinanceiro(sistemaFinanceiro);
        }

        public void AtualizarSistemaFinanceiro(SistemaFinanceiro sistemaFinanceiro)
        {
            _ISistemaFinanceiroServico.AtualizarSistemaFinanceiro(sistemaFinanceiro);
        }
    }
}
