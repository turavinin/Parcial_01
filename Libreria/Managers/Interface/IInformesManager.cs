using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Managers.Interface
{
    public interface IInformesManager
    {
        void GenerarInformeInscripcionPeriodos(int? año, int? cuatrimestre);
        void GenerarInformeEstudianteCursos(string codigoCurso);
    }
}
