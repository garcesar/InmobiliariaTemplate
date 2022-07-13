using System;
using System.Collections.Generic;
using System.Text;

public class Apartamento : Vivienda
{
    //Atributos
    private bool _Portero;
    private int _Piso;
    private double _GComunes;



    //Propiedades
    public int Piso
    {
        set
        {
            if (value >= 0)
                _Piso = value;
            else
                throw new Exception("No hay pisos por debajo de la PB");
        }
        get { return _Piso; }
    }

    public bool Portero
    {
        set { _Portero = value; }
        get { return _Portero; }
    }

    public double GComunes
    {
        set
        {
            if (value <= 0)
                throw new Exception("No se le pagan los Gastos Comunes al Inquilino");
            else
                _GComunes = value;
        }
        get { return _GComunes; }
    }

    

    //Constructores
    public Apartamento(int pPadron, string pDir, DateTime pFecha, double pAlquiler, bool pPortero, int pPiso, double pGastos, Duenio unD)
        : base(pPadron, pDir, pFecha, pAlquiler, unD)
    {
        Portero = pPortero;
        Piso = pPiso;
        GComunes = pGastos;
    }

    

    //Operaciones
    public override string ToString()
    {
        string _completo = base.ToString() + " - Piso: " + _Piso + " - ";

        if (_Portero)
            _completo += " Portero";
        else
            _completo += " Sin Portero";

        return (_completo);
    }

    public override double AlquilerAnual()
    {
        return ((base.Alquiler + GComunes) * 12);
    }
  
}
