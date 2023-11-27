using Libreria.Entidades;
using Libreria.Entidades.Filters;
using Libreria.Helpers;
using Libreria.Managers.Interface;
using Libreria.Repositorios;
using Libreria.Repositorios.Interface;

namespace Libreria.Managers
{
    public class InformesManager : IInformesManager
    {
        private readonly IEstudianteRepositorio _estudianteRepositorio;
        private readonly IPagoRepositorio _pagoRepositorio;
        private readonly ICursoManager _cursoManager;
        public InformesManager()
        {
            _pagoRepositorio = new PagoRepositorio();
            _estudianteRepositorio = new EstudianteRepositorio();
            _cursoManager = new CursoManager();
        }

        public void GenerarInformeInscripcionPeriodos(int? año, int? cuatrimestre)
        {
            var filters = new EstudianteFilters
            {
                Anio = año,
                Cuatrimestre = cuatrimestre
            };
            var estudiantes = _estudianteRepositorio.Get(filters);

            var headers = new List<string>() { "Nombre", "Legajo", "Documento", "Curso", "Cuatrimestre", "Año" };
            var dataEstudiantes = new List<List<string>>();
            foreach (var estudiante in estudiantes)
            {
                foreach (var inscripcion in estudiante.Inscripciones)
                {
                    var dataEstudiante = new List<string>()
                    {
                        estudiante.Nombre,
                        estudiante.Legajo,
                        estudiante.Documento,
                        inscripcion.Curso.Nombre,
                        inscripcion.Cuatrimestre.ToString(),
                        inscripcion.Anio.ToString()
                    };

                    dataEstudiantes.Add(dataEstudiante);
                }
            }

            var excelHelper = new ExcelHelper();
            excelHelper.SetFileData("InformeEstudiantes", "Informe Estudiantes")
                       .SetHeaders(headers)
                       .SetData(dataEstudiantes)
                       .Export();
        }

        public void GenerarInformeEstudianteCursos(string codigoCurso)
        {
            var filters = new EstudianteFilters
            {
                CodigoCurso = codigoCurso
            };
            var estudiantes = _estudianteRepositorio.Get(filters);

            var headers = new List<string>() { "Nombre", "Legajo", "Documento", "Direccion", "Telefono", "Email" };
            var dataEstudiantes = new List<List<string>>();
            foreach (var estudiante in estudiantes)
            {
                var dataEstudiante = new List<string>()
                {
                        estudiante.Nombre,
                        estudiante.Legajo,
                        estudiante.Documento,
                        estudiante.Direccion,
                        estudiante.Telefono,
                        estudiante.Email
                };

                dataEstudiantes.Add(dataEstudiante);
            }

            var excelHelper = new ExcelHelper();
            excelHelper.SetFileData("InformeEstudianteCursos", "Informe Estudiantes Cursos")
                       .SetHeaders(headers)
                       .SetData(dataEstudiantes)
                       .Export();
        }

        public void GenerarInformeIngresosConcepto(int conceptoId)
        {
            var filters = new PagoFilters { ConceptoId = conceptoId };
            var pagos = _pagoRepositorio.Get(filters);

            var headers = new List<string>() { "Concepto", "MontoPagado" };
            var dataPagos = new List<List<string>>();
            foreach (var pago in pagos)
            {
                var dataPago = new List<string>()
                {
                        pago.Concepto.Descripcion,
                        pago.MontoPagado.ToString()
                };

                dataPagos.Add(dataPago);
            }

            var excelHelper = new ExcelHelper();
            excelHelper.SetFileData("InformePagosConcepto", "Informe pagos Concepto")
                       .SetHeaders(headers)
                       .SetData(dataPagos)
                       .Export();
        }

        public void GenerarInformeCarreras(int carreraId)
        {
            var filters = new EstudianteFilters
            {
                CarreraId = carreraId
            };
            var estudiantes = _estudianteRepositorio.Get(filters);

            var headers = new List<string>() { "Nombre", "Legajo", "Documento", "Curso", "Cuatrimestre", "Año" };
            var dataEstudiantes = new List<List<string>>();
            foreach (var estudiante in estudiantes)
            {
                foreach (var inscripcion in estudiante.Inscripciones)
                {
                    var dataEstudiante = new List<string>()
                    {
                        estudiante.Nombre,
                        estudiante.Legajo,
                        estudiante.Documento,
                        inscripcion.Curso.Nombre,
                        inscripcion.Cuatrimestre.ToString(),
                        inscripcion.Anio.ToString()
                    };

                    dataEstudiantes.Add(dataEstudiante);
                }
            }

            var excelHelper = new ExcelHelper();
            excelHelper.SetFileData("InformeCarreras", "Informe Carreras")
                       .SetHeaders(headers)
                       .SetData(dataEstudiantes)
                       .Export();
        }

        public void GenerarInformeListaEspera(int cursoId)
        {
            var listaEspera = _cursoManager.GetListaEspera(new ListaEsperaFilters() { CursoId = cursoId });

            var headers = new List<string>() { "Nombre estudiante", "Curso", "Fecha Agregado" };
            var dataListaEsperas = new List<List<string>>();

            foreach (var estudianteEspera in listaEspera)
            {
                var data = new List<string>()
                {
                        estudianteEspera.Estudiante.Nombre,
                        estudianteEspera.Curso.Nombre,
                        estudianteEspera.FechaAgregado.ToString()
                };

                dataListaEsperas.Add(data);
            }

            var excelHelper = new ExcelHelper();
            excelHelper.SetFileData("InformeListaEspera", "Informe Lista Espera")
                       .SetHeaders(headers)
                       .SetData(dataListaEsperas)
                       .Export();

        }
    }
}
