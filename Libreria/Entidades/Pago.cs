using Libreria.Entidades.Enums;
using System.Numerics;

namespace Libreria.Entidades
{
    public class Pago
    {
        #region Atributos
        private int _id;
        private TipoMetodoPago _tipoMetodoPago;
        private BigInteger _numero;
        private int _codigo;
        private bool _cancelado;
        private int _montoPagado;
        private Concepto _concepto;
        #endregion

        #region Propiedades
        public int Id { get => _id; set => _id = value; }
        public TipoMetodoPago TipoMetodoPago { get => _tipoMetodoPago; set => _tipoMetodoPago = value; }
        public BigInteger Numero { get => _numero; set => value = _numero; }
        public int Codigo { get => _codigo; set => _codigo = value; }
        public bool Cancelado { get => _cancelado; set => _cancelado = value; }
        public int MontoPagado { get => _montoPagado; set => _montoPagado = value; }
        public Concepto Concepto { get => _concepto; set => _concepto = value; }
        #endregion

        #region Constructores
        public Pago()
        {
        }

        public Pago(BigInteger numero, int codigo, TipoMetodoPago tipoPago)
        {
            this.Numero = numero;
            this.Codigo = codigo;
            this.TipoMetodoPago = tipoPago;
        }
        #endregion
    }
}
