using Libreria.Entidades;
using Libreria.Entidades.Enums;
using Libreria.Exceptions;
using Libreria.Exceptions.Enums;
using Libreria.Helpers;
using Libreria.Repositorios;
using System.Security.Cryptography;
using System.Text;

namespace Libreria.Managers
{
    public class AdministracionManager
    {
        private EstudianteRepositorio _estudianteRepositorio;
        private AdministradorRepositorio _administradorRepositorio;
        private CursoRepositorio _cursoRepositorio;
        private EstudianteCursoRepositorio _estudiantesCursosRepositorio;
        private ConceptoRepositorio _conceptoRepositorio;
        private EstudianteConceptoRepositorio _estudianteConceptoRepositorio;

        private Estudiante _estudiante;
        private Administrador _administrador;

        private EmailHelper _emailHelper;

        public Estudiante Estudiante { get => _estudiante; }

        public AdministracionManager()
        {
            _estudianteRepositorio = new EstudianteRepositorio();
            _administradorRepositorio = new AdministradorRepositorio();
            _cursoRepositorio = new CursoRepositorio();
            _estudiantesCursosRepositorio = new EstudianteCursoRepositorio();
            _conceptoRepositorio = new ConceptoRepositorio();
            _estudianteConceptoRepositorio = new EstudianteConceptoRepositorio();
            _emailHelper = new EmailHelper();
        }

        public bool LoginUsuario(string usuario, string clave, bool isAdmin)
        {
            if (isAdmin)
            {
                return LoginAdministrador(usuario, clave);
            }

            return LoginEstudiante(usuario, clave);
        }

        #region Estudiante
        public Estudiante? GetEstudiante(string legajo)
        {
            return _estudianteRepositorio.Get(legajo);
        }

        public bool RegistrarEstudiante(Estudiante estudiante)
        {
            _administrador.AsginarLegajoEstudiante(estudiante);

            if (!estudiante.Validar())
            {
                throw new ExceptionsInternas(estudiante.ErroresValidacion, TipoError.ErrorCrearUsuario);
            }

            estudiante.EncryptClave();

            _estudianteRepositorio.Post(estudiante);
            _emailHelper.EnviarEmail(estudiante.Email, $"Estudiante creado. Legajo: {estudiante.Legajo}");

            return true;
        } 

        public bool ActualizarClaveEstudiante(Estudiante estudiante)
        {
            if (!estudiante.Validar(true))
            {
                throw new ExceptionsInternas(estudiante.ErroresValidacion, TipoError.ErrorActualizarClaveEstudiante);
            }

            estudiante.CambiarClave = false;
            estudiante.EncryptClave();
            _estudianteRepositorio.Update(estudiante);
            return true;
        }

        public bool InscribirCursosAEstudiante(Estudiante estudiante, List<string> codigosCursos)
        {
            var cursos = _cursoRepositorio.Get();

            var cursosSeleccionados = cursos.Where(x => codigosCursos.Contains(x.Codigo)).ToList();
            if (!cursosSeleccionados.Any())
            {
                throw new ExceptionsInternas("No se encontraron los cursos seleccionados", TipoError.ErrorInscribirCursoAEstudiante);
            }

            var cursosAgotados = cursosSeleccionados.Where(x => x.CupoMaximo <= 0).ToList();
            if (cursosAgotados.Count == cursosSeleccionados.Count)
            {
                throw new ExceptionsInternas("Todos los cursos seleccionados no tienen cupo", TipoError.ErrorInscribirCursoAEstudiante);
            }

            var cursosValidos = cursosSeleccionados.Except(cursosAgotados).ToList();
            var cursosFallidos = new List<Curso>();

            AsignarCursos(cursosValidos, Estudiante, cursosFallidos);
            InformarErrores(cursosAgotados, cursosFallidos);

            return true;
        }

        private void AsignarCursos(List<Curso> cursos, Estudiante estudiante, List<Curso> cursosFallidos)
        {
            cursosFallidos ??= new List<Curso>();

            foreach (var curso in cursos)
            {
                var estudianteCurso = AsignarCursoYHorarios(estudiante, curso, cursosFallidos);

                if (estudianteCurso != null)
                {
                    curso.CupoMaximo--;
                    _cursoRepositorio.Update(curso, curso.Codigo);
                    _estudiantesCursosRepositorio.Post(estudianteCurso);
                }
            }
        }

        private EstudianteCurso AsignarCursoYHorarios(Estudiante estudiante, Curso curso, List<Curso> cursosFallidos, bool buscarPorTurno = false)
        {
            var cursosAsignados = _estudiantesCursosRepositorio.Get(estudiante.Legajo);
            var diaAsignado = Dia.Default;
            var turnoAsignado = Turno.Default;
            
            foreach (var dia in EnumDiaHelper.GetDias())
            {
                if (buscarPorTurno)
                {
                    var turnoDisponible = Turno.Default;
                    var turnoEcontrado = BuscarTurnoDisponible(cursosAsignados, dia, out turnoDisponible);

                    if (!turnoEcontrado)
                    {
                        continue;
                    }

                    diaAsignado = dia;
                    turnoAsignado = turnoDisponible;
                    break;
                }

                if (cursosAsignados == null || !cursosAsignados.Any(x => x.Dia == dia))
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
                return new EstudianteCurso(estudiante.Legajo, curso.Codigo, turnoAsignado, diaAsignado);
            }
        }

