using Libreria.Entidades;
using Libreria.Entidades.Filters;
using Libreria.Managers.Interface;
using Libreria.Repositorios;
using Libreria.Repositorios.Interface;

namespace Libreria.Managers
{
    public class CursoManager : ICursoManager
    {
        private ICursoRepositorio _cursoRepositorio;
        private IEstudianteManager _estudianteManager;
        private INotificacionesRepositorio _notificacionesRepositorio;

        public CursoManager()
        {
            _cursoRepositorio = new CursoRepositorio();
            _notificacionesRepositorio = new NotificacionesRepositorio();
        }

        public List<Curso> Get()
        {
            return _cursoRepositorio.Get();
        }

        public Curso Get(int id)
        {
            return _cursoRepositorio.Get(new CursoFilters { Id = id }).FirstOrDefault();
        }

        public List<Curso> Get(bool sinCupo)
        {
            return _cursoRepositorio.Get(new CursoFilters { SinCupo = sinCupo });
        }

        public void Crear(Curso curso)
        {
            _cursoRepositorio.Post(curso);
        }

        public void Editar(Curso curso)
        {
            var cursoExistente = _cursoRepositorio.Get(new CursoFilters { Id= curso.Id }).FirstOrDefault();

            _cursoRepositorio.Update(curso);

            Task.Run(async () =>
            {
                await ManejarListaEspera(cursoExistente, curso);
            });
        }

        public void Eliminar(int id)
        {
            _cursoRepositorio.Delete(id);
        }

        public List<Carrera> GetCarreras()
        {
            return _cursoRepositorio.GetCarreras();
        }

        public List<ListaEspera> GetListaEspera(ListaEsperaFilters filers = null)
        {
            return _cursoRepositorio.GetListaEspera(filers);
        }

        public void GuardarListaEspera(List<Estudiante> estudiantes, int idCurso)
        {
            var listaDeEspera = _cursoRepositorio.GetListaEspera(new ListaEsperaFilters { CursoId = idCurso });
            var estudiantesNuevos = estudiantes.Where(x => !listaDeEspera.Any(y => y.Estudiante.Id == x.Id)).ToList();

            foreach (var estudiante in estudiantesNuevos)
            {
                _cursoRepositorio.GuardarListaEspera(estudiante, idCurso);
            }
        }

        public void EliminarListaEspera(List<Estudiante> estudiantes, int idCurso)
        {
            var listaDeEspera = _cursoRepositorio.GetListaEspera(new ListaEsperaFilters { CursoId = idCurso });
            var estudiantesAEliminar = estudiantes.Where(x => listaDeEspera.Any(y => y.Estudiante.Id == x.Id)).ToList();

            foreach (var estudiante in estudiantesAEliminar)
            {
                _cursoRepositorio.EliminarListaEspera(estudiante, idCurso);
            }
        }

        #region Private
        public async Task ManejarListaEspera(Curso cursoExistente, Curso cursoEditado)
        {
            if (cursoExistente.Cupo < 1 && cursoEditado.Cupo > 0)
            {
                var listaDeEspera = _cursoRepositorio.GetListaEspera(new ListaEsperaFilters { CursoId = cursoEditado.Id, Inscripto = false });

                if(listaDeEspera.Count > 0)
                {
                    var jjj = listaDeEspera.OrderBy(x => x.FechaAgregado);
                    var listasDeEsperaEstudiantes = listaDeEspera.OrderBy(x => x.FechaAgregado).Take((int)cursoEditado.Cupo).ToList();

                    foreach (var listasDeEsperaEstudiante in listasDeEsperaEstudiantes)
                    {
                        _estudianteManager = new EstudianteManager();
                        var estudiante = _estudianteManager.Get(listasDeEsperaEstudiante.Estudiante.Id);
                        _estudianteManager.Inscribir(estudiante, new List<string> { cursoEditado.Codigo });
                        _cursoRepositorio.CompletarListaEspera(estudiante, cursoEditado.Id);

                        await _notificacionesRepositorio.CrearNotificacion(estudiante.Id, cursoEditado.Id);
                    }
                }
            }
        }
        #endregion
    }
}
