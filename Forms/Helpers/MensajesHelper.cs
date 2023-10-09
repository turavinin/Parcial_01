using System.Text;

namespace Forms.Helpers
{
    public class MensajesHelper
    {
        private static List<string> errores;
        public static List<string> Errores { get => MensajesHelper.errores; set => MensajesHelper.errores = value.Count > 0 ? value : MensajesHelper.errores; }

        static MensajesHelper()
        {
            MensajesHelper.errores = new List<string>();
        }

        public static void MostrarException(Exception ex)
        {
            MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void MostrarError(string error)
        {
            MessageBox.Show($"{error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void MensajeAceptar(string mensaje)
        {
            MessageBox.Show(mensaje);
        }

        public static DialogResult MensajeSiNo(string mensaje, string accion)
        {
            return MessageBox.Show(mensaje, accion, MessageBoxButtons.YesNo);
        }

        public static void MostrarListaErrores(string tituloErrores, bool reiniciarLista = true)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{tituloErrores}");
            if (MensajesHelper.errores.Count > 0)
            {
                foreach (string error in MensajesHelper.Errores)
                {
                    sb.AppendLine($" - {error}");
                }
            }

            if (reiniciarLista)
            {
                MensajesHelper.errores = new List<string>();
            }

            MensajesHelper.MostrarError(sb.ToString());
        }
    }
}
