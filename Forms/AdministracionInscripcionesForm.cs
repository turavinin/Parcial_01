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
    public partial class AdministracionInscripcionesForm : Form
    {
        private AdministracionManager _administracionManager;
        public AdministracionInscripcionesForm(AdministracionManager administracionManager)
        {
            _administracionManager = administracionManager;
            InitializeComponent();
        }

        private void btnInscripcionCursos_Click(object sender, EventArgs e)
        {
            var inscripcionCursosForm = new InscripcionCursosForm(_administracionManager);
            inscripcionCursosForm.ShowDialog();
        }

        private void btnConsultarHorario_Click(object sender, EventArgs e)
        {
            var form = new HorarioCursosForm(_administracionManager);
            form.ShowDialog();
        }

        private void btnCerrarAdminInscr_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
