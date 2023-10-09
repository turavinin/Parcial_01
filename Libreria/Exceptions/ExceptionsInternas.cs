using Libreria.Exceptions.Enums;

namespace Libreria.Exceptions
{
    public class ExceptionsInternas : Exception
    {
        public TipoError TipoError { get; }
        public List<string> Errores { get; }

        public ExceptionsInternas(List<string> errores, TipoError tipoError) : base(string.Join(",", errores))
        {
            Errores = errores;
            TipoError = tipoError;
        }

        public ExceptionsInternas(string message, TipoError tipoError) : base(message)
        {
            TipoError = tipoError;
            Errores = new List<string> { message };
        }

        public ExceptionsInternas(string message, TipoError tipoError, Exception innerException) : base(message, innerException)
        {
            TipoError = tipoError;
            Errores = new List<string> { message };
        }
    }
}
