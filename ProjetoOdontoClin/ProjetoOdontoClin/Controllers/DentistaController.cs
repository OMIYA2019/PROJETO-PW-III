using ProjetoOdontoClin.Dados;
using ProjetoOdontoClin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoOdontoClin.Controllers
{
    public class DentistaController : Controller
    {
        // GET: Dentista
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult cadDentista()
        {
            return View();
        }
        acoesDentista ac = new acoesDentista();
        public ActionResult confCadDentista(modelDentista m)
        {

            ac.inserirDentista(m);
            ViewBag.mensagem = "Cadastro Realizado com sucesso";
            return View();
        }


    }
}