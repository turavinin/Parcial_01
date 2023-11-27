using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Entidades
{
    public class Concepto
    {
        #region Atributos
        private int _id;
        private string _descripcion;
        private int _monto;
        #endregion

        #region Propiedades
        public int Id { get => this._id; set => this._id = value; }
        public string Descripcion { get => this._descripcion; set => this._descripcion = value; }
        public int Monto { get => this._monto; set => this._monto = value; }
        #endregion
    }
}
