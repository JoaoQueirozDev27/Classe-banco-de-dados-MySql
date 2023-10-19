using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace appintegracao
{
    public class Banco_dados
    {
        public string nome_banco { get; set; }

        public void cmd_ns(string comando)
        {
            string linhaConexao = $@"SERVER=localhost;UID=root;PASSWORD=root;DATABASE={nome_banco}";
            MySqlConnection conexao = new MySqlConnection(linhaConexao);
            try
            {
                conexao.Open();
                MySqlCommand cSQL = new MySqlCommand(comando, conexao);
                cSQL.ExecuteNonQuery();
            }
            catch
            {
                return;
            }
            finally
            {
                if (conexao.State == System.Data.ConnectionState.Open)
                    conexao.Close();
            }
        }

        public MySqlDataReader cmd_select(string comando)
        {
            string linhaConexao = $@"SERVER=localhost;UID=root;PASSWORD=root;DATABASE={nome_banco}";
            MySqlConnection conexao = new MySqlConnection(linhaConexao);
            MySqlDataReader dados = null;
            try
            {
                conexao.Open();
                MySqlCommand cSQL = new MySqlCommand(comando, conexao);
                dados = cSQL.ExecuteReader();
                if (!(dados.Read()))
                {
                    throw new Exception(" a variavel 'dados' é nula");
                }
                return dados;
            }
            catch
            {
                throw new Exception("Não foi possível conectar ao servidor");
                //}
                //finally
                //{
                //    if (!dados.IsClosed)
                //        dados.Close();
                //    if (conexao.State == System.Data.ConnectionState.Open)
                //        conexao.Close();
                //}
            }
        }
    }
}