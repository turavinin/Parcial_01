using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Entidades.Enums
{
    public enum Dia
    {
        Default = 0,
        Lunes = 1,
        Martes,
        Miercoles,
        Jueves,
        Viernes
    }

    public static class EnumDiaHelper
    {
        public static List<Dia> GetDias(bool conDefault = false)
        {
            var lista = ((Dia[])Enum.GetValues(typeof(Dia)));

            if(!conDefault)
            {
                return lista.Where(x => x != Dia.Default).ToList();
            }

            return lista.ToList();
        }
    }
}
