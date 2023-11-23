using Libreria.Entidades;
using Libreria.Entidades.Filters;

namespace Libreria.Repositorios.Interface
{
    public interface IEstudianteRepositorio
    {
        List<Estudiante> Get(EstudianteFilters filters = null);
        void Post(Estudiante estudiante);
        void Update(Estudiante estudiante);
    }
}
