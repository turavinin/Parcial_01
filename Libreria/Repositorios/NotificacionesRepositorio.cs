using Dapper;
using DocumentFormat.OpenXml.Spreadsheet;
using Libreria.Entidades;
using Libreria.Repositorios.Handlers;
using Libreria.Repositorios.Interface;
using System.Data.SqlClient;
using System.Text;

namespace Libreria.Repositorios
{
    public class NotificacionesRepositorio : INotificacionesRepositorio
    {
        private string _connectionString;
        public NotificacionesRepositorio()
        {
            _connectionString = Database.ConnectionString;
        }

        public async Task<List<Notificacion>> Get(int estudianteId)
        {
            var sql = new StringBuilder();
            var dapperBuilder = new DapperBuilderManager();

            sql.AppendLine("SELECT");
            sql.AppendLine("  N.Id AS Id");
            sql.AppendLine(" ,N.EstudianteId AS EstudianteId");
            sql.AppendLine(" ,N.CursoId AS CursoId");
            sql.AppendLine(" ,N.Recibida AS Recibida");
            sql.AppendLine("FROM Notificacion N");

            dapperBuilder.AddWhereFilter("EstudianteId", "N.EstudianteId = @EstudianteId", estudianteId)
                         .AddWhereFilter("Recibida", "N.Recibida = @Recibida", false)
                         .AddWhereToSQL(sql);

            using var connection = new SqlConnection(_connectionString);
            var notificaciones = await connection.QueryAsync<Notificacion>(sql.ToString(), dapperBuilder.Parameters);


            return notificaciones.ToList();
        }

        public async Task ActualizarNotificaciones(int estudianteId, int cursoId)
        {
            var sql = new StringBuilder();
            var dapperBuilder = new DapperBuilderManager();

            dapperBuilder.AddSetFilter("Recibida", "Recibida = @Recibida", true)
                         .AddWhereFilter("EstudianteId", "EstudianteId = @EstudianteId", estudianteId)
                         .AddWhereFilter("CursoId", "CursoId = @CursoId", cursoId)
                         .AddUpdateSetWhereToSQL(sql, "Notificacion");

            using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync(sql.ToString(), dapperBuilder.Parameters);
        }

        public async Task CrearNotificacion(int estudianteId, int cursoId)
        {
            var sql = new StringBuilder();
            var dapperBuilder = new DapperBuilderManager();

            sql.AppendLine("INSERT INTO Notificacion");
            dapperBuilder.AddInsertFilter("EstudianteId", "EstudianteId", estudianteId)
                         .AddInsertFilter("CursoId", "CursoId", cursoId)
                         .AddInsertFilter("Recibida", "Recibida", false)
                         .AddInsertToSQL(sql);

            using var connection = new SqlConnection(_connectionString);
            connection.Execute(sql.ToString(), dapperBuilder.Parameters);
        }
    }
}
