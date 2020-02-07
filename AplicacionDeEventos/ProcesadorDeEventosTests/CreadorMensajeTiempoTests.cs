using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProcesadorDeEventos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProcesadorDeEventos.Tests
{
    [TestClass()]
    public class CreadorMensajeTiempoTests
    {

        [TestMethod]
        [DataRow("06/02/2020 00:20:30", "06/02/2020 00:40:30", 20)]
        [DataRow("06/02/2020 00:40:30", "06/02/2020 00:15:30", 25)]
        [DataRow("06/02/2020 00:00:30", "06/02/2020 00:59:30", 59)]
        public void CrearMensajeTiempo_DifEnMinutos_DevuelveMensajeMinutos(string sfechaEvento, string sfechaActual , int diferencia )
        {
            //Arrange
            string expected = diferencia+ " minutos.";
            DateTime fechaEvento = DateTime.Parse(sfechaEvento);
            DateTime fechaActual = DateTime.Parse(sfechaActual);
            CreadorMensajeTiempo creadorMensajeTiempo = new CreadorMensajeTiempo();
            //Act
            string act = creadorMensajeTiempo.CrearMensajeTiempo(fechaEvento,fechaActual);
            //Assert
            Assert.AreEqual(expected, act);
        }


        [TestMethod]
        [DataRow("06/02/2020 01:20:30", "06/02/2020 02:40:30", 1)]
        [DataRow("06/02/2020 01:40:30", "06/02/2020 03:40:30", 2)]
        [DataRow("07/02/2020 00:00:00", "06/02/2020 00:00:01", 23)]
        public void CrearMensajeTiempo_DifEnHoras_DevuelveMensajeHoras(string sfechaEvento, string sfechaActual, int diferencia)
        {
            //Arrange
            string expected = diferencia + " horas.";
            DateTime fechaEvento = DateTime.Parse(sfechaEvento);
            DateTime fechaActual = DateTime.Parse(sfechaActual);
            CreadorMensajeTiempo creadorMensajeTiempo = new CreadorMensajeTiempo();
            //Act
            string act = creadorMensajeTiempo.CrearMensajeTiempo(fechaEvento, fechaActual);
            //Assert
            Assert.AreEqual(expected, act);
        }

        [TestMethod]
        [DataRow("07/02/2020 00:00:00", "06/02/2020 00:00:00", 1)]
        [DataRow("08/02/2020 04:40:30", "06/02/2020 03:40:30", 2)]
        [DataRow("01/03/2020 00:00:00", "31/03/2020 00:00:00", 30)]
        public void CrearMensajeTiempo_DifEnDias_DevuelveMensajeDias(string sfechaEvento, string sfechaActual, int diferencia)
        {
            //Arrange
            string expected = diferencia + " días.";
            DateTime fechaEvento = DateTime.Parse(sfechaEvento);
            DateTime fechaActual = DateTime.Parse(sfechaActual);
            CreadorMensajeTiempo creadorMensajeTiempo = new CreadorMensajeTiempo();
            //Act
            string act = creadorMensajeTiempo.CrearMensajeTiempo(fechaEvento, fechaActual);
            //Assert
            Assert.AreEqual(expected, act);
        }

        [TestMethod]
        [DataRow("07/03/2020 00:00:00", "06/04/2020 00:00:00", 1)]
        [DataRow("08/04/2020 04:40:30", "06/02/2020 03:40:30", 2)]
        [DataRow("01/03/2021 00:00:00", "31/03/2020 00:00:00", 12)]
        public void CrearMensajeTiempo_DifEnMeses_DevuelveMensajeMeses(string sfechaEvento, string sfechaActual, int diferencia)
        {
            //Arrange
            string expected = diferencia + " meses.";
            DateTime fechaEvento = DateTime.Parse(sfechaEvento);
            DateTime fechaActual = DateTime.Parse(sfechaActual);
            CreadorMensajeTiempo creadorMensajeTiempo = new CreadorMensajeTiempo();
            //Act
            string act = creadorMensajeTiempo.CrearMensajeTiempo(fechaEvento, fechaActual);
            //Assert
            Assert.AreEqual(expected, act);
        }


        [TestMethod]
        public void CrearMensajeTiempo_FechaEventoInvalida_LanzaExcepcion()
        {
            //Arrange
            DateTime fechaEvento = new DateTime();
            DateTime fechaActual = DateTime.Now;
            CreadorMensajeTiempo creadorMensajeTiempo = new CreadorMensajeTiempo();
            //Act
            //Assert
            Assert.ThrowsException<ArgumentException>(() => creadorMensajeTiempo.CrearMensajeTiempo(fechaEvento, fechaActual));
        }

        [TestMethod]
        public void CrearMensajeTiempo_FechaEventoInvalida_DevuelveMensajeEnExcepcion()
        {
            //Arrange
            string message = "El formato de fecha es inválido";
            DateTime fechaEvento = new DateTime();
            DateTime fechaActual = DateTime.Now;
            CreadorMensajeTiempo creadorMensajeTiempo = new CreadorMensajeTiempo();
            //Act
            //Assert
            ArgumentException exception= Assert.ThrowsException<ArgumentException>(() => creadorMensajeTiempo.CrearMensajeTiempo(fechaEvento, fechaActual));
            Assert.AreEqual(message, exception.Message);
        }

        [TestMethod]
        public void CrearMensajeTiempo_FechaActualInvalida_LanzaExcepcion()
        {
            //Arrange
            DateTime fechaActual = new DateTime();
            DateTime fechaEvento = DateTime.Now;
            CreadorMensajeTiempo creadorMensajeTiempo = new CreadorMensajeTiempo();
            //Act
            //Assert
            Assert.ThrowsException<ArgumentException>(() => creadorMensajeTiempo.CrearMensajeTiempo(fechaEvento, fechaActual));
        }

        [TestMethod]
        public void CrearMensajeTiempo_FechaActualInvalida_DevuelveMensajeEnExcepcion()
        {
            //Arrange
            string message = "El formato de fecha es inválido";
            DateTime fechaEvento = new DateTime();
            DateTime fechaActual = DateTime.Now;
            CreadorMensajeTiempo creadorMensajeTiempo = new CreadorMensajeTiempo();
            //Act
            //Assert
            ArgumentException exception = Assert.ThrowsException<ArgumentException>(() => creadorMensajeTiempo.CrearMensajeTiempo(fechaEvento, fechaActual));
            Assert.AreEqual(message, exception.Message);
        }
    }
}