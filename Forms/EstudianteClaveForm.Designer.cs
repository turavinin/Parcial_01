namespace Forms
{
    partial class EstudianteClaveForm
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
            btnCancelarNuevaClave = new Button();
            btnAceptarNuevaClave = new Button();
            lblNuevaClave = new Label();
            txtNuevaClave = new TextBox();
            SuspendLayout();
            // 
            // btnCancelarNuevaClave
            // 
            btnCancelarNuevaClave.Anchor = AnchorStyles.None;
            btnCancelarNuevaClave.Font = new Font("Agency FB", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancelarNuevaClave.Location = new Point(18, 186);
            btnCancelarNuevaClave.Name = "btnCancelarNuevaClave";
            btnCancelarNuevaClave.Size = new Size(275, 45);
            btnCancelarNuevaClave.TabIndex = 50;
            btnCancelarNuevaClave.Text = "CANCELAR";
            btnCancelarNuevaClave.UseMnemonic = false;
            btnCancelarNuevaClave.UseVisualStyleBackColor = true;
            btnCancelarNuevaClave.Click += btnCancelarNuevaClave_Click;
            // 
            // btnAceptarNuevaClave
            // 
            btnAceptarNuevaClave.Anchor = AnchorStyles.None;
            btnAceptarNuevaClave.Font = new Font("Agency FB", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnAceptarNuevaClave.Location = new Point(18, 135);
            btnAceptarNuevaClave.Name = "btnAceptarNuevaClave";
            btnAceptarNuevaClave.Size = new Size(275, 45);
            btnAceptarNuevaClave.TabIndex = 49;
            btnAceptarNuevaClave.Text = "ACEPTAR";
            btnAceptarNuevaClave.UseMnemonic = false;
            btnAceptarNuevaClave.UseVisualStyleBackColor = true;
            btnAceptarNuevaClave.Click += btnAceptarNuevaClave_Click;
            // 
            // lblNuevaClave
            // 
            lblNuevaClave.AutoSize = true;
            lblNuevaClave.Font = new Font("Agency FB", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point);
            lblNuevaClave.Location = new Point(18, 36);
            lblNuevaClave.Name = "lblNuevaClave";
            lblNuevaClave.Size = new Size(105, 28);
            lblNuevaClave.TabIndex = 42;
            lblNuevaClave.Text = "Nueva clave";
            // 
            // txtNuevaClave
            // 
            txtNuevaClave.Location = new Point(18, 67);
            txtNuevaClave.Name = "txtNuevaClave";
            txtNuevaClave.Size = new Size(275, 27);
            txtNuevaClave.TabIndex = 51;
            // 
            // EstudianteClaveForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(314, 266);
            ControlBox = false;
            Controls.Add(txtNuevaClave);
            Controls.Add(btnCancelarNuevaClave);
            Controls.Add(btnAceptarNuevaClave);
            Controls.Add(lblNuevaClave);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "EstudianteClaveForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cambiar clave";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancelarNuevaClave;
        private Button btnAceptarNuevaClave;
        private TextBox txtDescripcionCurso;
        private Label lblDescripcionCurso;
        private TextBox txtNombreCurso;
        private Label lblNuevaClave;
        private TextBox txtNuevaClave;
    }
}