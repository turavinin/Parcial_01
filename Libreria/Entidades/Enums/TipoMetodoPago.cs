namespace Libreria.Entidades.Enums
{
    public enum TipoMetodoPago
    {
        Credito,
        Debito,
        Deposito
    }

    public static class EnumTipoPagoHelper
    {
        public static List<TipoMetodoPago> GetTipoMetodoPago()
        {
            var lista = ((TipoMetodoPago[])Enum.GetValues(typeof(TipoMetodoPago)));

            return lista.ToList();
        }
    }
}
