using Libreria.Entidades;
using Libreria.Entidades.Filters;
using Libreria.Managers.Interface;
using Libreria.Repositorios;
using Libreria.Repositorios.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Managers
{
    public class PagoManager : IPagoManager
    {
        private IPagoRepositorio _pagoRepositorio;
        public PagoManager()
        {
            _pagoRepositorio = new PagoRepositorio();
        }

        public List<Pago> Get(PagoFilters filters = null)
        {
            return _pagoRepositorio.Get(filters);
        }

        public void Crear(Pago pago, int estudianteId)
        {
            _pagoRepositorio.Post(pago, estudianteId);
        }

        public void Actualizar(Pago pago, int estudianteId)
        {
            _pagoRepositorio.Update(pago, estudianteId);
        }
    }
}
