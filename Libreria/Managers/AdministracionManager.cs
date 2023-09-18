using Libreria.Entidades;
using Libreria.Repositorios;

namespace Libreria.Managers
{
    public class AdministracionManager
    {
        private EstudianteRepositorio _estudianteRepositorio;
        private AdministradorRepositorio _administradorRepositorio;
        private Estudiante _estudiante;
        private Administrador _administrador;

        public AdministracionManager()
        {
            _estudianteRepositorio = new EstudianteRepositorio();
            _administradorRepositorio = new AdministradorRepositorio();
        }

        public bool LoginUsuario(string usuario, string clave, bool isAdmin)
        {
            if (isAdmin)
            {
                return LoginAdministrador(usuario, clave);
            }

            return LoginEstudiante(usuario, clave);
        }

        #region Private
        private bool LoginAdministrador(string correo, string clave)
        {
            _administrador = _administradorRepositorio.Get(correo, clave);

            if (_administrador == null)
            {
                return false;
            }

            return true;
        }

        private bool LoginEstudiante(string legajo, string clave)
        {
            _estudiante = _estudianteRepositorio.Get(legajo, clave);

            if(_estudiante == null)
            {
                return false;
            }

            return true;
        }
        #endregion
    }
}
