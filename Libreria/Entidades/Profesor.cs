﻿namespace Libreria.Entidades
{
    public class Profesor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string AreasEspealizacion { get; set; }
        public List<Curso> Cursos { get; set; }
    }
}
