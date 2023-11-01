using Forms.Helpers;
using Libreria.Entidades;
using Libreria.Exceptions;
using Libreria.Exceptions.Enums;
using Libreria.Managers;
using Libreria.Managers.Interface;

namespace Forms
{
    public partial class CursoOperarForm : Form
    {
        private bool _esCrear;
        private int? _idCurso;

        private ICursoManager _cursoManager;

        public CursoOperarForm(int? idCurso = null)
        {
            _esCrear = idCurso is null;
            _idCurso = idCurso;

            _cursoManager = new CursoManager();

            InitializeComponent();
        }

        private void CursoOperarForm_Load(object sender, EventArgs e)
        {
            this.Text = _esCrear ? "Crear curso" : "Editar curso";

            if (!_esCrear && _idCurso != null)
            {
                IniciarFormCursoExistente();
            }
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
            var creadoConExito = true;

            try
            {
                var curso = new Curso(this.txtNombreCurso.Text, this.txtCodigoCurso.Text,
                                      this.txtDescripcionCurso.Text, int.Parse(this.txtCupoMaximo.Text));

                _cursoManager.Crear(curso);
            }
            catch (Exception ex)
            {
                MensajesHelper.Errores = new List<string>();

                if (ex is ExceptionsInternas exInterna && exInterna.TipoError == TipoError.ErrorCrearCurso)
                {
                    MensajesHelper.Errores = exInterna.Errores;
                }

                creadoConExito = false;
            }

            return creadoConExito;
        }

        private bool EditarCurso()
        {
            var edicionExitosa = true;

            try
            {
                var cursoExistente = _cursoManager.Get((int)_idCurso);

                if(cursoExistente == null)
                {
                    return false;
                }

                cursoExistente.Nombre = this.txtNombreCurso.Text;
                cursoExistente.Codigo = this.txtCodigoCurso.Text;
                cursoExistente.Descripcion = this.txtDescripcionCurso.Text;
                cursoExistente.Cupo = int.Parse(this.txtCupoMaximo.Text);

                _cursoManager.Editar(cursoExistente);
            }
            catch (Exception ex)
            {
                MensajesHelper.Errores = new List<string>();

                if (ex is ExceptionsInternas exInterna && exInterna.TipoError == TipoError.ErrorEditarCurso)
                {
                    MensajesHelper.Errores = exInterna.Errores;
                }

                edicionExitosa = false;
            }

            return edicionExitosa;
        }

        private void IniciarFormCursoExistente()
        {
            var curso = _cursoManager.Get((int)_idCurso);

            if (curso != null)
            {
                this.txtNombreCurso.Text = curso.Nombre;
                this.txtDescripcionCurso.Text = curso.Descripcion;
                this.txtCodigoCurso.Text = curso.Codigo;
                this.txtCupoMaximo.Text = curso.Cupo.ToString();
            }
        }
    }
}
