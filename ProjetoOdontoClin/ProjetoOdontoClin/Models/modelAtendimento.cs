using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoOdontoClin.Models
{
    public class modelAtendimento
    {
        public string codAtendimento { get; set; }
        public string dataAtend { get; set; }
        public string horaAtend { get; set; }
        public string codDentista { get; set; }
        public string codPac { get; set; }


        public string confAgendamento { get; set; }
        public string nomePac { get; set; }
        public string nomeDentista { get; set; }

    }
}