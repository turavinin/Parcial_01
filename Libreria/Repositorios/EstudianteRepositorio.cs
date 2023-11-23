using Dapper;
using Libreria.Entidades;
using Libreria.Entidades.Filters;
using Libreria.Repositorios.Handlers;
using Libreria.Repositorios.Interface;
using System.Data.SqlClient;
using System.Text;

namespace Libreria.Repositorios
{
    public class EstudianteRepositorio : IEstudianteRepositorio
    {
        private readonly string _connectionString;

        public EstudianteRepositorio()
        {
            _connectionString = Database.ConnectionString;
        }

        public List<Estudiante> Get(EstudianteFilters filters = null)
        {
            var sql = new StringBuilder();
            var dapperBuilder = new DapperBuilderManager();

            sql.AppendLine("SELECT");
            sql.AppendLine("  E.Id AS Id");
            sql.AppendLine(" ,E.Legajo AS Legajo");
            sql.AppendLine(" ,E.Nombre AS Nombre");
            sql.AppendLine(" ,E.Direccion AS Direccion");
            sql.AppendLine(" ,E.Documento AS Documento");
            sql.AppendLine(" ,E.Telefono AS Telefono");
            sql.AppendLine(" ,E.Email AS Email");
            sql.AppendLine(" ,E.Clave AS Clave");
            sql.AppendLine(" ,E.CambiarClave AS CambiarClave");
            sql.AppendLine(" ,I.Id AS Id");
            sql.AppendLine(" ,I.Turno AS Turno");
            sql.AppendLine(" ,I.Aula AS Aula");
            sql.AppendLine(" ,I.Dia AS Dia");
            sql.AppendLine(" ,I.Anio AS Anio");
            sql.AppendLine(" ,I.Cuatrimestre AS Cuatrimestre");
            sql.AppendLine(" ,C.Id AS Id");
            sql.AppendLine(" ,C.Nombre AS Nombre");
            sql.AppendLine(" ,C.Codigo AS Codigo");
            sql.AppendLine(" ,C.Descripcion AS Descripcion");;
            sql.AppendLine(" ,C.Cupo AS Cupo");
            sql.AppendLine(" ,P.Id AS Id");
            sql.AppendLine(" ,P.MontoPagado AS MontoPagado");
            sql.AppendLine(" ,P.Cancelado AS Cancelado");
            sql.AppendLine(" ,CO.Id AS Id");
            sql.AppendLine(" ,CO.Descripcion AS Descripcion");
            sql.AppendLine(" ,CO.Monto AS Monto");
            sql.AppendLine("FROM Estudiante E");
            sql.AppendLine("LEFT JOIN Inscripcion I ON E.Id = I.EstudianteId");
            sql.AppendLine("LEFT JOIN Curso C ON C.Id = I.CursoId");
            sql.AppendLine("LEFT JOIN Pago P ON P.EstudianteId = E.Id");
            sql.AppendLine("LEFT JOIN Concepto CO ON CO.Id = P.ConceptoId");

            BuildFilters(sql, dapperBuilder, filters);

            using var connection = new SqlConnection(_connectionString);
            var estudiantesDictionary = new Dictionary<int, Estudiante>();

            var result = connection.Query<Estudiante, Inscripcion, Curso, Pago, Concepto, Estudiante>(
                sql.ToString(),
                (estudianteQuery, inscripcionQuery, cursoQuery, pagoQuery, conceptoQuery) =>
                {
                    if (!estudiantesDictionary.TryGetValue(estudianteQuery.Id, out var existingEstudiante))
                    {
                        existingEstudiante = estudianteQuery;
                        existingEstudiante.Inscripciones = new List<Inscripcion>();
                        existingEstudiante.Pagos = new List<Pago>();
                        estudiantesDictionary.Add(estudianteQuery.Id, existingEstudiante);
                    }

                    if (inscripcionQuery != null && !existingEstudiante.Inscripciones.Any(x => x.Id == inscripcionQuery.Id))
                    {
                        existingEstudiante.Inscripciones.Add(inscripcionQuery);
                    }

                    if (cursoQuery != null)
                    {
                        inscripcionQuery.Curso = cursoQuery;
                    }

                    if (pagoQuery != null && !existingEstudiante.Pagos.Any(x => x.Id == pagoQuery.Id))
                    {
                        existingEstudiante.Pagos.Add(pagoQuery);
                    }

                    if (conceptoQuery != null)
                    {
                        pagoQuery.Concepto = conceptoQuery;
                    }

                    return estudianteQuery;

                }, param: dapperBuilder.Parameters, splitOn: "Id, Id, Id, Id").AsList();

            return estudiantesDictionary.Values.ToList();
        }

