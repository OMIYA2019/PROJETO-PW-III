using MySql.Data.MySqlClient;
using ProjetoOdontoClin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoOdontoClin.Dados
{
    public class acoesLogin
    {
        conexao con = new conexao();

        public void inserirLogin(modelLogin cm)
        {
            MySqlCommand cmd = new MySqlCommand("insert into tblogin values(@usuario, @Senha, @tipo)", con.MyConectarBD());

            cmd.Parameters.Add("@usuario", MySqlDbType.VarChar).Value = cm.usuario;
            cmd.Parameters.Add("@Senha", MySqlDbType.VarChar).Value = cm.senha;
            cmd.Parameters.Add("@tipo", MySqlDbType.VarChar).Value = cm.tipo;

            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }


        public void TestarUsuario(modelLogin user)
        {
            MySqlCommand cmd = new MySqlCommand("select * from tbLogin where usuario = @usuario and senha = @Senha ", con.MyConectarBD());

            cmd.Parameters.Add("@usuario", MySqlDbType.VarChar).Value = user.usuario;
            cmd.Parameters.Add("@Senha", MySqlDbType.VarChar).Value = user.senha;

            MySqlDataReader leitor;

            leitor = cmd.ExecuteReader();

            if (leitor.HasRows)
            {
                while (leitor.Read())
                {
                    user.usuario = Convert.ToString(leitor["usuario"]);
                    user.senha = Convert.ToString(leitor["senha"]);
                    user.tipo = Convert.ToString(leitor["tipo"]);
                }
            }

            else
            {
                user.usuario = null;
                user.senha = null;
                user.tipo = null;
            }

            con.MyDesconectarBD();
        }

    }
}