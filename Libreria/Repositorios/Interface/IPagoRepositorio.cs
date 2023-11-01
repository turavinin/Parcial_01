using Libreria.Entidades;

namespace Libreria.Repositorios.Interface
{
    public interface IPagoRepositorio
    {
        void Post(Pago pago, int estudianteId);
        void Update(Pago pago, int estudianteId);
    }
}
