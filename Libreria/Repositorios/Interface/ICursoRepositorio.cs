using Libreria.Entidades;
using Libreria.Entidades.Filters;

namespace Libreria.Repositorios.Interface
{
    public interface ICursoRepositorio
    {
        List<Curso> Get(CursoFilters filters = null);
        void Post(Curso curso);
        void Update(Curso curso);
        void Delete(int id);
        List<Carrera> GetCarreras();
        List<ListaEspera> GetListaEspera(ListaEsperaFilters filters = null);
        void GuardarListaEspera(Estudiante estudiante, int cursoId);
        void EliminarListaEspera(Estudiante estudiante, int cursoId);
        void CompletarListaEspera(Estudiante estudiante, int cursoId);
    }
}
