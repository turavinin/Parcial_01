﻿using Libreria.Managers;
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
    public partial class AdministracionEstudiantesForm : Form
    {
        private AdministracionManager _administracionManager;

        public AdministracionEstudiantesForm(AdministracionManager administracionManager)
        {
            _administracionManager = administracionManager;
            InitializeComponent();
        }

        private void btnRegistrarEstudiante_Click(object sender, EventArgs e)
        {
            var registroEstudiantes = new RegistroEstudianteForm(_administracionManager);
            registroEstudiantes.ShowDialog();
        }

        private void btnGestionarCursos_Click(object sender, EventArgs e)
        {
            var cursosFrom = new CursosForm(_administracionManager);
            cursosFrom.ShowDialog();
        }

        private void btnCerrarAdminEst_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
