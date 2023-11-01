using Dapper;
using Libreria.Entidades;
using Libreria.Repositorios.Handlers;
using Libreria.Repositorios.Interface;
using System.Data.SqlClient;
using System.Text;

namespace Libreria.Repositorios
{
    public class AdministradorRepositorio : IAdministradorRepositorio
    {
        private readonly string _connectionString;

        public AdministradorRepositorio()
        {
            _connectionString = Database.ConnectionString;
        }

        public List<Administrador> Get()
        {
            var sql = new StringBuilder();
            sql.AppendLine("SELECT");
            sql.AppendLine("  A.Id AS Id");
            sql.AppendLine(" ,A.Nombre AS Nombre");
            sql.AppendLine(" ,A.Usuario AS Usuario");
            sql.AppendLine(" ,A.Clave AS Clave");
            sql.AppendLine("FROM Administrador A");

            using var connection = new SqlConnection(_connectionString);
            return connection.Query<Administrador>(sql.ToString()).AsList();
        }

        public Administrador Get(string usuario, string clave)
        {
            var sql = new StringBuilder();
            sql.AppendLine("SELECT");
            sql.AppendLine("  A.Id AS Id");
            sql.AppendLine(" ,A.Nombre AS Nombre");
            sql.AppendLine(" ,A.Usuario AS Usuario");
            sql.AppendLine(" ,A.Clave AS Clave");
            sql.AppendLine("FROM Administrador A");
            sql.AppendLine("WHERE A.Usuario = @Usuario AND A.Clave = @Clave");

            var parameters = new DynamicParameters();
            parameters.Add("Usuario", usuario);
            parameters.Add("Clave", clave);

            using var connection = new SqlConnection(_connectionString);
            return connection.Query<Administrador>(sql.ToString(), parameters).FirstOrDefault();
        }
    }
}
