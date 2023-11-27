using Libreria.Entidades;
using Libreria.Entidades.Enums;
using Libreria.Entidades.Filters;
using Libreria.Exceptions;
using Libreria.Exceptions.Enums;
using Libreria.Managers.Interface;
using Libreria.Repositorios;
using Libreria.Repositorios.Interface;
using System.Text;

namespace Libreria.Managers
{
    public delegate void DelegadoNotificacion(int estudianteId, List<Curso> cursos);

    public class EstudianteManager : IEstudianteManager
    {
        private EstudianteRepositorio _estudianteRepositorio;

        private ICursoManager _cursoManager;
        private ICursoRepositorio _cursoRepositorio;
        private IConceptoManager _conceptoManager;
        private IPagoManager _pagoManager;
        private IInscripcionManager _inscripcionManager;
        private INotificacionesRepositorio _notificacionesRepositorio;
        public event DelegadoNotificacion EventoNotificacion;

        public EstudianteManager()
        {
            _estudianteRepositorio = new EstudianteRepositorio();
            _cursoManager = new CursoManager();
            _pagoManager = new PagoManager();
            _conceptoManager = new ConceptoManager();
            _inscripcionManager = new InscripcionManager();
            _notificacionesRepositorio = new NotificacionesRepositorio();
            _cursoRepositorio = new CursoRepositorio();

        }

        public bool Login(string legajo, string clave)
        {
            var estudiante = _estudianteRepositorio.Get(new EstudianteFilters { Legajo = legajo }).FirstOrDefault();
            return estudiante != null && estudiante.ClaveValida(clave);
        }

        public List<Estudiante> Get()
        {
            return _estudianteRepositorio.Get();
        }

        public Estudiante Get(int id)
        {
            return _estudianteRepositorio.Get(new EstudianteFilters { Id = id }).FirstOrDefault();
        }

        public Estudiante Get(string legajo)
        {
            return _estudianteRepositorio.Get(new EstudianteFilters { Legajo = legajo }).FirstOrDefault();
        }

        public void Crear(Estudiante estudiante)
        {
            estudiante.AsignarLegajo();

            if (!estudiante.Validar())
            {
                throw new ExceptionsInternas(estudiante.ErroresValidacion, TipoError.ErrorCrearUsuario);
            }

            estudiante.EncryptClave();

            _estudianteRepositorio.Post(estudiante);
        }

        public void ActualizarClave(Estudiante estudiante)
        {
            if (!estudiante.Validar(true))
            {
                throw new ExceptionsInternas(estudiante.ErroresValidacion, TipoError.ErrorActualizarClaveEstudiante);
            }

            estudiante.CambiarClave = false;
            estudiante.EncryptClave();
            _estudianteRepositorio.Update(estudiante);
        }

        public bool Inscribir(Estudiante estudiante, List<string> cursoCodigos)
        {
            var cursosExistentes = _cursoManager.Get();

            var cursosSeleccionados = cursosExistentes.Where(x => cursoCodigos.Contains(x.Codigo)).ToList();
            if (!cursosSeleccionados.Any())
            {
                throw new ExceptionsInternas("No se encontraron los cursos seleccionados", TipoError.ErrorInscribirCursoAEstudiante);
            }

            var cursosAgotados = cursosSeleccionados.Where(x => x.Cupo <= 0).ToList();
            if (cursosAgotados.Count == cursosSeleccionados.Count)
            {
                throw new ExceptionsInternas("Todos los cursos seleccionados no tienen cupo", TipoError.ErrorInscribirCursoAEstudiante);
            }

            var cursosValidos = cursosSeleccionados.Except(cursosAgotados).ToList();
            var cursosFallidos = new List<Curso>();

            AsignarCursos(estudiante, cursosValidos, cursosFallidos);
            InformarErrores(cursosAgotados, cursosFallidos);

            return true;
        }

        public void Pagar(Estudiante estudiante, Pago pago, Dictionary<int, string> conceptoMontoPagado)
        {
            ValidarYGestionarPago(pago);
            var conceptos = _conceptoManager.Get();

            foreach (var conceptoPagado in conceptoMontoPagado)
            {
                var concepto = conceptos.FirstOrDefault(x => x.Id == conceptoPagado.Key);

                if (concepto != null)
                {
                    var conceptoPagadoPreviamente = estudiante.Pagos.FirstOrDefault(x => x.Concepto.Id == concepto.Id);

                    if (conceptoPagadoPreviamente is null)
                    {
                        pago.Concepto = concepto;
                        pago.MontoPagado = int.Parse(conceptoPagado.Value);
                        pago.Cancelado = concepto.Monto == pago.MontoPagado;

                        _pagoManager.Crear(pago, estudiante.Id);
                    }
                    else
                    {
                        conceptoPagadoPreviamente.MontoPagado += int.Parse(conceptoPagado.Value);
                        conceptoPagadoPreviamente.Cancelado = conceptoPagadoPreviamente.MontoPagado == concepto.Monto;
                        _pagoManager.Actualizar(conceptoPagadoPreviamente, estudiante.Id);
                    }
                }
            }
        }

        public async Task CompletarNotificacion(int estudianteId, List<int> cursosIds)
        {
            foreach (var cursoId in cursosIds)
            {
                await _notificacionesRepositorio.ActualizarNotificaciones(estudianteId, cursoId);
            }
        }

