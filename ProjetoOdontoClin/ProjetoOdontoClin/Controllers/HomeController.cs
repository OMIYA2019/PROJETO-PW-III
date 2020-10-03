using ProjetoOdontoClin.Dados;
using ProjetoOdontoClin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ProjetoOdontoClin.Controllers
{
    public class HomeController : Controller
    {
        acoesLogin acLg = new acoesLogin();

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(modelLogin verLogin)
        {
            acLg.TestarUsuario(verLogin);

            if (verLogin.usuario != null && verLogin.senha != null)
            {
                FormsAuthentication.SetAuthCookie(verLogin.usuario, false);
                Session["usuarioLogado"] = verLogin.usuario.ToString();
                Session["senhaLogado"] = verLogin.senha.ToString();
                if (verLogin.tipo == "1")
                {
                    Session["tipoLogado1"] = verLogin.tipo.ToString(); //=1;
                }
                else
                {
                    Session["tipoLogado2"] = verLogin.tipo.ToString();//=2
                }
                return RedirectToAction("principal", "Home");
            }
            else
            {
                ViewBag.msgLogar = "Usuário não encontrado. Verifique o nome do usuário e a senha";
                return View();
            }
        }
        public ActionResult principal()
        {
            if ((Session["usuarioLogado"] == null) || (Session["senhaLogado"] == null))

            {
                return RedirectToAction("semAcesso", "");
            }
            else
            {
                ViewBag.usuarioLog = Session["usuarioLogado"];//Atribuir o nome do usuario a uma variavel
                return View();
            }
        }

        public ActionResult cadLogin()
        {
            if ((Session["usuarioLogado"] == null) || (Session["senhaLogado"] == null))

            {
                return RedirectToAction("semAcesso", "Home");
            }
            else
            {
                if (Session["tipoLogado1"] == null)
                {
                    return RedirectToAction("semAcesso", "Home");
                }
                else
                {
                    List<string> tipos = new List<string>();
                    tipos.Add("1");
          
                    tipos.Add("2");



                    ViewBag.tiposUsu = new SelectList(tipos);

                    return View();
                }
            }
        }

        [HttpPost]
        public ActionResult cadLogin(modelLogin lg)
        {
            List<string> tipos = new List<string>();
            tipos.Add("1");
            tipos.Add("2");
            ViewBag.tiposUsu = new SelectList(tipos); 
            if (lg.senha == lg.confSenha)
            {
                lg.tipo = Request["tiposUsu"];
                acLg.inserirLogin(lg);
                ViewBag.confCadastro = "Cadastro realizado com sucesso";
                return View();
                // return RedirectToAction("principal", "Home");
            }
            else
            {
                ViewBag.confCadastro = "As senhas digitadas não são iguais";
                return View();
            }
        }
        public ActionResult Logout()
        {
            Session["usuarioLogado"] = null;
            Session["senhaLogado"] = null;
            Session["tipoLogado1"] = null;
            Session["tipoLogado2"] = null;
            return RedirectToAction("Index", "Home");
        }
        public ActionResult semAcesso()
        {
            ViewBag.Message = "Você não pode acessar essa página";

            return View();
        }
    }
}