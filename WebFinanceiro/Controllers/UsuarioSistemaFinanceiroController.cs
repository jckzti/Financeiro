using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Applications.Interfaces;
using Entities.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace WebFinanceiro.Controllers
{
    public class UsuarioSistemaFinanceiroController : Controller
    {

        private readonly InterfaceAppUsuarioSistemaFinanceiro _interfaceAppUsuarioSistemaFinanceiro;

        public UsuarioSistemaFinanceiroController(InterfaceAppUsuarioSistemaFinanceiro interfaceAppUsuarioSistemaFinanceiro)
        {
            _interfaceAppUsuarioSistemaFinanceiro = interfaceAppUsuarioSistemaFinanceiro;
        }


        [HttpGet("UsuarioSistemaFinanceiro/ListaUsuariosSistema")]
        public async Task<JsonResult> ListaUsuariosSistema(int idSistema)
        {
            var usuarios = _interfaceAppUsuarioSistemaFinanceiro.ListarUsuariosSistema(idSistema)
                .Select(u => u.EmailUsuario).ToList();

            return Json(new { usuarios = usuarios });

        }

        [HttpPost("UsuarioSistemaFinanceiro/AdicionarUsuaio")]
        public async Task<JsonResult> AdicionarUsuaio(int idSistema, string emailUsuario)
        {

            if (string.IsNullOrWhiteSpace(emailUsuario))
                return Json(new { sucesso = "Digite um e-mail valido!" });

            try
            {
                _interfaceAppUsuarioSistemaFinanceiro.Add(new UsuarioSistemaFinanceiro
                {
                    IdSistema = idSistema,
                    EmailUsuario = emailUsuario,
                    Administrador = false,
                    SistemaAtual = true,

                });
                return Json(new { sucesso = "OK" });
            }
            catch (Exception)
            {

                return Json(new { sucesso = "Ocorreu um erro tente novamente mais tarde!" });
            }


        }


        [HttpPost("UsuarioSistemaFinanceiro/RemoverUsuario")]
        public async Task<JsonResult> RemoverUsuario(int idSistema, string emailUsuario)
        {

            try
            {

                var usuarioSistema = _interfaceAppUsuarioSistemaFinanceiro.ListarUsuariosSistema(idSistema)
                    .Where(u => u.EmailUsuario == emailUsuario).ToList();

                if (usuarioSistema != null)
                {
                    _interfaceAppUsuarioSistemaFinanceiro.RemoveUsuarios(usuarioSistema);
                }

                return Json(new { sucesso = "OK" });
            }
            catch (Exception ex)
            {

                return Json(new { sucesso = "Ocorreu um erro tente novamente mais tarde!" });
            }


        }


    }
}