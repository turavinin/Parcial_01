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
using Libreria.Managers.Interface;

namespace Forms
{
    public partial class CambioClaveForm : Form
    {
        private IEstudianteManager _estudianteManager;
        private Estudiante _estudiante;

        public CambioClaveForm(Estudiante estudiante)
        {
            _estudiante = estudiante;
            _estudianteManager = new EstudianteManager();

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
            var actualizacionCorrecta = true;

            try
            {
                _estudiante.Clave = this.txtNuevaClave.Text;
                _estudianteManager.ActualizarClave(_estudiante);
            }
            catch (Exception ex)
            {
                MensajesHelper.Errores = new List<string>();

                if (ex is ExceptionsInternas exInterna && exInterna.TipoError == TipoError.ErrorActualizarClaveEstudiante)
                {
                    MensajesHelper.Errores = exInterna.Errores;
                }

                actualizacionCorrecta = false;
            }

            return actualizacionCorrecta;
        }
    }
}
