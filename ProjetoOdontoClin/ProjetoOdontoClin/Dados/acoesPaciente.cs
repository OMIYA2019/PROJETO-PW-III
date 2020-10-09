using MySql.Data.MySqlClient;
using ProjetoOdontoClin.Models;
using System;
using System.Collections.Generic;
using System.Data;
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

        public DataTable selecionarPaciente()
        {
            MySqlCommand cmd = new MySqlCommand("select * from tbPaciente", con.MyConectarBD());
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable paciente = new DataTable();
            da.Fill(paciente);
            con.MyDesconectarBD();
            return paciente;
        }

        public DataTable selecionarBuscaPaciente(modelPaciente cm)
        {
            MySqlCommand cmd = new MySqlCommand("select * from tbPaciente where codPac=@codPac", con.MyConectarBD());

            cmd.Parameters.Add("@codPac", MySqlDbType.VarChar).Value = cm.CodPac;

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable paciente = new DataTable();
            da.Fill(paciente);
            con.MyDesconectarBD();
            return paciente;
        }


        public List<modelPaciente> BuscarPac()
        {
            List<modelPaciente> Paclist = new List<modelPaciente>();

            MySqlCommand cmd = new MySqlCommand("select * from tbPaciente", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                Paclist.Add(
                    new modelPaciente
                    {
                        CodPac = Convert.ToString(dr["codPac"]),
                        NomePac = Convert.ToString(dr["nomePac"]),
                        TelPac = Convert.ToString(dr["telPac"])
                    });
            }
            return Paclist;
        }


    }
}