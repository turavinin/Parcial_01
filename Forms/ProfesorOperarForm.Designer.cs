namespace Forms
{
    partial class ProfesorOperarForm
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
            lblNombre = new Label();
            txtEmail = new TextBox();
            lblTelefono = new Label();
            txtDireccion = new TextBox();
            txtTelefono = new TextBox();
            txtNombre = new TextBox();
            lblDireccion = new Label();
            lblEmail = new Label();
            btnCancelarCurso = new Button();
            btnAceptarCurso = new Button();
            SuspendLayout();
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Agency FB", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point);
            lblNombre.Location = new Point(12, 9);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(71, 28);
            lblNombre.TabIndex = 47;
            lblNombre.Text = "Nombre";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(328, 119);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(275, 27);
            txtEmail.TabIndex = 46;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Font = new Font("Agency FB", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point);
            lblTelefono.Location = new Point(328, 9);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(76, 28);
            lblTelefono.TabIndex = 45;
            lblTelefono.Text = "Telefono";
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(12, 119);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(275, 27);
            txtDireccion.TabIndex = 44;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(328, 40);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(275, 27);
            txtTelefono.TabIndex = 43;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(12, 40);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(275, 27);
            txtNombre.TabIndex = 42;
            // 
            // lblDireccion
            // 
            lblDireccion.AutoSize = true;
            lblDireccion.Font = new Font("Agency FB", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point);
            lblDireccion.Location = new Point(12, 88);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(83, 28);
            lblDireccion.TabIndex = 48;
            lblDireccion.Text = "Direccion";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Agency FB", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point);
            lblEmail.Location = new Point(328, 88);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(50, 28);
            lblEmail.TabIndex = 49;
            lblEmail.Text = "Email";
            // 
            // btnCancelarCurso
            // 
            btnCancelarCurso.Anchor = AnchorStyles.None;
            btnCancelarCurso.BackColor = Color.Black;
            btnCancelarCurso.Font = new Font("Agency FB", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancelarCurso.ForeColor = Color.White;
            btnCancelarCurso.Location = new Point(140, 250);
            btnCancelarCurso.Name = "btnCancelarCurso";
            btnCancelarCurso.Size = new Size(342, 45);
            btnCancelarCurso.TabIndex = 51;
            btnCancelarCurso.Text = "CANCELAR";
            btnCancelarCurso.UseMnemonic = false;
            btnCancelarCurso.UseVisualStyleBackColor = false;
            btnCancelarCurso.Click += btnCancelarCurso_Click;
            // 
            // btnAceptarCurso
            // 
            btnAceptarCurso.Anchor = AnchorStyles.None;
            btnAceptarCurso.Font = new Font("Agency FB", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnAceptarCurso.Location = new Point(140, 187);
            btnAceptarCurso.Name = "btnAceptarCurso";
            btnAceptarCurso.Size = new Size(342, 45);
            btnAceptarCurso.TabIndex = 50;
            btnAceptarCurso.Text = "ACEPTAR";
            btnAceptarCurso.UseMnemonic = false;
            btnAceptarCurso.UseVisualStyleBackColor = true;
            btnAceptarCurso.Click += btnAceptarCurso_Click;
            // 
            // ProfesorOperarForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(622, 316);
            ControlBox = false;
            Controls.Add(btnCancelarCurso);
            Controls.Add(btnAceptarCurso);
            Controls.Add(lblEmail);
            Controls.Add(lblDireccion);
            Controls.Add(lblNombre);
            Controls.Add(txtEmail);
            Controls.Add(lblTelefono);
            Controls.Add(txtDireccion);
            Controls.Add(txtTelefono);
            Controls.Add(txtNombre);
            Name = "ProfesorOperarForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Profesor";
            Load += ProfesorOperarForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNombre;
        private TextBox txtEmail;
        private Label lblTelefono;
        private TextBox txtDireccion;
        private TextBox txtTelefono;
        private TextBox txtNombre;
        private Label lblDireccion;
        private Label lblEmail;
        private Button btnCancelarCurso;
        private Button btnAceptarCurso;
    }
}