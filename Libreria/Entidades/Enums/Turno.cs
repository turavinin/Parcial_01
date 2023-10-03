using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Entidades.Enums
{
    public enum Turno
    {
        Default = 0,
        Mañana,
        Tarde,
        Noche
    }

    public static class EnumTurnoHelper
    {
        public static List<Turno> GetTurnos(bool conDefault = false)
        {
            var lista = ((Turno[])Enum.GetValues(typeof(Turno)));

            if (!conDefault)
            {
                return lista.Where(x => x != Turno.Default).ToList();
            }

            return lista.ToList();
        }
    }
}
