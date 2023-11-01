using Forms.Helpers;
using Libreria.Entidades;
using Libreria.Managers;
using Libreria.Managers.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms
{
    public partial class CursosForm : Form
    {
        private const int COLUMNA_CODIGO = 1;
        private List<Curso> _cursos;

        private ICursoManager _cursoManager;


        public CursosForm()
        {
            _cursos = new List<Curso>();
            _cursoManager = new CursoManager();

            InitializeComponent();
        }

        private void CursosForm_Load(object sender, EventArgs e)
        {
            ListarCursos();
        }

        private void ListarCursos()
        {
            _cursos = _cursoManager.Get();

            if (_cursos != null && _cursos.Any())
            {
                this.dgvListaCursos.Rows.Clear();
                _cursos.ForEach(x => this.dgvListaCursos.Rows.Add(x.Nombre, x.Codigo, x.Descripcion, x.Cupo));
            }
        }

        private void ActualizarAlCerrar(object sender, FormClosedEventArgs e)
        {
            ListarCursos();
        }

        private void btnAgregarCurso_Click(object sender, EventArgs e)
        {
            var registroEstudiantes = new CursoOperarForm();
            registroEstudiantes.FormClosed += ActualizarAlCerrar;
            registroEstudiantes.ShowDialog();
        }

        private void btnEditarCurso_Click(object sender, EventArgs e)
        {
            if (this.dgvListaCursos.SelectedRows.Count > 0)
            {
                var idCurso = this.ObtenerIdCurso();

                if (idCurso != null)
                {
                    var edicionEstudiante = new CursoOperarForm(idCurso);
                    edicionEstudiante.FormClosed += ActualizarAlCerrar;
                    edicionEstudiante.ShowDialog();
                }
            }
            else
            {
                MensajesHelper.MensajeAceptar("No hay cursos para editar.");
            }
        }

        private void btnEliminarCurso_Click(object sender, EventArgs e)
        {
            if (this.dgvListaCursos.SelectedRows.Count > 0)
            {
                var idCurso = this.ObtenerIdCurso();

                if (idCurso != null)
                {
                    _cursoManager.Eliminar((int)idCurso);
                    MensajesHelper.MensajeAceptar("Curso eliminado con éxito.");
                    ListarCursos();
                }
            }
            else
            {
                MensajesHelper.MensajeAceptar("No hay cursos para eliminar.");
            }
        }

        private int? ObtenerIdCurso()
        {
            var codigo = this.dgvListaCursos.SelectedRows[0].Cells[COLUMNA_CODIGO].Value.ToString();
            return _cursos.FirstOrDefault(x => x.Codigo == codigo)?.Id;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
