using ProcesadorDeEventos.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
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

                StreamReader file = _lectorArchivos.GetReader();

                while ((line = file.ReadLine()) != null)
                {
                    try
                    {

                        string[] splitLine = line.Split(',');
                        string evento = splitLine[0];
                        string fecha = splitLine[1];

                        Console.WriteLine(CrearMensaje(fecha, evento));


                        counter++;
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ha ocurrido un error:" + ex.Message);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                }

        }
        protected  string CrearMensaje(string fecha, string evento)
        {

            DateTime date = _convertidorFechas.ConvertirFecha(fecha);

            return string.Format("{0} {1}", evento.Trim() ,_comparadorFechas.CompararFechaActual(date));
        }

    }
}
