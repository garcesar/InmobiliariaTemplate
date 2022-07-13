using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;


public class Inmobiliaria
{
    //Atributos
    string mNombre;
    List<Vivienda> _ListaViviendas;
    List<Duenio> _ListaDuenios;


    //Propiedades
    public string Nombre
    {
        set { mNombre = value; }
        get { return mNombre; }
    }


    //Constructores
       public Inmobiliaria(string nom)
    {
        mNombre = nom;
        _ListaViviendas = new List<Vivienda>();
        _ListaDuenios = new List<Duenio>();
    }



    //Operaciones  - Vivienda
    public Vivienda Buscar(int padron)
    {
        foreach (Vivienda V in _ListaViviendas)
        {
            if (V.Padron == padron)
                return (V);
        }
        return null;
    }

    public bool Agregar(Vivienda unaVivienda)
    {
        if (Buscar(unaVivienda.Padron) == null)
        {
            _ListaViviendas.Add(unaVivienda);
            return(true);
        }
        
        return (false);
    }

    public bool Eliminar(Vivienda unaVivienda)
    {
        return _ListaViviendas.Remove(unaVivienda);
    }

    public bool Modificar(Vivienda unaVivienda)
    {
        if (Eliminar(unaVivienda))
        {
            Agregar(unaVivienda);
            return (true);
        }

        return (false);
    }

    public List<Vivienda> ListaViviendas()
    {
        return _ListaViviendas;
    }

      
    
    //Operaciones Clientes
    public Duenio BuscarD(int cedula)
    {
        foreach (Duenio unD in _ListaDuenios)
        {
            if (unD.CI == cedula)
                return (unD);
        }
        return(null);
    }

    public bool Agregar(Duenio unD)
    {
        if (BuscarD(unD.CI) == null)
        {
            _ListaDuenios.Add(unD);
            return(true);
        }
        return (false);
    }

    public bool Eliminar(Duenio unD)
    {
        return (_ListaDuenios.Remove(unD));
    }

    public bool Modificar(Duenio unD)
    {
        if (Eliminar(unD))
            return (Agregar(unD));
        else
            return false;
    }

    public List<Duenio> ListaDuenios()
    {
        return _ListaDuenios;
    }

}