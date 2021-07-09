using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using Bogus;
using MODEL;
namespace NutriwellnessTests
{
    public class Fakers
    {
        public static Usuario UsuarioFaker(bool existente=false)
        {
            GeneroFaker(true);
            var Faker = new Faker<MODEL.Usuario>()
                .RuleFor(u => u.nombre, fk => fk.Person.FirstName)
                .RuleFor(u => u.aPaterno, fk => fk.Person.LastName)
                .RuleFor(u => u.aMaterno, fk => fk.Person.LastName)
                .RuleFor(u => u.correo, fk => fk.Person.Email)
                .RuleFor(u => u.telefono, fk => fk.Person.Phone)
                .RuleFor(u => u.nacimiento, fk => fk.Person.DateOfBirth)
                .RuleFor(u => u.contrasena, fk => fk.Person.UserName)
                .RuleFor(u => u.Genero, fk => fk.PickRandom<Genero>());
            var Nuevousuario = Faker.Generate();
            if (existente)
            {
                MODEL.UsuarioModel.InsertarUsuario(Nuevousuario);
                Nuevousuario = MODEL.UsuarioModel.BuscarUsuarioCriterios(Nuevousuario.correo,true)[0];
            }
            return Nuevousuario;
        }

        public static Genero GeneroFaker(bool existente = false)
        {
            var Faker = new Faker<MODEL.Genero>()
                .RuleFor(g => g.genero1, fk => fk.Person.FullName);
            var Genero = Faker.Generate();
            if (existente)
            {
                Genero = MODEL.GeneroModel.InsertarGenero(Genero);
            }

            return Genero;
        }
    }
}
