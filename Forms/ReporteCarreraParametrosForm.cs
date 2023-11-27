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
    public partial class ReporteCarreraParametrosForm : Form
    {
        private readonly ICursoManager _cursoManager;
        private readonly IInformesManager _informesManager;
        private List<Carrera> _carreras;

        public ReporteCarreraParametrosForm()
        {
            _cursoManager = new CursoManager();
            _informesManager = new InformesManager();
            InitializeComponent();
        }

        private void btnCancelarInforme_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReporteCarreraParametrosForm_Load(object sender, EventArgs e)
        {
            CargarComboBox();
        }

        private void CargarComboBox()
        {
            _carreras = _cursoManager.GetCarreras();
            _carreras.ForEach(x => this.cmbCarrera.Items.Add(x.Descripcion.ToString()));
            this.cmbCarrera.SelectedIndex = 0;
        }

        private void btnGenerarInforme_Click(object sender, EventArgs e)
        {
            var carreraIndex = this.cmbCarrera.SelectedIndex;
            var carreraName = this.cmbCarrera.Items[carreraIndex];

            var carrera = _carreras.FirstOrDefault(x => x.Descripcion == carreraName);

            _informesManager.GenerarInformeCarreras(carrera.Id);

            MensajesHelper.MensajeAceptar("Informe generado");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
