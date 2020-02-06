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
            IProcesadorEventos procesador = CrearDependencias().GetService<IProcesadorEventos>();

            procesador.ProcesarEventos();
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
