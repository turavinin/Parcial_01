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

        public Estudiante? Get(string legajo, string clave)
        {
            var datosEstudiantes = _archivo.Leer();

            if (!string.IsNullOrEmpty(datosEstudiantes))
            {
                var estudiantes = JsonConvert.DeserializeObject <List<Estudiante>>(datosEstudiantes);
                var estudiante = estudiantes?.FirstOrDefault(x => x.Legajo == legajo && x.Clave == clave);

                if (estudiantes != null)
                {
                    return estudiante;
                }
            }

            return default;
        }
    }
}
