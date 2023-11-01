using Libreria.Entidades;
using Libreria.Managers;
using Libreria.Managers.Interface;

namespace Forms
{
    public partial class PanelEstudianteForm : Form
    {
        private int _estudianteId;

        public PanelEstudianteForm(int estudianteId)
        {
            _estudianteId = estudianteId;

            InitializeComponent();
        }

        private void btnInscripcionCursos_Click(object sender, EventArgs e)
        {
            var inscripcionCursosForm = new InscripcionCursosForm(_estudianteId);
            inscripcionCursosForm.ShowDialog();
        }

        private void btnConsultarHorario_Click(object sender, EventArgs e)
        {
            var form = new HorarioCursosForm(_estudianteId);
            form.ShowDialog();
        }

        private void btnRealizarPagos_Click(object sender, EventArgs e)
        {
            var form = new ConceptoForm(_estudianteId);
            form.ShowDialog();
        }

        private void btnCerrarAdminInscr_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
