using ProjetoOdontoClin.Dados;
using ProjetoOdontoClin.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoOdontoClin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult listarLogin()
        {
            ModelState.Clear();
            return View(ac.BuscarLogin());
        }

        public ActionResult cadLogin()
        {
            return View();
        }
        acoesLogin ac = new acoesLogin();

        public ActionResult confCadLogin(modelLogin m)
        {

            ac.inserirLogin(m);
            ViewBag.mensagem = "Cadastro Realizado com sucesso";
            return View();
        }

        public ActionResult consLogin()
        {
            GridView dgv = new GridView(); // Instância para a tabela 
            dgv.DataSource = ac.selecionarLogin(); //Atribuir ao grid o resultado da consulta 
            dgv.DataBind(); //Confirmação do Grid 
            StringWriter sw = new StringWriter(); //Comando para construção do Grid na tela 
            HtmlTextWriter htw = new HtmlTextWriter(sw); //Comando para construção do Grid na tela 
            dgv.RenderControl(htw); //Comando para construção do Grid na tela 
            ViewBag.GridViewString = sw.ToString(); //Atribuição para a construção do Grid na tela 
            return View();
        }

        public ActionResult consBuscaLogin()
        {
            GridView dgv = new GridView(); // Instância para a tabela 
            dgv.DataSource = ac.selecionarLogin(); //Atribuir ao grid o resultado da consulta 
            dgv.DataBind(); //Confirmação do Grid 
            StringWriter sw = new StringWriter(); //Comando para construção do Grid na tela 
            HtmlTextWriter htw = new HtmlTextWriter(sw); //Comando para construção do Grid na tela 
            dgv.RenderControl(htw); //Comando para construção do Grid na tela 
            ViewBag.GridViewString = sw.ToString(); //Atribuição para a construção do Grid na tela 
            return View();
        }

        [HttpPost]
        public ActionResult consBuscaLogin(modelLogin m)
        {
            GridView dgv = new GridView(); // Instância para a tabela 
            dgv.DataSource = ac.selecionarBuscaLogin(m); //Atribuir ao grid o resultado da consulta 
            dgv.DataBind(); //Confirmação do Grid 
            StringWriter sw = new StringWriter(); //Comando para construção do Grid na tela 
            HtmlTextWriter htw = new HtmlTextWriter(sw); //Comando para construção do Grid na tela 
            dgv.RenderControl(htw); //Comando para construção do Grid na tela 
            ViewBag.GridViewString = sw.ToString(); //Atribuição para a construção do Grid na tela 
            return View();
        }


    }
}