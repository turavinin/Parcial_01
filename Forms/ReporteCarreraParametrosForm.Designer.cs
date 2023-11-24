namespace Forms
{
    partial class ReporteCarreraParametrosForm
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
            lblCarrera = new Label();
            cmbCarrera = new ComboBox();
            btnCancelarInforme = new Button();
            btnGenerarInforme = new Button();
            SuspendLayout();
            // 
            // lblCarrera
            // 
            lblCarrera.AutoSize = true;
            lblCarrera.Font = new Font("Agency FB", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point);
            lblCarrera.Location = new Point(12, 19);
            lblCarrera.Name = "lblCarrera";
            lblCarrera.Size = new Size(73, 28);
            lblCarrera.TabIndex = 38;
            lblCarrera.Text = "Carrera";
            // 
            // cmbCarrera
            // 
            cmbCarrera.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCarrera.FormattingEnabled = true;
            cmbCarrera.Location = new Point(100, 22);
            cmbCarrera.Name = "cmbCarrera";
            cmbCarrera.Size = new Size(248, 28);
            cmbCarrera.TabIndex = 39;
            // 
            // btnCancelarInforme
            // 
            btnCancelarInforme.Anchor = AnchorStyles.None;
            btnCancelarInforme.BackColor = Color.Black;
            btnCancelarInforme.Font = new Font("Agency FB", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancelarInforme.ForeColor = Color.White;
            btnCancelarInforme.Location = new Point(44, 163);
            btnCancelarInforme.Name = "btnCancelarInforme";
            btnCancelarInforme.Size = new Size(275, 45);
            btnCancelarInforme.TabIndex = 59;
            btnCancelarInforme.Text = "CANCELAR";
            btnCancelarInforme.UseMnemonic = false;
            btnCancelarInforme.UseVisualStyleBackColor = false;
            btnCancelarInforme.Click += btnCancelarInforme_Click;
            // 
            // btnGenerarInforme
            // 
            btnGenerarInforme.Anchor = AnchorStyles.None;
            btnGenerarInforme.Font = new Font("Agency FB", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnGenerarInforme.Location = new Point(44, 112);
            btnGenerarInforme.Name = "btnGenerarInforme";
            btnGenerarInforme.Size = new Size(275, 45);
            btnGenerarInforme.TabIndex = 58;
            btnGenerarInforme.Text = "GENERAR INFORME";
            btnGenerarInforme.UseMnemonic = false;
            btnGenerarInforme.UseVisualStyleBackColor = true;
            btnGenerarInforme.Click += btnGenerarInforme_Click;
            // 
            // ReporteCarreraParametrosForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(365, 227);
            ControlBox = false;
            Controls.Add(btnCancelarInforme);
            Controls.Add(btnGenerarInforme);
            Controls.Add(cmbCarrera);
            Controls.Add(lblCarrera);
            Name = "ReporteCarreraParametrosForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Reporte";
            Load += ReporteCarreraParametrosForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCarrera;
        private ComboBox cmbCarrera;
        private Button btnCancelarInforme;
        private Button btnGenerarInforme;
    }
}