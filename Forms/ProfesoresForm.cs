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
    public partial class ProfesoresForm : Form
    {
        private readonly IProfesorManager _profesorManager;

        private List<Profesor> _profesores;
        private const int COLUMNA_EMAIL = 3;

        public ProfesoresForm()
        {
            _profesorManager = new ProfesorManager();

            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ProfesoresForm_Load(object sender, EventArgs e)
        {
            ListarProfesores();
        }

        private void ListarProfesores()
        {
            _profesores = _profesorManager.Get();

            if (_profesores != null && _profesores.Any())
            {
                this.dgvListaProfesores.Rows.Clear();
                _profesores.ForEach(x => this.dgvListaProfesores.Rows.Add(x.Nombre, x.Direccion, x.Telefono, x.Email, x.AreasEspealizacion));
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvListaProfesores.SelectedRows.Count > 0)
            {
                var id = this.ObtenerId();

                if (id != null)
                {
                    _profesorManager.Delete((int)id);
                    MensajesHelper.MensajeAceptar("Profesor eliminado con éxito.");
                    ListarProfesores();
                }
            }
            else
            {
                MensajesHelper.MensajeAceptar("No hay cursos para eliminar.");
            }
        }

        private int? ObtenerId()
        {
            var email = this.dgvListaProfesores.SelectedRows[0].Cells[COLUMNA_EMAIL].Value.ToString();
            return _profesores.FirstOrDefault(x => x.Email == email)?.Id;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var form = new ProfesorOperarForm();
            form.FormClosed += ActualizarAlCerrar;
            form.ShowDialog();
        }

        private void ActualizarAlCerrar(object sender, FormClosedEventArgs e)
        {
            ListarProfesores();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvListaProfesores.SelectedRows.Count > 0)
            {
                var id = this.ObtenerId();

                if (id != null)
                {
                    var edicionEstudiante = new ProfesorOperarForm(id);
                    edicionEstudiante.FormClosed += ActualizarAlCerrar;
                    edicionEstudiante.ShowDialog();
                }
            }
            else
            {
                MensajesHelper.MensajeAceptar("No hay profesores para editar.");
            }
        }

        private void btnAsginarCursos_Click(object sender, EventArgs e)
        {
            if (this.dgvListaProfesores.SelectedRows.Count > 0)
            {
                var id = this.ObtenerId();

                if (id != null)
                {
                    var edicionEstudiante = new AsignarCursosForm((int)id);
                    edicionEstudiante.FormClosed += ActualizarAlCerrar;
                    edicionEstudiante.ShowDialog();
                }
            }
            else
            {
                MensajesHelper.MensajeAceptar("No hay profesores para editar.");
            }
        }
    }
}
