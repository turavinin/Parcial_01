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
    public partial class CursoOperarForm : Form
    {
        private AdministracionManager _administracionManager;
        private bool _esCrear;

        public CursoOperarForm(AdministracionManager administracionManager, bool esCrear)
        {
            _administracionManager = administracionManager;
            _esCrear = esCrear;

            InitializeComponent();
        }

        private void CursoOperarForm_Load(object sender, EventArgs e)
        {
            this.Text = _esCrear ? "Crear curso" : "Editar curso";
        }

        private void btnAceptarCurso_Click(object sender, EventArgs e)
        {
            if (!DataCursoValida() || !OperarCurso())
            {
                MensajesHelper.MostrarListaErrores("Se encontraron los siguientes errores:");
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                var mensajeExito = _esCrear ? "Curso creado con éxito." : "Curso editado con éxito.";
                MensajesHelper.MensajeAceptar(mensajeExito);
                this.Close();
            }
        }

        private void btnCancelarCurso_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private bool DataCursoValida()
        {
            MensajesHelper.Errores = new List<string>();

            if (string.IsNullOrWhiteSpace(this.txtNombreCurso.Text))
            {
                MensajesHelper.Errores.Add($"El nombre del curso es obligatorio.");
            }

            if (string.IsNullOrWhiteSpace(this.txtDescripcionCurso.Text))
            {
                MensajesHelper.Errores.Add($"La descripción del curso es obligatoria.");
            }

            if (string.IsNullOrWhiteSpace(this.txtCodigoCurso.Text))
            {
                MensajesHelper.Errores.Add($"El código del curso obligatorio.");
            }

            if (!int.TryParse(this.txtCupoMaximo.Text, out _))
            {
                MensajesHelper.Errores.Add($"El cupo máximo ingresado es inválido.");
            }

            return !MensajesHelper.Errores.Any();
        }

        private bool OperarCurso()
        {
            if (_esCrear)
            {
                return CrearCurso();
            }
            else
            {
                return EditarCurso();
            }
        }

        private bool CrearCurso()
        {
            try
            {
                var curso = new Curso(this.txtNombreCurso.Text, this.txtCodigoCurso.Text, 
                                      this.txtDescripcionCurso.Text, int.Parse(this.txtCupoMaximo.Text));

                return _administracionManager.CrearCurso(curso);
            }
            catch (Exception ex)
            {
                MensajesHelper.Errores = new List<string>();

                if (ex is ExceptionsInternas exInterna && exInterna.TipoError == TipoError.ErrorCrearCurso)
                {
                    MensajesHelper.Errores = exInterna.Errores;
                }

                return false;
            }
        }

        private bool EditarCurso()
        {
            return true;
        }
    }
}
