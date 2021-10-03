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
    public class DespesasController : Controller
    {

        private readonly InterfaceAppDespesa _InterfaceAppDespesa;
        private readonly InterfaceAppCategoria _AppCategoria;

        public DespesasController(InterfaceAppDespesa InterfaceAppDespesa, InterfaceAppCategoria AppCategoria)
        {
            _AppCategoria = AppCategoria;
            _InterfaceAppDespesa = InterfaceAppDespesa;
        }

        // GET: Despesas
        public async Task<IActionResult> Index()
        {
            //var webFinanceiroContext = _InterfaceAppDespesa.Despesa.Include(d => d.Categoria);
            //return View(await webFinanceiroContext.ToListAsync());

            //var dispesas = _InterfaceAppDespesa.List();
            return View(_InterfaceAppDespesa.ListarDespesasUsuario(User.Identity.Name));
        }

        public async Task<IActionResult> DespesasAtrasadas()
        {
            //var webFinanceiroContext = _InterfaceAppDespesa.Despesa.Include(d => d.Categoria);
            //return View(await webFinanceiroContext.ToListAsync());

            //var dispesas = _InterfaceAppDespesa.List();

            var despesasAtrasadas = _InterfaceAppDespesa.ListarDespesasUsuarioNaoPagasMesesAnterior(User.Identity.Name);

            foreach (var item in despesasAtrasadas)
            {
                item.DespesaAntrasada = true;
            }

            return View("Index", despesasAtrasadas);
        }

        // GET: Despesas/Details/5
        public async Task<IActionResult> Details(int? id, bool despesaAntrasada = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var despesa = _InterfaceAppDespesa.GetEntityById((int)id);
            if (despesa == null)
            {
                return NotFound();
            }

            var categoria = _AppCategoria.GetEntityById(despesa.IdCategoria);
            despesa.Categoria = categoria;
            despesa.DespesaAntrasada = despesaAntrasada;

            return View(despesa);
        }

        // GET: Despesas/Create
        public IActionResult Create()
        {
            ViewData["IdCategoria"] = new SelectList(_AppCategoria.ListarCategoriasUsuario(User.Identity.Name), "Id", "Nome");

            CarregaTipoDespesa();
            return View(new Despesa { Pago = false });
        }

        // POST: Despesas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(Despesa despesa)
        {

            ViewData["IdCategoria"] = new SelectList(_AppCategoria.List(), "Id", "Nome", despesa.IdCategoria);

            CarregaTipoDespesa();

            try
            {
                _InterfaceAppDespesa.AdicionarDespesa(despesa);

                if (despesa.notificacoes.Any())
                {
                    foreach (var item in despesa.notificacoes)
                    {
                        ModelState.AddModelError(item.NomePropriedade, item.mensagem);
                    }

                    return View("Create", despesa);
                }

            }
            catch (Exception ERRO)
            {
                return View(despesa);
            }


            return RedirectToAction("Edit", new { id = despesa.Id });


        }


        // GET: Despesas/Edit/5
        public async Task<IActionResult> Edit(int? id, bool despesaAntrasada = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var despesa = await _context.Despesa.FindAsync(id);
            var despesa = _InterfaceAppDespesa.GetEntityById((int)id);
            if (despesa == null)
            {
                return NotFound();
            }
            ViewData["IdCategoria"] = new SelectList(_AppCategoria.ListarCategoriasUsuario(User.Identity.Name), "Id", "Nome", despesa.IdCategoria);

            CarregaTipoDespesa();

            despesa.DespesaAntrasada = despesaAntrasada;
            return View(despesa);
        }

        // POST: Despesas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Despesa despesa)
        {
            if (id != despesa.Id)
            {
                return NotFound();
            }

            ViewData["IdCategoria"] = new SelectList(_AppCategoria.ListarCategoriasUsuario(User.Identity.Name), "Id", "Nome", despesa.IdCategoria);

            CarregaTipoDespesa();

            try
            {

                if (despesa.Id > 0)
                {

                    _InterfaceAppDespesa.AtualizarDespesa(despesa);
                }
                else
                    _InterfaceAppDespesa.AdicionarDespesa(despesa);

                if (despesa.notificacoes.Any())
                {
                    foreach (var item in despesa.notificacoes)
                    {
                        ModelState.AddModelError(item.NomePropriedade, item.mensagem);
                    }

                    return View("Edit", despesa);
                }

            }
            catch (Exception ex)
            {
                return View(despesa);
            }

            return RedirectToAction("Edit", new { id = despesa.Id, despesaAntrasada = despesa.DespesaAntrasada });


        }

        // GET: Despesas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var despesa = await _context.Despesa
            //    .Include(d => d.Categoria)
            //    .FirstOrDefaultAsync(m => m.Id == id);

            var despesa = _InterfaceAppDespesa.GetEntityById((int)id);
            if (despesa == null)
            {
                return NotFound();
            }

            return View(despesa);
        }

        // POST: Despesas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var despesa = _InterfaceAppDespesa.GetEntityById((int)id);

                _InterfaceAppDespesa.Delete(despesa);
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Index));
            }


            return RedirectToAction(nameof(Index));
        }

        private bool DespesaExists(int id)
        {
            // return _context.Despesa.Any(e => e.Id == id);
            return _InterfaceAppDespesa.GetEntityById((int)id) != null;
        }


        [HttpGet("Despesas/CarregaGraficos")]
        public async Task<JsonResult> CarregaGraficos()
        {
            try
            {
                var despesasUsuario = _InterfaceAppDespesa.ListarDespesasUsuario(User.Identity.Name);
                // .Where(m => m.Mes == DateTime.Now.Month);

                var despesas_naoPagasMesesAnteriores = _InterfaceAppDespesa.ListarDespesasUsuarioNaoPagasMesesAnterior(User.Identity.Name).Sum(d => d.Valor);

                var despesas_pagas = despesasUsuario.Where(d => d.Pago && d.TipoDespesa == EnumTipoDespesa.Contas).Sum(d => d.Valor);

                var despesas_pendentes = despesasUsuario.Where(d => !d.Pago && d.TipoDespesa == EnumTipoDespesa.Contas).Sum(d => d.Valor);

                var investimentos = despesasUsuario.Where(d => d.TipoDespesa == EnumTipoDespesa.Investimento).Sum(d => d.Valor);

                return Json(new
                {
                    sucesso = "OK",
                    despesas_pagas = despesas_pagas,
                    despesas_pendentes = despesas_pendentes,
                    despesas_naoPagasMesesAnteriores = despesas_naoPagasMesesAnteriores,
                    investimentos = investimentos
                });

            }
            catch (Exception)
            {
                return Json(new { sucesso = "ERRO", despesas_pagas = 0, despesas_pendentes = 0, despesas_naoPagasMesesAnteriores = 0, investimentos = 0 });
            }



        }


        private void CarregaTipoDespesa()
        {
            var listaTipoDespesa = new List<SelectListItem>();
            listaTipoDespesa.Add(new SelectListItem { Text = "Contas", Value = "1" });
            listaTipoDespesa.Add(new SelectListItem { Text = "Investimento", Value = "2" });
            ViewData["TipoDespesa"] = listaTipoDespesa;
        }

    }
}
