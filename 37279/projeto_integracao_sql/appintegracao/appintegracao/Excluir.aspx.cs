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
        Banco_dados bd = new Banco_dados();
        string linhaConexao = "SERVER=localhost;UID=root;PASSWORD=root;DATABASE=integracao;";

        protected void Page_Load(object sender, EventArgs e)
        {
            bd.conectar(linhaConexao);

            if (!IsPostBack)
            {
                string codigo = Request["codigo"];
                MySqlDataReader dados = null;

                try
                {
                    string comando = $"select * from produto where cd_produto = {codigo}";
                    dados = bd.cmd_select(comando);
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
                    bd.desconectar();
                    return;
                }

                finally
                {
                    bd.desconectar();
                }
            }
        }

        protected void BtnSalvar_Click1(object sender, EventArgs e)
        {
            bd.conectar(linhaConexao);
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

            #region adicionar dados 
                try
                {
                    string comando = $"Delete from produto where cd_produto = {TxtCodigo.Text};";
                    bd.cmd_ns(comando);
                    Response.Write("<script>alert('Operação realizada com sucesso')</script>");
                    Response.Redirect("index.aspx");
                }
                catch
                {
                    Response.Write("<script>alert('Não foi possível conectar ao servidor')</script>");
                    bd.desconectar();
                    return;
                }
                finally { bd.desconectar(); }
            #endregion
        }

        protected void btnvoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
    }
}