using System;
using System.Collections.Generic;
using System.Text;


public class Casa : Vivienda
{
    //Atributos
    double _MtFondo;

    //Propiedades
    public double MtFondo
    {
        set
        {
            if (value >= 0)
                _MtFondo = value;
            else
                throw new Exception("Si no tiene Fondo - Metros = 0");
        }
        get { return _MtFondo; }
    }




    //CONTRUCTORES

    public Casa(int pPadron, string pDir, DateTime pFecha, double pAlq, double pMetros, Duenio unD)
        : base(pPadron, pDir, pFecha, pAlq, unD)
    {
        MtFondo = pMetros;
    }



    //Operaciones
    public override string ToString()
    {
        return (base.ToString() + " - Fondo: " + _MtFondo + " mt2");
    }


    public override double AlquilerAnual()
    {
        return Alquiler * 12;
    }

}
