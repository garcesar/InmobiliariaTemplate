using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ABMCasa : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Inmo"] == null)
            Response.Redirect("~/Default.aspx");

        if (!IsPostBack)
            this.LimpioFormulario();

        if (((Inmobiliaria)Session["Inmo"]).ListaDuenios().Count == 0)
        {
            lblError.Text = "No hay Dueños - No se puede trabajar con Casas";
            btnBuscar.Enabled = false;
        }
    }

    private void ActivoBotonesBM()
    {
        btnModificar.Enabled = true;
        btnEliminar.Enabled = true;

        btnAgregar.Enabled = false;
        btnBuscar.Enabled = false;

        txtPadron.Enabled = false;
        btnBuscoDuenio.Enabled = true;
    }

    private void ActivoBotonesA()
    {
        btnModificar.Enabled = false;
        btnEliminar.Enabled = false;

        btnAgregar.Enabled = true;
        btnBuscar.Enabled = false;

        txtPadron.Enabled = false;
        btnBuscoDuenio.Enabled = true;
    }

    private void LimpioFormulario()
    {
        btnAgregar.Enabled = false;
        btnModificar.Enabled = false;
        btnEliminar.Enabled = false;

        btnBuscar.Enabled = true;
        btnBuscoDuenio.Enabled = false;

        txtPadron.Enabled = true;

        txtPadron.Text = "0";
        txtDireccion.Text = "";
        txtAlquiler.Text = "0";
        textDuenioCedula.Text = "";
        lblDuenio.Text = "";
        lblError.Text = "";
    }

    protected void BtnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            Inmobiliaria _inmo = (Inmobiliaria)Session["Inmo"];

            //Busco Casa
            int _padron = Convert.ToInt32(txtPadron.Text);
            Vivienda _objeto = _inmo.Buscar(_padron);

            //Determino acciones
            if (_objeto == null)
            {
                //Alta
                this.ActivoBotonesA();
                Session["Casa"] = _objeto;
                Session["Duenio"] = null;
                lblError.Text = "No existe una casa con ese padron";
            }
            else if (_objeto is Apartamento)
                throw new Exception("El padron pertenece a un Apto - Error");
            else
            {
                this.ActivoBotonesBM();

                Session["Casa"] = _objeto;
                Session["Duenio"] = _objeto.Dueño;

                txtDireccion.Text = _objeto.Direccion;
                Calendar.SelectedDate = _objeto.FechaCons;
                Calendar.VisibleDate = _objeto.FechaCons;
                txtAlquiler.Text = _objeto.Alquiler.ToString();
                txtMetros.Text = ((Casa)_objeto).MtFondo.ToString();

                //Muestro el duenio de la Vivienda
                lblDuenio.Text = _objeto.Dueño.ToString();
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void BtnBuscoDuenio_Click(object sender, EventArgs e)
    {
        try
        {
            Inmobiliaria _inmo = (Inmobiliaria)Session["Inmo"];

            //Busco Duenio
            int _cedula = Convert.ToInt32(textDuenioCedula.Text);
            Duenio _objeto = _inmo.BuscarD(_cedula);

            //Determino acciones
            if (_objeto == null)
            {
                Session["Duenio"] = null;
                lblDuenio.Text = "No existe dicha cedula en el sistema";
            }
            else
            {
                Session["Duenio"] = _objeto;
                lblDuenio.Text = _objeto.ToString();
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
            Duenio _und = (Duenio)Session["Duenio"];

            //Verifico que tenga un dueño
            if (_und == null)
                throw new Exception("Deben seleccionar Dueño");

            //Creo el obj
            int padron = Convert.ToInt32(txtPadron.Text);

            Casa unaCasa = new Casa(padron, txtDireccion.Text ,Calendar.SelectedDate, Convert.ToDouble(txtAlquiler.Text), Convert.ToDouble(txtMetros.Text), _und);
            
            //Trato de agregar
            if (unaInmo.Agregar(unaCasa))
            {
                lblError.Text = "Alta con éxito";
                this.LimpioFormulario();
            }
            else
            {
                lblError.Text = "Padron Duplicado";
            }
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
            Casa _unaC = (Casa)Session["Casa"];
            Duenio _und = (Duenio)Session["Duenio"];

            //Verifico que tenga un dueño
            if (_und == null)
                throw new Exception("Debe seleccionar Dueño");

            //Modificar el obj
            _unaC.Direccion = txtDireccion.Text.Trim();
            _unaC.FechaCons = Calendar.SelectedDate;
            _unaC.Alquiler = Convert.ToDouble(txtAlquiler.Text);
            _unaC.Dueño = _und;

            //Trato de modificar
            if (_inmo.Modificar(_unaC))
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

    protected void BtnEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            Inmobiliaria _inmo = (Inmobiliaria)Session["Inmo"];
            Casa _unaC = (Casa)Session["Casa"];

            //Trato de eliminar
            if (_inmo.Eliminar(_unaC))
            {
                lblError.Text = "Eliminación con éxito";
                this.LimpioFormulario();
            }
            else
                lblError.Text = "error";
        }
        catch (Exception)
        {
            throw;
        }
    }

    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        this.LimpioFormulario();
    }
}