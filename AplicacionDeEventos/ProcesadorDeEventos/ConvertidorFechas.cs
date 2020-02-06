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
            DateTime date = new DateTime();
            try
            {
                date = Convert.ToDateTime(fecha);

            }
            catch (Exception ex)
            {
                throw new Exception("El formato de fecha es incorrecto: " + ex.Message);
            }

            return date;
        }
    }
}
