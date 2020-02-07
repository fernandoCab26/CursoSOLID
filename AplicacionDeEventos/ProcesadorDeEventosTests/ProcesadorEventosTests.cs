using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProcesadorDeEventos;
using ProcesadorDeEventos.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProcesadorDeEventos.Tests
{
    [TestClass()]
    public class ProcesadorEventosTests
    {

        [TestMethod]
        [DataRow(new string[] { "Navidad, 25/05/2019" }, 1)]
        [DataRow(new string[] { "Navidad, 25/05/2019", "Año nuevo, 31 / 12 / 2020" }, 2)]
        [DataRow(new string[] { "" }, 0)]
        public void ProcesarEventos_LectorDevuelveTexto_DevuelveMensaje(string[] contenidoArchivo, int expected )
        {
            //Arrange
            Mock<ILectorArchivos> lectorArchivosMock = new Mock<ILectorArchivos>();
            lectorArchivosMock.Setup(m => m.ObtenerContenido()).Returns(contenidoArchivo);
            Mock<IComparadorFechas> comparadorFechasMock = new Mock<IComparadorFechas>();
            Mock<IConvertidorFechas> convertidirFechasMock = new Mock<IConvertidorFechas>();
            ProcesadorEventos SUT = new ProcesadorEventos(lectorArchivosMock.Object, comparadorFechasMock.Object, convertidirFechasMock.Object);
            //Act
            List<string> act = SUT.ProcesarEventos();
            //Assert
            Assert.AreEqual(expected, act.Count);
        }


        [TestMethod]
        public void ProcesarEventos_LectorDevulveTexto_FormatoMenajeCorrecto()
        {
            //Arrange
            string expected = "Navidad ocurrió hace dos meses";
            string[] contenidoArchivo = new string[] { "Navidad, 25/12/2019" };
            Mock<ILectorArchivos> lectorArchivosMock = new Mock<ILectorArchivos>();
            Mock<IComparadorFechas> comparadorFechasMock = new Mock<IComparadorFechas>();
            Mock<IConvertidorFechas> convertidirFechasMock = new Mock<IConvertidorFechas>();

            lectorArchivosMock.Setup(m => m.ObtenerContenido()).Returns(contenidoArchivo);
            comparadorFechasMock.Setup(m => m.CompararFechaActual(It.IsAny<DateTime>())).Returns("ocurrió hace dos meses");

            ProcesadorEventos SUT = new ProcesadorEventos(lectorArchivosMock.Object, comparadorFechasMock.Object, convertidirFechasMock.Object);
            //Act
            List<string> act = SUT.ProcesarEventos();
            //Assert
            Assert.AreEqual(expected, act[0]);
        }


    }
}