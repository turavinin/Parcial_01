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

        /// <summary>
        /// Obtiene la lista de cursos guardados en la base.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Obtiene curso por su código.
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        public Curso? Get(string codigo)
        {
            var cursos = Get();

            if (cursos.Any())
            {
                return cursos?.FirstOrDefault(x => string.Equals(x.Codigo, codigo, StringComparison.OrdinalIgnoreCase));
            }

            return default;
        }

        /// <summary>
        /// Guarda un curso nuevo.
        /// </summary>
        /// <param name="curso"></param>
        public void Post(Curso curso)
        {
            var cursos = this.Get();
            cursos ??= new List<Curso>();

            cursos.Add(curso);
            var cursosJson = JsonConvert.SerializeObject(cursos);
            _archivo.Escribir(cursosJson);
        }

        /// <summary>
        /// Actualiza un curso.
        /// </summary>
        /// <param name="curso"></param>
        /// <param name="codigoCursoGuardado"></param>
        public void Update(Curso curso, string codigoCursoGuardado)
        {
            var cursos = this.Get();
            cursos ??= new List<Curso>();
            var cursoExistente = cursos?.FirstOrDefault(x => string.Equals(x.Codigo, codigoCursoGuardado, StringComparison.OrdinalIgnoreCase));

            if (cursoExistente != null)
            {
                cursoExistente.Codigo = curso.Codigo;
                cursoExistente.Nombre = curso.Nombre;
                cursoExistente.Descripcion = curso.Descripcion;
                cursoExistente.CupoMaximo = curso.CupoMaximo;
            }

            var cursosJson = JsonConvert.SerializeObject(cursos);
            _archivo.Escribir(cursosJson);
        }

        /// <summary>
        /// Elimina un curso.
        /// </summary>
        /// <param name="codigo"></param>
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
