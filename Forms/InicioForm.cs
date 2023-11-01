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
    public partial class InicioForm : Form
    {
        private IEstudianteManager _estudianteManager;
        private AdministracionManager _administracionManager;
        public InicioForm()
        {
            _estudianteManager = new EstudianteManager();
            _administracionManager = new AdministracionManager();
            InitializeComponent();
        }

        private void btnIngresoAdmin_Click(object sender, EventArgs e)
        {
            IniciarIngresoFrom(true);
        }

        private void btnIngresoEstudiante_Click(object sender, EventArgs e)
        {
            IniciarIngresoFrom(false);
        }

        private void IniciarIngresoFrom(bool esAdmin)
        {
            var ingresoFrom = new IngresoForm(_administracionManager, esAdmin);
            var result = ingresoFrom.ShowDialog();

            if (result == DialogResult.OK && ingresoFrom.IngresoCorrecto)
            {
                if (esAdmin)
                {
                    IniciarPanelAdministrador();
                }
                else
                {
                    IniciarPanelEstudiante(ingresoFrom.EstudianteLegajo);
                }
            }
        }

        private void IniciarPanelAdministrador()
        {
            var adminEstudiantes = new PanelAdministradorForm();
            adminEstudiantes.ShowDialog();
        }

        private void IniciarPanelEstudiante(string legajo)
        {
            DialogResult formNuevaClaveResult = DialogResult.None;

            var estudiante = _estudianteManager.Get(legajo: legajo);

            if (estudiante.CambiarClave == true)
            {
                var cambioClaveForm = new CambioClaveForm(estudiante);
                formNuevaClaveResult = cambioClaveForm.ShowDialog();
            }

            if (formNuevaClaveResult != DialogResult.Cancel)
            {
                var panelEstudianteForm = new PanelEstudianteForm(estudiante.Id);
                panelEstudianteForm.ShowDialog();
            }
        }
    }
}
