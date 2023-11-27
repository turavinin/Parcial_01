using Libreria.Entidades.Enums;

namespace Libreria.Entidades
{
    public class Inscripcion
    {
        #region Atributos
        private int _id;
        private Estudiante _estudiante;
        private Curso _curso;
        private Turno _turno;
        private Dia _dia;
        private int _aula;
        private int _anio;
        private int _cuatrimestre;
        #endregion

        #region Propiedades
        public int Id { get => _id; set => _id = value; }
        public Estudiante Estudiante { get => _estudiante; set => _estudiante = value; }
        public Curso Curso { get => _curso; set => _curso = value; }
        public Turno Turno { get => _turno; set => _turno = value; }
        public Dia Dia { get => _dia; set => _dia = value; }
        public int Aula { get => _aula; set => _aula = value; }
        public int Anio { get => _anio; set => _anio = value; }
        public int Cuatrimestre { get => _cuatrimestre; set => _cuatrimestre = value; }
        #endregion
    }
}
