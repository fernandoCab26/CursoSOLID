using ProcesadorDeEventos.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProcesadorDeEventos
{
    public class ComparadorFechas : IComparadorFechas
    {
        private const string Ocurrio = "ocurrió hace";
        private const string Ocurrira = "ocurrirá en";
        ICreadorMensajeTiempo _creadorMensaje;
        public ComparadorFechas(ICreadorMensajeTiempo mensajeTiempo)
        {
            _creadorMensaje = mensajeTiempo;
        }
        public string CompararFechas(DateTime date)
        {
            string mensajeTiempo = string.Empty;
            DateTime hoy = DateTime.Now;

            int comparator = DateTime.Compare(date, hoy);

            if (comparator < 0)
            {
                mensajeTiempo = Ocurrio + _creadorMensaje.CrearMensajeTiempo(date, hoy);
            }
            else if (comparator == 0)
            {
                //la fecha es igual
            }
            else
            {

                mensajeTiempo = Ocurrira + _creadorMensaje. CrearMensajeTiempo(date, hoy);
            }

            return mensajeTiempo;
        }
    }
}
