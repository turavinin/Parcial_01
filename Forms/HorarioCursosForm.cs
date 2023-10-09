using Forms.Helpers;
using Libreria.Entidades;
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
    public partial class HorarioCursosForm : Form
    {
        private AdministracionManager _administracionManager;
        public HorarioCursosForm(AdministracionManager administracionManager)
        {
            _administracionManager = administracionManager;
            InitializeComponent();
        }

        private void HorarioCursosForm_Load(object sender, EventArgs e)
        {
            ListEstudianteCursos();
        }

        private void ListEstudianteCursos()
        {
            var estudianteCursos = _administracionManager.Get(_administracionManager.Estudiante.Legajo);

            if (estudianteCursos != null && estudianteCursos.Any())
            {
                this.dgvListaCursosEstudiante.Rows.Clear();

                foreach (var estudianteCurso in estudianteCursos)
                {
                    var curso = _administracionManager.GetCurso(estudianteCurso.CodigoCurso);
                    this.dgvListaCursosEstudiante.Rows.Add(curso.Nombre, curso.Codigo, estudianteCurso.Turno.ToString(), estudianteCurso.Dia.ToString(), curso.Aula);
                }
            }
            else
            {
                MensajesHelper.MensajeAceptar("No cursos para informar el horario.");
                this.Close();
            }
        }

        private void btnCerrarHorarios_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
