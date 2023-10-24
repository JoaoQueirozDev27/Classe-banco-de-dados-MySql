using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace appintegracao
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string linhaConexao = "SERVER=localhost;UID=root;PASSWORD=root;DATABASE=integracao;";
            Banco_dados bd = new Banco_dados();
            bd.linha_conexao = linhaConexao;

            string codigo_exclusao = Request["codigo"];

            if (!String.IsNullOrEmpty(codigo_exclusao))
            {
                try
                {                    
                    string comando = $"delete from produto where cd_produto ={codigo_exclusao};";
                    bd.cmd_ns(comando);
                    Response.Write("<script>alert('Foi')</script>");
                }


                catch
                {
                    Response.Write("<script>alert('Não foi possível conectar ao servidor')</script>");
                    return;
                }

                finally
                {

                    Response.Redirect("index.aspx");
                }
            }
            
            MySqlDataReader dados = null;
            try
            {
                
                string comando = "select * from produto";
                dados = bd.cmd_select(comando);

                while (dados.Read())
                {
                    string codigo = dados.GetString(0);
                    string nome = dados.GetString(1);
                    double valor = dados.GetDouble(2);
                    litdados_tabela.Text += $@"<tr>
                                            <td>{codigo}</td>
                                            <td>{nome}</td>
                                            <td>{valor.ToString("C")}</td>
                                            <td><a href='editar.aspx?codigo={codigo}'><img src='images/editar.png'/></a> <a href='excluir.aspx?codigo={codigo}'><img src='images/excliuir.png'/></a></td>
                                        </tr>";
                }          
             }
            catch
            {
                litdados_tabela.Text = "Não foi possível conectar ao Servidor";
                return;
            }

            finally
            {
                if (!dados.IsClosed)
                {
                    dados.Close();
                }
            }
        }
    }
}