<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ABMCasa.aspx.cs" Inherits="ABMCasa" %>

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
                <strong>Mantenimiento Casa</strong>
            </span>
            <br />
            <br />
            
            <table class="table">
              <thead>
                <tr>
                  <th scope="col">Padron: </th>
                  <th scope="col">
                      <asp:TextBox ID="txtPadron" runat="server"></asp:TextBox>
                  </th>
                  <td>
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="BtnBuscar_Click" />
                  </td>
                </tr>
              </thead>
              <tbody>
                <tr>
                  <th scope="row">Dirección: </th>
                  <td>
                      <asp:TextBox ID="txtDireccion" runat="server" Width="180px"></asp:TextBox>
                  </td>
                  <td></td>
                </tr>
                <tr>
                  <th scope="row">Fecha de Construcción: </th>
                    <td>
                        <asp:Calendar ID="Calendar" runat="server"></asp:Calendar>
                    </td>
                    <td></td>
                </tr>
                <tr>
                  <th scope="row">Alquiler: </th>
                  <td>
                      <asp:TextBox ID="txtAlquiler" runat="server" Width="180px"></asp:TextBox>
                  </td>
                  <td></td>
                </tr>
                <tr>
                  <th scope="row">Metros de Construcción: </th>
                    <td>
                        <asp:TextBox ID="txtMetros" runat="server" Width="180px"></asp:TextBox>
                    </td>
                    <td></td>
                </tr>
                  <th scope="row">Dueño: </th>
                  <td>
                      <asp:TextBox ID="textDuenioCedula" runat="server" Width="180px"></asp:TextBox>
                      <asp:Button ID="btnBuscoDuenio" runat="server" Text="Buscar Dueño" OnClick="BtnBuscoDuenio_Click" />
                      <asp:Label ID="LabelDes1" runat="server" Text="Dueño: "></asp:Label>
                      <asp:Label ID="lblDuenio" runat="server" Text=""></asp:Label>
                  </td>
                  <td></td>
                </tr>
                <tr>
                  <th scope="row"></th>
                    <td>
                        <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
                        <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" />
                        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="BtnEliminar_Click" />
                        <asp:Button ID="Button3" runat="server" Text="Limpiar/Deshacer" OnClick="btnLimpiar_Click" />
                    </td>
                    <td></td>
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