        public void Post(Estudiante estudiante)
        {
            var sql = new StringBuilder();
            sql.AppendLine("INSERT INTO Estudiante");
            sql.AppendLine("(Legajo, Nombre, Direccion, Documento, Telefono, Email, Clave, CambiarClave)");
            sql.AppendLine("VALUES");
            sql.AppendLine("(@Legajo, @Nombre, @Direccion, @Documento, @Telefono, @Email, @Clave, @CambiarClave)");

            var parameters = new DynamicParameters();
            parameters.Add("Legajo", estudiante.Legajo);
            parameters.Add("Nombre", estudiante.Nombre);
            parameters.Add("Direccion", estudiante.Direccion);
            parameters.Add("Documento", estudiante.Documento);
            parameters.Add("Telefono", estudiante.Telefono);
            parameters.Add("Email", estudiante.Email);
            parameters.Add("Clave", estudiante.Clave);
            parameters.Add("CambiarClave", estudiante.CambiarClave);

            using var connection = new SqlConnection(_connectionString);
            connection.Execute(sql.ToString(), parameters);
        }

        public void Update(Estudiante estudiante)
        {
            var sql = new StringBuilder();
            sql.AppendLine("UPDATE Estudiante SET");
            sql.AppendLine("Legajo = @Legajo");
            sql.AppendLine(",Nombre = @Nombre");
            sql.AppendLine(",Direccion = @Direccion");
            sql.AppendLine(",Documento = @Documento");
            sql.AppendLine(",Telefono = @Telefono");
            sql.AppendLine(",Email = @Email");
            sql.AppendLine(",Clave = @Clave");
            sql.AppendLine(",CambiarClave = @CambiarClave");
            sql.AppendLine("WHERE Id = @Id");

            var parameters = new DynamicParameters();
            parameters.Add("Legajo", estudiante.Legajo);
            parameters.Add("Nombre", estudiante.Nombre);
            parameters.Add("Direccion", estudiante.Direccion);
            parameters.Add("Documento", estudiante.Documento);
            parameters.Add("Telefono", estudiante.Telefono);
            parameters.Add("Email", estudiante.Email);
            parameters.Add("Clave", estudiante.Clave);
            parameters.Add("CambiarClave", estudiante.CambiarClave);
            parameters.Add("Id", estudiante.Id);

            using var connection = new SqlConnection(_connectionString);
            connection.Execute(sql.ToString(), parameters);
        }

        private static void BuildFilters(StringBuilder sql, DapperBuilderManager dapperBuilder, EstudianteFilters filters = null)
        {
            dapperBuilder.AddWhereFilter("Id", "E.Id = @Id", filters?.Id)
                         .AddWhereFilter("Legajo", "E.Legajo = @Legajo", filters?.Legajo)
                         .AddWhereFilter("Anio", "I.Anio = @Anio", filters?.Anio)
                         .AddWhereFilter("Cuatrimestre", "I.Cuatrimestre = @Cuatrimestre", filters?.Cuatrimestre)
                         .AddWhereFilter("CodigoCurso", "C.Codigo = @CodigoCurso", filters?.CodigoCurso);
            dapperBuilder.AddWhereToSQL(sql);
        }
    }
}
