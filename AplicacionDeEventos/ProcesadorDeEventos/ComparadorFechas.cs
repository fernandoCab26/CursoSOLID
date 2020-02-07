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
        public string CompararFechaActual(DateTime date)
        {
            if( date== DateTime.MinValue)
            {
                throw new ArgumentException("El formato de fecha es inválido");
            }
            string mensajeTiempo = string.Empty;
            DateTime hoy = DateTime.Now;

            int comparator = DateTime.Compare(date, hoy);

            if (comparator < 0)
            {
                mensajeTiempo =  string.Format("{0} {1}", Ocurrio, _creadorMensaje.CrearMensajeTiempo(date, hoy));
            }
            else
            {

                mensajeTiempo = string.Format("{0} {1}", Ocurrira , _creadorMensaje. CrearMensajeTiempo(date, hoy));
            }

            return mensajeTiempo;
        }
    }
}
