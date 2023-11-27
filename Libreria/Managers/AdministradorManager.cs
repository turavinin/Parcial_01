using Libreria.Managers.Interface;
using Libreria.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Managers
{
    public class AdministradorManager : IAdministradorManager
    {
        private AdministradorRepositorio _administradorRepositorio;
        public AdministradorManager()
        {
            _administradorRepositorio = new AdministradorRepositorio();
        }

        public bool Login(string usuario, string clave)
        {
            var administrador = _administradorRepositorio.Get(usuario, clave);
            return administrador != null;
        }
    }
}
