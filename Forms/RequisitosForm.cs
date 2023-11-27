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
    public partial class RequisitosForm : Form
    {
        private readonly ICursoManager _cursoManager;

        private List<Curso> _cursos;
        private const int COLUMNA_NOMBRE = 0;

        public RequisitosForm()
        {
            _cursoManager = new CursoManager();

            InitializeComponent();
        }

        private void RequisitosForm_Load(object sender, EventArgs e)
        {
            ListarCursos();
        }

        private void ListarCursos()
        {
            _cursos = _cursoManager.Get();

            if (_cursos != null && _cursos.Any())
            {
                this.dgvListaCursos.Rows.Clear();
                _cursos.ForEach(x => this.dgvListaCursos.Rows.Add(x.Nombre, x.PromedioMinimo, GetListaNombresCorrelativas(x), x.CreditoMinimo));
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEditarCurso_Click(object sender, EventArgs e)
        {
            if (this.dgvListaCursos.SelectedRows.Count > 0)
            {
                var idCurso = this.ObtenerIdCurso();
                var curso = _cursos.FirstOrDefault(x => x.Id == idCurso);

                if (curso != null)
                {
                    var edicionEstudiante = new RequisitosOperarForm(curso);
                    edicionEstudiante.FormClosed += ActualizarAlCerrar;
                    edicionEstudiante.ShowDialog();
                }
            }
            else
            {
                MensajesHelper.MensajeAceptar("No hay cursos para editar.");
            }
        }

        private int? ObtenerIdCurso()
        {
            var nombre = this.dgvListaCursos.SelectedRows[0].Cells[COLUMNA_NOMBRE].Value.ToString();
            return _cursos.FirstOrDefault(x => x.Nombre == nombre)?.Id;
        }

        private void ActualizarAlCerrar(object sender, FormClosedEventArgs e)
        {
            ListarCursos();
        }

        private string GetListaNombresCorrelativas(Curso curso)
        {
            var cursosCorrelativosString = string.Empty;

            if(curso?.CursosCorrelativosIds?.Count > 0)
            {
                var cursosCorrelativos = _cursos.Where(x => curso.CursosCorrelativosIds.Contains(x.Id)).ToList();

                if (cursosCorrelativos.Count > 0)
                {
                    cursosCorrelativosString = string.Join(",", cursosCorrelativos.Select(x => x.Nombre));
                }
            }

            return cursosCorrelativosString;
        }
    }
}
