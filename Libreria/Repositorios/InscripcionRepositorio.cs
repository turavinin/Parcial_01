using Dapper;
using Libreria.Entidades;
using Libreria.Repositorios.Handlers;
using Libreria.Repositorios.Interface;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Text;

namespace Libreria.Repositorios
{
    public class InscripcionRepositorio : IInscripcionRepositorio
    {
        private readonly string _connectionString;

        public InscripcionRepositorio()
        {
            _connectionString = Database.ConnectionString;
        }

        public void Post(Inscripcion inscrpcion, int estudianteId)
        {
            var sql = new StringBuilder();
            sql.AppendLine("INSERT INTO Inscripcion");
            sql.AppendLine("(EstudianteId, CursoId, Turno, Aula, Dia)");
            sql.AppendLine("VALUES");
            sql.AppendLine("(@EstudianteId, @CursoId, @Turno, @Aula, @Dia)");

            var parameters = new DynamicParameters();
            parameters.Add("EstudianteId", estudianteId);
            parameters.Add("CursoId", inscrpcion.Curso.Id);
            parameters.Add("Turno", (int)inscrpcion.Turno);
            parameters.Add("Aula", (int)inscrpcion.Aula);
            parameters.Add("Dia", (int)inscrpcion.Dia);

            using var connection = new SqlConnection(_connectionString);
            connection.Execute(sql.ToString(), parameters);
        }
    }
}
