namespace Libreria.Entidades
{
    public class Curso
    {
        #region Atributos
        private string? _nombre;
        private string? _codigo;
        private string? _descripcion;
        private int? _cupoMaximo;
        #endregion

        #region Propiedades
        public string? Nombre { get => _nombre; set => _nombre = value; }
        public string? Codigo { get => _codigo; set => _codigo = value; }
        public string? Descripcion { get => _descripcion; set => _descripcion = value; }
        public int? CupoMaximo { get => _cupoMaximo; set => _cupoMaximo = value; }
        #endregion

        #region Constructores
        public Curso(string nombre, string codigo, string descripcion, int cupoMaximo)
        {
            this.Nombre = nombre;
            this.Codigo = codigo;
            this.Descripcion = descripcion;
            this.CupoMaximo = cupoMaximo;
        }
        #endregion
    }
}
