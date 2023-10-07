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
    public class ConceptoRepositorio
    {
        private readonly Archivo _archivo;
        private readonly string _path;

        public ConceptoRepositorio()
        {
            var pathSolucion = $"{Archivo.ObtenerDirectorioSolucion()?.FullName}\\Data\\Concepto";
            _path = Path.Combine(pathSolucion, "concepto.json");
            _archivo = new Archivo(_path);
        }

        public List<Concepto> Get()
        {
            var dataJson = _archivo.Leer();
            var data = new List<Concepto>();

            if (!string.IsNullOrEmpty(dataJson))
            {
                data = JsonConvert.DeserializeObject<List<Concepto>>(dataJson);
            }

            return data;
        }
    }
}