        private void AsignarCursos(Estudiante estudiante, List<Curso> cursosAInscribir, List<Curso> cursosFallidos)
        {
            cursosFallidos ??= new List<Curso>();

            foreach (var curso in cursosAInscribir)
            {
                var inscripcion = AsignarCursoYHorarios(estudiante, curso, cursosFallidos);

                if (inscripcion != null)
                {
                    AsginarAnioYCuatrimestre(inscripcion);
                    curso.Cupo--;
                    _cursoManager.Editar(curso);
                    _inscripcionManager.Crear(inscripcion, estudiante.Id);
                }
            }
        }

        private Inscripcion AsignarCursoYHorarios(Estudiante estudiante, Curso curso, List<Curso> cursosFallidos, bool buscarPorTurno = false)
        {
            var diaAsignado = Dia.Default;
            var turnoAsignado = Turno.Default;

            foreach (var dia in EnumDiaHelper.GetDias())
            {
                if (buscarPorTurno)
                {
                    var turnoDisponible = Turno.Default;
                    var turnoEcontrado = BuscarTurnoDisponible(estudiante, dia, out turnoDisponible);

                    if (!turnoEcontrado)
                    {
                        continue;
                    }

                    diaAsignado = dia;
                    turnoAsignado = turnoDisponible;
                    break;
                }

                if (estudiante?.Inscripciones.Count == 0 || !estudiante.Inscripciones.Any(x => x.Dia == dia))
                {
                    diaAsignado = dia;
                    turnoAsignado = Turno.Mañana;
                    break;
                }
            }

            if (diaAsignado == Dia.Default && !buscarPorTurno)
            {
                return AsignarCursoYHorarios(estudiante, curso, cursosFallidos, true);
            }
            else if (diaAsignado == Dia.Default && buscarPorTurno)
            {
                cursosFallidos.Add(curso);
                return default;
            }
            else
            {
                var inscripcion = new Inscripcion();
                inscripcion.Curso = curso;
                inscripcion.Turno = turnoAsignado;
                inscripcion.Dia = diaAsignado;
                inscripcion.Aula = new Random().Next(1, 50);

                return inscripcion;
            }
        }

        private bool BuscarTurnoDisponible(Estudiante estudiante, Dia diaAnalizado, out Turno turnoDisponible)
        {
            turnoDisponible = Turno.Default;
            var turnos = EnumTurnoHelper.GetTurnos();
            var turnosOcupados = estudiante.Inscripciones.Where(x => x.Dia == diaAnalizado).Select(x => x.Turno).ToList();
            var noHayTurnosDisponibles = turnosOcupados.Count == turnos.Count;

            if (noHayTurnosDisponibles)
            {
                return false;
            }

            var posibleTurnoDisponible = turnos.Where(x => !turnosOcupados.Any(z => z == x)).FirstOrDefault();
            if (posibleTurnoDisponible == null)
            {
                return false;
            }

            turnoDisponible = posibleTurnoDisponible;
            return true;
        }

        private void InformarErrores(List<Curso> cursosAgotados, List<Curso> cursosFallidos)
        {
            var mensajeError = new StringBuilder();
            var listaErrores = new List<string>();

            if (cursosAgotados.Any())
            {
                mensajeError.Append("No se pudo inscribir los siguientes cursos por agotarse el cupo:");
                mensajeError.AppendLine();
                cursosAgotados.ForEach(x => mensajeError.AppendLine(x.Nombre));

                listaErrores.Add(mensajeError.ToString());
                mensajeError.Clear();
            }

            if (cursosFallidos.Any())
            {
                mensajeError.Append("No se pudo inscribir los siguientes cursos por agotarse los turnos:");
                mensajeError.AppendLine();
                cursosFallidos.ForEach(x => mensajeError.AppendLine(x.Nombre));

                listaErrores.Add(mensajeError.ToString());
                mensajeError.Clear();
            }

            if (listaErrores.Count > 0)
            {
                throw new ExceptionsInternas(listaErrores, TipoError.ErrorInscribirCursoAEstudiante);
            }
        }

        private void ValidarYGestionarPago(Pago pago)
        {
            if (pago.Codigo == 666)
            {
                throw new ExceptionsInternas("No se pudo realizar le pago. Intente de nuevo.", TipoError.ErrorPago);
            }
        }

        private void AsginarAnioYCuatrimestre(Inscripcion inscripcion)
        {
            inscripcion.Anio = DateTime.Now.Year;
            inscripcion.Cuatrimestre = DateTime.Now.Month <= 7 ? 1 : 2;
        }

        public async Task VerificarNotificacionesCursos(Estudiante estudiante)
        {
            do
            {
                var notificaciones = await _notificacionesRepositorio.Get(estudiante.Id);
                var cursos = new List<Curso>();

                if (notificaciones.Count > 0)
                {
                    foreach (var notificacion in notificaciones)
                    {
                        var curso = _cursoRepositorio.Get(new CursoFilters { Id = notificacion.CursoId }).FirstOrDefault();
                        cursos.Add(curso);
                    }

                    if (this.EventoNotificacion is not null)
                    {
                        this.EventoNotificacion.Invoke(estudiante.Id, cursos);
                    }
                }

                await Task.Delay(60000);

            } while (true);
        }
    }
}
