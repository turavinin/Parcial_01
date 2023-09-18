namespace Libreria.Entidades
{
    public class Administrador
    {
        #region Atributos
        private string? _nombreCompleto;
        private string? _usuario;
        private string? _clave;
        #endregion

        #region Propiedades
        public string? NombreCompleto { get => _nombreCompleto; set => _nombreCompleto = value; }
        public string? Usuario { get => _usuario; set => _usuario = value; }
        public string? Clave { get => _clave; set => _clave = value; }
        #endregion

        #region Constructores
        public Administrador()
        {
                
        }
        public Administrador(string nombreCompleto, string usuario, string clave)
        {
            this.NombreCompleto = nombreCompleto;
            this.Usuario = usuario;
            this.Clave = clave;
        }
        #endregion

        #region Privados
        #endregion
    }
}
