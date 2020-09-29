using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projetoLogin.Dados
{
    public class conexao
    {
         MySqlConnection cn = new MySqlConnection("Server=localhost; DataBase=bdLogin2; User=omiya;pwd=628398;Port=3307");

      /*  MySqlConnection cn = new MySqlConnection("Server=localhost; DataBase=bdLogin2; User=root;pwd=;sslmode=none");*/

        public static string msg;

        public MySqlConnection MyConectarBD() //Método: MyConectarBD()
        {

            try
            {
                cn.Open();
            }

            catch (Exception erro)
            {
                msg = "Ocorreu um erro ao se conectar" + erro.Message;
            }
            return cn;
        }
       
        public MySqlConnection MyDesConectarBD()  //Método: MyDesConectarBD()
        {

            try
            {
                cn.Close();
            }

            catch (Exception erro)
            {
                msg = "Ocorreu um erro ao se conectar" + erro.Message;
            }
            return cn;
        }

    }
}