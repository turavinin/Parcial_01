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
    public partial class ReporteIngresoConceptoParametrosForm : Form
    {
        private readonly IConceptoManager _conceptoManager;
        private readonly IInformesManager _informesManager;

        private List<Concepto> _conceptos;

        public ReporteIngresoConceptoParametrosForm()
        {
            _conceptoManager = new ConceptoManager();
            _informesManager = new InformesManager();
            InitializeComponent();
        }

        private void btnCancelarInforme_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReporteIngresoConceptoParametrosForm_Load(object sender, EventArgs e)
        {
            CargarComboBox();
        }

        private void CargarComboBox()
        {
            _conceptos = _conceptoManager.Get();
            _conceptos.ForEach(x => this.cmbConcepto.Items.Add(x.Descripcion.ToString()));
            this.cmbConcepto.SelectedIndex = 0;
        }

        private void btnGenerarInforme_Click(object sender, EventArgs e)
        {
            var conceptoIndex = this.cmbConcepto.SelectedIndex;
            var conceptoName = this.cmbConcepto.Items[conceptoIndex];

            var concepto = _conceptos.FirstOrDefault(x => x.Descripcion == conceptoName);

            _informesManager.GenerarInformeIngresosConcepto(concepto.Id);

            MensajesHelper.MensajeAceptar("Informe generado");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
