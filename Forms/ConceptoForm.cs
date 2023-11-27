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
    public partial class ConceptoForm : Form
    {
        private IEstudianteManager _estudianteManager;
        private IConceptoManager _conceptoManager;
        private Estudiante _estudiante;
        private List<Concepto> _conceptos;

        private const int COLUMNA_INGRESAR_MONTO = 3;
        private const int COLUMNA_MONTO = 2;
        public ConceptoForm(int estudianteId)
        {
            _estudianteManager = new EstudianteManager();
            _conceptoManager = new ConceptoManager();
            _estudiante = _estudianteManager.Get(estudianteId);

            InitializeComponent();
        }

        private void ConceptoForm_Load(object sender, EventArgs e)
        {
            ListarConceptos();
        }

        private void ListarConceptos()
        {
            var estudianteActualizado = _estudianteManager.Get(_estudiante.Id);
            _conceptos = _conceptoManager.Get();

            if (_conceptos.Count > 0)
            {
                this.dgvListaConceptos.Rows.Clear();

                foreach (var concepto in _conceptos)
                {
                    var index = this.dgvListaConceptos.Rows.Add(false, concepto.Descripcion, concepto.Monto);
                    var conceptoPagado = estudianteActualizado.Pagos.FirstOrDefault(x => x.Concepto.Id == concepto.Id);

                    if (conceptoPagado?.Cancelado == true)
                    {
                        DesactivarTexto(index, Color.Green);
                        ActualizarMonto(index, "Pagado");
                        DesactivarChekbox(index, Color.Green);

                    }
                    else if (conceptoPagado?.MontoPagado != null)
                    {
                        concepto.Monto = concepto.Monto - conceptoPagado.MontoPagado;
                        ActualizarMonto(index, concepto.Monto.ToString());
                        DesactivarTexto(index, Color.Gray);
                    }
                    else
                    {
                        DesactivarTexto(index, Color.Gray);
                    }
                }
            }
        }

        #region Checkbox event
        private void dgvListaConceptos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvListaConceptos.Columns[e.ColumnIndex].Name == "pagar" && dgvListaConceptos.CurrentCell is DataGridViewCheckBoxCell)
            {
                bool isChecked = (bool)dgvListaConceptos[e.ColumnIndex, e.RowIndex].EditedFormattedValue;

                if (isChecked)
                {
                    ActivarTexto(e.RowIndex);
                }
                else
                {
                    ActivarTexto(e.RowIndex);
                }

                dgvListaConceptos.EndEdit();
            }
        }

        private void dgvListaConceptos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgvListaConceptos.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dgvListaConceptos_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvListaConceptos.CurrentCell is DataGridViewCheckBoxCell)
            {
                dgvListaConceptos.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        #endregion

        private void DesactivarChekbox(int rowIndex, Color? color = null)
        {
            this.dgvListaConceptos.Rows[rowIndex].Cells[0] = new DataGridViewTextBoxCell();
            this.dgvListaConceptos.Rows[rowIndex].Cells[0].Value = "";
            this.dgvListaConceptos.Rows[rowIndex].Cells[0].ReadOnly = true;

            if (color != null)
            {
                this.dgvListaConceptos.Rows[rowIndex].Cells[0].Style.BackColor = (Color)color;

            }
        }
        private void DesactivarTexto(int rowIndex, Color? color = null)
        {
            this.dgvListaConceptos.Rows[rowIndex].Cells[COLUMNA_INGRESAR_MONTO].Value = "";
            this.dgvListaConceptos.Rows[rowIndex].Cells[COLUMNA_INGRESAR_MONTO].ReadOnly = true;

            if (color != null)
            {
                this.dgvListaConceptos.Rows[rowIndex].Cells[COLUMNA_INGRESAR_MONTO].Style.BackColor = (Color)color;

            }
        }
        private void ActivarTexto(int rowIndex)
        {
            this.dgvListaConceptos.Rows[rowIndex].Cells[COLUMNA_INGRESAR_MONTO].Value = "0";
            this.dgvListaConceptos.Rows[rowIndex].Cells[COLUMNA_INGRESAR_MONTO].ReadOnly = false;
            this.dgvListaConceptos.Rows[rowIndex].Cells[COLUMNA_INGRESAR_MONTO].Style.BackColor = Color.White;
        }
        private void ActualizarMonto(int rowIndex, string monto)
        {
            this.dgvListaConceptos.Rows[rowIndex].Cells[COLUMNA_MONTO].Value = monto;

        }
        private void btnCancelarInscripcion_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            var conceptosIdsConMontos = GetIdsConceptosConMontosCheckeados();

            if (conceptosIdsConMontos.Count == 0)
            {
                MensajesHelper.MensajeAceptar("No hay conceptos pendientes de pago");
            }
            else if (!MontosValidos(conceptosIdsConMontos))
            {
                MensajesHelper.MostrarListaErrores("Se encontraron los siguientes errores:");
            }
            else
            {
                var form = new PagoForm(conceptosIdsConMontos);
                var result = form.ShowDialog();

                if (result == DialogResult.OK)
                {
                    if (!ProcesarPago(form.Pago, conceptosIdsConMontos) )
                    {
                        MensajesHelper.MostrarListaErrores("Se encontraron los siguientes errores:");
                    }
                    else
                    {
                        MensajesHelper.MensajeAceptar("Pago realizado con éxito");
                        ListarConceptos();
                    }
                }
            }
        }

        private Dictionary<int, string> GetIdsConceptosConMontosCheckeados()
        {
            var conceptoIdsCheckeados = new Dictionary<int, string>();

            foreach (DataGridViewRow row in dgvListaConceptos.Rows)
            {
                if (row.Cells[0] is DataGridViewCheckBoxCell)
                {
                    bool isChecked = (bool)row.Cells[0].EditedFormattedValue;

                    if (isChecked)
                    {
                        var concepto = _conceptos.FirstOrDefault(x => x.Descripcion == row.Cells[1].Value);
                        var montoIngresados = row.Cells[COLUMNA_INGRESAR_MONTO]?.Value?.ToString();
                        conceptoIdsCheckeados.Add(concepto.Id, montoIngresados);
                    }
                }
            }

            return conceptoIdsCheckeados;
        }

        private bool MontosValidos(Dictionary<int, string> conceptosMontos)
        {
            MensajesHelper.Errores = new List<string>();

            foreach (var conceptoMonto in conceptosMontos)
            {
                var monto = conceptoMonto.Value;
                var concepto = _conceptos.FirstOrDefault(x => x.Id == conceptoMonto.Key);

                if (string.IsNullOrEmpty(monto))
                {
                    MensajesHelper.Errores.Add($"El monto a pagar es obligatorio para el concepto: {concepto.Descripcion}");
                }
                else if (!int.TryParse(monto, out int conceptoDecimalAPagar) || conceptoDecimalAPagar < 1)
                {
                    MensajesHelper.Errores.Add($"El monto a pagar es inválido para el concepto: {concepto.Descripcion}");
                }
                else if (conceptoDecimalAPagar > concepto.Monto)
                {
                    MensajesHelper.Errores.Add($"El monto a pagar no puede ser mayor que el monto en el concepto: {concepto.Descripcion}");
                }
            }

            return !MensajesHelper.Errores.Any();
        }

        private bool ProcesarPago(Pago pago, Dictionary<int, string> conceptoMontoPagado)
        {
            var pagoValido = true;
            try
            {
                var estudiante = _estudianteManager.Get(_estudiante.Id);
                _estudianteManager.Pagar(estudiante, pago, conceptoMontoPagado);
            }
            catch (Exception ex)
            {
                MensajesHelper.Errores = new List<string>();

                if (ex is ExceptionsInternas exInterna && exInterna.TipoError == TipoError.ErrorPago)
                {
                    MensajesHelper.Errores = exInterna.Errores;
                }

                pagoValido = false;
            }

            return pagoValido;
        }
    }
}
