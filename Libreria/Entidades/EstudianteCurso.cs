using Libreria.Entidades.Enums;
using Newtonsoft.Json;

namespace Libreria.Entidades
{
    public class EstudianteCurso
    {
        #region Atributos
        private string? _legajoEstudiante;
        private string? _codigoCurso;
        private Turno? _turno;
        private Dia? _dia;
        #endregion

        #region Propiedades
        public string? LegajoEstudiante { get => _legajoEstudiante; set => _legajoEstudiante = value; }
        public string? CodigoCurso { get => _codigoCurso; set => _codigoCurso = value; }
        public Turno? Turno { get => _turno; set => _turno = value; }
        public Dia? Dia { get => _dia; set => _dia = value; }
        #endregion

        #region Constructores
        [JsonConstructor]
        public EstudianteCurso(string legajoEstudiante, string codigoCurso, Turno turno, Dia dia)
        {
            this._legajoEstudiante = legajoEstudiante;
            this._codigoCurso = codigoCurso;
            this._turno = turno;
            this._dia = dia;
        } 
        #endregion
    }
}
