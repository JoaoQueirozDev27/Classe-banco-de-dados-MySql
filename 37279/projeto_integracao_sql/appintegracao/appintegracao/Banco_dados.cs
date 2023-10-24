using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;

namespace appintegracao
{
    public class Banco_dados
    {
        public string linha_conexao { get; set;}

        private MySqlConnection _conexao;

        private MySqlConnection conexao
        {
            get { return _conexao = new MySqlConnection(linha_conexao);}
        }


        public void cmd_ns(string comando)
        {
            try
            {               
                conexao.Open();
                MySqlCommand cSQL = new MySqlCommand(comando,_conexao);
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
            MySqlDataReader dados = null;
            try
            {
                conexao.Open();
                MySqlCommand cSQL = new MySqlCommand(comando, _conexao);
                dados = cSQL.ExecuteReader();
                if (!dados.HasRows)
                {
                    throw new Exception(" a variavel 'dados' é nula");
                }
                return dados;
            }
            catch
            {
                throw new Exception("Não foi possível conectar ao servidor");
            }
            finally
            {
                if (conexao.State == System.Data.ConnectionState.Open)
                    conexao.Close();
            }
        }
    }
}
