﻿using ProjetoOdontoClin.Dados;
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
    public class PacienteController : Controller
    {
        // GET: Paciente
        public ActionResult Index()
        {
            return View();
        }

        acoesPaciente ac = new acoesPaciente();

        public ActionResult cadPaciente()
        {
            return View();
        }

        public ActionResult listarPaciente()
        {
            ModelState.Clear();
            return View(ac.BuscarPac());
        }



        public ActionResult confCadPaciente(modelPaciente m)
        {

            ac.inserirPaciente(m);
            ViewBag.mensagem = "Cadastro Realizado com sucesso";
            return View();
        }

        public ActionResult consPaciente()
        {
            GridView dgv = new GridView(); // Instância para a tabela 
            dgv.DataSource = ac.selecionarPaciente(); //Atribuir ao grid o resultado da consulta 
            dgv.DataBind(); //Confirmação do Grid 
            StringWriter sw = new StringWriter(); //Comando para construção do Grid na tela 
            HtmlTextWriter htw = new HtmlTextWriter(sw); //Comando para construção do Grid na tela 
            dgv.RenderControl(htw); //Comando para construção do Grid na tela 
            ViewBag.GridViewString = sw.ToString(); //Atribuição para a construção do Grid na tela 
            return View();
        }

        public ActionResult consBuscaPaciente()
        {
            GridView dgv = new GridView(); // Instância para a tabela 
            dgv.DataSource = ac.selecionarPaciente(); //Atribuir ao grid o resultado da consulta 
            dgv.DataBind(); //Confirmação do Grid 
            StringWriter sw = new StringWriter(); //Comando para construção do Grid na tela 
            HtmlTextWriter htw = new HtmlTextWriter(sw); //Comando para construção do Grid na tela 
            dgv.RenderControl(htw); //Comando para construção do Grid na tela 
            ViewBag.GridViewString = sw.ToString(); //Atribuição para a construção do Grid na tela 
            return View();
        }

        [HttpPost]
        public ActionResult consBuscaPaciente(modelPaciente m)
        {
            GridView dgv = new GridView(); // Instância para a tabela 
            dgv.DataSource = ac.selecionarBuscaPaciente(m); //Atribuir ao grid o resultado da consulta 
            dgv.DataBind(); //Confirmação do Grid 
            StringWriter sw = new StringWriter(); //Comando para construção do Grid na tela 
            HtmlTextWriter htw = new HtmlTextWriter(sw); //Comando para construção do Grid na tela 
            dgv.RenderControl(htw); //Comando para construção do Grid na tela 
            ViewBag.GridViewString = sw.ToString(); //Atribuição para a construção do Grid na tela 
            return View();
        }



    }
}