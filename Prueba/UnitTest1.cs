using System;
using Xunit;
using CONTROLLER;
using VIEW;
using MODEL;
namespace Prueba
{
    public class UnitTest1
    {
        [Fact]
        public void CalcularEdad()
        {
            //Arrange
            var fechaNamiento = new DateTime(1998, 09, 26);

            //Act
            int edad = UsuarioControlador.CalculateAge(fechaNamiento);


            //Assert
            Assert.Equal(23,edad);
        }
    }
}
