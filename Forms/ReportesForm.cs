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
    public partial class ReportesForm : Form
    {
        public ReportesForm()
        {
            InitializeComponent();
        }

        private void btnCerrarReportes_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInformeInscripciones_Click(object sender, EventArgs e)
        {
            var form = new ReportesInscripcionPeriodoParametrosForm();
            form.ShowDialog();
        }

        private void btnInformeEstuCurs_Click(object sender, EventArgs e)
        {
            var form = new ReporteEstudianteCursoParametrosForm();
            form.ShowDialog();
        }

        private void btnInformeIngrConcepto_Click(object sender, EventArgs e)
        {
            var form = new ReporteIngresoConceptoParametrosForm();
            form.ShowDialog();
        }

        private void btnInformeEstInsc_Click(object sender, EventArgs e)
        {
            var form = new ReporteCarreraParametrosForm();
            form.ShowDialog();
        }

        private void btnInformeListaEspera_Click(object sender, EventArgs e)
        {
            var form = new ReporteListaEsperaParametrosForm();
            form.ShowDialog();
        }
    }
}
