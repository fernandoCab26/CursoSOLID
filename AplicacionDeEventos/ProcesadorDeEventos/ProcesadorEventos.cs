using System;
using System.Collections.Generic;
using System.Text;

namespace ProcesadorDeEventos
{
    public class ProcesadorEventos
    {
        private const string Ocurrio = "ocurrió hace";
        private const string Ocurrira = "ocurrirá en";
        private string RutaEventos = AppDomain.CurrentDomain.BaseDirectory +"Eventos.txt";
        public void ProcesarEvento()
        {
            int counter = 0;
            string line;

            System.IO.StreamReader file = new System.IO.StreamReader(@RutaEventos);

            while ((line = file.ReadLine()) != null)
            {
                string[] splitLine = line.Split(',');
                string evento = splitLine[0];
                string fecha = splitLine[1];

                Console.WriteLine(CrearMensaje(fecha, evento));

                counter++;
            }
        }
        protected  string CrearMensaje(string fecha, string evento)
        {
            DateTime date = ConvertirFecha(fecha);

            return evento.Trim() + " " + ComparadorFechas(date);
        }

        protected  DateTime ConvertirFecha(string fecha)
        {
            DateTime date = new DateTime();
            try
            {
                date = Convert.ToDateTime(fecha);

            }
            catch (Exception ex)
            {
                Console.WriteLine("El formato de fecha es incorrecto:", ex.Message);
            }

            return date;
        }

        protected string ComparadorFechas(DateTime date)
        {
            string mensajeTiempo = string.Empty;
            DateTime hoy = DateTime.Now;

            int comparator = DateTime.Compare(date, hoy);

            if (comparator < 0)
            {
                mensajeTiempo = Ocurrio + CrearMensajeTiempo(date, hoy);
            }
            else if (comparator == 0)
            {
                //la fecha es igual
            }
            else
            {

                mensajeTiempo = Ocurrira + CrearMensajeTiempo(date, hoy);
            }

            return mensajeTiempo;
        }

        protected string CrearMensajeTiempo(DateTime date, DateTime hoy)
        {
            string mensajeTiempo = string.Empty;


            int difMinutos = Math.Abs((date - hoy).Minutes);
            int difHoras = Math.Abs((date - hoy).Hours); 
            int difDias = Math.Abs((date - hoy).Days);
            int difMeses = Math.Abs((date.Month - hoy.Month) + 12 * (date.Year - hoy.Year));

            if (difMinutos < 60)
            {
                mensajeTiempo = $" { difMinutos} minutos.";
            }
            if (difHoras < 24 && difHoras != 0)
            {
                mensajeTiempo = $" { difHoras} horas.";
            }
            if (difDias < 30 && difDias != 0)
            {
                mensajeTiempo = $" { difDias} días.";
            }
            if (difMeses != 0)
            {
                mensajeTiempo = $" {difMeses} meses.";
            }

            return mensajeTiempo;

        }
    }
}
