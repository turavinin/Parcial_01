using Dapper;
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
