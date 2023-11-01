using Forms.Helpers;
using Libreria.Entidades;
using Libreria.Exceptions;
using Libreria.Exceptions.Enums;
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
    public partial class RegistroEstudianteForm : Form
    {
        private IEstudianteManager _estudianteManager;

        public RegistroEstudianteForm()
        {
            _estudianteManager = new EstudianteManager();

            InitializeComponent();
        }

        private void btnCancelarEstudiante_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnAceptarEstudiante_Click(object sender, EventArgs e)
        {
            if (!DataRegistroValida() || !RegistrarEstudiante())
            {
                MensajesHelper.MostrarListaErrores("Se encontraron los siguientes errores:");
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                MensajesHelper.MensajeAceptar("Estudiante creado con éxito.");
                this.Close();
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

            return esValido;
        }

        private bool RegistrarEstudiante()
        {
            var esValido = true;

            try
            {
                var estudiante = new Estudiante(this.txtNombreCompletoEstudiante.Text, this.txtDireccionEstudiante.Text,
                                 this.txtDniEstudiante.Text, this.txtTelefonoEstudiante.Text,
                                 this.txtEmailEstudiante.Text, this.chkCambiarClave.Checked, true);

                _estudianteManager.Crear(estudiante);
            }
            catch (Exception ex)
            {
                MensajesHelper.Errores = new List<string>();

                if (ex is ExceptionsInternas exInterna && exInterna.TipoError == TipoError.ErrorCrearUsuario)
                {
                    MensajesHelper.Errores = exInterna.Errores;
                }

                esValido = false;
            }

            return esValido;
        }
    }
}
