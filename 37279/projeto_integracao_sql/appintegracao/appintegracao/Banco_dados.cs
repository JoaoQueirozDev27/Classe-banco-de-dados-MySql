using System;
using MySql.Data.MySqlClient;

namespace appintegracao
{
    public class Banco_dados
    {
        MySqlConnection conexao;
        public void conectar(string linha_conexao)
        {
            conexao = new MySqlConnection(linha_conexao);
            conexao.Open();
        }
        public void desconectar()
        {
            if (conexao.State == System.Data.ConnectionState.Open)
                conexao.Close();
        }
        public void cmd_ns(string comando)
        {
            try
            {
                MySqlCommand cSQL = new MySqlCommand(comando,conexao);
                cSQL.ExecuteNonQuery();
            }
            catch
            {
                return;
            }
        }

        public MySqlDataReader cmd_select(string comando)
        {          
            MySqlDataReader dados = null;
            try
            {
                MySqlCommand cSQL = new MySqlCommand(comando,conexao);
                dados = cSQL.ExecuteReader();
                return dados;
            }
            catch
            {
                throw new Exception("Não foi possível conectar ao servidor");
            }
        }
    }
}
