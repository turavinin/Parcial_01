namespace Forms
{
    public partial class PanelAdministradorForm : Form
    {
        public PanelAdministradorForm()
        {
            InitializeComponent();
        }

        private void btnRegistrarEstudiante_Click(object sender, EventArgs e)
        {
            var registroEstudiantes = new RegistroEstudianteForm();
            registroEstudiantes.ShowDialog();
        }

        private void btnGestionarCursos_Click(object sender, EventArgs e)
        {
            var cursosFrom = new CursosForm();
            cursosFrom.ShowDialog();
        }

        private void btnGenerarReportes_Click(object sender, EventArgs e)
        {
            var form = new ReportesForm();
            form.ShowDialog();
        }

        private void btnCerrarAdminEst_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRequisitos_Click(object sender, EventArgs e)
        {
            var form = new RequisitosForm();
            form.ShowDialog();
        }
    }
}
