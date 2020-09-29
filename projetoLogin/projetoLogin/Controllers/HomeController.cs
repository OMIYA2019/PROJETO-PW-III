using projetoLogin.Dados;
using projetoLogin.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace projetoLogin.Controllers
{
    public class HomeController : Controller
    {
        clAcoesLogin ac = new clAcoesLogin();

        public ActionResult Index(clLogin verLogin)
        {
            ac.TestarUsuario(verLogin);

            if (verLogin.usuario != null && verLogin.senha != null)
            {
                FormsAuthentication.SetAuthCookie(verLogin.usuario, false);
                Session["usuarioLogado"] = verLogin.usuario.ToString();
                Session["senhaLogado"] = verLogin.senha.ToString();
                if (verLogin.tipo == "1")
                {
                    Session["tipoLogado1"] = verLogin.tipo.ToString();
                }
                else
                {
                    Session["tipoLogado2"] = verLogin.tipo.ToString();
                }
                return RedirectToAction("About", "Home");
            }
            else
            {
                return View();
            }

        }

        public ActionResult semAcesso()
        {
            return View();
        }

        public ActionResult logout()
        {
            Session["usuarioLogado"] = null;
            Session["senhaLogado"] = null;
            Session["tipoLogado1"] = null;
            Session["tipoLogado2"] = null;
            return RedirectToAction("Index", "Home");
        }


        public ActionResult About()
        {
           if ((Session["usuarioLogado"] == null) || (Session["senhaLogado"] == null))
            {
                return RedirectToAction("semAcesso", "Home");      
            }
            else
            {
                return View();
            }
        }

        public ActionResult Contact()
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
                    return View();
                }
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

        public ActionResult confCadLogin(clLogin logar)
        {
           if (logar.senha == logar.confSenha)
            {
                logar.tipo = Request["tiposUsu"];
                if (logar.tipo == "")
                {
                    ViewBag.mensagem = "Erro! Tipo de usuario não escolhido";
                    return View();
                }
                else
                {
                    ac.inserirLogin(logar);
                    ViewBag.mensagem = "Cadastro efetuado com sucesso";
                    return View();
                }
            }
           else
            {
                ViewBag.mensagem = "Erro! As senhas não conferem!";
                return View();
            }
        }

        public ActionResult listarUsuarios()
        {
            GridView dgv = new GridView();// Instância para a tabela

            dgv.DataSource = ac.selecionarUsuario();//Atribuir ao grid o resultado da consulta

            dgv.DataBind();//Confirmação do Grid

            StringWriter sw = new StringWriter();//Comando para construção do Grid na Tela

            HtmlTextWriter htw = new HtmlTextWriter(sw);//Comando para construção do Grid na Tela

            dgv.RenderControl(htw);//Comando para construção do Grid na tela

            ViewBag.GridViewString = sw.ToString(); //Comando para construção do Grid na tela

            return View();
        }

        public ActionResult filtrarUsuarios(clLogin cm)
        {
            if (cm.usuario != null)
            {

                GridView dgv = new GridView(); // Instância para a tabela 

                dgv.DataSource = ac.buscarUsuario(cm); //Atribuir ao grid o resultado da consulta 

                dgv.DataBind(); //Confirmação do Grid 

                StringWriter sw = new StringWriter(); //Comando para construção do Grid na tela 

                HtmlTextWriter htw = new HtmlTextWriter(sw); //Comando para construção do Grid na tela 

                dgv.RenderControl(htw); //Comando para construção do Grid na tela 

                ViewBag.GridViewString = sw.ToString(); //Atribuição para a construção do Grid na tela 

                return View();
            }
            else
            {
                return View();
            }
        }



    }
}