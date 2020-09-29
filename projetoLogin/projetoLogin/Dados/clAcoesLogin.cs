using MySql.Data.MySqlClient;
using projetoLogin.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace projetoLogin.Dados
{

    public class clAcoesLogin
        {
        conexao con = new conexao();
        public void TestarUsuario(clLogin user)
        {
            MySqlCommand cmd = new MySqlCommand("select * from tbLogin where usuario = @usuario and senha = @Senha ", con.MyConectarBD()); // @: PARAMETRO


            cmd.Parameters.Add("@usuario", MySqlDbType.VarChar).Value = user.usuario;
            cmd.Parameters.Add("@Senha", MySqlDbType.VarChar).Value = user.senha;

            MySqlDataReader leitor;

            con.MyConectarBD();  /*acrescentou essa linha de comando*/
            leitor = cmd.ExecuteReader();

            if (leitor.HasRows)
            {
                while (leitor.Read())
                {
                    {
                        user.usuario = Convert.ToString(leitor["usuario"]);
                        user.senha = Convert.ToString(leitor["Senha"]);
                        user.tipo = Convert.ToString(leitor["tipo"]);
                    }

                }
            }

            else
            {
                user.usuario = null;
                user.senha = null;
                user.tipo = null;
            } 
            con.MyDesConectarBD();
        }

        public void inserirLogin(clLogin cm)
        {
            MySqlCommand cmd = new MySqlCommand("insert into tblogin(usuario,senha,tipo) values(@usuario,@senha,@tipo)", con.MyConectarBD());

            cmd.Parameters.Add("@usuario", MySqlDbType.VarChar).Value = cm.usuario;
            cmd.Parameters.Add("@senha", MySqlDbType.VarChar).Value = cm.senha;
            cmd.Parameters.Add("@tipo", MySqlDbType.VarChar).Value = cm.tipo;

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }

        public DataTable selecionarUsuario()
        {

            MySqlCommand cmd = new MySqlCommand("select * from tblogin", con.MyConectarBD());

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            DataTable Usuario = new DataTable();

            da.Fill(Usuario);

            con.MyDesConectarBD();

            return Usuario;
        }

        public DataTable buscarUsuario(clLogin cm)
        {

            MySqlCommand cmd = new MySqlCommand("select * from tblogin where usuario=@usuario", con.MyConectarBD());

            cmd.Parameters.Add("@usuario", MySqlDbType.VarChar).Value = cm.usuario;

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            DataTable Usuario = new DataTable();

            da.Fill(Usuario);

            con.MyDesConectarBD();

            return Usuario;
        }


    }
}