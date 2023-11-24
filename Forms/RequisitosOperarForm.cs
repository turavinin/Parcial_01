using Forms.Helpers;
using Libreria.Entidades;
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
    public partial class RequisitosOperarForm : Form
    {
        private readonly ICursoManager _cursoManager;
        private List<Curso> _cursos;
        private Curso _curso;

        public RequisitosOperarForm(Curso curso)
        {
            _cursoManager = new CursoManager();
            _curso = curso;

            InitializeComponent();
        }

        private void RequisitosOperarForm_Load(object sender, EventArgs e)
        {
            this.lblNombreCurso.Text = $"Requisitos para {_curso.Nombre}";
            this.txtPromedio.Text = _curso.PromedioMinimo.ToString();
            this.txtCredito.Text = _curso.CreditoMinimo.ToString();

            ListarCursos();
        }

        private void ListarCursos()
        {
            _cursos = _cursoManager.Get();

            if (_cursos.Count > 0)
            {
                this.dgvListaCursos.Rows.Clear();

                foreach (var cursoCorrelativo in _cursos)
                {
                    if (cursoCorrelativo.Id != _curso.Id)
                    {
                        var cursoCorrelativoEstablecido = _curso?.CursosCorrelativosIds?.Contains(cursoCorrelativo.Id);
                        this.dgvListaCursos.Rows.Add(cursoCorrelativoEstablecido, cursoCorrelativo.Nombre);
                    }
                }
            }
        }

        private void btnCancelarCurso_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptarCurso_Click(object sender, EventArgs e)
        {
            if (!DatosValidos())
            {
                MensajesHelper.MostrarListaErrores("Se encontraron los siguientes errores:");
            }
            else
            {
                var promedio = int.Parse(this.txtPromedio.Text);
                var credito = int.Parse(this.txtCredito.Text);
                var correlatividades = GetCorrelatividadesCheckeados();

                _curso.PromedioMinimo = promedio;
                _curso.CreditoMinimo = credito;
                _curso.Correlativas = string.Join(",", correlatividades.Select(x => x.Id));
                _cursoManager.Editar(_curso);

                this.DialogResult = DialogResult.OK;
                MensajesHelper.MensajeAceptar("Curso editado con éxito.");
                this.Close();
            }
        }

        private List<Curso> GetCorrelatividadesCheckeados()
        {
            var correlatividadesChequeadas = new List<Curso>();

            foreach (DataGridViewRow row in dgvListaCursos.Rows)
            {
                if (row.Cells[0] is DataGridViewCheckBoxCell)
                {
                    bool isChecked = (bool)row.Cells[0].EditedFormattedValue;

                    if (isChecked)
                    {
                        var curso = _cursos.FirstOrDefault(x => x.Nombre == row.Cells[1].Value);
                        correlatividadesChequeadas.Add(curso);
                    }
                }
            }

            return correlatividadesChequeadas;
        }

        private bool DatosValidos()
        {
            MensajesHelper.Errores = new List<string>();

            if (!string.IsNullOrWhiteSpace(this.txtPromedio.Text))
            {
                if (!int.TryParse(this.txtPromedio.Text, out int promedio) || promedio < 1 || promedio > 10)
                {
                    MensajesHelper.Errores.Add($"El promedio es invalido");
                }
            }

            if (!string.IsNullOrWhiteSpace(this.txtCredito.Text))
            {
                if (!int.TryParse(this.txtCredito.Text, out int credito) || credito < 1)
                {
                    MensajesHelper.Errores.Add($"El credito es invalido");
                }
            }

            return !MensajesHelper.Errores.Any();
        }
    }

}
