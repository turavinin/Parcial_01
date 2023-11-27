using Forms.Helpers;
using Libreria.Entidades;
using Libreria.Exceptions.Enums;
using Libreria.Exceptions;
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
    public partial class ProfesorOperarForm : Form
    {
        private int? _idProfesor;
        private bool _esCrear;

        private readonly IProfesorManager _profesorManager;

        public ProfesorOperarForm(int? id = null)
        {
            _idProfesor = id;
            _esCrear = id is null;

            _profesorManager = new ProfesorManager();

            InitializeComponent();
        }

        private void ProfesorOperarForm_Load(object sender, EventArgs e)
        {
            this.Text = _esCrear ? "Crear profesor" : "Editar profesor";

            if (!_esCrear && _idProfesor != null)
            {
                IniciarFormProfesorExistente();
            }
        }

        private void IniciarFormProfesorExistente()
        {
            var profesor = _profesorManager.Get((int)_idProfesor);

            if (profesor != null)
            {
                this.txtNombre.Text = profesor.Nombre;
                this.txtTelefono.Text = profesor.Telefono;
                this.txtDireccion.Text = profesor.Direccion;
                this.txtEmail.Text = profesor.Email.ToString();
            }
        }

        private void btnCancelarCurso_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptarCurso_Click(object sender, EventArgs e)
        {
            if (!DatosValidos() || !OperarProfesor())
            {
                MensajesHelper.MostrarListaErrores("Se encontraron los siguientes errores:");
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                var mensajeExito = _esCrear ? "Profesor creado con éxito." : "Profesor editado con éxito.";
                MensajesHelper.MensajeAceptar(mensajeExito);
                this.Close();
            }
        }

        private bool DatosValidos()
        {
            MensajesHelper.Errores = new List<string>();

            if (string.IsNullOrWhiteSpace(this.txtDireccion.Text))
            {
                MensajesHelper.Errores.Add($"La direccion del profesor es obligatorio.");
            }

            if (string.IsNullOrWhiteSpace(this.txtEmail.Text))
            {
                MensajesHelper.Errores.Add($"El email del profesor es obligatoria.");
            }

            if (string.IsNullOrWhiteSpace(this.txtNombre.Text))
            {
                MensajesHelper.Errores.Add($"El nombre del profesor es obligatorio.");
            }

            if (string.IsNullOrWhiteSpace(this.txtTelefono.Text))
            {
                MensajesHelper.Errores.Add($"El telefono del profesor es obligatorio.");
            }

            return !MensajesHelper.Errores.Any();
        }

        private bool OperarProfesor()
        {
            if (_esCrear)
            {
                return CrearProfesor();
            }
            else
            {
                return EditarProfesor();
            }
        }

        private bool CrearProfesor()
        {
            var creadoConExito = true;

            try
            {
                var profesor = new Profesor()
                {
                    Nombre = this.txtNombre.Text,
                    Direccion = this.txtDireccion.Text,
                    Email = this.txtEmail.Text,
                    Telefono = this.txtTelefono.Text
                };

                _profesorManager.Create(profesor);
            }
            catch (Exception ex)
            {
                MensajesHelper.Errores = new List<string>();

                if (ex is ExceptionsInternas exInterna && exInterna.TipoError == TipoError.ErrorCrearProfesor)
                {
                    MensajesHelper.Errores = exInterna.Errores;
                }

                creadoConExito = false;
            }

            return creadoConExito;
        }

        private bool EditarProfesor()
        {
            var edicionExitosa = true;

            try
            {
                var profesorExistente = _profesorManager.Get((int)_idProfesor);

                if (profesorExistente == null)
                {
                    return false;
                }

                profesorExistente.Nombre = this.txtNombre.Text;
                profesorExistente.Direccion = this.txtDireccion.Text;
                profesorExistente.Email = this.txtEmail.Text;
                profesorExistente.Telefono = this.txtTelefono.Text;

                _profesorManager.Update(profesorExistente);
            }
            catch (Exception ex)
            {
                MensajesHelper.Errores = new List<string>();

                if (ex is ExceptionsInternas exInterna && exInterna.TipoError == TipoError.ErrorEditarProfesor)
                {
                    MensajesHelper.Errores = exInterna.Errores;
                }

                edicionExitosa = false;
            }

            return edicionExitosa;
        }
    }
}
