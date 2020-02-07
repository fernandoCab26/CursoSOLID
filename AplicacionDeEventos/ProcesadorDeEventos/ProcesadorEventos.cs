using ProcesadorDeEventos.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

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

        public List<string> ProcesarEventos()
        {
            List<string> mensajes = new List<string>();
            string[] contenido = _lectorArchivos.ObtenerContenido();

            foreach (string linea in contenido)
            {
                if (!string.IsNullOrWhiteSpace(linea))
                { 
                    string[] splitLine = linea.Split(',');
                    string evento = splitLine[0];
                    string fecha = splitLine[1];

                    mensajes.Add(CrearMensaje(fecha, evento));
                }
            }

            return mensajes;
        }
        protected string CrearMensaje(string fecha, string evento)
        {

            DateTime date = _convertidorFechas.ConvertirFecha(fecha);

            return string.Format("{0} {1}", evento.Trim(), _comparadorFechas.CompararFechaActual(date));
        }

    }
}
