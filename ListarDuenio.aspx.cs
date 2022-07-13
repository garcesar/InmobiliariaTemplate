using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ListarDuenio : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Inmobiliaria _inmo = (Inmobiliaria)Session["Inmo"];

            //No existe el repositorio de datos
            if (_inmo == null)
                Response.Redirect("~/Default.aspx");

            //Despliego
            lbPersonas.Items.Clear();
            lbPersonas.DataSource = _inmo.ListaDuenios();
            lbPersonas.DataBind();
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
 
    }
}