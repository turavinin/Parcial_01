using Forms.Helpers;
using Libreria.Managers;
using Libreria.Managers.Interface;

namespace Forms
{
    public partial class ReportesInscripcionPeriodoParametrosForm : Form
    {
        private readonly IInformesManager _informeManager;

        public ReportesInscripcionPeriodoParametrosForm()
        {
            _informeManager = new InformesManager();
            InitializeComponent();
        }

        private void btnCancelarInforme_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReportesInscripcionPeriodoParametrosForm_Load(object sender, EventArgs e)
        {
            this.txtAnio.Text = DateTime.Now.Year.ToString();
            CargarComboBox();
        }

        private void CargarComboBox()
        {
            var cuatrimestres = new List<int>() { 1, 2 };
            cuatrimestres.ForEach(x => this.cmbCuatrimestres.Items.Add(x.ToString()));
            this.cmbCuatrimestres.SelectedIndex = 0;
        }

        private void btnGenerarInforme_Click(object sender, EventArgs e)
        {
            if (!DatosValidos())
            {
                MensajesHelper.MostrarListaErrores("Se encontraron los siguientes errores:");
            }
            else
            {
                var cuatrimestre = (int)this.cmbCuatrimestres.SelectedIndex == 0 ? 1 : 2;
                var anio = int.Parse(this.txtAnio.Text);

                _informeManager.GenerarInformeInscripcionPeriodos(anio, cuatrimestre);

                MensajesHelper.MensajeAceptar("Informe generado");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool DatosValidos()
        {
            MensajesHelper.Errores = new List<string>();

            if (!int.TryParse(this.txtAnio.Text, out int anio) || anio < 0)
            {
                MensajesHelper.Errores.Add($"El año debe ser mayor a 0");
            }
            else if (anio.ToString().Length > 6)
            {
                MensajesHelper.Errores.Add($"El año ingresado es exagerado.");
            }

            return !MensajesHelper.Errores.Any();
        }
    }
}
