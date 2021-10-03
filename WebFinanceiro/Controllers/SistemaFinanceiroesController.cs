using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Entities.Entidades;
using WebFinanceiro.Data;
using Applications.App;
using Applications.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace WebFinanceiro.Controllers
{
    [Authorize]
    public class SistemaFinanceiroesController : Controller
    {

        private readonly InterfaceAppSistemaFinanceiro _appSistemaFinanceiro;
        private readonly InterfaceAppUsuarioSistemaFinanceiro _appAppUsuarioSistemaFinanceiro;

        public SistemaFinanceiroesController(InterfaceAppSistemaFinanceiro appSistemaFinanceiro,
            InterfaceAppUsuarioSistemaFinanceiro appAppUsuarioSistemaFinanceiro)
        {
            _appSistemaFinanceiro = appSistemaFinanceiro;
            _appAppUsuarioSistemaFinanceiro = appAppUsuarioSistemaFinanceiro;
        }

        // GET: SistemaFinanceiroes
        public async Task<IActionResult> Index()
        {
            return View(_appSistemaFinanceiro.ListaSistemasUsuario(User.Identity.Name));
        }

        // GET: SistemaFinanceiroes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sistemaFinanceiro = _appSistemaFinanceiro.GetEntityById((int)id);
            if (sistemaFinanceiro == null)
            {
                return NotFound();
            }

            return View(sistemaFinanceiro);
        }

        // GET: SistemaFinanceiroes/Create
        public IActionResult Create()
        {
            return View(new SistemaFinanceiro());
        }



        // POST: SistemaFinanceiroes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SistemaFinanceiro sistemaFinanceiro)
        {
            try
            {
           
                _appSistemaFinanceiro.AdicionarSistemaFinanceiro(sistemaFinanceiro);

                if (sistemaFinanceiro.notificacoes.Any())
                {
                    foreach (var item in sistemaFinanceiro.notificacoes)
                    {
                        ModelState.AddModelError(item.NomePropriedade, item.mensagem);
                    }

                    return View("Create", sistemaFinanceiro);
                }
                else
                {
                    // Adcionar Junto o usuário Adm do Financeiro
                    _appAppUsuarioSistemaFinanceiro.Add(new UsuarioSistemaFinanceiro
                    {
                        Administrador = true,
                        EmailUsuario = User.Identity.Name.Trim(),
                        IdSistema = sistemaFinanceiro.Id,
                        SistemaAtual = true,

                    });
                }

            }
            catch (Exception ERRO)
            {
                return View(sistemaFinanceiro);
            }
            return RedirectToAction("Edit", new { id = sistemaFinanceiro.Id });
        }

        // GET: SistemaFinanceiroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sistemaFinanceiro = _appSistemaFinanceiro.GetEntityById((int)id);
            if (sistemaFinanceiro == null)
            {
                return NotFound();
            }
            return View(sistemaFinanceiro);
        }

        // POST: SistemaFinanceiroes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SistemaFinanceiro sistemaFinanceiro)
        {
            if (id != sistemaFinanceiro.Id)
            {
                return NotFound();
            }

            try
            {


                _appSistemaFinanceiro.AtualizarSistemaFinanceiro(sistemaFinanceiro);

                if (sistemaFinanceiro.notificacoes.Any())
                {
                    foreach (var item in sistemaFinanceiro.notificacoes)
                    {
                        ModelState.AddModelError(item.NomePropriedade, item.mensagem);
                    }

                    return View("Edit",sistemaFinanceiro);
                }


            }
            catch (Exception ERRO)
            {
                return View(sistemaFinanceiro);
            }
            return RedirectToAction("Edit", new { id = sistemaFinanceiro.Id });

        }

        // GET: SistemaFinanceiroes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sistemaFinanceiro = _appSistemaFinanceiro.GetEntityById((int)id);
            if (sistemaFinanceiro == null)
            {
                return NotFound();
            }

            return View(sistemaFinanceiro);
        }

        // POST: SistemaFinanceiroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var sistemaFinanceiro = _appSistemaFinanceiro.GetEntityById((int)id);
            //_appSistemaFinanceiro.Delete(sistemaFinanceiro);

            return RedirectToAction(nameof(Index));
        }

        private bool SistemaFinanceiroExists(int id)
        {
            return _appSistemaFinanceiro.GetEntityById((int)id) != null;
        }
    }
}
