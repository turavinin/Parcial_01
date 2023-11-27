using Forms.Helpers;
using Libreria.Entidades;
using Libreria.Managers;
using Libreria.Managers.Interface;

namespace Forms
{
    public partial class ReporteEstudianteCursoParametrosForm : Form
    {
        private readonly IInformesManager _informeManager;
        private readonly ICursoManager _cursoManager;
        private List<Curso> _cursos;

        public ReporteEstudianteCursoParametrosForm()
        {
            _cursoManager = new CursoManager();
            _informeManager = new InformesManager();
            InitializeComponent();
        }

        private void btnCancelarInforme_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Reporte_Load(object sender, EventArgs e)
        {
            CargarComboBox();
        }

        private void CargarComboBox()
        {
            _cursos = _cursoManager.Get();
            _cursos.ForEach(x => this.cmbCurso.Items.Add(x.Nombre.ToString()));
            this.cmbCurso.SelectedIndex = 0;
        }

        private void btnGenerarInforme_Click(object sender, EventArgs e)
        {
            var cursoIndex = this.cmbCurso.SelectedIndex;
            var cursoName = this.cmbCurso.Items[cursoIndex];

            var cursoSeleccionado = _cursos.FirstOrDefault(x => x.Nombre == cursoName);

            _informeManager.GenerarInformeEstudianteCursos(cursoSeleccionado.Codigo);

            MensajesHelper.MensajeAceptar("Informe generado");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
