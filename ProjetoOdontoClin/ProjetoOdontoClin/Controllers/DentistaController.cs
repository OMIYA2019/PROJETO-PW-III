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
    public class DentistaController : Controller
    {
        // GET: Dentista
        public ActionResult Index()
        {
            return View();
        }

        acoesDentista ac = new acoesDentista();

        public ActionResult cadDentista()
        {
            return View();
        }

        public ActionResult listarDentista()
        {
            ModelState.Clear();
            return View(ac.BuscaDentista());
        }

        public ActionResult confCadDentista(modelDentista m)
        {

            ac.inserirDentista(m);
            ViewBag.mensagem = "Cadastro Realizado com sucesso";
            return View();
        }

        public ActionResult consDentista()
        {
            GridView dgv = new GridView(); // Instância para a tabela 
            dgv.DataSource = ac.selecionarDentista(); //Atribuir ao grid o resultado da consulta 
            dgv.DataBind(); //Confirmação do Grid 
            StringWriter sw = new StringWriter(); //Comando para construção do Grid na tela 
            HtmlTextWriter htw = new HtmlTextWriter(sw); //Comando para construção do Grid na tela 
            dgv.RenderControl(htw); //Comando para construção do Grid na tela 
            ViewBag.GridViewString = sw.ToString(); //Atribuição para a construção do Grid na tela 
            return View();
        }

        public ActionResult consBuscaDentista()
        {
            GridView dgv = new GridView(); // Instância para a tabela 
            dgv.DataSource = ac.selecionarDentista(); //Atribuir ao grid o resultado da consulta 
            dgv.DataBind(); //Confirmação do Grid 
            StringWriter sw = new StringWriter(); //Comando para construção do Grid na tela 
            HtmlTextWriter htw = new HtmlTextWriter(sw); //Comando para construção do Grid na tela 
            dgv.RenderControl(htw); //Comando para construção do Grid na tela 
            ViewBag.GridViewString = sw.ToString(); //Atribuição para a construção do Grid na tela 
            return View();
        }

        [HttpPost]
        public ActionResult consBuscaDentista(modelDentista m)
        {
            GridView dgv = new GridView(); // Instância para a tabela 
            dgv.DataSource = ac.selecionarBuscaDentista(m); //Atribuir ao grid o resultado da consulta 
            dgv.DataBind(); //Confirmação do Grid 
            StringWriter sw = new StringWriter(); //Comando para construção do Grid na tela 
            HtmlTextWriter htw = new HtmlTextWriter(sw); //Comando para construção do Grid na tela 
            dgv.RenderControl(htw); //Comando para construção do Grid na tela 
            ViewBag.GridViewString = sw.ToString(); //Atribuição para a construção do Grid na tela 
            return View();
        }



    }
}