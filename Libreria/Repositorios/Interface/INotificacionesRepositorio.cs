﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Repositorios.Interface
{
    public interface INotificacionesRepositorio
    {
        Task CrearNotificacion(int estudianteId, int cursoId);
    }
}
