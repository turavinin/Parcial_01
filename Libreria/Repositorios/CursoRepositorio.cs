using Dapper;
using Libreria.Entidades;
using Libreria.Entidades.Enums;
using Libreria.Repositorios.Handlers;
using Libreria.Repositorios.Interface;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Text;

namespace Libreria.Repositorios
{
    public class CursoRepositorio : ICursoRepositorio
    {
        private readonly Archivo _archivo;
        private readonly string _path;
        private readonly string _connectionString;

        public CursoRepositorio()
        {
            var pathSolucion = $"{Archivo.ObtenerDirectorioSolucion()?.FullName}\\Data\\Cursos";
            _path = Path.Combine(pathSolucion, "cursos.json");
            _archivo = new Archivo(_path);

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
            sql.AppendLine("FROM Curso C");


            if (id != null)
            {
                sql.AppendLine("WHERE C.Id = @Id");
                parameters.Add("Id", id);
            }

            using var connection = new SqlConnection(_connectionString);
            return connection.Query<Curso>(sql.ToString(), parameters).AsList();
        }

        public void Post(Curso curso)
        {
            var sql = new StringBuilder();
            sql.AppendLine("INSERT INTO Curso");
            sql.AppendLine("(Nombre, Codigo, Descripcion, Cupo)");
            sql.AppendLine("VALUES");
            sql.AppendLine("(@Nombre, @Codigo, @Descripcion, @Cupo)");

            var parameters = new DynamicParameters();
            parameters.Add("Nombre", curso.Nombre);
            parameters.Add("Codigo", curso.Codigo);
            parameters.Add("Descripcion", curso.Descripcion);
            parameters.Add("Cupo", curso.Cupo);

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
            sql.AppendLine("WHERE Id = @Id");

            var parameters = new DynamicParameters();
            parameters.Add("Nombre", curso.Nombre);
            parameters.Add("Codigo", curso.Codigo);
            parameters.Add("Descripcion", curso.Descripcion);
            parameters.Add("Cupo", curso.Cupo);
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
    }
}
