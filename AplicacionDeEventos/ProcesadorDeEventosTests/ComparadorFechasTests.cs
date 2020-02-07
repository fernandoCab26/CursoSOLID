using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProcesadorDeEventos.Interfaces;
using System;

namespace ProcesadorDeEventos.Tests
{
    [TestClass()]
    public class ComparadorFechasTests
    {
        [TestMethod]
        public void CompararFechaActual_FechaEventoMenorActual_DevulveMensajeocurrio()
        {
            //Arrange
            string mensaje = "mensajeTiempo";
            string expected = "ocurrió hace " + mensaje;
            Mock<ICreadorMensajeTiempo> creadorMensajetiempoMock = new Mock<ICreadorMensajeTiempo>();
            creadorMensajetiempoMock.Setup(m => m.CrearMensajeTiempo(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(mensaje);
            ComparadorFechas comparadorFechas = new ComparadorFechas(creadorMensajetiempoMock.Object);
            DateTime fechaEvento = DateTime.Now.AddDays(-1);

            //Act
            string act = comparadorFechas.CompararFechaActual(fechaEvento);
            //Assert
            Assert.AreEqual(expected, act);
        }

        [TestMethod]
        public void CompararFechaActual_FechaEventoMayorActual_DevulveMensajeOcurrira()
        {
            //Arrange
            string mensaje = "mensajeTiempo";
            string expected = "ocurrirá en " + mensaje;
            Mock<ICreadorMensajeTiempo> creadorMensajetiempoMock = new Mock<ICreadorMensajeTiempo>();
            creadorMensajetiempoMock.Setup(m => m.CrearMensajeTiempo(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(mensaje);
            ComparadorFechas comparadorFechas = new ComparadorFechas(creadorMensajetiempoMock.Object);
            DateTime fechaEvento = DateTime.Now.AddDays(+1);

            //Act
            string act = comparadorFechas.CompararFechaActual(fechaEvento);
            //Assert
            Assert.AreEqual(expected, act);
        }


        [TestMethod]
        public void CompararFechaActual_FechaEventoInvalida_LanzaExcepcion()
        {
            //Arrange
            DateTime fechaEvento = new DateTime();
            Mock<ICreadorMensajeTiempo> creadorMensajetiempoMock = new Mock<ICreadorMensajeTiempo>();
            ComparadorFechas comparadorFechas = new ComparadorFechas(creadorMensajetiempoMock.Object);
            //Act
            //Assert
            Assert.ThrowsException<ArgumentException>(() => comparadorFechas.CompararFechaActual(fechaEvento));
        }


        [TestMethod]
        public void CompararFechaActual_FechaEventoInvalida_DevuelveMensajeEnExcepcion()
        {
            //Arrange
            string expected = "El formato de fecha es inválido";
            DateTime fechaEvento = new DateTime();
            Mock<ICreadorMensajeTiempo> creadorMensajetiempoMock = new Mock<ICreadorMensajeTiempo>();
            ComparadorFechas comparadorFechas = new ComparadorFechas(creadorMensajetiempoMock.Object);
            //Act
            //Assert
            ArgumentException exception = Assert.ThrowsException<ArgumentException>(() => comparadorFechas.CompararFechaActual(fechaEvento));
            Assert.AreEqual(expected, exception.Message);
        }
    }
}