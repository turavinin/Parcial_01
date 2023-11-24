using Libreria.Entidades;

namespace Libreria.Managers.Interface
{
    public interface ICursoManager
    {
        List<Curso> Get();
        Curso Get(int id);
        void Crear(Curso curso);
        void Editar(Curso curso);
        void Eliminar(int id);
        List<Carrera> GetCarreras();
    }
}
