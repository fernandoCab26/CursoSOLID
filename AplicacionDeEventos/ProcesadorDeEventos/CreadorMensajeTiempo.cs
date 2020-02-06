using ProcesadorDeEventos.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProcesadorDeEventos
{
    public class CreadorMensajeTiempo : ICreadorMensajeTiempo
    {
        public string CrearMensajeTiempo(DateTime date, DateTime hoy)
        {
            if (date == DateTime.MinValue)
            {
                throw new ArgumentException("El formato de fecha es inválido");
            }
            if (hoy == DateTime.MinValue)
            {
                throw new ArgumentException("El formato de fecha es inválido");
            }

            string mensajeTiempo = string.Empty;
            int difMinutos = Math.Abs((date - hoy).Minutes);
            int difHoras = Math.Abs((date - hoy).Hours);
            int difDias = Math.Abs((date - hoy).Days);
            int difMeses = Math.Abs((date.Month - hoy.Month) + 12 * (date.Year - hoy.Year));

            if (difMinutos < 60)
            {
                mensajeTiempo = $"{ difMinutos} minutos.";
            }
            if (difHoras < 24 && difHoras != 0)
            {
                mensajeTiempo = $"{ difHoras} horas.";
            }
            if (difDias < 30 && difDias != 0)
            {
                mensajeTiempo = $"{ difDias} días.";
            }
            if (difMeses != 0)
            {
                mensajeTiempo = $"{difMeses} meses.";
            }

            return mensajeTiempo;
        }
    }
}
