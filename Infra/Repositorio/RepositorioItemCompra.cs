using Domain.Interfaces.ICompra;
using Entities.Entidades;
using Infra.Configuracao;
using Infra.Repositorio.Genericos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Infra.Repositorio
{
    public class RepositorioItemCompra : RepositorioGenerico<ItemCompra>, InterfaceItemCompra
    {
        private readonly DbContextOptions<Contexto> _OptionsBuilder;

        public RepositorioItemCompra()
        {
            _OptionsBuilder = new DbContextOptions<Contexto>();
        }

        public void AtualizarItemCompra(ItemCompra ItemCompra)
        {
            using (var banco = new Contexto(_OptionsBuilder))
            {
                var itemCompra = banco.ItemCompra.Find(ItemCompra.Id);
                itemCompra.Comprado = ItemCompra.Comprado;
                banco.ItemCompra.Update(itemCompra);
                banco.SaveChanges();
            }
        }

        public void DeletarItemPorId(int Id)
        {
            using (var banco = new Contexto(_OptionsBuilder))
            {
                var itemCompra = banco.ItemCompra.Find(Id);      
                banco.ItemCompra.Remove(itemCompra);
                banco.SaveChanges();
            }
        }

        public IList<ItemCompra> ListarItensDaCompra(int IdCompra)
        {
            using (var banco = new Contexto(_OptionsBuilder))
            {
                return (from s in banco.SistemaFinanceiro
                        join c in banco.Categoria on s.Id equals c.IdSistema
                        join us in banco.UsuarioSistemaFinanceiro on s.Id equals us.IdSistema
                        join compra in banco.Compra on c.Id equals compra.IdCategoria
                        join item in banco.ItemCompra on compra.Id equals item.IdCompra
                        where compra.Id == IdCompra
                        select item).AsNoTracking().Distinct().ToList();
            }
        }
    }
}
