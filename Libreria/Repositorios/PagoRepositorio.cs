using Dapper;
using Libreria.Entidades;
using Libreria.Repositorios.Handlers;
using Libreria.Repositorios.Interface;
using System.Data.SqlClient;
using System.Text;

namespace Libreria.Repositorios
{
    public class PagoRepositorio : IPagoRepositorio
    {
        private string _connectionString;
        public PagoRepositorio()
        {
            _connectionString = Database.ConnectionString;
        }

        public void Post(Pago pago, int estudianteId)
        {
            var sql = new StringBuilder();
            sql.AppendLine("INSERT INTO Pago");
            sql.AppendLine("(EstudianteId, ConceptoId, MontoPagado, Cancelado)");
            sql.AppendLine("VALUES");
            sql.AppendLine("(@EstudianteId, @ConceptoId, @MontoPagado, @Cancelado)");

            var parameters = new DynamicParameters();
            parameters.Add("EstudianteId", estudianteId);
            parameters.Add("ConceptoId", pago.Concepto.Id);
            parameters.Add("MontoPagado", pago.MontoPagado);
            parameters.Add("Cancelado", pago.Cancelado);

            using var connection = new SqlConnection(_connectionString);
            connection.Execute(sql.ToString(), parameters);
        }

        public void Update(Pago pago, int estudianteId)
        {
            var sql = new StringBuilder();
            sql.AppendLine("UPDATE Pago SET");
            sql.AppendLine("EstudianteId = @EstudianteId");
            sql.AppendLine(",ConceptoId = @ConceptoId");
            sql.AppendLine(",MontoPagado = @MontoPagado");
            sql.AppendLine(",Cancelado = @Cancelado");
            sql.AppendLine("WHERE Id = @Id");

            var parameters = new DynamicParameters();
            parameters.Add("EstudianteId", estudianteId);
            parameters.Add("ConceptoId", pago.Concepto.Id);
            parameters.Add("MontoPagado", pago.MontoPagado);
            parameters.Add("Cancelado", pago.Cancelado);
            parameters.Add("Id", pago.Id);

            using var connection = new SqlConnection(_connectionString);
            connection.Execute(sql.ToString(), parameters);
        }
    }
}
