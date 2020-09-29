using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace projetoLogin.Models
{
    public class clLogin
    {
        public string usuario { get; set; }
        public string senha { get; set; }
        public string tipo { get; set; }
        [DisplayName("Confirme a Senha")]
        public string confSenha { get; set; }
    }
}