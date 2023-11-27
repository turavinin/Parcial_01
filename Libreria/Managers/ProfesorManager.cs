using Dapper;
using Libreria.Entidades;
using Libreria.Entidades.Filters;
using Libreria.Exceptions.Enums;
using Libreria.Exceptions;
using Libreria.Managers.Interface;
using Libreria.Repositorios;
using Libreria.Repositorios.Interface;
using System.Data.SqlClient;
using System.Text;

namespace Libreria.Managers
{
    public class ProfesorManager : IProfesorManager
    {
        private readonly IProfesorRepositorio _profesorRepositorio;
        public ProfesorManager()
        {
            _profesorRepositorio = new ProfesorRepositorio();
        }

        public List<Profesor> Get()
        {
            return _profesorRepositorio.Get();
        }

        public Profesor Get(int id)
        {
            return _profesorRepositorio.Get(new ProfesorFilters { Id = id}).FirstOrDefault();
        }

        public void Delete(int id)
        {
            _profesorRepositorio.Delete(id);
        }

        public void Create(Profesor profesor)
        {
            MailValido(profesor);

            _profesorRepositorio.Create(profesor);
        }

        public void Update(Profesor profesor)
        {
            MailValido(profesor, true);

            _profesorRepositorio?.Update(profesor);
        }

        public void AsignarCursos(Profesor profesor)
        {
            _profesorRepositorio.DeleteCursoProfesor(profesor.Id);

            if (profesor.Cursos != null && profesor.Cursos.Count > 0)
            {
                foreach (var curso in profesor.Cursos)
                {
                    _profesorRepositorio.AsignarCursos(profesor.Id, curso.Id);
                }
            }
        }

        private void MailValido(Profesor profesor, bool esEditar = false)
        {
            var profesores = _profesorRepositorio.Get(new ProfesorFilters { Email = profesor.Email });

            if ((profesores.Count > 0 && !esEditar) || (profesores.Count > 0 && esEditar && profesores.FirstOrDefault().Id != profesor.Id))
            {
                var tipoError = esEditar ? TipoError.ErrorEditarProfesor : TipoError.ErrorCrearProfesor;
                throw new ExceptionsInternas("Email repetido", tipoError);
            }
        }
    }
}
