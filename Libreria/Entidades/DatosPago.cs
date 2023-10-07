using Libreria.Entidades.Enums;
using System.Numerics;

namespace Libreria.Entidades
{
    public class DatosPago
    {
        #region Atributos
        private TipoMetodoPago _tipoMetodoPago;
        private BigInteger _numero;
        private int _codigo;
        #endregion

        #region Propiedades
        public TipoMetodoPago TipoMetodoPago { get => _tipoMetodoPago; set => _tipoMetodoPago = value; }
        public BigInteger Numero { get => _numero; set => value = _numero; }
        public int Codigo { get => _codigo; set => _codigo = value; }
        #endregion

        #region Constructores
        public DatosPago(TipoMetodoPago tipoMetodoPago, BigInteger numero, int codigo)
        {
            this._tipoMetodoPago = tipoMetodoPago;
            this._numero = numero;
            this._codigo = codigo;
        }
        #endregion
    }
}
