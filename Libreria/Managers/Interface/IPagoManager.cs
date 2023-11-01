using Libreria.Entidades;

namespace Libreria.Managers.Interface
{
    public interface IPagoManager
    {
        void Crear(Pago pago, int estudianteId);
        void Actualizar(Pago pago, int estudianteId);
    }
}
