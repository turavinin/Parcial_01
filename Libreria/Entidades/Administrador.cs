namespace Libreria.Entidades
{
    public class Administrador : Usuario
    {
        #region Atributos
        private string? _nombre;
        private string? _usuario;
        #endregion

        #region Propiedades
        public string? Nombre { get => _nombre; set => _nombre = value; }
        public string? Usuario { get => _usuario; set => _usuario = value; }
        #endregion

        #region Constructores
        public Administrador()
        {
            
        }
        public Administrador(string nombre, string usuario, string clave) : base(clave)
        {
            this.Nombre = nombre;
            this.Usuario = usuario;
        }
        #endregion
    }
}
