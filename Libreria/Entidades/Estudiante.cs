using Libreria.Repositorios;
using Newtonsoft.Json;

namespace Libreria.Entidades
{
    public class Estudiante : Usuario
    {
        #region Atributos
        private string? _legajo;
        private string? _nombreCompleto;
        private string? _direccion;
        private string? _dni;
        private string? _telefono;
        private string? _email;
        private bool? _cambiarClave;

        private List<string> _erroresValidacion;
        #endregion

        #region Propiedades
        public string? Legajo { get => _legajo; internal set => _legajo = value; }
        public string? NombreCompleto { get => _nombreCompleto; set => _nombreCompleto = value; }
        public string? Direccion { get => _direccion; set => _direccion = value; }
        public string? Dni { get => _dni; set => _dni = value; }
        public string? Telefono { get => _telefono; set => _telefono = value; }
        public string? Email { get => _email; set => _email = value; }
        public bool? CambiarClave { get => _cambiarClave; set => _cambiarClave = value; }
        public List<string> ErroresValidacion { get => _erroresValidacion; }
        #endregion

        #region Constructores
        public Estudiante(string nombreCompleto, string direccion, string dni, string telefono, string email, bool? cambiarCalve, bool generarClaveProvisional, string? clave = null) : base(clave, generarClaveProvisional)
        {
            this.NombreCompleto = nombreCompleto;
            this.Direccion = direccion;
            this.Dni = dni;
            this.Telefono = telefono;
            this.Email = email;
            this.CambiarClave = cambiarCalve;
        }

        [JsonConstructor]
        internal Estudiante(string nombreCompleto, string direccion, string dni, string telefono, string email, string clave, bool? cambiarCalve, string legajo) 
            : this(nombreCompleto, direccion, dni, telefono, email, cambiarCalve, false, clave)
        {
            this.Legajo = legajo;
        }
        #endregion

        public override bool Validar()
        {
            _erroresValidacion = new List<string>();
            var repositorio = new EstudianteRepositorio();

            if (!base.Validar())
            {
                _erroresValidacion.Add("Clave inválida");
            }

            var estudiantes = repositorio.Get();

            if (estudiantes != null)
            {
                if (estudiantes.Any(x => x.Email == _email))
                {
                    _erroresValidacion.Add("El email ya esta utilizado.");
                }

                if (estudiantes.Any(x => x.Legajo == _legajo))
                {
                    _erroresValidacion.Add("El legajo generado ya es utilizado.");
                }

                if (estudiantes.Any(x => x.Dni == _dni))
                {
                    _erroresValidacion.Add("El DNI ya esta utilizado");
                }
            }

            return !_erroresValidacion.Any();
        }
    }
}
