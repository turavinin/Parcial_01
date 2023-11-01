﻿namespace Forms
{
    public partial class PanelAdministradorForm : Form
    {
        public PanelAdministradorForm()
        {
            InitializeComponent();
        }

        private void btnRegistrarEstudiante_Click(object sender, EventArgs e)
        {
            var registroEstudiantes = new RegistroEstudianteForm();
            registroEstudiantes.ShowDialog();
        }

        private void btnGestionarCursos_Click(object sender, EventArgs e)
        {
            var cursosFrom = new CursosForm();
            cursosFrom.ShowDialog();
        }

        private void btnCerrarAdminEst_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}