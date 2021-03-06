<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListarDuenio.aspx.cs" Inherits="ListarDuenio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    <style type="text/css">
        .container{
            text-align: center;
            background-color: rgb(237,245,245);
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <strong>
            <span style="font-size: 16pt; color: #336666; text-decoration: underline">Listado de Dueños</span>
        </strong>
        <br />
            <asp:ListBox ID="lbPersonas" runat="server" Height="144px" Width="684px"></asp:ListBox>
        <br /><br />
        <asp:Label ID="lblError" runat="server"></asp:Label><br />
        <asp:LinkButton ID="LinkButton4" runat="server" PostBackUrl="~/Default.aspx">Volver</asp:LinkButton>
    </div>
    </form>
</body>
</html>
