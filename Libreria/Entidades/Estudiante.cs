namespace Libreria.Entidades
{
    public class Estudiante
    {
        #region Atributos
        private string? _legajo;
        private string? _nombreCompleto;
        private string? _direccion;
        private string? _dni;
        private string? _telefono;
        private string? _email;
        private string? _clave;
        private bool? _cambiarClave;
        #endregion

        #region Propiedades
        public string? Legajo { get => _legajo; set => _legajo = value; }
        public string? NombreCompleto { get => _nombreCompleto; set => _nombreCompleto = value; }
        public string? Direccion { get => _direccion; set => _direccion = value; }
        public string? Dni { get => _dni; set => _dni = value; }
        public string? Telefono { get => _telefono; set => _telefono = value; }
        public string? Email { get => _email; set => _email = value; }
        public string? Clave { get => _clave; set => _clave = value; }
        public bool? CambiarClave { get => _cambiarClave; set => _cambiarClave = value; }
        #endregion

        #region Constructores
        public Estudiante()
        { 
        }
        public Estudiante(string nombreCompleto, string direccion, string dni, string telefono, string email, string clave, bool? cambiarCalve)
        {
            this.NombreCompleto = nombreCompleto;
            this.Direccion = direccion;
            this.Dni = dni;
            this.Telefono = telefono;
            this.Email = email;
            this.Clave = clave;
            this.CambiarClave = cambiarCalve;
            this.Legajo = AsignarLegajo();
        }
        #endregion

        #region Privados
        private static string AsignarLegajo()
        {
            var random = new Random();
            return random.Next(1, 10000).ToString();
        }
        #endregion
    }
}
