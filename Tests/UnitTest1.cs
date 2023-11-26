using Libreria.Entidades;
using Libreria.Managers;

namespace Tests
{
    public class UnitTest1
    {
        [Fact]
        public void ValidarEstudianteLoginValido()
        {
            //ARRENGE
            var manager = new AdministracionManager();
            var legajo = "5361";
            var clave = "clave";
            var valido = true;

            //ACT
            var resultado = manager.LoginUsuario(legajo, clave, false);

            //ASSERT
            Assert.Equal(valido, resultado);
        }

        [Fact]
        public void ValidarEstudianteLoginInvalido()
        {
            //ARRENGE
            var manager = new AdministracionManager();
            var legajo = "5361";
            var clave = "claveInvalida";
            var valido = false;

            //ACT
            var resultado = manager.LoginUsuario(legajo, clave, false);

            //ASSERT
            Assert.Equal(valido, resultado);
        }

        [Fact]
        public void ValidarClaveNueva()
        {
            //ARRENGE
            var estudiante = new Estudiante();
            var claveInvalida = " ";
            var valido = false;

            //ACT
            var resultado = estudiante.ClaveValida(claveInvalida);

            //ASSERT
            Assert.Equal(valido, resultado);
        }
    }
}