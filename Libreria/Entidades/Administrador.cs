namespace Libreria.Entidades
{
    public class Administrador : Usuario
    {
        #region Atributos
        private string? _nombreCompleto;
        private string? _usuario;
        #endregion

        #region Propiedades
        public string? NombreCompleto { get => _nombreCompleto; set => _nombreCompleto = value; }
        public string? Usuario { get => _usuario; set => _usuario = value; }
        #endregion

        #region Constructores
        public Administrador(string nombreCompleto, string usuario, string clave) : base(clave)
        {
            this.NombreCompleto = nombreCompleto;
            this.Usuario = usuario;
        }
        #endregion

        public void AsginarLegajoEstudiante(Estudiante estudiante)
        {
            estudiante.Legajo = AsignarLegajo();
        }

        #region Privados
        private static string AsignarLegajo()
        {
            var random = new Random();
            return random.Next(1, 10000).ToString();
        }
        #endregion
    }
}
