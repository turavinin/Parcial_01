using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Entidades
{
    public class EstudianteConcepto
    {
        #region Atricutos
        private string _legajo;
        private int _idConcepto;
        private float _montoPagado;
        private bool _cancelado;
        #endregion

        #region Propiedades
        public string Legajo { get => _legajo; set => _legajo = value; }
        public int IdConcepto { get => _idConcepto; set => _idConcepto = value; }
        public float MontoPagado { get => _montoPagado; set => _montoPagado = value; }
        public bool Cancelado { get => _cancelado; set => _cancelado = value; }
        #endregion

        #region Constructores
        public EstudianteConcepto(string legajo, int idConcepto, float montoPagado, bool cancelado)
        {
            this._legajo = legajo;
            this._idConcepto = idConcepto;
            this._montoPagado = montoPagado;
            this._cancelado = cancelado;
        }
        #endregion
    }
}
