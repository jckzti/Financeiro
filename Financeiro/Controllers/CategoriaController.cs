using Applications.App;
using Entities.Entidades;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Financeiro.Controllers
{
    public class CategoriaController : Controller
    {

        private readonly AppCategoria _AppCategoria;

        public CategoriaController(AppCategoria AppCategoria)
        {
            _AppCategoria = AppCategoria;
        }

        // GET: Categoria
        public ActionResult Index()
        {
            return View(_AppCategoria.List());
        }

        // GET: Categoria/Details/5
        public ActionResult Details(int id)
        {
            return View(_AppCategoria.GetEntityById(id));
        }

        // GET: Categoria/Create
        public ActionResult Create()
        {
            return View(new Categoria());
        }

        // POST: Categoria/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria categoria)
        {
            try
            {
                _AppCategoria.Add(categoria);

                if (categoria.notificacoes.Any())
                {
                    foreach (var item in categoria.notificacoes)
                    {
                        ModelState.AddModelError(item.NomePropriedade, item.mensagem);
                    }
                }

                //return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(categoria);
            }


            return View(categoria);
        }

        // GET: Categoria/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_AppCategoria.GetEntityById(id));
        }

        // POST: Categoria/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Categoria categoria)
        {
            try
            {
                _AppCategoria.Update(categoria);

                if (categoria.notificacoes.Any())
                {
                    foreach (var item in categoria.notificacoes)
                    {
                        ModelState.AddModelError(item.NomePropriedade, item.mensagem);
                    }
                }

                // return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(categoria);
            }

            return View(categoria);
        }

        // GET: Categoria/Delete/5
        public ActionResult Delete(int id)
        {
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

                // return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(categoria);
            }

            return View(categoria);
        }
    }
}