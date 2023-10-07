namespace Forms
{
    partial class CursoOperarForm
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
            btnCancelarCurso = new Button();
            btnAceptarCurso = new Button();
            txtCupoMaximo = new TextBox();
            lblCupoMaximo = new Label();
            txtCodigoCurso = new TextBox();
            txtDescripcionCurso = new TextBox();
            lblDescripcionCurso = new Label();
            txtNombreCurso = new TextBox();
            lblNombreCurso = new Label();
            lblCodigoCurso = new Label();
            SuspendLayout();
            // 
            // btnCancelarCurso
            // 
            btnCancelarCurso.Anchor = AnchorStyles.None;
            btnCancelarCurso.BackColor = Color.Black;
            btnCancelarCurso.Font = new Font("Agency FB", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancelarCurso.ForeColor = Color.White;
            btnCancelarCurso.Location = new Point(125, 258);
            btnCancelarCurso.Name = "btnCancelarCurso";
            btnCancelarCurso.Size = new Size(342, 45);
            btnCancelarCurso.TabIndex = 40;
            btnCancelarCurso.Text = "CANCELAR";
            btnCancelarCurso.UseMnemonic = false;
            btnCancelarCurso.UseVisualStyleBackColor = false;
            btnCancelarCurso.Click += btnCancelarCurso_Click;
            // 
            // btnAceptarCurso
            // 
            btnAceptarCurso.Anchor = AnchorStyles.None;
            btnAceptarCurso.Font = new Font("Agency FB", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnAceptarCurso.Location = new Point(125, 195);
            btnAceptarCurso.Name = "btnAceptarCurso";
            btnAceptarCurso.Size = new Size(342, 45);
            btnAceptarCurso.TabIndex = 39;
            btnAceptarCurso.Text = "ACEPTAR";
            btnAceptarCurso.UseMnemonic = false;
            btnAceptarCurso.UseVisualStyleBackColor = true;
            btnAceptarCurso.Click += btnAceptarCurso_Click;
            // 
            // txtCupoMaximo
            // 
            txtCupoMaximo.Location = new Point(314, 131);
            txtCupoMaximo.Name = "txtCupoMaximo";
            txtCupoMaximo.Size = new Size(275, 27);
            txtCupoMaximo.TabIndex = 35;
            // 
            // lblCupoMaximo
            // 
            lblCupoMaximo.AutoSize = true;
            lblCupoMaximo.Font = new Font("Agency FB", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point);
            lblCupoMaximo.Location = new Point(314, 100);
            lblCupoMaximo.Name = "lblCupoMaximo";
            lblCupoMaximo.Size = new Size(113, 28);
            lblCupoMaximo.TabIndex = 34;
            lblCupoMaximo.Text = "Cupo máximo";
            // 
            // txtCodigoCurso
            // 
            txtCodigoCurso.Location = new Point(314, 51);
            txtCodigoCurso.Name = "txtCodigoCurso";
            txtCodigoCurso.Size = new Size(275, 27);
            txtCodigoCurso.TabIndex = 33;
            // 
            // txtDescripcionCurso
            // 
            txtDescripcionCurso.Location = new Point(12, 131);
            txtDescripcionCurso.Name = "txtDescripcionCurso";
            txtDescripcionCurso.Size = new Size(275, 27);
            txtDescripcionCurso.TabIndex = 29;
            // 
            // lblDescripcionCurso
            // 
            lblDescripcionCurso.AutoSize = true;
            lblDescripcionCurso.Font = new Font("Agency FB", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point);
            lblDescripcionCurso.Location = new Point(12, 100);
            lblDescripcionCurso.Name = "lblDescripcionCurso";
            lblDescripcionCurso.Size = new Size(101, 28);
            lblDescripcionCurso.TabIndex = 28;
            lblDescripcionCurso.Text = "Descripción";
            // 
            // txtNombreCurso
            // 
            txtNombreCurso.Location = new Point(12, 51);
            txtNombreCurso.Name = "txtNombreCurso";
            txtNombreCurso.Size = new Size(275, 27);
            txtNombreCurso.TabIndex = 27;
            // 
            // lblNombreCurso
            // 
            lblNombreCurso.AutoSize = true;
            lblNombreCurso.Font = new Font("Agency FB", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point);
            lblNombreCurso.Location = new Point(12, 20);
            lblNombreCurso.Name = "lblNombreCurso";
            lblNombreCurso.Size = new Size(71, 28);
            lblNombreCurso.TabIndex = 26;
            lblNombreCurso.Text = "Nombre";
            // 
            // lblCodigoCurso
            // 
            lblCodigoCurso.AutoSize = true;
            lblCodigoCurso.Font = new Font("Agency FB", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point);
            lblCodigoCurso.Location = new Point(314, 20);
            lblCodigoCurso.Name = "lblCodigoCurso";
            lblCodigoCurso.Size = new Size(62, 28);
            lblCodigoCurso.TabIndex = 41;
            lblCodigoCurso.Text = "Código";
            // 
            // CursoOperarForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(601, 325);
            ControlBox = false;
            Controls.Add(lblCodigoCurso);
            Controls.Add(btnCancelarCurso);
            Controls.Add(btnAceptarCurso);
            Controls.Add(txtCupoMaximo);
            Controls.Add(lblCupoMaximo);
            Controls.Add(txtCodigoCurso);
            Controls.Add(txtDescripcionCurso);
            Controls.Add(lblDescripcionCurso);
            Controls.Add(txtNombreCurso);
            Controls.Add(lblNombreCurso);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "CursoOperarForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Curso";
            Load += CursoOperarForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancelarCurso;
        private Button btnAceptarCurso;
        private CheckBox chkCambiarClave;
        private TextBox txtTelefonoEstudiante;
        private Label lblTelefonoEstudiante;
        private TextBox txtCupoMaximo;
        private Label lblCupoMaximo;
        private TextBox txtCodigoCurso;
        private Label lblEmailEstudiante;
        private TextBox txtDniEstudiante;
        private Label lblDniEstudiante;
        private TextBox txtDescripcionCurso;
        private Label lblDescripcionCurso;
        private TextBox txtNombreCurso;
        private Label lblNombreCurso;
        private Label lblCodigoCurso;
    }
}