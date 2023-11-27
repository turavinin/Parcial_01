using Forms.Helpers;
using Libreria.Entidades;
using Libreria.Entidades.Filters;
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
    public partial class GestionarListaEsperaForm : Form
    {
        private readonly ICursoManager _cursoManager;
        private readonly IEstudianteManager _estudianteManager;
        private List<ListaEspera> _listaEspera;
        private List<Estudiante> _estudiantes;
        private Curso _curso;

        private int _idCurso;

        public GestionarListaEsperaForm(int idCurso)
        {
            _cursoManager = new CursoManager();
            _estudianteManager = new EstudianteManager();
            _idCurso = idCurso;

            _curso = _cursoManager.Get(idCurso);

            InitializeComponent();
        }

        private void btnCancelarCurso_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GestionarListaEsperaForm_Load(object sender, EventArgs e)
        {
            this.lblGestionarListaEspera.Text = $"Gestionar lista espera para: {_curso.Nombre}";
            ListarListaEspera(_idCurso);
        }

        private void ListarListaEspera(int idCurso)
        {
            _listaEspera = _cursoManager.GetListaEspera(new ListaEsperaFilters { CursoId = idCurso });
            _estudiantes = _estudianteManager.Get();

            if (_estudiantes.Count > 0)
            {
                this.dgvListaEspera.Rows.Clear();

                foreach (var estudiante in _estudiantes)
                {
                    if (!estudiante.Inscripciones.Any(x => x.Curso.Id == idCurso))
                    {
                        var estudianteEnListaEspera = false;

                        if (_listaEspera.Count > 0)
                        {
                            estudianteEnListaEspera = _listaEspera.Any(x => x.Estudiante.Id == estudiante.Id);
                        }

                        this.dgvListaEspera.Rows.Add(estudianteEnListaEspera, estudiante.Nombre);
                    }
                }
            }
        }

        private void btnAceptarCurso_Click(object sender, EventArgs e)
        {
            var estudiantesNoCheackeados = GetEstudiantesCheckeados(false);
            _cursoManager.EliminarListaEspera(estudiantesNoCheackeados, _idCurso);

            var estudiantesCheckeados = GetEstudiantesCheckeados();
            _cursoManager.GuardarListaEspera(estudiantesCheckeados, _idCurso);

            this.DialogResult = DialogResult.OK;
            MensajesHelper.MensajeAceptar("Lista de espera actualizada con éxito.");
            this.Close();
        }

        private List<Estudiante> GetEstudiantesCheckeados(bool checkeados = true)
        {
            var estudiantes = new List<Estudiante>();

            foreach (DataGridViewRow row in dgvListaEspera.Rows)
            {
                if (row.Cells[0] is DataGridViewCheckBoxCell)
                {
                    bool isChecked = (bool)row.Cells[0].EditedFormattedValue;

                    if (isChecked && checkeados)
                    {
                        var estudiante = _estudiantes.FirstOrDefault(x => x.Nombre == row.Cells[1].Value);
                        estudiantes.Add(estudiante);
                    }
                    else if (!isChecked && !checkeados)
                    {
                        var estudiante = _estudiantes.FirstOrDefault(x => x.Nombre == row.Cells[1].Value);
                        estudiantes.Add(estudiante);
                    }
                }
            }

            return estudiantes;
        }
    }
}
