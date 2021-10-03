using System;
using System.Collections.Generic;
using System.Text;

namespace Applications.Interfaces
{
    public interface InterfaceGenericaApp<T> where T : class
    {
        void Add(T Objeto);
        void Update(T Objeto);
        void Delete(T Objeto);
        T GetEntityById(int Id);
        List<T> List();
    }
}
