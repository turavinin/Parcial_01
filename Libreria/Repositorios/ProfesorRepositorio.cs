using Dapper;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using Libreria.Entidades;
using Libreria.Entidades.Filters;
using Libreria.Repositorios.Handlers;
using Libreria.Repositorios.Interface;
using System.Data.SqlClient;
using System.Text;

namespace Libreria.Repositorios
{
    public class ProfesorRepositorio : IProfesorRepositorio
    {
        private readonly string _connectionString;
        public ProfesorRepositorio()
        {
            _connectionString = Database.ConnectionString;
        }

        public List<Profesor> Get(ProfesorFilters filters = null)
        {
            var sql = new StringBuilder();
            var dapperBuilder = new DapperBuilderManager();

            sql.AppendLine("SELECT");
            sql.AppendLine("  P.Id AS Id");
            sql.AppendLine(" ,P.Nombre AS Nombre");
            sql.AppendLine(" ,P.Direccion AS Direccion");
            sql.AppendLine(" ,P.Telefono AS Telefono");
            sql.AppendLine(" ,P.Email AS Email");
            sql.AppendLine(" ,P.AreasEspealizacion AS AreasEspealizacion");
            sql.AppendLine(" ,C.Id AS Id");
            sql.AppendLine(" ,C.Nombre AS Nombre");
            sql.AppendLine(" ,C.Codigo AS Codigo");
            sql.AppendLine(" ,C.Descripcion AS Descripcion"); ;
            sql.AppendLine(" ,C.Cupo AS Cupo");
            sql.AppendLine("FROM Profesor P");
            sql.AppendLine("LEFT JOIN CursoProfesor CP ON P.Id = CP.ProfesorId");
            sql.AppendLine("LEFT JOIN Curso C ON C.Id = CP.CursoId");

            dapperBuilder.AddWhereFilter("Id", "P.Id = @Id", filters?.Id)
                         .AddWhereFilter("Email", "P.Email = @Email", filters?.Email);
            dapperBuilder.AddWhereToSQL(sql);

            using var connection = new SqlConnection(_connectionString);
            var profesoresDictionary = new Dictionary<int, Profesor>();

            var result = connection.Query<Profesor, Curso, Profesor>(
                sql.ToString(),
                (profesorQuery, cursoQuery) =>
                {
                    if (!profesoresDictionary.TryGetValue(profesorQuery.Id, out var profesorExistente))
                    {
                        profesorExistente = profesorQuery;
                        profesorExistente.Cursos = new List<Curso>();
                        profesoresDictionary.Add(profesorQuery.Id, profesorExistente);
                    }

                    if (cursoQuery != null && !profesorExistente.Cursos.Any(x => x.Id == cursoQuery.Id))
                    {
                        profesorExistente.Cursos.Add(cursoQuery);
                    }

                    return profesorQuery;

                }, param: dapperBuilder.Parameters, splitOn: "Id").AsList();

            return profesoresDictionary.Values.ToList();
        }

        public void Create(Profesor profesor)
        {
            var sql = new StringBuilder();
            var dapperBuilder = new DapperBuilderManager();

            sql.AppendLine("INSERT INTO Profesor");
            dapperBuilder.AddInsertFilter("Nombre", "Nombre", profesor.Nombre)
                         .AddInsertFilter("Direccion", "Direccion", profesor.Direccion)
                         .AddInsertFilter("Telefono", "Telefono", profesor.Telefono)
                         .AddInsertFilter("Email", "Email", profesor.Email)
                         .AddInsertToSQL(sql);

            using var connection = new SqlConnection(_connectionString);
            connection.Execute(sql.ToString(), dapperBuilder.Parameters);
        }

        public void Update(Profesor profesor)
        {
            var sql = new StringBuilder();
            var dapperBuilder = new DapperBuilderManager();

            dapperBuilder.AddSetFilter("Nombre", "Nombre = @Nombre", profesor.Nombre)
                         .AddSetFilter("Direccion", "Direccion = @Direccion", profesor.Direccion)
                         .AddSetFilter("Telefono", "Telefono = @Telefono", profesor.Telefono)
                         .AddSetFilter("Email", "Email = @Email", profesor.Email)
                         .AddWhereFilter("Id", "Id = @Id", profesor.Id)
                         .AddUpdateSetWhereToSQL(sql, "Profesor");

            using var connection = new SqlConnection(_connectionString);
            connection.Execute(sql.ToString(), dapperBuilder.Parameters);
        }

        public void AsignarCursos(int profesorId, int cursoId)
        {
            var sql = new StringBuilder();
            var dapperBuilder = new DapperBuilderManager();

            sql.AppendLine("INSERT INTO CursoProfesor");
            dapperBuilder.AddInsertFilter("ProfesorId", "ProfesorId", profesorId)
                         .AddInsertFilter("CursoId", "CursoId", cursoId)
                         .AddInsertToSQL(sql);

            using var connection = new SqlConnection(_connectionString);
            connection.Execute(sql.ToString(), dapperBuilder.Parameters);
        }

        public void Delete(int id)
        {
            DeleteCursoProfesor(id);

            var sql = new StringBuilder();
            sql.AppendLine("DELETE FROM Profesor");
            sql.AppendLine("WHERE Id = @Id");

            var parameters = new DynamicParameters();
            parameters.Add("Id", id);

            using var connection = new SqlConnection(_connectionString);
            connection.Execute(sql.ToString(), parameters);
        }

        public void DeleteCursoProfesor(int profesorId)
        {
            var sql = new StringBuilder();
            sql.AppendLine("DELETE FROM CursoProfesor");
            sql.AppendLine("WHERE ProfesorId = @ProfesorId");

            var parameters = new DynamicParameters();
            parameters.Add("ProfesorId", profesorId);

            using var connection = new SqlConnection(_connectionString);
            connection.Execute(sql.ToString(), parameters);
        }
    }
}
