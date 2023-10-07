using Forms.Helpers;
using Libreria.Entidades;
using Libreria.Entidades.Enums;
using Libreria.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms
{
    public partial class DatosPagoForm : Form
    {
        private AdministracionManager _administracionManager;
        private Dictionary<int, string> _conceptosMontos;
        private DatosPago _pago;

        public DatosPago Pago { get => _pago; set => _pago = value; }

        public DatosPagoForm(AdministracionManager administracionManager, Dictionary<int, string> conceptosMontos)
        {
            _administracionManager = administracionManager;
            _conceptosMontos = conceptosMontos;
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DatosPagoForm_Load(object sender, EventArgs e)
        {
            CargarComboBox();
        }

        private void CargarComboBox()
        {
            var tipoPagoList = EnumTipoPagoHelper.GetTipoMetodoPago();
            tipoPagoList.ForEach(x => this.cmbMetodosPago.Items.Add(x.ToString()));
            this.cmbMetodosPago.SelectedIndex = 0;
        }

        private void cmbMetodosPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbMetodosPago.SelectedIndex == (int)TipoMetodoPago.Deposito)
            {
                this.lblCodigo.Text = string.Empty;
                this.txtCodigo.Enabled = false;
                this.lblNumero.Text = "CBU";
            }
            else
            {
                this.lblNumero.Text = "Número de la tarjeta";
                this.lblCodigo.Text = "Código";
                this.txtCodigo.Enabled = true;
            }
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            if (!DatosPagoValidos())
            {
                MensajesHelper.MostrarListaErrores("Se encontraron los siguientes errores:");
            }
            else
            {
                var tipoPago = (TipoMetodoPago)this.cmbMetodosPago.SelectedIndex;
                var numero = BigInteger.Parse(this.txtNumero.Text);
                var codigo = tipoPago == TipoMetodoPago.Deposito ? 0 : int.Parse(this.txtCodigo.Text);

                _pago = new DatosPago(tipoPago, numero, codigo);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool DatosPagoValidos()
        {
            switch (this.cmbMetodosPago.SelectedIndex)
            {
                case (int)TipoMetodoPago.Credito:
                case (int)TipoMetodoPago.Debito:
                    return ValidarCreditoDebito();
                case (int)TipoMetodoPago.Deposito:
                    return ValidarDeposito();
                default:
                    break;
            }

            return false;
        }

        private bool ValidarCreditoDebito()
        {
            MensajesHelper.Errores = new List<string>();

            if (!long.TryParse(this.txtNumero.Text, out long numeroTarjeta) || numeroTarjeta < 0)
            {
                MensajesHelper.Errores.Add($"El numero de la tarjeta es inválido.");
            }
            else if (numeroTarjeta.ToString().Length != 16)
            {
                MensajesHelper.Errores.Add($"Cantidad de números invalidos para la tarjeta. La cantidad debe ser 16.");
            }

            if (!int.TryParse(this.txtCodigo.Text, out int numeroCodigo) || numeroCodigo < 0)
            {
                MensajesHelper.Errores.Add($"El código es inválido.");
            }
            else if (numeroCodigo.ToString().Length != 3)
            {
                MensajesHelper.Errores.Add($"Cantidad de números invalidos para el código. La cantidad debe ser 3.");
            }

            return !MensajesHelper.Errores.Any();
        }

        private bool ValidarDeposito()
        {
            MensajesHelper.Errores = new List<string>();

            if (!BigInteger.TryParse(this.txtNumero.Text, out BigInteger numeroTarjeta) || numeroTarjeta < 0)
            {
                MensajesHelper.Errores.Add($"El CBU es inválido");
            }
            else if (numeroTarjeta.ToString().Length != 22)
            {
                MensajesHelper.Errores.Add($"Cantidad de números invalidos para el CBU. La cantidad debe ser 22.");
            }

            return !MensajesHelper.Errores.Any();
        }
    }
}
