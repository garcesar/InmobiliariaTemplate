using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ListarViviendas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Inmobiliaria _inmo = (Inmobiliaria)Session["Inmo"];

            //No existe el repositorio de datos
            if (_inmo == null)
                Response.Redirect("~/Default.aspx");

            //Despliego prueba
            //lbViviendas.Items.Clear();
            //lbViviendas.DataSource = _inmo.ListaViviendas();
            //lbViviendas.DataBind();
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    //protected void DDlTipo_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        Inmobiliaria _inmo = (Inmobiliaria)Session["Inmo"];

    //        lbViviendas.Items.Clear();

    //        if (DDlTipo.SelectedIndex == 0)
    //        {
    //            //Muestro todas las viviendas
    //            lbViviendas.DataSource = _inmo.ListaViviendas();
    //            lbViviendas.DataBind();
    //        }
    //        else if (DDlTipo.SelectedIndex == 1)
    //        {
    //            //Muestro solo las casas
    //            foreach (Vivienda unav in _inmo.ListaViviendas())
    //            {
    //                if (unav is Casa)
    //                    lbViviendas.Items.Add(unav.ToString());
    //            }
    //        }
    //        else
    //        {
    //            //Muestro solo los aptos
    //            foreach (Vivienda unav in _inmo.ListaViviendas())
    //            {
    //                if (unav is Apartamento)
    //                    lbViviendas.Items.Add(unav.ToString());
    //            }
    //        }

    //    }
    //    catch (Exception ex)
    //    {
    //        lblError.Text = ex.Message;
    //    }
    //}

    protected void DropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Inmobiliaria _inmo = (Inmobiliaria)Session["Inmo"];

            lbViviendas.Items.Clear();

            if (DropDownList.SelectedIndex == 0)
            {   
                //Muestro todas las viviendas
                lbViviendas.DataSource = _inmo.ListaViviendas();
                lbViviendas.DataBind();
            }
            else if (DropDownList.SelectedIndex == 1)
            {
                //Muestro solo las casas
                foreach (Vivienda unav in _inmo.ListaViviendas())
                {
                    if (unav is Casa)
                        lbViviendas.Items.Add(unav.ToString());
                }
            }
            else
            {
                //Muestro solo los aptos
                foreach (Vivienda unav in _inmo.ListaViviendas())
                {
                    if (unav is Apartamento)
                        lbViviendas.Items.Add(unav.ToString());
                }
            }

        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
}