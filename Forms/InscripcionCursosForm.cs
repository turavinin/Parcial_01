using Forms.Helpers;
using Libreria.Entidades;
using Libreria.Exceptions.Enums;
using Libreria.Exceptions;
using Libreria.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms
{
    public partial class InscripcionCursosForm : Form
    {
        private const int COLUMNA_CODIGO = 2;
        private const int COLUMNA_CUPO = 4;

        private AdministracionManager _administracionManager;
        private List<Curso> _cursos;

        public InscripcionCursosForm(AdministracionManager administracionManager)
        {
            _administracionManager = administracionManager;
            InitializeComponent();
        }

        private void InscripcionCursosForm_Load(object sender, EventArgs e)
        {
            ListarCursos();
        }

        private void dgvListaCursosEstudiante_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvListaCursosEstudiante.Columns[e.ColumnIndex].Name == "Seleccionar" && dgvListaCursosEstudiante.CurrentCell is DataGridViewCheckBoxCell)
            {
                bool isChecked = (bool)dgvListaCursosEstudiante[e.ColumnIndex, e.RowIndex].EditedFormattedValue;

                if (isChecked)
                {
                    VerificarCupoDisponible(e.RowIndex);
                }
                else
                {
                    dgvListaCursosEstudiante[e.ColumnIndex, e.RowIndex].ReadOnly = false;
                }

                dgvListaCursosEstudiante.EndEdit();
            }
        }

        private void dgvListaCursosEstudiante_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgvListaCursosEstudiante.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dgvListaCursosEstudiante_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvListaCursosEstudiante.CurrentCell is DataGridViewCheckBoxCell)
            {
                dgvListaCursosEstudiante.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void btnInscribirse_Click(object sender, EventArgs e)
        {
            var listaCodigos = GetCodigosCursosSeleccionados();

            if (!listaCodigos.Any())
            {
                MensajesHelper.MostrarError("No se seleccionó ningun curso.");
            }
            else if (!InscribirCursos(listaCodigos))
            {
                MensajesHelper.MostrarListaErrores("Se encontraron los siguientes errores:");
            }
            else
            {
                var mensajeExito = "Inscripción realizada con éxito";
                MensajesHelper.MensajeAceptar(mensajeExito);
            }

            ListarCursos();
        }

        private bool InscribirCursos(List<string> codigosCursos)
        {
            try
            {
                return _administracionManager.InscribirCursosAEstudiante(_administracionManager.Estudiante, codigosCursos);
            }
            catch (Exception ex)
            {
                MensajesHelper.Errores = new List<string>();

                if (ex is ExceptionsInternas exInterna && exInterna.TipoError == TipoError.ErrorInscribirCursoAEstudiante)
                {
                    MensajesHelper.Errores = exInterna.Errores;
                }

                return false;
            }
        }

        private void DisableChekbox(int rowIndex, Color? color = null)
        {
            this.dgvListaCursosEstudiante.Rows[rowIndex].Cells[0] = new DataGridViewTextBoxCell();
            this.dgvListaCursosEstudiante.Rows[rowIndex].Cells[0].Value = "";
            this.dgvListaCursosEstudiante.Rows[rowIndex].Cells[0].ReadOnly = true;

            if (color != null)
            {
                this.dgvListaCursosEstudiante.Rows[rowIndex].Cells[0].Style.BackColor = (Color)color;

            }
        }

        private List<string> GetCodigosCursosSeleccionados()
        {
            var listaCodigos = new List<string>();

            foreach (DataGridViewRow row in dgvListaCursosEstudiante.Rows)
            {
                if (row.Cells[0] is DataGridViewCheckBoxCell chk)
                {
                    if (chk.Value != null && (bool)chk.Value == true)
                    {
                        var codigo = row.Cells[COLUMNA_CODIGO].Value.ToString();
                        listaCodigos.Add(codigo);
                    }
                }
            }

            return listaCodigos;
        }

        private string ObtenerCodigoCursoSeleccionado()
        {
            return this.dgvListaCursosEstudiante.SelectedRows[0].Cells[COLUMNA_CODIGO].Value.ToString();
        }

        private void VerificarCupoDisponible(int rowIndex)
        {
            var cell = (DataGridViewCheckBoxCell)dgvListaCursosEstudiante.CurrentCell;
            cell.ReadOnly = true;

            var codigo = ObtenerCodigoCursoSeleccionado();
            var hayCupoDisponible = _administracionManager.GetCurso(codigo);

            if (hayCupoDisponible != null && hayCupoDisponible.CupoMaximo <= 0)
            {
                var cursoNoDisponible = _cursos.FirstOrDefault(x => x.Codigo == codigo);
                MensajesHelper.MostrarError($"No hay cupo disponible para el curso de {cursoNoDisponible.Nombre}");

                DisableChekbox(rowIndex);
                dgvListaCursosEstudiante[COLUMNA_CUPO, rowIndex].Value = 0;
            }
            else
            {
                cell.ReadOnly = false;
            }
        }

        private void ListarCursos()
        {
            _cursos = _administracionManager.GetCursos();
            var estudianteActualizado = _administracionManager.GetEstudiante(_administracionManager.Estudiante.Legajo);

            if (_cursos != null && _cursos.Any())
            {
                this.dgvListaCursosEstudiante.Rows.Clear();

                foreach (var curso in _cursos)
                {
                    var index = this.dgvListaCursosEstudiante.Rows.Add(false, curso.Nombre, curso.Codigo, curso.Descripcion, curso.CupoMaximo);

                    if (estudianteActualizado.Cursos.Any(x => x.Codigo == curso.Codigo))
                    {
                        DisableChekbox(index, Color.Green);
                    }
                    else if (curso.CupoMaximo <= 0)
                    {
                        DisableChekbox(index);
                    }
                }
            }
        }

        private void btnCancelarInscripcion_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
