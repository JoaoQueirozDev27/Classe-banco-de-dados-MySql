<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="novo_produto.aspx.cs" Inherits="appintegracao.novo_produto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1" />
<link href="css/estilo_novo.css" rel="stylesheet" />
<title>Adicione um novo produto</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <section>
                <label>Código:</label>
                <asp:TextBox ID="TxtCodigo" CssClass="caixa_texto" runat="server" ReadOnly="true"></asp:TextBox>
                <label>Nome:</label>
                <asp:TextBox ID="TxtNome" CssClass="caixa_texto" runat="server"></asp:TextBox>
                <label>Valor</label>
                <asp:TextBox ID="TxtValor" CssClass="caixa_texto" runat="server" ></asp:TextBox>
                <asp:Button ID="BtnSalvar" CssClass="botao" runat="server" Text="Salvar" OnClick="BtnSalvar_Click" />
                <asp:Button ID="btnvoltar" CssClass="botao" runat="server" Text="Voltar" OnClick="btnvoltar_Click" />
            </section>
        </div>
    </form>
</body>
</html>
