using Libreria.Entidades;

namespace Libreria.Managers.Interface
{
    public interface IProfesorManager
    {
        List<Profesor> Get();
        Profesor Get(int id);
        void Create(Profesor profesor);
        void Update(Profesor profesor);
        void AsignarCursos(Profesor profesor);
        void Delete(int id);
    }
}
