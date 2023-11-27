using Libreria.Entidades;
using Libreria.Entidades.Filters;

namespace Libreria.Repositorios.Interface
{
    public interface IProfesorRepositorio
    {
        List<Profesor> Get(ProfesorFilters filters = null);
        void Create(Profesor profesor);
        void Update(Profesor profesor);
        void AsignarCursos(int profesorId, int cursoId);
        void Delete(int id);
        void DeleteCursoProfesor(int profesorId);
    }
}
