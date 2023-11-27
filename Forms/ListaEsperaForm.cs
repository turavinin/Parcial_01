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
    public partial class ListaEsperaForm : Form
    {
        private readonly ICursoManager _cursoManager;

        private List<ListaEspera> _listaEspera;
        private List<Curso> _cursos;

        public ListaEsperaForm()
        {
            _cursoManager = new CursoManager();

            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ListaEsperaForm_Load(object sender, EventArgs e)
        {
            ListarCursos();
        }

        private void ListarCursos()
        {
            _cursos = _cursoManager.Get(true);

            if (_cursos != null && _cursos.Any())
            {
                this.dgvListaEspera.Rows.Clear();

                _cursos.ForEach(x => this.dgvListaEspera.Rows.Add(x.Nombre));
            }
        }

        private void btnGestionarLista_Click(object sender, EventArgs e)
        {
            if (this.dgvListaEspera.SelectedRows.Count > 0)
            {
                var idCurso = this.ObtenerIdCurso();

                if (idCurso != null)
                {
                    var edicionEstudiante = new GestionarListaEsperaForm((int)idCurso);
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
            var nombre = this.dgvListaEspera.SelectedRows[0].Cells[0].Value.ToString();
            return _cursos.FirstOrDefault(x => x.Nombre == nombre)?.Id;
        }
        private void ActualizarAlCerrar(object sender, FormClosedEventArgs e)
        {
            ListarCursos();
        }

    }
}
