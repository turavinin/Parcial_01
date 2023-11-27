namespace Forms
{
    partial class ReportesInscripcionPeriodoParametrosForm
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
            lblAnio = new Label();
            txtAnio = new TextBox();
            lblCuatrimestre = new Label();
            cmbCuatrimestres = new ComboBox();
            btnCancelarInforme = new Button();
            btnGenerarInforme = new Button();
            SuspendLayout();
            // 
            // lblAnio
            // 
            lblAnio.AutoSize = true;
            lblAnio.Font = new Font("Agency FB", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point);
            lblAnio.Location = new Point(12, 20);
            lblAnio.Name = "lblAnio";
            lblAnio.Size = new Size(40, 28);
            lblAnio.TabIndex = 30;
            lblAnio.Text = "Año";
            // 
            // txtAnio
            // 
            txtAnio.Location = new Point(131, 20);
            txtAnio.Name = "txtAnio";
            txtAnio.Size = new Size(100, 27);
            txtAnio.TabIndex = 34;
            // 
            // lblCuatrimestre
            // 
            lblCuatrimestre.AutoSize = true;
            lblCuatrimestre.Font = new Font("Agency FB", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point);
            lblCuatrimestre.Location = new Point(12, 53);
            lblCuatrimestre.Name = "lblCuatrimestre";
            lblCuatrimestre.Size = new Size(113, 28);
            lblCuatrimestre.TabIndex = 35;
            lblCuatrimestre.Text = "Cuatrimestre";
            // 
            // cmbCuatrimestres
            // 
            cmbCuatrimestres.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCuatrimestres.FormattingEnabled = true;
            cmbCuatrimestres.Location = new Point(131, 53);
            cmbCuatrimestres.Name = "cmbCuatrimestres";
            cmbCuatrimestres.Size = new Size(100, 28);
            cmbCuatrimestres.TabIndex = 36;
            // 
            // btnCancelarInforme
            // 
            btnCancelarInforme.Anchor = AnchorStyles.None;
            btnCancelarInforme.BackColor = Color.Black;
            btnCancelarInforme.Font = new Font("Agency FB", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancelarInforme.ForeColor = Color.White;
            btnCancelarInforme.Location = new Point(31, 165);
            btnCancelarInforme.Name = "btnCancelarInforme";
            btnCancelarInforme.Size = new Size(275, 45);
            btnCancelarInforme.TabIndex = 53;
            btnCancelarInforme.Text = "CANCELAR";
            btnCancelarInforme.UseMnemonic = false;
            btnCancelarInforme.UseVisualStyleBackColor = false;
            btnCancelarInforme.Click += btnCancelarInforme_Click;
            // 
            // btnGenerarInforme
            // 
            btnGenerarInforme.Anchor = AnchorStyles.None;
            btnGenerarInforme.Font = new Font("Agency FB", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnGenerarInforme.Location = new Point(31, 114);
            btnGenerarInforme.Name = "btnGenerarInforme";
            btnGenerarInforme.Size = new Size(275, 45);
            btnGenerarInforme.TabIndex = 54;
            btnGenerarInforme.Text = "GENERAR INFORME";
            btnGenerarInforme.UseMnemonic = false;
            btnGenerarInforme.UseVisualStyleBackColor = true;
            btnGenerarInforme.Click += btnGenerarInforme_Click;
            // 
            // ReportesInscripcionPeriodoParametrosForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(337, 222);
            ControlBox = false;
            Controls.Add(btnGenerarInforme);
            Controls.Add(btnCancelarInforme);
            Controls.Add(cmbCuatrimestres);
            Controls.Add(lblCuatrimestre);
            Controls.Add(txtAnio);
            Controls.Add(lblAnio);
            Name = "ReportesInscripcionPeriodoParametrosForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Parametros";
            Load += ReportesInscripcionPeriodoParametrosForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblAnio;
        private TextBox txtAnio;
        private Label lblCuatrimestre;
        private ComboBox cmbCuatrimestres;
        private Button btnCancelarInforme;
        private Button btnGenerarInforme;
    }
}