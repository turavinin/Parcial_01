namespace Forms
{
    partial class PagoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cmbMetodosPago = new ComboBox();
            lblMetodoPago = new Label();
            lblNumero = new Label();
            txtNumero = new TextBox();
            lblCodigo = new Label();
            txtCodigo = new TextBox();
            btnCancelar = new Button();
            btnPagar = new Button();
            SuspendLayout();
            // 
            // cmbMetodosPago
            // 
            cmbMetodosPago.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMetodosPago.FormattingEnabled = true;
            cmbMetodosPago.Location = new Point(12, 51);
            cmbMetodosPago.Name = "cmbMetodosPago";
            cmbMetodosPago.Size = new Size(261, 28);
            cmbMetodosPago.TabIndex = 0;
            cmbMetodosPago.SelectedIndexChanged += cmbMetodosPago_SelectedIndexChanged;
            // 
            // lblMetodoPago
            // 
            lblMetodoPago.AutoSize = true;
            lblMetodoPago.Font = new Font("Agency FB", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point);
            lblMetodoPago.Location = new Point(12, 20);
            lblMetodoPago.Name = "lblMetodoPago";
            lblMetodoPago.Size = new Size(130, 28);
            lblMetodoPago.TabIndex = 29;
            lblMetodoPago.Text = "Método de pago";
            // 
            // lblNumero
            // 
            lblNumero.AutoSize = true;
            lblNumero.Font = new Font("Agency FB", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point);
            lblNumero.Location = new Point(12, 104);
            lblNumero.Name = "lblNumero";
            lblNumero.Size = new Size(127, 28);
            lblNumero.TabIndex = 30;
            lblNumero.Text = "Número tarjeta";
            // 
            // txtNumero
            // 
            txtNumero.Location = new Point(12, 135);
            txtNumero.Name = "txtNumero";
            txtNumero.Size = new Size(261, 27);
            txtNumero.TabIndex = 31;
            // 
            // lblCodigo
            // 
            lblCodigo.AutoSize = true;
            lblCodigo.Font = new Font("Agency FB", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point);
            lblCodigo.Location = new Point(15, 184);
            lblCodigo.Name = "lblCodigo";
            lblCodigo.Size = new Size(62, 28);
            lblCodigo.TabIndex = 32;
            lblCodigo.Text = "Codigo";
            // 
            // txtCodigo
            // 
            txtCodigo.Location = new Point(12, 215);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(78, 27);
            txtCodigo.TabIndex = 33;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.None;
            btnCancelar.BackColor = Color.Black;
            btnCancelar.Font = new Font("Agency FB", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(7, 329);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(275, 45);
            btnCancelar.TabIndex = 52;
            btnCancelar.Text = "CANCELAR";
            btnCancelar.UseMnemonic = false;
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnPagar
            // 
            btnPagar.Anchor = AnchorStyles.None;
            btnPagar.Font = new Font("Agency FB", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnPagar.Location = new Point(7, 278);
            btnPagar.Name = "btnPagar";
            btnPagar.Size = new Size(275, 45);
            btnPagar.TabIndex = 51;
            btnPagar.Text = "PAGAR";
            btnPagar.UseMnemonic = false;
            btnPagar.UseVisualStyleBackColor = true;
            btnPagar.Click += btnPagar_Click;
            // 
            // DatosPagoForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(288, 397);
            ControlBox = false;
            Controls.Add(btnCancelar);
            Controls.Add(btnPagar);
            Controls.Add(txtCodigo);
            Controls.Add(lblCodigo);
            Controls.Add(txtNumero);
            Controls.Add(lblNumero);
            Controls.Add(lblMetodoPago);
            Controls.Add(cmbMetodosPago);
            Name = "DatosPagoForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Datos Pago";
            Load += DatosPagoForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbMetodosPago;
        private Label lblMetodoPago;
        private Label lblNumero;
        private TextBox txtNumero;
        private Label lblCodigo;
        private TextBox txtCodigo;
        private Button btnCancelar;
        private Button btnPagar;
    }
}