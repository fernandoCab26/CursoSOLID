using ProcesadorDeEventos.Interfaces;
using System;
using System.IO;

namespace ProcesadorDeEventos
{
    public class LectorArchivos : ILectorArchivos
    {
        private string RutaEventos = AppDomain.CurrentDomain.BaseDirectory + "Eventos.txt";
        public StreamReader GetReader()
        {
            return new StreamReader(@RutaEventos);
        }
    }
}
