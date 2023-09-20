using Libreria.Entidades;
using Libreria.Exceptions;
using Libreria.Exceptions.Enums;
using Libreria.Helpers;
using Libreria.Repositorios;

namespace Libreria.Managers
{
    public class AdministracionManager
    {
        private EstudianteRepositorio _estudianteRepositorio;
        private AdministradorRepositorio _administradorRepositorio;
        private CursoRepositorio _cursoRepositorio;

        private Estudiante _estudiante;
        private Administrador _administrador;

        private EmailHelper _emailHelper;

        public AdministracionManager()
        {
            _estudianteRepositorio = new EstudianteRepositorio();
            _administradorRepositorio = new AdministradorRepositorio();
            _cursoRepositorio = new CursoRepositorio();
            _emailHelper = new EmailHelper();
        }

        public bool LoginUsuario(string usuario, string clave, bool isAdmin)
        {
            if (isAdmin)
            {
                return LoginAdministrador(usuario, clave);
            }

            return LoginEstudiante(usuario, clave);
        }

        public bool RegistrarEstudiante(Estudiante estudiante)
        {
            _administrador.AsginarLegajoEstudiante(estudiante);

            if (!estudiante.Validar())
            {
                throw new ExceptionsInternas(estudiante.ErroresValidacion, TipoError.ErrorCrearUsuario);
            }

            _estudianteRepositorio.Post(estudiante);
            _emailHelper.EnviarEmail(estudiante.Email, $"Estudiante creado. Legajo: {estudiante.Legajo}");

            return true;
        }

        #region Cursos
        public List<Curso>? GetCursos()
        {
            return _cursoRepositorio.Get();
        } 

        public bool CrearCurso(Curso curso)
        {
            // Validar curso contra base

            _cursoRepositorio.Post(curso);
            return true;
        }

        public bool EliminarCurso(string codigo)
        {
            _cursoRepositorio.Delete(codigo);
            return true;
        }
        #endregion

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
