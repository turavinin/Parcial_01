namespace Forms
{
    partial class ReporteIngresoConceptoParametrosForm
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
            lblConcepto = new Label();
            cmbConcepto = new ComboBox();
            btnGenerarInforme = new Button();
            btnCancelarInforme = new Button();
            SuspendLayout();
            // 
            // lblConcepto
            // 
            lblConcepto.AutoSize = true;
            lblConcepto.Font = new Font("Agency FB", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point);
            lblConcepto.Location = new Point(9, 20);
            lblConcepto.Name = "lblConcepto";
            lblConcepto.Size = new Size(82, 28);
            lblConcepto.TabIndex = 37;
            lblConcepto.Text = "Concepto";
            // 
            // cmbConcepto
            // 
            cmbConcepto.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbConcepto.FormattingEnabled = true;
            cmbConcepto.Location = new Point(97, 23);
            cmbConcepto.Name = "cmbConcepto";
            cmbConcepto.Size = new Size(269, 28);
            cmbConcepto.TabIndex = 38;
            // 
            // btnGenerarInforme
            // 
            btnGenerarInforme.Anchor = AnchorStyles.None;
            btnGenerarInforme.Font = new Font("Agency FB", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnGenerarInforme.Location = new Point(55, 117);
            btnGenerarInforme.Name = "btnGenerarInforme";
            btnGenerarInforme.Size = new Size(275, 45);
            btnGenerarInforme.TabIndex = 56;
            btnGenerarInforme.Text = "GENERAR INFORME";
            btnGenerarInforme.UseMnemonic = false;
            btnGenerarInforme.UseVisualStyleBackColor = true;
            btnGenerarInforme.Click += btnGenerarInforme_Click;
            // 
            // btnCancelarInforme
            // 
            btnCancelarInforme.Anchor = AnchorStyles.None;
            btnCancelarInforme.BackColor = Color.Black;
            btnCancelarInforme.Font = new Font("Agency FB", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancelarInforme.ForeColor = Color.White;
            btnCancelarInforme.Location = new Point(55, 168);
            btnCancelarInforme.Name = "btnCancelarInforme";
            btnCancelarInforme.Size = new Size(275, 45);
            btnCancelarInforme.TabIndex = 57;
            btnCancelarInforme.Text = "CANCELAR";
            btnCancelarInforme.UseMnemonic = false;
            btnCancelarInforme.UseVisualStyleBackColor = false;
            btnCancelarInforme.Click += btnCancelarInforme_Click;
            // 
            // ReporteIngresoConceptoParametrosForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(379, 225);
            ControlBox = false;
            Controls.Add(btnCancelarInforme);
            Controls.Add(btnGenerarInforme);
            Controls.Add(cmbConcepto);
            Controls.Add(lblConcepto);
            Name = "ReporteIngresoConceptoParametrosForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Reporte";
            Load += ReporteIngresoConceptoParametrosForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblConcepto;
        private ComboBox cmbConcepto;
        private Button btnGenerarInforme;
        private Button btnCancelarInforme;
    }
}