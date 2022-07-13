<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Control de Inmobiliaria</title>
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
    <div class="container" style="text-align: center">
        <span style="font-size: 14pt; color: #006699; text-decoration: underline"><strong>Menu
            Principal de la Inmobiliaria</strong></span><br />
        <br />
    
        <table style="width:20%;">
            <tr>
                <td style="width: 426px">
                  <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/ABMCasa.aspx">Mantenimiento Casa</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td style="width: 426px">
    
        <asp:LinkButton ID="LinkButton2" runat="server" 
            PostBackUrl="~/ABMApartamento.aspx">Mantenimiento Apartamento</asp:LinkButton>
    
                </td>
            </tr>
            <tr>
                <td style="width: 426px">
                    <asp:LinkButton ID="LinkButton4" runat="server" PostBackUrl="~/ABM_Duenio.aspx">Mantenimiento Dueños</asp:LinkButton></td>
            </tr>
            <tr>
                <td style="width: 426px">
                    .</td>
            </tr>
            <tr>
                <td style="width: 426px">
                    <asp:LinkButton ID="LinkButton3" runat="server" 
                        PostBackUrl="~/ListarViviendas.aspx">Listar viviendas</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td style="width: 426px">
                    &nbsp;<asp:LinkButton ID="LinkButton6" runat="server" PostBackUrl="~/ListarDuenio.aspx">Listar Clientes</asp:LinkButton></td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
