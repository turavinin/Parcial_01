using Libreria.Entidades;
using Libreria.Managers.Interface;
using Libreria.Repositorios;
using Libreria.Repositorios.Interface;

namespace Libreria.Managers
{
    public class InscripcionManager : IInscripcionManager
    {
        IInscripcionRepositorio _inscripcionRepositorio;

        public InscripcionManager()
        {
            _inscripcionRepositorio = new InscripcionRepositorio();
        }

        public void Crear(Inscripcion inscripcion, int estudianteId)
        {
            _inscripcionRepositorio.Post(inscripcion, estudianteId);
        }
    }
}
