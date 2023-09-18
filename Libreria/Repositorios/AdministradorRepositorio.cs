using Libreria.Entidades;
using Libreria.Repositorios.Handlers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Administrador? Get(string legajo, string clave)
        {
            var admins = Get();

            if (admins != null && admins.Count > 0)
            {
                return admins?.FirstOrDefault(x => x.Usuario == legajo && x.Clave == clave);
            }

            return default;
        }
    }
}
