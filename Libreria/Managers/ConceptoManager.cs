using Libreria.Entidades;
using Libreria.Managers.Interface;
using Libreria.Repositorios;
using Libreria.Repositorios.Interface;

namespace Libreria.Managers
{
    public class ConceptoManager : IConceptoManager
    {
        private IConceptoRepositorio _conceptoRepositorio;
        public ConceptoManager()
        {
            _conceptoRepositorio = new ConceptoRepositorio();
        }

        public List<Concepto> Get()
        {
            return _conceptoRepositorio.Get();
        }
    }
}