        private bool BuscarTurnoDisponible(List<EstudianteCurso> cursosAsignados, Dia diaAnalizado, out Turno turnoDisponible)
        {
            turnoDisponible = Turno.Default;
            var turnos = EnumTurnoHelper.GetTurnos();
            var turnosOcupados = cursosAsignados.Where(x => x.Dia == diaAnalizado).Select(x => x.Turno).ToList();
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

            if(cursosAgotados.Any())
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
        #endregion

        #region Cursos
        public List<Curso>? GetCursos()
        {
            return _cursoRepositorio.Get();
        } 

        public Curso? GetCurso(string codigo)
        {
            return _cursoRepositorio.Get(codigo);
        }

        public bool CrearCurso(Curso curso)
        {
            if (!curso.Validar())
            {
                throw new ExceptionsInternas(curso.ErroresValidacion, TipoError.ErrorCrearCurso);
            }

            curso.Codigo = curso.Codigo.ToUpper();
            AsginarAula(curso);
            _cursoRepositorio.Post(curso);
            return true;
        }

        public bool EditarCurso(Curso curso, string codigoCursoGuardado)
        {
            if (!curso.Validar(true, codigoCursoGuardado))
            {
                throw new ExceptionsInternas(curso.ErroresValidacion, TipoError.ErrorEditarCurso);
            }

            curso.Codigo = curso.Codigo.ToUpper();
            _cursoRepositorio.Update(curso, codigoCursoGuardado);
            return true;
        }

        public bool EliminarCurso(string codigo)
        {
            _cursoRepositorio.Delete(codigo);
            return true;
        }

        private void AsginarAula(Curso curso)
        {
            var cursos = _cursoRepositorio.Get();

            for (int i = 1; i < int.MaxValue; i++)
            {
                if (cursos == null  || !cursos.Any(x => x.Aula == i))
                {
                    curso.Aula = i;
                    break;
                }
            }
        }
        #endregion

        #region EstudianteCursos
        public List<EstudianteCurso> Get(string legajo)
        {
            return _estudiantesCursosRepositorio.Get(legajo);
        }
        #endregion

        #region Concepto
        public List<Concepto> GetConceptos()
        {
            return _conceptoRepositorio.Get();
        }

        public List<EstudianteConcepto> GetEstudianteConcepto(string legajo)
        {
            return _estudianteConceptoRepositorio.Get(legajo);
        }

        public void ProcesarPago(Estudiante estudiante, DatosPago datosPago, Dictionary<int, string> conceptoMontoPagado)
        {
            ValidarYGestionarPago(datosPago, conceptoMontoPagado);

            var conceptos = _conceptoRepositorio.Get();

            foreach (var conceptoPagado in conceptoMontoPagado)
            {
                var conceptoAPagar = conceptos.FirstOrDefault(x => x.Id == conceptoPagado.Key);

                if(conceptoAPagar != null)
                {
                    var conceptosEstudiante = _estudianteConceptoRepositorio.Get(estudiante.Legajo);
                    var conceptoEstudianteRegistrado = conceptosEstudiante.FirstOrDefault(x => x.IdConcepto == conceptoPagado.Key);

                    if (conceptoEstudianteRegistrado is null)
                    {
                        var cancelado = float.Parse(conceptoPagado.Value) == conceptoAPagar.Monto;
                        conceptoEstudianteRegistrado = new EstudianteConcepto(estudiante.Legajo, conceptoAPagar.Id, float.Parse(conceptoPagado.Value), cancelado);
                    }
                    else
                    {
                        conceptoEstudianteRegistrado.MontoPagado += float.Parse(conceptoPagado.Value);
                        conceptoEstudianteRegistrado.Cancelado = conceptoEstudianteRegistrado.MontoPagado == conceptoAPagar.Monto;
                    }

                    _estudianteConceptoRepositorio.PostOrUpdate(conceptoEstudianteRegistrado);
                }
            }
        }

        private void ValidarYGestionarPago(DatosPago pago, Dictionary<int, string> conceptoMontoPagado)
        {
            if (pago.Codigo == 666)
            {
                throw new ExceptionsInternas("No se pudo realizar le pago. Intente de nuevo.", TipoError.ErrorPago);
            }
        }
        #endregion

        #region Private
        private bool LoginAdministrador(string usuario, string clave)
        {
            _administrador = _administradorRepositorio.Get(usuario, clave);

            if (_administrador == null)
            {
                return false;
            }

            return true;
        }

        private bool LoginEstudiante(string legajo, string clave)
        {
            _estudiante = _estudianteRepositorio.Get(legajo);

            if(_estudiante == null || !_estudiante.ClaveValida(clave))
            {
                return false;
            }

            return true;
        }
        #endregion
    }
}
