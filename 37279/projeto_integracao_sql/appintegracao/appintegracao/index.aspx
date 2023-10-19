<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="appintegracao.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1" />
<link href="css/estilo_geral.css" rel="stylesheet" />
<title>Tabela produtos</title>
</head>
<body>
    <form id="form1" runat="server">
        <section>
        <p><a href="">Produto</a></p>
        <p><a href="novo_produto.aspx">Novo</a></p>
      </section>
        <table id='tabela_produtos'>
           <tr>
               <th>Código</th>
               <th>Nome</th>
               <th>Valor</th>
               <th></th>
           </tr>
           <asp:Literal ID="litdados_tabela" runat="server"></asp:Literal>        
        </table>
    </form>
</body>
</html>
