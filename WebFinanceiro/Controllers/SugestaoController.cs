using Applications.Interfaces;
using Entities.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;

namespace WebFinanceiro.Controllers
{
    [Authorize]
    public class SugestaoController : Controller
    {

        private readonly InterfaceAppSugestao _AppSugestao;


        public SugestaoController(InterfaceAppSugestao AppSugestao)
        {
            _AppSugestao = AppSugestao;

        }

        // GET: Sugestao
        public ActionResult Index()
        {
            return View(_AppSugestao.List());
        }

        // GET: Sugestao/Details/5
        public ActionResult Details(int id)
        {

            return View(_AppSugestao.GetEntityById(id));
        }

        // GET: Sugestao/Create
        public ActionResult Create()
        {
            return View(new Sugestao());
        }

        // POST: Sugestao/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Sugestao Sugestao)
        {
            try
            {

                // E-mail Usuário Logado
                Sugestao.EmailUsuario = User.Identity.Name;

                _AppSugestao.Add(Sugestao);

                if (Sugestao.notificacoes.Any())
                {
                    foreach (var item in Sugestao.notificacoes)
                    {
                        ModelState.AddModelError(item.NomePropriedade, item.mensagem);
                    }

                    return View("Create", Sugestao);
                }


                //return RedirectToAction(nameof(Index));
            }
            catch (Exception ERRO)
            {
                return View(Sugestao);
            }


            return RedirectToAction("Index", "Home");
        }

        // GET: Sugestao/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_AppSugestao.GetEntityById(id));
        }

        // POST: Sugestao/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Sugestao Sugestao)
        {

            try
            {
                _AppSugestao.Update(Sugestao);

                if (Sugestao.notificacoes.Any())
                {
                    foreach (var item in Sugestao.notificacoes)
                    {
                        ModelState.AddModelError(item.NomePropriedade, item.mensagem);
                    }
                    return View("Edit", Sugestao);
                }


            }
            catch
            {
                return View(Sugestao);
            }

            return RedirectToAction("Edit", new { id = Sugestao.Id });
        }

        // GET: Sugestao/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_AppSugestao.GetEntityById(id));
        }

        // POST: Sugestao/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Sugestao Sugestao)
        {
            try
            {
                _AppSugestao.Delete(Sugestao);

                if (Sugestao.notificacoes.Any())
                {
                    foreach (var item in Sugestao.notificacoes)
                    {
                        ModelState.AddModelError(item.NomePropriedade, item.mensagem);
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(Sugestao);
            }


        }
    }
}