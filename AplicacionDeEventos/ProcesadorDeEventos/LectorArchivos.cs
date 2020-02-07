using ProcesadorDeEventos.Interfaces;
using System;
using System.IO;

namespace ProcesadorDeEventos
{
    public class LectorArchivos : ILectorArchivos
    {
        private string RutaEventos = AppDomain.CurrentDomain.BaseDirectory + "Eventos.txt";

        public string[] ObtenerContenido()
        {
            StreamReader file = new StreamReader(RutaEventos);
            var fileContent = file.ReadToEnd().Split(Environment.NewLine,
                              StringSplitOptions.RemoveEmptyEntries);

            return fileContent;
        }
    }
}
