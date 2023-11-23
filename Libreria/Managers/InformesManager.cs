using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml;
using Libreria.Entidades.Filters;
using Libreria.Managers.Interface;
using Libreria.Repositorios;
using Libreria.Repositorios.Interface;
using DocumentFormat.OpenXml.Spreadsheet;
using Libreria.Entidades;
using Libreria.Helpers;

namespace Libreria.Managers
{
    public class InformesManager : IInformesManager
    {
        private readonly IEstudianteRepositorio _estudianteRepositorio;
        public InformesManager()
        {
            _estudianteRepositorio = new EstudianteRepositorio();
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
    }
}
