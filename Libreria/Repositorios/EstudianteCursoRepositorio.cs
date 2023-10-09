using Libreria.Entidades;
using Libreria.Repositorios.Handlers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Repositorios
{
    public class EstudianteCursoRepositorio
    {
        private readonly Archivo _archivo;
        private readonly string _path;

        public EstudianteCursoRepositorio()
        {
            var pathSolucion = $"{Archivo.ObtenerDirectorioSolucion()?.FullName}\\Data\\EstudiantesCursos";
            _path = Path.Combine(pathSolucion, "estudiantescursos.json");
            _archivo = new Archivo(_path);
        }

        /// <summary>
        /// Obtiene una lista de cursos de los estudiantes.
        /// </summary>
        /// <returns></returns>
        public List<EstudianteCurso>? Get()
        {
            var datosJson = _archivo.Leer();
            if (!string.IsNullOrEmpty(datosJson))
            {
                var datos = JsonConvert.DeserializeObject<List<EstudianteCurso>>(datosJson);
                return datos;
            }

            return default;
        }

        /// <summary>
        /// Obtiene la lista de cursos a los que está inscripto el estudiante.
        /// </summary>
        /// <param name="legajo"></param>
        /// <returns></returns>
        public List<EstudianteCurso>? Get(string legajo)
        {
            var estudiantesCursos = Get();

            if(estudiantesCursos != null)
            {
                return estudiantesCursos.Where(x => x.LegajoEstudiante == legajo).ToList();
            }

            return default;
        }

        /// <summary>
        /// Guarda cursos a los que se inscribió el estudiante.
        /// </summary>
        /// <param name="estudiantesCursos"></param>
        public void Post(List<EstudianteCurso> estudiantesCursos)
        {
            var data = this.Get();
            data ??= new List<EstudianteCurso>();

            data.AddRange(estudiantesCursos);

            var dataJson = JsonConvert.SerializeObject(data);
            _archivo.Escribir(dataJson);
        }

        /// <summary>
        /// Guarda un curso al que se inscribió el estudiante.
        /// </summary>
        /// <param name="estudianteCurso"></param>
        public void Post(EstudianteCurso estudianteCurso)
        {
            Post(new List<EstudianteCurso>() { estudianteCurso });
        }
    }
}
