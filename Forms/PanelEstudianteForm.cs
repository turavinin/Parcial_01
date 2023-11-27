using Forms.Helpers;
using Libreria.Entidades;
using Libreria.Managers;
using Libreria.Managers.Interface;

namespace Forms
{
    public partial class PanelEstudianteForm : Form
    {
        private int _estudianteId;

        private readonly IEstudianteManager _estudianteManager;
        private EstudianteManager estudianteManagerEvent;

        public PanelEstudianteForm(int estudianteId)
        {
            _estudianteId = estudianteId;
            _estudianteManager = new EstudianteManager();

            estudianteManagerEvent = new EstudianteManager();
            estudianteManagerEvent.EventoNotificacion += NotificarCurso;

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

        private void NotificarCurso(int estudianteId, List<Curso> cursos)
        {
            if (cursos.Count > 0)
            {
                var stringNombresCursos = string.Join(",", cursos.Select(x => x.Nombre));
                _estudianteManager.CompletarNotificacion(estudianteId, cursos.Select(x => x.Id).ToList());
                MensajesHelper.MensajeAceptar($"Se le inscribieron los siguientes cursos: {stringNombresCursos}");
            }
        }

        private void PanelEstudianteForm_Load(object sender, EventArgs e)
        {
            var estudiante = estudianteManagerEvent.Get(_estudianteId);
            Task.Run(async () =>
            {
                await estudianteManagerEvent.VerificarNotificacionesCursos(estudiante);
            });
        }
    }
}
