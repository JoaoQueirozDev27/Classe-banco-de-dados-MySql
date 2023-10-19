using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace appintegracao
{
    public partial class Excluir : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string codigo = Request["codigo"];

                string linhaConexao = "SERVER=localhost;UID=root;PASSWORD=root;DATABASE=integracao;";
                MySqlConnection conexao = new MySqlConnection(linhaConexao); //Instanciamento
                MySqlDataReader dados = null;

                try
                {
                    conexao.Open();
                    string comando = $"select * from produto where cd_produto = {codigo}";
                    MySqlCommand cSQL = new MySqlCommand(comando, conexao);
                    dados = cSQL.ExecuteReader();
                    while (dados.Read())
                    {
                        TxtCodigo.Text = dados.GetString(0);
                        TxtNome.Text = dados.GetString(1);
                        litnome_produto.Text = dados.GetString(1);
                        TxtValor.Text = dados.GetString(2);
                    }

                }


                catch
                {
                    return;
                }

                finally
                {
                    if (!dados.IsClosed)
                    {
                        dados.Close();
                    }

                    if (conexao.State == System.Data.ConnectionState.Open)
                    {
                        conexao.Close();
                    }
                }
            }
        }

        protected void BtnSalvar_Click1(object sender, EventArgs e)
        {
            try
            {
                double.Parse(TxtValor.Text.Replace(",", "."));
            }
            catch
            {
                Response.Write("<script>alert('Nao digite letras no valor')</script>");
                return;
            }

            #region pegar dados das TextBox
            string nome = TxtNome.Text;
            double valor = double.Parse(TxtValor.Text);
            #endregion 

            string linhaConexao = "SERVER=localhost;UID=root;PASSWORD=root;DATABASE=integracao;";
            MySqlConnection conexao = new MySqlConnection(linhaConexao); //Instanciamento

            #region adicionar dados 
            try
            {
                conexao.Open();
                string comando = $"Delete from produto where cd_produto = {TxtCodigo.Text};";
                MySqlCommand cSQL = new MySqlCommand(comando, conexao);
                cSQL.ExecuteNonQuery();
                Response.Write("<script>alert('Operação realizada com sucesso')</script>");
                Response.Redirect("index.aspx");
            }


            catch
            {
                Response.Write("<script>alert('Não foi possível conectar ao servidor')</script>");
                return;
            }

            finally
            {

                if (conexao.State == System.Data.ConnectionState.Open)
                {
                    conexao.Close();
                }

            }
            #endregion
        }

        protected void btnvoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
    }
}