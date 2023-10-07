namespace Forms
{
    partial class ConceptoForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dgvListaConceptos = new DataGridView();
            pagar = new DataGridViewCheckBoxColumn();
            concepto = new DataGridViewTextBoxColumn();
            monto = new DataGridViewTextBoxColumn();
            pago = new DataGridViewTextBoxColumn();
            pnlPagos = new Panel();
            lblPagos = new Label();
            btnCancelarInscripcion = new Button();
            btnPagar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvListaConceptos).BeginInit();
            pnlPagos.SuspendLayout();
            SuspendLayout();
            // 
            // dgvListaConceptos
            // 
            dgvListaConceptos.AllowUserToAddRows = false;
            dgvListaConceptos.AllowUserToDeleteRows = false;
            dgvListaConceptos.AllowUserToResizeColumns = false;
            dgvListaConceptos.AllowUserToResizeRows = false;
            dgvListaConceptos.BackgroundColor = SystemColors.ButtonHighlight;
            dgvListaConceptos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvListaConceptos.Columns.AddRange(new DataGridViewColumn[] { pagar, concepto, monto, pago });
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgvListaConceptos.DefaultCellStyle = dataGridViewCellStyle1;
            dgvListaConceptos.Location = new Point(12, 69);
            dgvListaConceptos.MultiSelect = false;
            dgvListaConceptos.Name = "dgvListaConceptos";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = Color.Transparent;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvListaConceptos.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvListaConceptos.RowHeadersVisible = false;
            dgvListaConceptos.RowHeadersWidth = 51;
            dgvListaConceptos.RowTemplate.Height = 29;
            dgvListaConceptos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvListaConceptos.Size = new Size(761, 280);
            dgvListaConceptos.TabIndex = 9;
            dgvListaConceptos.TabStop = false;
            dgvListaConceptos.CellContentClick += dgvListaConceptos_CellContentClick;
            dgvListaConceptos.CellEndEdit += dgvListaConceptos_CellEndEdit;
            dgvListaConceptos.CurrentCellDirtyStateChanged += dgvListaConceptos_CurrentCellDirtyStateChanged;
            // 
            // pagar
            // 
            pagar.Frozen = true;
            pagar.HeaderText = "Pagar";
            pagar.MinimumWidth = 6;
            pagar.Name = "pagar";
            pagar.Resizable = DataGridViewTriState.False;
            pagar.Width = 60;
            // 
            // concepto
            // 
            concepto.Frozen = true;
            concepto.HeaderText = "Concepto";
            concepto.MinimumWidth = 6;
            concepto.Name = "concepto";
            concepto.ReadOnly = true;
            concepto.Width = 300;
            // 
            // monto
            // 
            monto.Frozen = true;
            monto.HeaderText = "Monto";
            monto.MinimumWidth = 6;
            monto.Name = "monto";
            monto.ReadOnly = true;
            monto.Resizable = DataGridViewTriState.False;
            monto.Width = 200;
            // 
            // pago
            // 
            pago.Frozen = true;
            pago.HeaderText = "Ingresar monto";
            pago.MinimumWidth = 6;
            pago.Name = "pago";
            pago.Width = 200;
            // 
            // pnlPagos
            // 
            pnlPagos.BackColor = Color.Black;
            pnlPagos.Controls.Add(lblPagos);
            pnlPagos.Location = new Point(-2, 0);
            pnlPagos.Name = "pnlPagos";
            pnlPagos.Size = new Size(790, 63);
            pnlPagos.TabIndex = 10;
            // 
            // lblPagos
            // 
            lblPagos.AutoSize = true;
            lblPagos.Font = new Font("Agency FB", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point);
            lblPagos.ForeColor = SystemColors.ButtonHighlight;
            lblPagos.Location = new Point(353, 9);
            lblPagos.Name = "lblPagos";
            lblPagos.Size = new Size(96, 41);
            lblPagos.TabIndex = 1;
            lblPagos.Text = "PAGOS";
            // 
            // btnCancelarInscripcion
            // 
            btnCancelarInscripcion.Anchor = AnchorStyles.None;
            btnCancelarInscripcion.BackColor = Color.Black;
            btnCancelarInscripcion.Font = new Font("Agency FB", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancelarInscripcion.ForeColor = Color.White;
            btnCancelarInscripcion.Location = new Point(230, 434);
            btnCancelarInscripcion.Name = "btnCancelarInscripcion";
            btnCancelarInscripcion.Size = new Size(342, 45);
            btnCancelarInscripcion.TabIndex = 42;
            btnCancelarInscripcion.Text = "CERRAR";
            btnCancelarInscripcion.UseMnemonic = false;
            btnCancelarInscripcion.UseVisualStyleBackColor = false;
            btnCancelarInscripcion.Click += btnCancelarInscripcion_Click;
            // 
            // btnPagar
            // 
            btnPagar.Anchor = AnchorStyles.None;
            btnPagar.Font = new Font("Agency FB", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnPagar.Location = new Point(230, 383);
            btnPagar.Name = "btnPagar";
            btnPagar.Size = new Size(342, 45);
            btnPagar.TabIndex = 43;
            btnPagar.Text = "PAGAR";
            btnPagar.UseMnemonic = false;
            btnPagar.UseVisualStyleBackColor = true;
            btnPagar.Click += btnPagar_Click;
            // 
            // ConceptoForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(786, 512);
            ControlBox = false;
            Controls.Add(btnPagar);
            Controls.Add(btnCancelarInscripcion);
            Controls.Add(pnlPagos);
            Controls.Add(dgvListaConceptos);
            Name = "ConceptoForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Pagos";
            Load += ConceptoForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvListaConceptos).EndInit();
            pnlPagos.ResumeLayout(false);
            pnlPagos.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvListaConceptos;
        private Panel pnlPagos;
        private Label lblPagos;
        private Button btnCancelarInscripcion;
        private Button btnPagar;
        private DataGridViewCheckBoxColumn pagar;
        private DataGridViewTextBoxColumn concepto;
        private DataGridViewTextBoxColumn monto;
        private DataGridViewTextBoxColumn pago;
    }
}