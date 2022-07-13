<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ABM_Duenio.aspx.cs" Inherits="ABM_Duenio" %>

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
                <span style="font-size: 14pt; color: #006699; text-decoration: underline">
                <strong>Agregar Dueño</strong>
                </span>
                <br />
                <br />

                <table class="table table-sm">
                  <thead>
                    <tr>
                      <th scope="col">Cliente: </th>
                      <th scope="col"></th>
                      <th scope="col"></th>
                    </tr>
                  </thead>
                  <tbody>
                    <tr>
                      <th scope="row">Cedula: </th>
                      <td>
                          <asp:TextBox ID="txtCI" runat="server" Width="180px"></asp:TextBox>
                      </td>
                        <td>
                            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
                        </td>
                    </tr>
                    <tr>
                      <th scope="row">Nombre: </th>
                        <td>
                            <asp:TextBox ID="txtNombre" runat="server" Width="180px"></asp:TextBox>
                        </td>  
                        <td></td>
                    </tr>
                    <tr>
                      <th scope="row"></th>
                        <td>
                            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
                            <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" />
                            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
                        </td>
                        <td>
                            <asp:Button ID="Button5" runat="server" Text="Limpiar / Deshacer" OnClick="btnLimpiar_Click" />
                        </td>
                    </tr>
                    <tr>
                        <th scope="row"></th>
                        <td>
                            <asp:Label ID="LabelDes" runat="server" Text="Descripción del Error: "></asp:Label>
                            <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <th scope="row"></th>
                        <td>
                            <asp:LinkButton ID="LinkButton4" runat="server" PostBackUrl="~/Default.aspx">Volver</asp:LinkButton>
                        </td>
                        <td></td>
                    </tr>
                  </tbody>
                </table>
        </div>
           
    </form>
</body>
</html>
