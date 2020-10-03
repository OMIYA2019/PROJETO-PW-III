using ProjetoOdontoClin.Dados;
using ProjetoOdontoClin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoOdontoClin.Controllers
{
    public class PacienteController : Controller
    {
        // GET: Paciente
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult cadPaciente()
        {
            return View();
        }
        acoesPaciente ac = new acoesPaciente();
        public ActionResult confCadPaciente(modelPaciente m)
        {

            ac.inserirPaciente(m);
            ViewBag.mensagem = "Cadastro Realizado com sucesso";
            return View();
        }

    }
}