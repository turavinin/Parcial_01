using Libreria.Entidades;
using Libreria.Entidades.Filters;

namespace Libreria.Repositorios.Interface
{
    public interface IPagoRepositorio
    {
        List<Pago> Get(PagoFilters filters = null);
        void Post(Pago pago, int estudianteId);
        void Update(Pago pago, int estudianteId);
    }
}
