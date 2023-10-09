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

        /// <summary>
        /// Valida al usuario
        /// </summary>
        /// <param name="esEditar"></param>
        /// <returns>True: si el usuario es valido.</returns>

        public virtual bool Validar(bool esEditar = false)
        {
            if (!string.IsNullOrWhiteSpace(this._clave) && this._clave.Length <= 5)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Valida la clave
        /// </summary>
        /// <param name="clave"></param>
        /// <returns>True: si la clave es válida</returns>
        public bool ClaveValida(string clave)
        {
            var esValida = false;

            try
            {
                if (!string.IsNullOrEmpty(clave) && !string.IsNullOrEmpty(this.Clave))
                {
                    esValida = BCrypt.Net.BCrypt.EnhancedVerify(clave, this.Clave);
                }
            }
            catch (Exception)
            {
                esValida = false;
            }

            return esValida;
        }

        private static string GenerarClaveProvisional()
        {
            return "clave";
        }

        /// <summary>
        /// Encrypta la clave del usuario.
        /// </summary>
        public void EncryptClave()
        {
            this.Clave = BCrypt.Net.BCrypt.EnhancedHashPassword(this.Clave, 8);
        }
    }
}
