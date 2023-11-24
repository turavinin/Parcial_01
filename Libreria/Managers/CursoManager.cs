using Libreria.Entidades;
using Libreria.Managers.Interface;
using Libreria.Repositorios;
using Libreria.Repositorios.Interface;

namespace Libreria.Managers
{
    public class CursoManager : ICursoManager
    {
        private ICursoRepositorio _cursoRepositorio;

        public CursoManager()
        {
            _cursoRepositorio = new CursoRepositorio();
        }

        public List<Curso> Get()
        {
            return _cursoRepositorio.Get();
        }

        public Curso Get(int id)
        {
            return _cursoRepositorio.Get(id).FirstOrDefault();
        }

        public void Crear(Curso curso)
        {
            _cursoRepositorio.Post(curso);
        }

        public void Editar(Curso curso)
        {
            _cursoRepositorio.Update(curso);
        }

        public void Eliminar(int id)
        {
            _cursoRepositorio.Delete(id);
        }

        public List<Carrera> GetCarreras()
        {
            return _cursoRepositorio.GetCarreras();
        }
    }
}
