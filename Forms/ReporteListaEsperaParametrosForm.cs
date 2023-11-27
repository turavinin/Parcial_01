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
    public partial class ReporteListaEsperaParametrosForm : Form
    {
        private readonly ICursoManager _cursoManager;
        private readonly IInformesManager _informeManager;
        private List<Curso> _cursos;

        public ReporteListaEsperaParametrosForm()
        {
            _cursoManager = new CursoManager();
            _informeManager = new InformesManager();
            InitializeComponent();
        }

        private void btnCancelarInforme_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGenerarInforme_Click(object sender, EventArgs e)
        {
            var cursoIndex = this.cmbConcepto.SelectedIndex;
            var cursoName = this.cmbConcepto.Items[cursoIndex];

            var curso = _cursos.FirstOrDefault(x => x.Nombre == cursoName);

            _informeManager.GenerarInformeListaEspera (curso.Id);

            MensajesHelper.MensajeAceptar("Informe generado");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ReporteListaEsperaParametrosForm_Load(object sender, EventArgs e)
        {
            CargarComboBox();
        }

        private void CargarComboBox()
        {
            _cursos = _cursoManager.Get();
            _cursos.ForEach(x => this.cmbConcepto.Items.Add(x.Nombre.ToString()));
            this.cmbConcepto.SelectedIndex = 0;
        }
    }
}
