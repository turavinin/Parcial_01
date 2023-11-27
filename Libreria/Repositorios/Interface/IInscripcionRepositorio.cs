using Libreria.Entidades;

namespace Libreria.Repositorios.Interface
{
    public interface IInscripcionRepositorio
    {
        void Post(Inscripcion inscrpcion, int estudianteId);
    }
}
