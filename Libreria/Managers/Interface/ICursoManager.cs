using Libreria.Entidades;
using Libreria.Entidades.Filters;

namespace Libreria.Managers.Interface
{
    public interface ICursoManager
    {
        List<Curso> Get();
        Curso Get(int id);
        List<Curso> Get(bool sinCupo);
        void Crear(Curso curso);
        void Editar(Curso curso);
        void Eliminar(int id);
        List<Carrera> GetCarreras();
        List<ListaEspera> GetListaEspera(ListaEsperaFilters filers = null);
        void GuardarListaEspera(List<Estudiante> estudiantes, int idCurso);
        void EliminarListaEspera(List<Estudiante> estudiantes, int idCurso);
    }
}
