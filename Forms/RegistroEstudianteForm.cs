﻿using Forms.Helpers;
using Libreria.Entidades;
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
    public partial class RegistroEstudianteForm : Form
    {
        private AdministracionManager _administracionManager;

        public RegistroEstudianteForm(AdministracionManager administracionManager)
        {
            _administracionManager = administracionManager;
            InitializeComponent();
        }

        private void btnCancelarEstudiante_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnAceptarEstudiante_Click(object sender, EventArgs e)
        {
            var ingresoValido = DataRegistroValida();
            if (!ingresoValido)
            {
                MensajesHelper.MostrarListaErrores("Se encontraron los siguientes errores:");
            }
            else
            {
                var registroValido = RegistrarEstudiante();
            }
        }

        private bool DataRegistroValida()
        {
            var esValido = true;
            MensajesHelper.Errores = new List<string>();

            if (string.IsNullOrWhiteSpace(this.txtNombreCompletoEstudiante.Text))
            {
                MensajesHelper.Errores.Add($"El nombre completo es obligatorio.");
                esValido = false;
            }

            if (string.IsNullOrWhiteSpace(this.txtDireccionEstudiante.Text))
            {
                MensajesHelper.Errores.Add($"La dirección es obligatoria.");
                esValido = false;
            }

            if (string.IsNullOrWhiteSpace(this.txtDniEstudiante.Text))
            {
                MensajesHelper.Errores.Add($"El DNI es obligatorio.");
                esValido = false;
            }

            if (string.IsNullOrWhiteSpace(this.txtTelefonoEstudiante.Text))
            {
                MensajesHelper.Errores.Add($"El telefono es obligatorio.");
                esValido = false;
            }

            if (string.IsNullOrWhiteSpace(this.txtEmailEstudiante.Text))
            {
                MensajesHelper.Errores.Add($"El email es obligatorio.");
                esValido = false;
            }

            if (string.IsNullOrWhiteSpace(this.txtClaveEstudiante.Text))
            {
                MensajesHelper.Errores.Add($"La clave es obligatoria.");
                esValido = false;
            }


            return esValido;
        }

        private bool RegistrarEstudiante()
        {
            var estudiante = new Estudiante(this.txtNombreCompletoEstudiante.Text, this.txtDireccionEstudiante.Text,
                                             this.txtDniEstudiante.Text, this.txtTelefonoEstudiante.Text, 
                                             this.txtEmailEstudiante.Text, this.txtClaveEstudiante.Text, this.chkCambiarClave.Checked);

            return _administracionManager.RegistrarEstudiante(estudiante);
        }
    }
}
