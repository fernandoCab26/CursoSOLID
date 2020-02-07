using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProcesadorDeEventos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProcesadorDeEventos.Tests
{
    [TestClass()]
    public class ConvertidorFechasTests
    {

        [TestMethod]
        [DataRow("20.19.2019")]
        [DataRow("formatoInvalido")]
        [DataRow("2343211")]
        public void ConvertirFecha_FormatoInvalido_LanzarExcepcion(string formatoInvalido)
        {
            //Arrange
            ConvertidorFechas sut = new ConvertidorFechas();
            //Act
            //Assert
            Assert.ThrowsException<ArgumentException>(() => sut.ConvertirFecha(formatoInvalido));
        }


        [TestMethod]
        [DataRow("20.19.2019")]
        [DataRow("formatoInvalido")]
        [DataRow("2343211")]
        public void ConvertirFecha_FormatoInvalid_DevuelveMensajeEnExcepcion(string formatoInvalido)
        {
            //Arrange
            string expected = "El formato de fecha es incorrecto:";
            ConvertidorFechas sut = new ConvertidorFechas();
            //Act
            //Assert
            ArgumentException exception = Assert.ThrowsException<ArgumentException>(() => sut.ConvertirFecha(formatoInvalido));
            Assert.IsTrue(exception.Message.Contains(expected));
        }


        [TestMethod]
        public void ConvertirFecha_FormatoCorrecto_DevuelveFecha()
        {
            //Arrange
            DateTime someDate = new DateTime(2020, 02,06);
            ConvertidorFechas sut = new ConvertidorFechas();
            //Act
          DateTime act=  sut.ConvertirFecha(someDate.ToString());
            //Assert
            Assert.AreEqual(someDate, act);
        }

    }
}