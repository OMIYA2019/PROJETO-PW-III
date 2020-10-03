using MySql.Data.MySqlClient;
using ProjetoOdontoClin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoOdontoClin.Dados
{
    public class acoesDentista
    {
        conexao con = new conexao();

        public void inserirDentista(modelDentista cm)
        {
            MySqlCommand cmd = new MySqlCommand("insert into tbDentista values(@CodDentista, @NomeDentista, @TelDentista,@EmailDentista)", con.MyConectarBD());

            cmd.Parameters.Add("@codDentista", MySqlDbType.VarChar).Value = cm.CodDentista;
            cmd.Parameters.Add("@nomeDentista", MySqlDbType.VarChar).Value = cm.NomeDentista;
            cmd.Parameters.Add("@telDentista", MySqlDbType.VarChar).Value = cm.TelDentista;
            cmd.Parameters.Add("@emailDentista", MySqlDbType.VarChar).Value = cm.EmailDentista;
            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }
    }
}