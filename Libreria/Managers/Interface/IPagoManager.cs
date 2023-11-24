using Libreria.Entidades;
using Libreria.Entidades.Filters;

namespace Libreria.Managers.Interface
{
    public interface IPagoManager
    {
        List<Pago> Get(PagoFilters filters = null);
        void Crear(Pago pago, int estudianteId);
        void Actualizar(Pago pago, int estudianteId);
    }
}
