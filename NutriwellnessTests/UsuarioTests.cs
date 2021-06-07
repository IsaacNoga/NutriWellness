using System;
using Xunit;
using Moq;
using Bogus;
using CONTROLLER;
using MODEL;
namespace NutriwellnessTests
{
    public class UnitTest1
    {
        [Fact]
        public void InsertarUnUsuario()
        {
            var Usuario = Fakers.UsuarioFaker();
            CONTROLLER.UsuarioControlador.InsertarUsuario(Usuario);

            Assert.True(ComprobarUsuarioExiste(Usuario));
        }

        private Boolean ComprobarUsuarioExiste(Usuario ComprobarUsuario) 
        {
            var UsuarioExistente = MODEL.UsuarioModel.BuscarUsuarioCriterios(ComprobarUsuario.correo,true)[0];
            if( UsuarioExistente.nombre == ComprobarUsuario.nombre && UsuarioExistente.nacimiento == ComprobarUsuario.nacimiento &&
                UsuarioExistente.telefono == ComprobarUsuario.telefono && UsuarioExistente.aMaterno == ComprobarUsuario.aMaterno &&
                UsuarioExistente.aPaterno == ComprobarUsuario.aPaterno && UsuarioExistente.contrasena == ComprobarUsuario.contrasena &&
                UsuarioExistente.correo == ComprobarUsuario.correo && UsuarioExistente.Genero == ComprobarUsuario.Genero)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}
