using System;
using System.Collections.Generic;
using System.Text;

namespace ProcesadorDeEventos.Interfaces
{
    public interface ICreadorMensajeTiempo
    {
        string CrearMensajeTiempo(DateTime date, DateTime hoy);
    }
}
