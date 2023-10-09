using Libreria.Entidades;
using Libreria.Repositorios.Handlers;
using Newtonsoft.Json;

namespace Libreria.Repositorios
{
    public class EstudianteConceptoRepositorio
    {
        private readonly Archivo _archivo;
        private readonly string _path;

        public EstudianteConceptoRepositorio()
        {
            var pathSolucion = $"{Archivo.ObtenerDirectorioSolucion()?.FullName}\\Data\\EstudianteConcepto";
            _path = Path.Combine(pathSolucion, "estudianteConcepto.json");
            _archivo = new Archivo(_path);
        }

        /// <summary>
        /// Obtiene los conceptos pagados por los estudiantes.
        /// </summary>
        /// <returns></returns>
        public List<EstudianteConcepto> Get()
        {
            var datosJson = _archivo.Leer();
            var data = new List<EstudianteConcepto>();

            if (!string.IsNullOrEmpty(datosJson))
            {
                data = JsonConvert.DeserializeObject<List<EstudianteConcepto>>(datosJson);
            }

            return data;
        }

        /// <summary>
        /// Obtiene los conceptos pagados por el estudiante del legajo.
        /// </summary>
        /// <param name="legajo"></param>
        /// <returns></returns>
        public List<EstudianteConcepto> Get(string legajo)
        {
            var data = Get();

            if (data.Count > 0)
            {
                return data.Where(x => x.Legajo == legajo).ToList();
            }

            return data;
        }

        /// <summary>
        /// Crea o guarda un nuevo registro de concepto del estudiante.
        /// </summary>
        /// <param name="estudianteConcepto"></param>
        public void PostOrUpdate(EstudianteConcepto estudianteConcepto)
        {
            var estudianteConceptos = Get(estudianteConcepto.Legajo);
            estudianteConceptos ??= new List<EstudianteConcepto>();
            var estudianteConceptoExistente = estudianteConceptos.FirstOrDefault(x => x.IdConcepto == estudianteConcepto.IdConcepto);

            if (estudianteConceptoExistente != null)
            {
                estudianteConceptoExistente.MontoPagado = estudianteConcepto.MontoPagado;
                estudianteConceptoExistente.Cancelado = estudianteConcepto.Cancelado;
            }
            else
            {
                estudianteConceptos.Add(estudianteConcepto);
            }

            var json = JsonConvert.SerializeObject(estudianteConceptos);
            _archivo.Escribir(json);
        }
    }
}
