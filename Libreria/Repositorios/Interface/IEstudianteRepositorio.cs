using Libreria.Entidades;

namespace Libreria.Repositorios.Interface
{
    public interface IEstudianteRepositorio
    {
        List<Estudiante> Get(int? id = null, string? legajo = null);
        void Post(Estudiante estudiante);
        void Update(Estudiante estudiante);
    }
}
