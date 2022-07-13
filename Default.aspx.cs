using System;
using System.Configuration;
using System.Data;
//using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
//using System.Xml.Linq;



public partial class _Default : System.Web.UI.Page 
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Inmo"] == null) //Validamos si la Session tiene almacenada una obj Inmobiliaria
        {
            try
            {
                Inmobiliaria _inm = new Inmobiliaria("Nuestros Hogares");
                Session["Inmo"] = _inm;

                Duenio uno = new Duenio(1, "Jose");
                Duenio dos = new Duenio(2, "Juan");
                Duenio tres = new Duenio(3, "Ana");
                Duenio cuatro = new Duenio(4, "Juana");

                _inm.Agregar(uno);
                _inm.Agregar(dos);
                _inm.Agregar(tres);
                _inm.Agregar(cuatro);

                _inm.Agregar(new Casa(1, "Callejón Diagon", Convert.ToDateTime("01-01-2022"), 900, 250, uno));
                _inm.Agregar(new Casa(2, "Bosque Howart", Convert.ToDateTime("01-01-2022"), 400, 1000, dos));
                _inm.Agregar(new Apartamento(3, "Callejón Diagon", Convert.ToDateTime("01-01-2022"), 1000, false, 3, 150, tres));
                _inm.Agregar(new Apartamento(4, "Callejón Diagon", Convert.ToDateTime("01-01-2022"), 2000, true, 8, 500, cuatro));
            }
            catch (Exception ex)
            {
                //
            }
        }
    }

}
