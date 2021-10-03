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

    public class ItemCompraController : Controller
    {

        private readonly InterfaceAppItemCompra _AppCompraItem;

        private readonly InterfaceAppCompra _AppCompra;

        public ItemCompraController(InterfaceAppItemCompra AppCompraItem, InterfaceAppCompra AppCompra)
        {
            _AppCompraItem = AppCompraItem;
            _AppCompra = AppCompra;

        }

        // GET: Compra
        public ActionResult Index()
        {
            // return View(_InterfaceAppDespesa.ListarDespesasUsuario(User.Identity.Name));
            return View(_AppCompraItem.List());
        }

        // GET: Compra/Details/5
        public ActionResult Details(int id)
        {
            var ItemCompra = _AppCompraItem.GetEntityById(id);
            var compra = _AppCompra.GetEntityById(ItemCompra.IdCompra);
            ItemCompra.Compra = compra;

            return View(ItemCompra);
        }

        // GET: Compra/Create
        public ActionResult Create()
        {
            // ViewData["IdCategoria"] = new SelectList(_AppCompra.ListarCategoriasUsuario(User.Identity.Name), "Id", "Nome");
            return View(new ItemCompra());
        }

        // POST: Compra/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ItemCompra itemCompra)
        {

            //ViewData["IdCategoria"] = new SelectList(_AppCompra.List(), "Id", "Nome", itemCompra.IdCategoria);
            //try
            //{
            //    // E-mail Usuário Logado
            //    var categoria = _AppCompra.GetEntityById(itemCompra.IdCategoria);
            //    itemCompra.Categoria = categoria;

            //    _AppCompraItem.Add(itemCompra);

            //    if (itemCompra.notificacoes.Any())
            //    {
            //        foreach (var item in itemCompra.notificacoes)
            //        {
            //            ModelState.AddModelError(item.NomePropriedade, item.mensagem);
            //        }

            //        return View("Create", itemCompra);
            //    }

            //}
            //catch (Exception ERRO)
            //{
            //    return View(Compra);
            //}

            return RedirectToAction("Index", "Compras");
        }

        // GET: Compra/Edit/5
        public ActionResult Edit(int id)
        {
            //var compra = _AppCompraItem.GetEntityById(id);
            //var categoria = _AppCompra.GetEntityById(compra.IdCategoria);
            //compra.Categoria = categoria;

            //return View(compra);
            return View();
        }

        // POST: Compra/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Compra Compra)
        {

            // ViewData["IdCategoria"] = new SelectList(_AppCompra.ListarCategoriasUsuario(User.Identity.Name), "Id", "Nome", Compra.IdCategoria);

            //try
            //{
            //    _AppCompraItem.Update(Compra);

            //    if (Compra.notificacoes.Any())
            //    {
            //        foreach (var item in Compra.notificacoes)
            //        {
            //            ModelState.AddModelError(item.NomePropriedade, item.mensagem);
            //        }
            //        return View("Edit", Compra);
            //    }


            //}
            //catch
            //{
            //    return View(Compra);
            //}

            return RedirectToAction("Edit", new { id = Compra.Id });
        }

        // GET: Compra/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_AppCompraItem.GetEntityById(id));
        }

        // POST: Compra/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Compra Compra)
        {
            //try
            //{
            //    _AppCompraItem.Delete(Compra);

            //    if (Compra.notificacoes.Any())
            //    {
            //        foreach (var item in Compra.notificacoes)
            //        {
            //            ModelState.AddModelError(item.NomePropriedade, item.mensagem);
            //        }
            //    }

            //    return RedirectToAction("Index", "Compras");
            //}
            //catch
            //{
            //    //return View(Compra);
            //    
            //}
            return RedirectToAction("Index", "Compras");
        }



        [HttpPost("ItemCompra/AtualizaItem")]
        public async Task<JsonResult> AtualizaItem(int id, bool comprado)
        {
            try
            {
                var itemCompra = new ItemCompra { Comprado = comprado, Id = id };

                _AppCompraItem.AtualizarItemCompra(itemCompra);


                return Json(new
                {
                    sucesso = "OK",
                    comprado = comprado
                });

            }
            catch (Exception erro)
            {
                return Json(new { sucesso = "ERRO", comprado = false });
            }

        }

        [HttpPost("ItemCompra/AdicionarItem")]
        public async Task<JsonResult> AdicionarItem(int id, string descricao)
        {
            try
            {
                _AppCompraItem.AdicionarItemCompra(new ItemCompra
                {
                    IdCompra = id,
                    Nome = descricao,
                });

                return Json(new
                {
                    sucesso = "OK",
                });
            }
            catch (Exception erro)
            {
                return Json(new { sucesso = "ERRO" });
            }
        }



        [HttpGet("ItemCompra/CarregaItensCompra")]
        public async Task<JsonResult> CarregaItensCompra(int idCompra)
        {
            try
            {
                var dados = _AppCompraItem.ListarItensDaCompra(idCompra);

                return Json(new
                {
                    sucesso = "OK",
                    dados = dados
                });

            }
            catch (Exception erro)
            {
                return Json(new { sucesso = "ERRO" });
            }

        }


        [HttpPost("ItemCompra/RemoveItem")]
        public async Task<JsonResult> RemoveItem(int id)
        {
            try
            {
                _AppCompraItem.DeletarItemPorId(id);

                return Json(new
                {
                    sucesso = "OK",
                });
            }
            catch (Exception erro)
            {
                return Json(new { sucesso = "ERRO" });
            }
        }


    }
}
