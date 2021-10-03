using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Applications.App;
using Applications.Interfaces;
using Entities.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebFinanceiro.Controllers
{
    [Authorize]
    public class CategoriaController : Controller
    {

        private readonly InterfaceAppCategoria _AppCategoria;
        private readonly InterfaceAppSistemaFinanceiro _sistemaFinanceiro;

        public CategoriaController(InterfaceAppCategoria AppCategoria, InterfaceAppSistemaFinanceiro sistemaFinanceiro)
        {
            _AppCategoria = AppCategoria;
            _sistemaFinanceiro = sistemaFinanceiro;
        }

        // GET: Categoria
        public ActionResult Index()
        {
            return View(_AppCategoria.ListarCategoriasUsuario(User.Identity.Name));
        }

        // GET: Categoria/Details/5
        public ActionResult Details(int id)
        {
            ViewData["IdSistema"] = new SelectList(_sistemaFinanceiro.ListaSistemasUsuario(User.Identity.Name), "Id", "Nome");

            return View(_AppCategoria.GetEntityById(id));
        }

        // GET: Categoria/Create
        public ActionResult Create()
        {

            ViewData["IdSistema"] = new SelectList(_sistemaFinanceiro.ListaSistemasUsuario(User.Identity.Name), "Id", "Nome");
            return View(new Categoria());
        }

        // POST: Categoria/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria categoria)
        {
            try
            {
                _AppCategoria.AdicionarCategoria(categoria);

                if (categoria.notificacoes.Any())
                {
                    foreach (var item in categoria.notificacoes)
                    {
                        ModelState.AddModelError(item.NomePropriedade, item.mensagem);
                    }

                    return View("Create", categoria);
                }

               

                //return RedirectToAction(nameof(Index));
            }
            catch (Exception ERRO)
            {
                return View(categoria);
            }

            ViewData["IdSistema"] = new SelectList(_sistemaFinanceiro.ListaSistemasUsuario(User.Identity.Name), "Id", "Nome");

            return RedirectToAction("Edit", new { id = categoria.Id });
        }

        // GET: Categoria/Edit/5
        public ActionResult Edit(int id)
        {
            ViewData["IdSistema"] = new SelectList(_sistemaFinanceiro.ListaSistemasUsuario(User.Identity.Name), "Id", "Nome");

            return View(_AppCategoria.GetEntityById(id));
        }

        // POST: Categoria/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Categoria categoria)
        {
            ViewData["IdSistema"] = new SelectList(_sistemaFinanceiro.ListaSistemasUsuario(User.Identity.Name), "Id", "Nome");
            try
            {
                _AppCategoria.AtualizarCategoria(categoria);

                if (categoria.notificacoes.Any())
                {
                    foreach (var item in categoria.notificacoes)
                    {
                        ModelState.AddModelError(item.NomePropriedade, item.mensagem);
                    }
                    return View("Edit", categoria);
                }

                //  var sistemasUsuario = _sistemaFinanceiro.ListaSistemasUsuario(User.Identity.Name);

                // return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(categoria);
            }

            return RedirectToAction("Edit", new { id = categoria.Id });
        }

        // GET: Categoria/Delete/5
        public ActionResult Delete(int id)
        {
            ViewData["IdSistema"] = new SelectList(_sistemaFinanceiro.ListaSistemasUsuario(User.Identity.Name), "Id", "Nome");
            return View(_AppCategoria.GetEntityById(id));
        }

        // POST: Categoria/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Categoria categoria)
        {
            try
            {
                _AppCategoria.Delete(categoria);

                if (categoria.notificacoes.Any())
                {
                    foreach (var item in categoria.notificacoes)
                    {
                        ModelState.AddModelError(item.NomePropriedade, item.mensagem);
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(categoria);
            }


        }
    }
}