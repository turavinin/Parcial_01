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

        public List<EstudianteConcepto> Get(string legajo)
        {
            var data = Get();

            if (data.Count > 0)
            {
                return data.Where(x => x.Legajo == legajo).ToList();
            }

            return data;
        }

        public List<EstudianteConcepto> Get(string legajo, bool cancelado)
        {
            var data = Get();

            if (data.Count > 0)
            {
                return data.Where(x => x.Legajo == legajo && x.Cancelado == cancelado).ToList();
            }

            return data;
        }

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
