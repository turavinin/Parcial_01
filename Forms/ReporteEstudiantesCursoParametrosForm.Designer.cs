namespace Forms
{
    partial class ReporteEstudianteCursoParametrosForm
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
            lblReporteCurso = new Label();
            cmbCurso = new ComboBox();
            btnGenerarInforme = new Button();
            btnCancelarInforme = new Button();
            SuspendLayout();
            // 
            // lblReporteCurso
            // 
            lblReporteCurso.AutoSize = true;
            lblReporteCurso.Font = new Font("Agency FB", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point);
            lblReporteCurso.Location = new Point(12, 20);
            lblReporteCurso.Name = "lblReporteCurso";
            lblReporteCurso.Size = new Size(57, 28);
            lblReporteCurso.TabIndex = 36;
            lblReporteCurso.Text = "Curso";
            // 
            // cmbCurso
            // 
            cmbCurso.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCurso.FormattingEnabled = true;
            cmbCurso.Location = new Point(93, 23);
            cmbCurso.Name = "cmbCurso";
            cmbCurso.Size = new Size(269, 28);
            cmbCurso.TabIndex = 37;
            // 
            // btnGenerarInforme
            // 
            btnGenerarInforme.Anchor = AnchorStyles.None;
            btnGenerarInforme.Font = new Font("Agency FB", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnGenerarInforme.Location = new Point(54, 117);
            btnGenerarInforme.Name = "btnGenerarInforme";
            btnGenerarInforme.Size = new Size(275, 45);
            btnGenerarInforme.TabIndex = 55;
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
            btnCancelarInforme.Location = new Point(54, 177);
            btnCancelarInforme.Name = "btnCancelarInforme";
            btnCancelarInforme.Size = new Size(275, 45);
            btnCancelarInforme.TabIndex = 56;
            btnCancelarInforme.Text = "CANCELAR";
            btnCancelarInforme.UseMnemonic = false;
            btnCancelarInforme.UseVisualStyleBackColor = false;
            btnCancelarInforme.Click += btnCancelarInforme_Click;
            // 
            // ReporteEstudianteCursoParametrosForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(387, 244);
            ControlBox = false;
            Controls.Add(btnCancelarInforme);
            Controls.Add(btnGenerarInforme);
            Controls.Add(cmbCurso);
            Controls.Add(lblReporteCurso);
            Name = "ReporteEstudianteCursoParametrosForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Reporte";
            Load += Reporte_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblReporteCurso;
        private ComboBox cmbCurso;
        private Button btnGenerarInforme;
        private Button btnCancelarInforme;
    }
}