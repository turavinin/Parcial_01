using Libreria.Entidades;
using Libreria.Repositorios.Handlers;
using Newtonsoft.Json;

namespace Libreria.Repositorios
{
    public class AdministradorRepositorio
    {
        private readonly Archivo _archivo;
        private readonly string _path;

        public AdministradorRepositorio()
        {
            var pathSolucion = $"{Archivo.ObtenerDirectorioSolucion()?.FullName}\\Data\\Administradores";
            _path = Path.Combine(pathSolucion, "administradores.json");
            _archivo = new Archivo(_path);
        }

        public List<Administrador>? Get()
        {
            var datoAdmins = _archivo.Leer();
            var admins = new List<Administrador>();

            if (!string.IsNullOrEmpty(datoAdmins))
            {
                admins = JsonConvert.DeserializeObject<List<Administrador>>(datoAdmins);
            }

            return admins;
        }

        /// <summary>
        /// Obtiene al administrador.
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="clave"></param>
        /// <returns>Al administrador o null.</returns>
        public Administrador? Get(string usuario, string clave)
        {
            var admins = Get();

            if (admins != null && admins.Count > 0)
            {
                return admins?.FirstOrDefault(x => x.Usuario == usuario && x.Clave == clave);
            }

            return default;
        }
    }
}
