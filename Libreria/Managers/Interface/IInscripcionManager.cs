using Libreria.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Managers.Interface
{
    public interface IInscripcionManager
    {
        void Crear(Inscripcion inscripcion, int estudianteId);
    }
}
