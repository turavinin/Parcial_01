using Libreria.Entidades;
using Libreria.Repositorios.Handlers;
using Newtonsoft.Json;

namespace Libreria.Repositorios
{
    public class EstudianteRepositorio
    {
        private readonly Archivo _archivo;
        private readonly string _pathEstudiantes;

        public EstudianteRepositorio()
        {
            var pathSolucion = $"{Archivo.ObtenerDirectorioSolucion()?.FullName}\\Data\\Estudiantes";
            _pathEstudiantes = Path.Combine(pathSolucion, "estudiantes.json");
            _archivo = new Archivo(_pathEstudiantes);
        }

        public List<Estudiante>? Get()
        {
            var datosEstudiantes = _archivo.Leer();
            if (!string.IsNullOrEmpty(datosEstudiantes))
            {
                var estudiantes = JsonConvert.DeserializeObject<List<Estudiante>>(datosEstudiantes);
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

        public void Post(Estudiante estudiante)
        {
            var estudiantesExistentes = this.Get();
            estudiantesExistentes ??= new List<Estudiante>();

            estudiantesExistentes.Add(estudiante);
            var estudiantesJson = JsonConvert.SerializeObject(estudiantesExistentes);
            _archivo.Escribir(estudiantesJson);
        }
    }
}
