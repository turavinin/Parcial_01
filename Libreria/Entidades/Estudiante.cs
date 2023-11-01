using Libreria.Repositorios;

namespace Libreria.Entidades
{
    public class Estudiante : Usuario
    {
        #region Atributos
        private string? _legajo;
        private string? _nombre;
        private string? _direccion;
        private string? _documento;
        private string? _telefono;
        private string? _email;
        private bool? _cambiarClave;
        private List<Inscripcion> _inscripciones;
        private List<Pago> _pagos;
        private List<string> _erroresValidacion;
        #endregion

        #region Propiedades
        public string? Legajo { get => _legajo; set => _legajo = value; }
        public string? Nombre { get => _nombre; set => _nombre = value; }
        public string? Direccion { get => _direccion; set => _direccion = value; }
        public string? Documento { get => _documento; set => _documento = value; }
        public string? Telefono { get => _telefono; set => _telefono = value; }
        public string? Email { get => _email; set => _email = value; }
        public bool? CambiarClave { get => _cambiarClave; set => _cambiarClave = value; }
        public List<Inscripcion> Inscripciones { get => _inscripciones; internal set => _inscripciones = value; }
        public List<Pago> Pagos { get => _pagos; internal set => _pagos = value; }

        public List<string> ErroresValidacion { get => _erroresValidacion; }
        #endregion

        #region Constructores
        public Estudiante()
        {
            
        }
        public Estudiante(string nombre, string direccion, string documento, string telefono, string email, bool? cambiarCalve, bool generarClaveProvisional, string? clave = null) : base(clave, generarClaveProvisional)
        {
            this.Nombre = nombre;
            this.Direccion = direccion;
            this.Documento = documento;
            this.Telefono = telefono;
            this.Email = email;
            this.CambiarClave = cambiarCalve;
        }
        #endregion

        public override bool Validar(bool esEditar = false)
        {
            _erroresValidacion = new List<string>();

            if (!base.Validar())
            {
                _erroresValidacion.Add("Clave inválida");
            }

            if(!esEditar)
            {
                var repositorio = new EstudianteRepositorio();
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

                    if (estudiantes.Any(x => x.Documento == _documento))
                    {
                        _erroresValidacion.Add("El DNI ya esta utilizado");
                    }
                }
            }

            return !_erroresValidacion.Any();
        }

        public void AsignarLegajo()
        {
            var random = new Random();
            this.Legajo = random.Next(1, 10000).ToString();
        }
    }
}
