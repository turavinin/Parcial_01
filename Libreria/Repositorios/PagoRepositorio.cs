using Dapper;
using Libreria.Entidades;
using Libreria.Entidades.Filters;
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

        public List<Pago> Get(PagoFilters filters = null)
        {
            var sql = new StringBuilder();
            var dapperBuilder = new DapperBuilderManager();

            sql.AppendLine("SELECT");
            sql.AppendLine("  P.Id AS Id");
            sql.AppendLine(" ,P.MontoPagado AS MontoPagado");
            sql.AppendLine(" ,P.Cancelado AS Cancelado");
            sql.AppendLine(" ,C.Id AS Id");
            sql.AppendLine(" ,C.Descripcion AS Descripcion");
            sql.AppendLine("FROM Pago P");
            sql.AppendLine("INNER JOIN Concepto C ON C.Id = P.ConceptoId");

            dapperBuilder.AddWhereFilter("ConceptoId", "C.Id = @ConceptoId", filters?.ConceptoId);
            dapperBuilder.AddWhereToSQL(sql);

            using var connection = new SqlConnection(_connectionString);
            var pagosDictionary = new Dictionary<int, Pago>();


            var result = connection.Query<Pago, Concepto, Pago>(
                sql.ToString(),
                (pagoQuery, conceptoQuery) =>
                {
                    if (!pagosDictionary.TryGetValue(pagoQuery.Id, out var pagoExistente))
                    {
                        pagoExistente = pagoQuery;
                        pagosDictionary.Add(pagoQuery.Id, pagoExistente);
                    }

                    if (conceptoQuery != null)
                    {
                        pagoExistente.Concepto = conceptoQuery;
                    }

                    return pagoQuery;

                }, param: dapperBuilder.Parameters, splitOn: "Id").AsList();


            return pagosDictionary.Values.ToList();
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
