using Dapper;
using DocumentFormat.OpenXml.Spreadsheet;
using Libreria.Entidades;
using Libreria.Entidades.Filters;
using Libreria.Repositorios.Handlers;
using Libreria.Repositorios.Interface;
using System.Data.SqlClient;
using System.Text;

namespace Libreria.Repositorios
{
    public class CursoRepositorio : ICursoRepositorio
    {
        private readonly string _connectionString;

        public CursoRepositorio()
        {
            _connectionString = Database.ConnectionString;
        }

        public List<Curso> Get(CursoFilters filters = null)
        {
            var sql = new StringBuilder();
            var dapperBuilder = new DapperBuilderManager();

            sql.AppendLine("SELECT");
            sql.AppendLine("  C.Id AS Id");
            sql.AppendLine(" ,C.Nombre AS Nombre");
            sql.AppendLine(" ,C.Codigo AS Codigo");
            sql.AppendLine(" ,C.Descripcion AS Descripcion");
            sql.AppendLine(" ,C.Cupo AS Cupo");
            sql.AppendLine(" ,C.Correlativas AS Correlativas");
            sql.AppendLine(" ,C.PromedioMinimo AS PromedioMinimo");
            sql.AppendLine(" ,C.CreditoMinimo AS CreditoMinimo");
            sql.AppendLine("FROM Curso C");

            dapperBuilder.AddWhereFilter("Id", "C.Id = @Id", filters?.Id)
                         .AddWhereBoolFilter("SinCupo", "C.Cupo = 0", filters?.SinCupo)
                         .AddWhereToSQL(sql);

            using var connection = new SqlConnection(_connectionString);
            var cursos = connection.Query<Curso>(sql.ToString(), dapperBuilder.Parameters).AsList();

            EstablecerCorrelativas(cursos);

            return cursos;
        }

        public void Post(Curso curso)
        {
            var sql = new StringBuilder();
            sql.AppendLine("INSERT INTO Curso");
            sql.AppendLine("(Nombre, Codigo, Descripcion, Cupo, Correlativas, PromedioMinimo, CreditoMinimo)");
            sql.AppendLine("VALUES");
            sql.AppendLine("(@Nombre, @Codigo, @Descripcion, @Cupo, @Correlativas, @PromedioMinimo, @CreditoMinimo)");

            var parameters = new DynamicParameters();
            parameters.Add("Nombre", curso.Nombre);
            parameters.Add("Codigo", curso.Codigo);
            parameters.Add("Descripcion", curso.Descripcion);
            parameters.Add("Cupo", curso.Cupo);
            parameters.Add("Correlativas", curso.Cupo);
            parameters.Add("PromedioMinimo", curso.Cupo);
            parameters.Add("CreditoMinimo", curso.Cupo);

            using var connection = new SqlConnection(_connectionString);
            connection.Execute(sql.ToString(), parameters);
        }

        public void Update(Curso curso)
        {
            var sql = new StringBuilder();
            sql.AppendLine("UPDATE Curso SET");
            sql.AppendLine("Nombre = @Nombre");
            sql.AppendLine(",Codigo = @Codigo");
            sql.AppendLine(",Descripcion = @Descripcion");
            sql.AppendLine(",Cupo = @Cupo");
            sql.AppendLine(",Correlativas = @Correlativas");
            sql.AppendLine(",PromedioMinimo = @PromedioMinimo");
            sql.AppendLine(",CreditoMinimo = @CreditoMinimo");
            sql.AppendLine("WHERE Id = @Id");

            var parameters = new DynamicParameters();
            parameters.Add("Nombre", curso.Nombre);
            parameters.Add("Codigo", curso.Codigo);
            parameters.Add("Descripcion", curso.Descripcion);
            parameters.Add("Cupo", curso.Cupo);
            parameters.Add("Correlativas", curso.Correlativas);
            parameters.Add("PromedioMinimo", curso.PromedioMinimo);
            parameters.Add("CreditoMinimo", curso.CreditoMinimo);
            parameters.Add("Id", curso.Id);

            using var connection = new SqlConnection(_connectionString);
            connection.Execute(sql.ToString(), parameters);
        }

        public void Delete(int id)
        {
            var sql = new StringBuilder();
            sql.AppendLine("DELETE FROM Curso");
            sql.AppendLine("WHERE Id = @Id");

            var parameters = new DynamicParameters();
            parameters.Add("Id", id);

            using var connection = new SqlConnection(_connectionString);
            connection.Execute(sql.ToString(), parameters);
        }

        public List<Carrera> GetCarreras()
        {
            var sql = new StringBuilder();
            var parameters = new DynamicParameters();

            sql.AppendLine("SELECT");
            sql.AppendLine("  C.Id AS Id");
            sql.AppendLine(" ,C.Descripcion AS Descripcion");
            sql.AppendLine("FROM Carrera C");

            using var connection = new SqlConnection(_connectionString);
            return connection.Query<Carrera>(sql.ToString(), parameters).AsList();
        }

