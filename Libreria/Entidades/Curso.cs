using Libreria.Repositorios;

namespace Libreria.Entidades
{
    public class Curso
    {
        #region Atributos
        private int _id;
        private string? _nombre;
        private string? _codigo;
        private string? _descripcion;
        private int? _cupo;
        private string? _correlativas;
        private int? _promedioMinimo;
        private int? _creditoMinimo;
        private List<Inscripcion> _inscripciones;
        private List<int> _cursosCorrelativosIds;
        private List<string> _erroresValidacion;
        #endregion

        #region Propiedades
        public int Id { get => _id; set => _id = value; }
        public string? Nombre { get => _nombre; set => _nombre = value; }
        public string? Codigo { get => _codigo; set => _codigo = value; }
        public string? Descripcion { get => _descripcion; set => _descripcion = value; }
        public string? Correlativas { get => _correlativas; set => _correlativas = value; }
        public int? Cupo { get => _cupo; set => _cupo = value; }
        public int? PromedioMinimo { get => _promedioMinimo; set => _promedioMinimo = value; }
        public int? CreditoMinimo { get => _creditoMinimo; set => _creditoMinimo = value; }
        public List<Inscripcion> Inscripciones { get => _inscripciones; set => _inscripciones = value; }
        public List<int> CursosCorrelativosIds { get => _cursosCorrelativosIds; set => _cursosCorrelativosIds = value; }

        public List<string> ErroresValidacion { get => _erroresValidacion; }
        #endregion

        #region Constructores
        public Curso()
        {
            
        }

        public Curso(string nombre, string codigo, string descripcion, int cupoMaximo)
        {
            this.Nombre = nombre;
            this.Codigo = codigo;
            this.Descripcion = descripcion;
            this.Cupo = cupoMaximo;
        }
        #endregion

        public bool Validar(bool esEditar = false, string? codigoAnterior = null)
        {
            _erroresValidacion = new List<string>();

            if (string.IsNullOrEmpty(this.Nombre) )
            {
                _erroresValidacion.Add("El nombre no puede estar vacío.");
            }

            if (string.IsNullOrEmpty(this.Descripcion))
            {
                _erroresValidacion.Add("La descripción no puede estar vacía.");
            }

            if (this.Cupo <= 0)
            {
                _erroresValidacion.Add("El cupo máximo debe ser mayor a 0.");
            }

            if (!_erroresValidacion.Any())
            {
                ValidacionesRepositorio(esEditar, codigoAnterior, _erroresValidacion);
            }

            return !_erroresValidacion.Any();
        }

        private void ValidacionesRepositorio(bool esEditar, string codigoAnterior, List<string> errores)
        {
            var repositorio = new CursoRepositorio();
            var cursos = repositorio.Get();
            var cursoCodigoExiste = cursos.Any(x => string.Equals(x.Codigo, this.Codigo, StringComparison.OrdinalIgnoreCase));

            if (!esEditar)
            {
                if (cursoCodigoExiste)
                {
                    _erroresValidacion.Add("El código ya existe.");
                }

                if (cursos.Any(x => string.Equals(x.Nombre, this.Nombre, StringComparison.OrdinalIgnoreCase)))
                {
                    _erroresValidacion.Add("Ya existe un curso con el mismo nombre.");
                }
            }

            if (esEditar && !string.IsNullOrEmpty(codigoAnterior))
            {
                var cursoEditadoExiste = cursos.Find(x => string.Equals(x.Codigo, codigoAnterior, StringComparison.OrdinalIgnoreCase));

                if (cursoEditadoExiste == null)
                {
                    _erroresValidacion.Add("No existe el curso para editar.");
                }
                else
                {
                    if (!string.Equals(this.Codigo, codigoAnterior, StringComparison.OrdinalIgnoreCase) && cursoCodigoExiste)
                    {
                        _erroresValidacion.Add("El código ya existe.");
                    }

                    if (!string.Equals(cursoEditadoExiste.Nombre, this.Nombre, StringComparison.OrdinalIgnoreCase) && cursos.Any(x => string.Equals(x.Nombre, this.Nombre, StringComparison.OrdinalIgnoreCase)))
                    {
                        _erroresValidacion.Add("Ya existe un curso con el mismo nombre.");
                    }
                }
            }
        }
    }
}
