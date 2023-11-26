namespace Libreria.Entidades
{
    public class ListaEspera
    {
        public int Id { get; set; }
        public Estudiante Estudiante { get; set; }
        public Curso Curso { get; set; }
        public DateTime FechaAgregado { get; set; }
        public DateTime? FechaInscripto { get; set; }
    }
}
