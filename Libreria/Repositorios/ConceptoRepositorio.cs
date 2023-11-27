using Dapper;
using Libreria.Entidades;
using Libreria.Repositorios.Handlers;
using Libreria.Repositorios.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Repositorios
{
    public class ConceptoRepositorio : IConceptoRepositorio
    {
        private readonly string _connectionString;

        public ConceptoRepositorio()
        {
            _connectionString = Database.ConnectionString;
        }

        public List<Concepto> Get()
        {
            var sql = new StringBuilder();
            sql.AppendLine("SELECT");
            sql.AppendLine("  C.Id AS Id");
            sql.AppendLine(" ,C.Descripcion AS Descripcion");
            sql.AppendLine(" ,C.Monto AS Monto");
            sql.AppendLine("FROM Concepto C");

            using var connection = new SqlConnection(_connectionString);
            return connection.Query<Concepto>(sql.ToString()).AsList();
        }
    }
}
