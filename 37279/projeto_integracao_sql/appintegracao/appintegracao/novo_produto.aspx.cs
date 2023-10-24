﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace appintegracao
{
    public partial class novo_produto : System.Web.UI.Page
    {
        Banco_dados bd = new Banco_dados();
        protected void Page_Load(object sender, EventArgs e)
        {
            #region pegar maior código,somar 1 e adicionar a textbox
            
            string linhaConexao = "SERVER=localhost;UID=root;PASSWORD=root;DATABASE=integracao;";
            bd.linha_conexao = linhaConexao;
            MySqlDataReader dados = null;

            int maior_codigo;

            try
            {
                string comando = "select max(cd_produto) from produto";
                dados = bd.cmd_select(comando);
                while (dados.Read())
                {
                    maior_codigo = dados.GetInt32(0);
                    TxtCodigo.Text = (maior_codigo + 1).ToString();
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
            }
            #endregion
        }

        protected void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(TxtNome.Text))
            {
                Response.Write("<script>alert('Preencha o nome do produto')</script>");
                return;
            }
            if (String.IsNullOrEmpty(TxtCodigo.Text))
            {
                Response.Write("<script>alert('Preencha o nome do codigo')</script>");
                return;
            }
            if (String.IsNullOrEmpty(TxtValor.Text))
            {
                Response.Write("<script>alert('Preencha o nome do valor')</script>");
                return;
            }
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
                    string comando = $"insert into produto values({double.Parse(TxtCodigo.Text)},'{nome}',{valor.ToString("#.##").Replace(",",".")})";
                    bd.cmd_ns(comando);
                    Response.Write("<script>alert('Produto adicionado com sucesso')</script>");
                    Response.Redirect("index.aspx");
            }


                catch
                {
                    Response.Write("<script>alert('Não foi possível conectar ao servidor')</script>");

                    return;
                }
            #endregion

        }

        protected void btnvoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }


    }
}