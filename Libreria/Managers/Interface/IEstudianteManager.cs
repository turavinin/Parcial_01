using Libreria.Entidades;

namespace Libreria.Managers.Interface
{
    public interface IEstudianteManager
    {
        bool Login(string legajo, string clave);
        List<Estudiante> Get();
        Estudiante Get(int id);
        Estudiante Get(string legajo);
        void Crear(Estudiante estudiante);
        bool Inscribir(Estudiante estudiante, List<string> cursoCodigos);
        void ActualizarClave(Estudiante estudiante);
        void Pagar(Estudiante estudiante, Pago pago, Dictionary<int, string> conceptoMontoPagado);
    }
}
