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
    public partial class InicioForm : Form
    {
        private AdministracionManager _administracionManager;
        public InicioForm()
        {
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
                if(esAdmin)
                {
                    IniciarAdministracionEstudiantes();
                }
            }
        }

        private void IniciarAdministracionEstudiantes()
        {
            var adminEstudiantes = new AdministracionEstudiantesForm(_administracionManager);
            var result = adminEstudiantes.ShowDialog();
        }
    }
}