        public List<ListaEspera> GetListaEspera(ListaEsperaFilters filters = null)
        {
            var sql = new StringBuilder();
            var dapperBuilder = new DapperBuilderManager();

            sql.AppendLine("SELECT");
            sql.AppendLine("  LE.Id AS Id");
            sql.AppendLine(" ,LE.FechaAgregado AS FechaAgregado");
            sql.AppendLine(" ,LE.FechaInscripto AS FechaInscripto");
            sql.AppendLine(" ,E.Id AS Id");
            sql.AppendLine(" ,E.Legajo AS Legajo");
            sql.AppendLine(" ,E.Nombre AS Nombre");
            sql.AppendLine(" ,E.Direccion AS Direccion");
            sql.AppendLine(" ,E.Documento AS Documento");
            sql.AppendLine(" ,E.Telefono AS Telefono");
            sql.AppendLine(" ,E.Email AS Email");
            sql.AppendLine(" ,E.Clave AS Clave");
            sql.AppendLine(" ,E.CambiarClave AS CambiarClave");
            sql.AppendLine(" ,C.Id AS Id");
            sql.AppendLine(" ,C.Nombre AS Nombre");
            sql.AppendLine(" ,C.Codigo AS Codigo");
            sql.AppendLine(" ,C.Descripcion AS Descripcion"); ;
            sql.AppendLine(" ,C.Cupo AS Cupo");
            sql.AppendLine("FROM ListaEspera LE");
            sql.AppendLine("INNER JOIN Estudiante E ON E.Id = LE.EstudianteId");
            sql.AppendLine("INNER JOIN Curso C ON C.Id = LE.CursoId");

            dapperBuilder.AddWhereFilter("CursoId", "C.Id = @CursoId", filters?.CursoId)
                         .AddWhereFilter("EstudianteId", "E.Id = @EstudianteId", filters?.EstudianteId)
                         .AddWhereConditionalFilter("Inscripto", "LE.FechaInscripto IS NOT NULL", "LE.FechaInscripto IS NULL", filters?.Inscripto)
                         .AddWhereToSQL(sql);

            using var connection = new SqlConnection(_connectionString);
            var listasEspera = new Dictionary<int, ListaEspera>();

            var result = connection.Query<ListaEspera, Estudiante, Curso, ListaEspera>(
                sql.ToString(),
                (listaEsperaQuery, estudianteQuery, cursoQuery) =>
                {
                    if (!listasEspera.TryGetValue(listaEsperaQuery.Id, out var listaEsperaExistente))
                    {
                        listaEsperaExistente = listaEsperaQuery;
                        listasEspera.Add(listaEsperaQuery.Id, listaEsperaExistente);
                    }

                    if (estudianteQuery != null)
                    {
                        listaEsperaQuery.Estudiante = estudianteQuery;
                    }

                    if (cursoQuery != null)
                    {
                        listaEsperaQuery.Curso = cursoQuery;
                    }

                    return listaEsperaQuery;

                }, param: dapperBuilder.Parameters, splitOn: "Id, Id").AsList();

            return listasEspera.Values.ToList();

        }

        public void GuardarListaEspera(Estudiante estudiante, int cursoId)
        {
            var sql = new StringBuilder();
            var dapperBuilder = new DapperBuilderManager();

            sql.AppendLine("INSERT INTO ListaEspera");
            dapperBuilder.AddInsertFilter("EstudianteId", "EstudianteId", estudiante.Id)
                         .AddInsertFilter("CursoId", "CursoId", cursoId)
                         .AddInsertFilter("FechaAgregado", "FechaAgregado", DateTime.Now)
                         .AddInsertToSQL(sql);


            using var connection = new SqlConnection(_connectionString);
            connection.Execute(sql.ToString(), dapperBuilder.Parameters);
        }

        public void EliminarListaEspera(Estudiante estudiante, int cursoId)
        {
            var sql = new StringBuilder();
            var dapperBuilder = new DapperBuilderManager();

            dapperBuilder.AddWhereFilter("EstudianteId", "EstudianteId = @EstudianteId", estudiante.Id)
                         .AddWhereFilter("CursoId", "CursoId = @CursoId", cursoId)
                         .AddDeleteFromWhereToSQL(sql, "ListaEspera");

            using var connection = new SqlConnection(_connectionString);
            connection.Execute(sql.ToString(), dapperBuilder.Parameters);
        }

        public void CompletarListaEspera(Estudiante estudiante, int cursoId)
        {
            var sql = new StringBuilder();
            var dapperBuilder = new DapperBuilderManager();

            dapperBuilder.AddSetFilter("FechaInscripto", "FechaInscripto = @FechaInscripto", DateTime.Now)
                .AddWhereFilter("EstudianteId", "EstudianteId = @EstudianteId", estudiante.Id)
                .AddWhereFilter("CursoId", "CursoId = @CursoId", cursoId)
                .AddUpdateSetWhereToSQL(sql, "ListaEspera");

            using var connection = new SqlConnection(_connectionString);
            connection.Execute(sql.ToString(), dapperBuilder.Parameters);
        }

        private void EstablecerCorrelativas(List<Curso> cursos) 
        {
            foreach (var curso in cursos)
            {
                if (!string.IsNullOrWhiteSpace(curso.Correlativas))
                {
                    curso.CursosCorrelativosIds = curso.Correlativas.Split(',').ToList().ConvertAll(int.Parse);
                }
            }
        }
    }
}
