using Libreria.Managers.Interface;

namespace Libreria.Managers
{
    public class AdministracionManager
    {
        private IAdministradorManager _administradorManager;
        private IEstudianteManager _estudianteManager;

        public AdministracionManager()
        {
            _administradorManager = new AdministradorManager();
            _estudianteManager = new EstudianteManager();
        }


        #region Login
        public bool LoginUsuario(string usuario, string clave, bool isAdmin)
        {
            return isAdmin ? _administradorManager.Login(usuario, clave) : _estudianteManager.Login(usuario, clave);
        }
        #endregion
    }
}
