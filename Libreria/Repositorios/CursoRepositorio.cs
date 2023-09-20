using Libreria.Entidades;
using Libreria.Repositorios.Handlers;
using Newtonsoft.Json;

namespace Libreria.Repositorios
{
    public class CursoRepositorio
    {
        private readonly Archivo _archivo;
        private readonly string _path;

        public CursoRepositorio()
        {
            var pathSolucion = $"{Archivo.ObtenerDirectorioSolucion()?.FullName}\\Data\\Cursos";
            _path = Path.Combine(pathSolucion, "cursos.json");
            _archivo = new Archivo(_path);
        }

        public List<Curso>? Get()
        {
            var dataString = _archivo.Leer();
            var data = new List<Curso>();

            if (!string.IsNullOrEmpty(dataString))
            {
                data = JsonConvert.DeserializeObject<List<Curso>>(dataString);
            }

            return data;
        }

        public void Post(Curso curso)
        {
            var cursos = this.Get();
            cursos ??= new List<Curso>();

            cursos.Add(curso);
            var cursosJson = JsonConvert.SerializeObject(cursos);
            _archivo.Escribir(cursosJson);
        }

        public void Delete(string codigo)
        {
            var cursos = this.Get();

            if(cursos != null && cursos.Count > 0) 
            {
                cursos.RemoveAll(x => x.Codigo == codigo);
                var cursosJson = JsonConvert.SerializeObject(cursos);
                _archivo.Escribir(cursosJson);
            }
        }
    }
}
