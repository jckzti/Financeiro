using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Entities.Entidades;
using WebFinanceiro.Models;
using Applications.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Entities.Enums;

namespace WebFinanceiro.Controllers
{
    [Authorize]
    //[LogAction]

    public class ComprasController : Controller
    {

        private readonly InterfaceAppCompra _AppCompra;
        private readonly InterfaceAppCategoria _AppCategoria;



        public ComprasController(InterfaceAppCompra AppCompra, InterfaceAppCategoria AppCategoria)
        {
            _AppCompra = AppCompra;
            _AppCategoria = AppCategoria;

        }

        // GET: Compra
        public ActionResult Index()
        {
            return View(_AppCompra.ListarComprasUsuario(User.Identity.Name));
         
        }

        // GET: Compra/Details/5
        public ActionResult Details(int id)
        {
            var compra = _AppCompra.GetEntityById(id);
            var categoria = _AppCategoria.GetEntityById(compra.IdCategoria);
            compra.Categoria = categoria;

            return View(compra);
        }

        // GET: Compra/Create
        public ActionResult Create()
        {
            ViewData["IdCategoria"] = new SelectList(_AppCategoria.ListarCategoriasUsuario(User.Identity.Name), "Id", "Nome");
            return View(new Compra());
        }

        // POST: Compra/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Compra Compra)
        {
            ViewData["IdCategoria"] = new SelectList(_AppCategoria.ListarCategoriasUsuario(User.Identity.Name), "Id", "Nome", Compra.IdCategoria);
            try
            {
              
                _AppCompra.AdicionarCompra(Compra);

                if (Compra.notificacoes.Any())
                {
                    foreach (var item in Compra.notificacoes)
                    {
                        ModelState.AddModelError(item.NomePropriedade, item.mensagem);
                    }

                    return View("Create", Compra);
                }

            }
            catch (Exception ERRO)
            {
                return View(Compra);
            }

            return RedirectToAction("Index", "Compras");
        }

        // GET: Compra/Edit/5
        public ActionResult Edit(int id)
        {
            var compra = _AppCompra.GetEntityById(id);
            var categoria = _AppCategoria.GetEntityById(compra.IdCategoria);
            compra.Categoria = categoria;

            ViewData["IdCategoria"] = new SelectList(_AppCategoria.ListarCategoriasUsuario(User.Identity.Name), "Id", "Nome", compra.IdCategoria);
            return View(compra);
        }

        // POST: Compra/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Compra Compra)
        {

            ViewData["IdCategoria"] = new SelectList(_AppCategoria.ListarCategoriasUsuario(User.Identity.Name), "Id", "Nome", Compra.IdCategoria);

            try
            {
                _AppCompra.AtualizarCompra(Compra);

                if (Compra.notificacoes.Any())
                {
                    foreach (var item in Compra.notificacoes)
                    {
                        ModelState.AddModelError(item.NomePropriedade, item.mensagem);
                    }
                    return View("Edit", Compra);
                }


            }
            catch
            {
                return View(Compra);
            }

            return RedirectToAction("Edit", new { id = Compra.Id });
        }

        // GET: Compra/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_AppCompra.GetEntityById(id));
        }

        // POST: Compra/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Compra Compra)
        {
            try
            {
                _AppCompra.Delete(Compra);

                if (Compra.notificacoes.Any())
                {
                    foreach (var item in Compra.notificacoes)
                    {
                        ModelState.AddModelError(item.NomePropriedade, item.mensagem);
                    }
                }

                return RedirectToAction("Index", "Compras");
            }
            catch
            {
                //return View(Compra);
                return RedirectToAction("Index", "Compras");
            }

        }




    }
}
