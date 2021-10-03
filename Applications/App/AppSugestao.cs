using Applications.Interfaces;
using Domain.ISugestao;
using Entities.Entidades;
using System.Collections.Generic;

namespace Applications.App
{
    public class AppSugestao : InterfaceAppSugestao
    {

        InterfaceSugestao InterfaceSugestao;


        public AppSugestao(InterfaceSugestao interfaceSugestao)
        {
            InterfaceSugestao = interfaceSugestao;
        }

        public void Add(Sugestao Objeto)
        {
            InterfaceSugestao.Add(Objeto);
        }

        public void Delete(Sugestao Objeto)
        {
            InterfaceSugestao.Delete(Objeto);
        }

        public Sugestao GetEntityById(int Id)
        {
            return InterfaceSugestao.GetEntityById(Id);
        }

        public List<Sugestao> List()
        {
            return InterfaceSugestao.List();
        }

        public void Update(Sugestao Objeto)
        {
            InterfaceSugestao.Update(Objeto);
        }

    }
}
