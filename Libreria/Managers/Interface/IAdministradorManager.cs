using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Managers.Interface
{
    public interface IAdministradorManager
    {
        bool Login(string usuario, string clave);
    }
}
