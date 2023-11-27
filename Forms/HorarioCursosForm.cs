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
    public partial class HorarioCursosForm : Form
    {
        private IEstudianteManager _estudianteManager;
        private Estudiante _estudiante;


        public HorarioCursosForm(int estudianteId)
        {
            _estudianteManager = new EstudianteManager();
            _estudiante = _estudianteManager.Get(id: estudianteId);

            InitializeComponent();
        }

        private void HorarioCursosForm_Load(object sender, EventArgs e)
        {
            ListEstudianteCursos();
        }

        private void ListEstudianteCursos()
        {
            if (_estudiante.Inscripciones != null && _estudiante.Inscripciones.Any())
            {
                this.dgvListaCursosEstudiante.Rows.Clear();

                foreach (var inscrpcion in _estudiante.Inscripciones)
                {
                    this.dgvListaCursosEstudiante.Rows.Add(inscrpcion.Curso.Nombre, inscrpcion.Curso.Codigo, inscrpcion.Turno.ToString(), inscrpcion.Dia.ToString(), inscrpcion.Aula.ToString());
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
