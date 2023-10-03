using Libreria.Entidades;
using Libreria.Repositorios.Handlers;
using Newtonsoft.Json;

namespace Libreria.Repositorios
{
    public class EstudianteRepositorio
    {
        private readonly Archivo _archivo;
        private readonly string _pathEstudiantes;
        private EstudianteCursoRepositorio _estudiantesCursosRepositorio;
        private CursoRepositorio _cursoRepositorio;

        public EstudianteRepositorio()
        {
            var pathSolucion = $"{Archivo.ObtenerDirectorioSolucion()?.FullName}\\Data\\Estudiantes";
            _pathEstudiantes = Path.Combine(pathSolucion, "estudiantes.json");
            _archivo = new Archivo(_pathEstudiantes);
            _estudiantesCursosRepositorio = new EstudianteCursoRepositorio();
            _cursoRepositorio = new CursoRepositorio();
        }

        public List<Estudiante>? Get()
        {
            var datosEstudiantes = _archivo.Leer();

            if (!string.IsNullOrEmpty(datosEstudiantes))
            {
                var estudiantes = JsonConvert.DeserializeObject<List<Estudiante>>(datosEstudiantes);
                RelacionarCursoAEstudiante(estudiantes);
                return estudiantes;
            }

            return default;
        }

        public Estudiante? Get(string legajo, string clave)
        {
            var estudiantes = Get();
            if (estudiantes != null && estudiantes.Count > 0)
            {
                return estudiantes?.FirstOrDefault(x => x.Legajo == legajo && x.Clave == clave);
            }

            return default;
        }

        public Estudiante? Get(string legajo)
        {
            var estudiantes = Get();
            if (estudiantes != null && estudiantes.Count > 0)
            {
                return estudiantes?.FirstOrDefault(x => x.Legajo == legajo);
            }

            return default;
        }

        public void Post(Estudiante estudiante)
        {
            var estudiantesExistentes = this.Get();
            estudiantesExistentes ??= new List<Estudiante>();

            estudiantesExistentes.Add(estudiante);
            var estudiantesJson = JsonConvert.SerializeObject(estudiantesExistentes);
            _archivo.Escribir(estudiantesJson);
        }

        public void Update(Estudiante estudiante)
        {
            var estudiantes = this.Get();
            estudiantes ??= new List<Estudiante>();
            var estudianteExistente = estudiantes?.FirstOrDefault(x => string.Equals(x.Legajo, estudiante.Legajo, StringComparison.OrdinalIgnoreCase));

            if (estudianteExistente != null)
            {
                estudianteExistente.Clave = estudiante.Clave;
                estudianteExistente.CambiarClave = estudiante.CambiarClave;
            }

            var estudiantesJson = JsonConvert.SerializeObject(estudiantes);
            _archivo.Escribir(estudiantesJson);
        }

        private void RelacionarCursoAEstudiante(List<Estudiante>? estudiantes)
        {
            if (estudiantes.Count > 0)
            {
                var cursos = _cursoRepositorio.Get();
                var estudiantesCursos = _estudiantesCursosRepositorio.Get();

                foreach (var estudiante in estudiantes)
                {
                    var codigos = estudiantesCursos?.Where(x => x.LegajoEstudiante == estudiante.Legajo)?.Select(x => x.CodigoCurso).ToList();

                    estudiante.Cursos = codigos is null ? new List<Curso>() : cursos.Where(x => codigos.Contains(x.Codigo)).ToList();
                }
            }
        }
    }
}
