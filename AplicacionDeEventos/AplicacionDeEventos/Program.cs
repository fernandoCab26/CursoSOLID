using Microsoft.Extensions.DependencyInjection;
using ProcesadorDeEventos;
using ProcesadorDeEventos.Interfaces;
using System;

namespace AplicacionDeEventos
{
    class Program
    {

        static void Main(string[] args)
        {
            try
            {
                IProcesadorEventos procesador = CrearDependencias().GetService<IProcesadorEventos>();

                foreach (string mensaje in procesador.ProcesarEventos())
                {
                    Console.WriteLine(mensaje);   
                }
                
            }
            catch(Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ha ocurrido un error:" + ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        protected static IServiceProvider CrearDependencias()
        {
            //setup our DI
            IServiceProvider serviceProvider = new ServiceCollection()
                .AddSingleton<IComparadorFechas, ComparadorFechas>()
                .AddSingleton<IConvertidorFechas, ConvertidorFechas>()
                .AddSingleton<ILectorArchivos, LectorArchivos>()
                .AddSingleton<ICreadorMensajeTiempo, CreadorMensajeTiempo>()
                .AddSingleton<IProcesadorEventos, ProcesadorEventos>()
                .BuildServiceProvider();

            return serviceProvider;
        }
    }
}
