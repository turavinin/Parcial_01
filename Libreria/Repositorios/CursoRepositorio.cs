using Dapper;
using Libreria.Entidades;
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

        public List<Curso> Get(int? id = null)
        {
            var sql = new StringBuilder();
            var parameters = new DynamicParameters();

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


            if (id != null)
            {
                sql.AppendLine("WHERE C.Id = @Id");
                parameters.Add("Id", id);
            }

            using var connection = new SqlConnection(_connectionString);
            var cursos = connection.Query<Curso>(sql.ToString(), parameters).AsList();

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
