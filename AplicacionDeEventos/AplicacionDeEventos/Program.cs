using ProcesadorDeEventos;
using System;

namespace AplicacionDeEventos
{
    class Program
    {

        static void Main(string[] args)
        {
            ProcesadorEventos procesador = new ProcesadorEventos();
            procesador.ProcesarEvento();
        }
    }
}
