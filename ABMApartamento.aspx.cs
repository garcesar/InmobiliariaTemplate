using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ABMApartamento : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Inmo"] == null)
            Response.Redirect("~/Default.aspx");

        if (!IsPostBack)
            this.LimpioFormulario();

        if(((Inmobiliaria)Session["Inmo"]).ListaDuenios().Count == 0)
        {
            lblError.Text = "No hay Dueños - No se puede trabajar con Aptos";
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
        chkPortero.Checked = false;
        txtPiso.Text = "0";
        TxtGastosComunes.Text = "0";
        textDuenioCedula.Text = "";
        lblDuenio.Text = "";
        lblError.Text = "";
    }

    protected void BtnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            Inmobiliaria _inmo = (Inmobiliaria)Session["Inmo"];

            //Busco Apto
            int _padron = Convert.ToInt32(txtPadron.Text);
            Vivienda _objeto = _inmo.Buscar(_padron);

            //Determino acciones
            if (_objeto == null)
            {
                //Alta
                this.ActivoBotonesA();
                Session["Apto"] = _objeto;
                Session["Duenio"] = null;
                lblError.Text = "No existe un apto con ese padron";
            }
            else if (_objeto is Casa)
                throw new Exception("El padron pertenece a una Casa - Error");
            else
            {
                this.ActivoBotonesBM();

                Session["Apto"] = _objeto;
                Session["Duenio"] = _objeto.Dueño;

                txtDireccion.Text = _objeto.Direccion;
                Calendar.SelectedDate = _objeto.FechaCons;
                Calendar.VisibleDate = _objeto.FechaCons;
                txtAlquiler.Text = _objeto.Alquiler.ToString();
                chkPortero.Checked = ((Apartamento)_objeto).Portero;
                txtPiso.Text = ((Apartamento)_objeto).Piso.ToString();
                TxtGastosComunes.Text = ((Apartamento)_objeto).GComunes.ToString();

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

            Apartamento unApto = new Apartamento(padron, txtDireccion.Text, Calendar.SelectedDate, Convert.ToDouble(txtAlquiler.Text), chkPortero.Checked,
                Convert.ToInt32(txtPiso.Text), Convert.ToDouble(TxtGastosComunes.Text), _und);

            //Trato de agregar
            if( unaInmo.Agregar(unApto))
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
            Apartamento _unA = (Apartamento)Session["Apto"];
            Duenio _und = (Duenio)Session["Duenio"];

            //Verifico que tenga un dueño
            if (_und == null)
                throw new Exception("Debe seleccionar Dueño");

            //Modificar el obj
            _unA.Direccion = txtDireccion.Text.Trim();
            _unA.FechaCons = Calendar.SelectedDate;
            _unA.Alquiler = Convert.ToDouble(txtAlquiler.Text);
            _unA.Portero = chkPortero.Checked;
            _unA.Piso = Convert.ToInt32(txtPiso.Text);
            _unA.GComunes = Convert.ToDouble(TxtGastosComunes.Text);
            _unA.Dueño = _und;

            //Trato de modificar
            if (_inmo.Modificar(_unA))
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
            Apartamento _unA = (Apartamento)Session["Apto"];

            //Trato de eliminar
            if (_inmo.Eliminar(_unA))
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