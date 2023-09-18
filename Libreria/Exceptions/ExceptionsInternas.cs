namespace Libreria.Exceptions
{
    internal class ExceptionsInternas : Exception
    {
        public ExceptionsInternas(string message) : base(message)
        {
        }

        public ExceptionsInternas(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
