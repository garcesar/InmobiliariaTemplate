using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ABM_Duenio : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Inmo"] == null)
            Response.Redirect("~/ABM_Default.aspx");

        /*Se valida si está haciendo un PostBack al servidor, para conocer si es su primer despligue o está volviendo con información*/
        if (!IsPostBack)
            this.LimpioFormulario();
    }

    private void ActivoBotonesBM()
    {
        btnModificar.Enabled = true;
        btnEliminar.Enabled = true;

        btnAgregar.Enabled = false;
        btnBuscar.Enabled = false;

        txtCI.Enabled = false;
    }

    private void ActivoBotonesA()
    {
        btnModificar.Enabled = false;
        btnEliminar.Enabled = false;

        btnAgregar.Enabled = true;
        btnBuscar.Enabled = false;

        txtCI.Enabled = false;
    }

    private void LimpioFormulario()
    {
        btnAgregar.Enabled = false;
        btnModificar.Enabled = false;
        btnEliminar.Enabled = false;

        btnBuscar.Enabled = true;
        txtCI.Enabled = true;

        txtCI.Text = "0";
        txtNombre.Text = "";
        lblError.Text = "";
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            Inmobiliaria _inmo = (Inmobiliaria)Session["Inmo"];

            //Busco Duenio
            int _cedula = Convert.ToInt32(txtCI.Text);
            Duenio _objeto = _inmo.BuscarD(_cedula);

            //Determino acciones
            if (_objeto == null)
            {
                //Alta
                this.ActivoBotonesA();
                Session["DuenioABM"] = null;
                lblError.Text = "No existe un dueño registrado con esa cedula";
            }
            else
            {
                this.ActivoBotonesBM();
                Session["DuenioABM"] = _objeto;

                txtNombre.Text = _objeto.Nombre;
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        try
        {
            //Obtengo la inmobiliaria
            Inmobiliaria unaInmo = (Inmobiliaria)Session["Inmo"];

            //Agrego la persona
            Duenio unD = new Duenio(Convert.ToInt32(txtCI.Text), txtNombre.Text.Trim());

            if (unaInmo.Agregar(unD))
            {
                lblError.Text = "Alta y Asignacion con exito";

                //Limpio pantalla
                this.LimpioFormulario();
            }
            else
                lblError.Text = "Error en alta de Persona";
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void btnModificar_Click(object sender, EventArgs e)
    {
        try
        {
            Inmobiliaria _inmo = (Inmobiliaria)Session["Inmo"];
            Duenio _und = (Duenio)Session["DuenioABM"];

            //Modificar el obj
            _und.Nombre = txtNombre.Text.Trim();

            //Trato de modificar
            if (_inmo.Modificar(_und))
            {
                lblError.Text = "Modificación con éxito";
                this.LimpioFormulario();
            }
            else
                lblError.Text = "error";
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            Inmobiliaria _inmo = (Inmobiliaria)Session["Inmo"];
            Duenio _und = (Duenio)Session["DuenioABM"];

            //Trato de eliminar
            if (_inmo.Eliminar(_und))
            {
                lblError.Text = "Eliminación con éxito";
                this.LimpioFormulario();
            }
            else
                lblError.Text = "error";
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        this.LimpioFormulario();
    }
}