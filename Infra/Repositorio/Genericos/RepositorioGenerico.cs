using Domain.Interfaces.Generics;
using Infra.Configuracao;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Infra.Repositorio.Genericos
{
    public class RepositorioGenerico<T> : InterfaceGeneric<T>, IDisposable where T : class
    {

        private readonly DbContextOptions<Contexto> _OptionsBuilder;

        public RepositorioGenerico()
        {
            _OptionsBuilder = new DbContextOptions<Contexto>();
        }



        public void Add(T Objeto)
        {
            using (var banco = new Contexto(_OptionsBuilder))
            {
                banco.Set<T>().Add(Objeto);
                banco.SaveChanges();
            }
        }

        public void Delete(T Objeto)
        {
            using (var banco = new Contexto(_OptionsBuilder))
            {
                banco.Set<T>().Remove(Objeto);
                banco.SaveChangesAsync();
            }
        }

        public T GetEntityById(int Id)
        {
            using (var banco = new Contexto(_OptionsBuilder))
            {
                var objeto = banco.Set<T>().Find(Id);

                banco.Database.CloseConnection();

                return objeto;
            }
        }

        public List<T> List()
        {
            using (var banco = new Contexto(_OptionsBuilder))
            {
                return banco.Set<T>().AsNoTracking().ToList();

            }
        }

        public void Update(T Objeto)
        {
            using (var banco = new Contexto(_OptionsBuilder))
            {
                banco.Set<T>().Update(Objeto);
                banco.SaveChangesAsync();
            }
        }

        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.
                //
            }

            disposed = true;
        }

        ~RepositorioGenerico()
        {
            Dispose(false);
        }
    }
}
