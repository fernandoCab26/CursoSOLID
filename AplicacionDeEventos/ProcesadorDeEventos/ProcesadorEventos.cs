using ProcesadorDeEventos.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProcesadorDeEventos
{
    public class ProcesadorEventos : IProcesadorEventos
    {

        private readonly ILectorArchivos _lectorArchivos;
        private readonly IComparadorFechas _comparadorFechas;
        private readonly IConvertidorFechas _convertidorFechas;

        public ProcesadorEventos(ILectorArchivos lectorArchivos, IComparadorFechas comparadorFechas, IConvertidorFechas convertidorFechas)
        {
            _lectorArchivos = lectorArchivos;
            _comparadorFechas = comparadorFechas;
            _convertidorFechas = convertidorFechas;
        }

        public void ProcesarEventos()
        {
            int counter = 0;
            string line;

            System.IO.StreamReader file = _lectorArchivos.GetReader();

            while ((line = file.ReadLine()) != null)
            {
                string[] splitLine = line.Split(',');
                string evento = splitLine[0];
                string fecha = splitLine[1];

                Console.WriteLine( CrearMensaje(fecha, evento));

                counter++;
            }
        }
        protected  string CrearMensaje(string fecha, string evento)
        {

            DateTime date = _convertidorFechas.ConvertirFecha(fecha);

            return evento.Trim() + " " +_comparadorFechas.CompararFechas(date);
        }

    }
}
