using Forms.Helpers;
using Libreria.Managers;
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
        private AdministracionManager _administracionManager;

        public CursosForm(AdministracionManager administracionManager)
        {
            _administracionManager = administracionManager;
            InitializeComponent();
        }

        private void CursosForm_Load(object sender, EventArgs e)
        {
            ListarCursos();
        }

        private void ListarCursos()
        {
            var cursos = _administracionManager.GetCursos();

            if (cursos != null && cursos.Any())
            {
                this.dgvListaCursos.Rows.Clear();
                cursos.ForEach(x => this.dgvListaCursos.Rows.Add(x.Nombre, x.Codigo, x.Descripcion, x.CupoMaximo));
            }
        }

        private void ActualizarAlCerrar(object sender, FormClosedEventArgs e)
        {
            ListarCursos();
        }

        private void btnAgregarCurso_Click(object sender, EventArgs e)
        {
            var registroEstudiantes = new CursoOperarForm(_administracionManager);
            registroEstudiantes.FormClosed += ActualizarAlCerrar;
            registroEstudiantes.ShowDialog();
        }

        private void btnEditarCurso_Click(object sender, EventArgs e)
        {
            if (this.dgvListaCursos.SelectedRows.Count > 0)
            {
                var codigo = this.ObtenerCodigoCursoSeleccionado();

                if (!string.IsNullOrEmpty(codigo))
                {
                    var edicionEstudiante = new CursoOperarForm(_administracionManager, codigo);
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
                var codigo = this.ObtenerCodigoCursoSeleccionado();

                if (!string.IsNullOrEmpty(codigo))
                {
                    _administracionManager.EliminarCurso(codigo);
                    MensajesHelper.MensajeAceptar("Curso eliminado con éxito.");
                    ListarCursos();
                }
            }
            else
            {
                MensajesHelper.MensajeAceptar("No hay cursos para eliminar.");
            }
        }

        private string ObtenerCodigoCursoSeleccionado()
        {
            return this.dgvListaCursos.SelectedRows[0].Cells[COLUMNA_CODIGO].Value.ToString();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
