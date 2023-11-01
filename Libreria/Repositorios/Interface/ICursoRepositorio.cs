using Libreria.Entidades;

namespace Libreria.Repositorios.Interface
{
    public interface ICursoRepositorio
    {
        List<Curso> Get(int? id = null);
        void Post(Curso curso);
        void Update(Curso curso);
        void Delete(int id);
    }
}
