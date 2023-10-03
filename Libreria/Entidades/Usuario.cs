namespace Libreria.Entidades
{
    public class Usuario
    {
        private string? _clave;

        public string? Clave { get => _clave; set => _clave = value; }

        public Usuario(string? clave = null, bool generarClaveProvisional = false)
        {
            if (generarClaveProvisional)
            {
                this.Clave = GenerarClaveProvisional();
            }
            else if (!string.IsNullOrEmpty(clave))
            {
                this.Clave = clave;
            }
        }

        public virtual bool Validar(bool esEditar = false)
        {
            if (!string.IsNullOrWhiteSpace(this._clave) && this._clave.Length <= 5)
            {
                return true;
            }

            return false;
        }

        private static string GenerarClaveProvisional()
        {
            var random = new Random();
            return random.Next(1, 33333).ToString();
        }
    }
}
