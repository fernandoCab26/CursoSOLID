using ProcesadorDeEventos.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProcesadorDeEventos
{
    public class ConvertidorFechas : IConvertidorFechas
    {
        public DateTime ConvertirFecha(string fecha)
        {
            DateTime date;
            try
            {
                date = Convert.ToDateTime(fecha);

            }
            catch (Exception ex)
            {
                throw new ArgumentException("El formato de fecha es incorrecto: " + ex.Message);
            }

            return date;
        }
    }
}
