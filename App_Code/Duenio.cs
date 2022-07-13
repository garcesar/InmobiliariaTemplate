using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;


public class Duenio
{
    //Atributos
    private int _Ci;
    private string _Nombre;
    

    //Propiedades
    public int CI
    {
        set
        {
            if (value <= 0)
                throw new Exception("CI invalida");
            else
                _Ci = value;
        }
        get { return _Ci; }
    }

    public string Nombre
    {
        set { _Nombre = value; }
        get { return _Nombre; }
    }



    //Cosntructores
    public Duenio()
    {
        _Ci = 1000;
        _Nombre = "<Sin Nombre>";
    }

    public Duenio(int cedula, string nombre)
    {
        _Ci = cedula;
        _Nombre = nombre;
    }


    //Operaciones
    public override string ToString()
    {
        return (Nombre + " - " + CI);
    }

}