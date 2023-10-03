using Forms.Helpers;
using Libreria.Entidades;
using Libreria.Exceptions.Enums;
using Libreria.Exceptions;
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
    public partial class EstudianteClaveForm : Form
    {
        private AdministracionManager _administracionManager;

        public EstudianteClaveForm(AdministracionManager administracionManager)
        {
            _administracionManager = administracionManager;
            InitializeComponent();
        }

        private void btnCancelarNuevaClave_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnAceptarNuevaClave_Click(object sender, EventArgs e)
        {
            if (!DataValida() || !ActualzarClave())
            {
                MensajesHelper.MostrarListaErrores("Se encontraron los siguientes errores:");
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                var mensajeExito = "Clave guardada con éxito.";
                MensajesHelper.MensajeAceptar(mensajeExito);
                this.Close();
            }
        }

        private bool DataValida()
        {
            MensajesHelper.Errores = new List<string>();

            if (string.IsNullOrWhiteSpace(this.txtNuevaClave.Text))
            {
                MensajesHelper.Errores.Add($"La clave es obligatoria.");
            }
            else if (this.txtNuevaClave.Text.Contains(' '))
            {
                MensajesHelper.Errores.Add($"La clave tiene caracteres inválidos");
            }
            else if (this.txtNuevaClave.Text.Length > 5)
            {
                MensajesHelper.Errores.Add($"La clave debe tener menos de 5 caracteres.");
            }

            return !MensajesHelper.Errores.Any();
        }

        private bool ActualzarClave()
        {
            try
            {
                _administracionManager.Estudiante.Clave = this.txtNuevaClave.Text;
                return _administracionManager.ActualizarClaveEstudiante(_administracionManager.Estudiante);
            }
            catch (Exception ex)
            {
                MensajesHelper.Errores = new List<string>();

                if (ex is ExceptionsInternas exInterna && exInterna.TipoError == TipoError.ErrorActualizarClaveEstudiante)
                {
                    MensajesHelper.Errores = exInterna.Errores;
                }

                return false;
            }
        }
    }
}
