using MySql.Data.MySqlClient;
using ProjetoOdontoClin.Models;
using System;
using System.Collections.Generic;
using System.Data;
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

        public DataTable selecionarDentista()
        {
            MySqlCommand cmd = new MySqlCommand("select * from tbDentista", con.MyConectarBD());
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dentista = new DataTable();
            da.Fill(dentista);
            con.MyDesconectarBD();
            return dentista;
        }

        public DataTable selecionarBuscaDentista(modelDentista cm)
        {
            MySqlCommand cmd = new MySqlCommand("select * from tbDentista where codDentista=@codDentista", con.MyConectarBD());

            cmd.Parameters.Add("@codDentista", MySqlDbType.VarChar).Value = cm.CodDentista;

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dentista = new DataTable();
            da.Fill(dentista);
            con.MyDesconectarBD();
            return dentista;
        }


        public List<modelDentista> BuscaDentista()
        {
            List<modelDentista> Dentistalist = new List<modelDentista>();

            MySqlCommand cmd = new MySqlCommand("select * from tbDentista", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                Dentistalist.Add(
                    new modelDentista
                    {
                        CodDentista = Convert.ToString(dr["codDentista"]),
                        NomeDentista = Convert.ToString(dr["nomeDentista"]),
                        TelDentista = Convert.ToString(dr["telDentista"]),
                        EmailDentista = Convert.ToString(dr["emailDentista"])
                    });
            }
            return Dentistalist;
        }
    }
}