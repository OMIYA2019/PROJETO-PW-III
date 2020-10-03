using MySql.Data.MySqlClient;
using ProjetoOdontoClin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoOdontoClin.Dados
{
    public class acoesPaciente
    {
        conexao con = new conexao();

        public void inserirPaciente(modelPaciente cm)
        {
            MySqlCommand cmd = new MySqlCommand("insert into tbPaciente values(@codPac, @nomePac, @telPac)", con.MyConectarBD());

            cmd.Parameters.Add("@codPac", MySqlDbType.VarChar).Value = cm.CodPac;
            cmd.Parameters.Add("@nomePac", MySqlDbType.VarChar).Value = cm.NomePac;
            cmd.Parameters.Add("@telPac", MySqlDbType.VarChar).Value = cm.TelPac;

            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }
    }
}