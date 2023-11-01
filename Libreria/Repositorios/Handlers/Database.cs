namespace Libreria.Repositorios.Handlers
{
    public static class Database
    {
        private static readonly string _connectionString = $"Server=localhost;Database=Sysacad;Trusted_Connection=True;";
        public static string ConnectionString { get => _connectionString; }
    }
}
