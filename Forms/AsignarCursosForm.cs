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
    public partial class AsignarCursosForm : Form
    {
        private readonly ICursoManager _cursoManager;
        private readonly IProfesorManager _profesorManager;

        private List<Curso> _cursos;
        private Profesor _profesor;

        public AsignarCursosForm(int profesorId)
        {
            _cursoManager = new CursoManager();
            _profesorManager = new ProfesorManager();

            _profesor = _profesorManager.Get(profesorId);

            InitializeComponent();
        }

        private void btnCancelarCurso_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AsignarCursosForm_Load(object sender, EventArgs e)
        {
            ListarCursos();
        }

        private void ListarCursos()
        {
            _cursos = _cursoManager.Get();

            if (_cursos.Count > 0)
            {
                this.dgvListaCursos.Rows.Clear();

                foreach (var curso in _cursos)
                {
                    var cursoEstablecido = false;

                    if (_profesor.Cursos != null && _profesor.Cursos.Count > 0)
                    {
                        cursoEstablecido = _profesor.Cursos.Any(x => x.Id == curso.Id);
                    }

                    this.dgvListaCursos.Rows.Add(cursoEstablecido, curso.Nombre);
                }
            }
        }

        private void btnAceptarCurso_Click(object sender, EventArgs e)
        {
            var cursos = GetCursosCheckeados();

            _profesor.Cursos = cursos;
            _profesorManager.AsignarCursos(_profesor);

            this.DialogResult = DialogResult.OK;
            MensajesHelper.MensajeAceptar("Curso asignado con éxito.");
            this.Close();
        }

        private List<Curso> GetCursosCheckeados()
        {
            var cursosCheckeados = new List<Curso>();

            foreach (DataGridViewRow row in dgvListaCursos.Rows)
            {
                if (row.Cells[0] is DataGridViewCheckBoxCell)
                {
                    bool isChecked = (bool)row.Cells[0].EditedFormattedValue;

                    if (isChecked)
                    {
                        var curso = _cursos.FirstOrDefault(x => x.Nombre == row.Cells[1].Value);
                        cursosCheckeados.Add(curso);
                    }
                }
            }

            return cursosCheckeados;
        }
    }
}
