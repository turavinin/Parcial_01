namespace Forms
{
    partial class RegistroEstudianteForm
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
            lblNombreCompletoEstudiante = new Label();
            txtNombreCompletoEstudiante = new TextBox();
            txtDireccionEstudiante = new TextBox();
            lblDireccionEstudiante = new Label();
            txtDniEstudiante = new TextBox();
            lblDniEstudiante = new Label();
            txtEmailEstudiante = new TextBox();
            lblEmailEstudiante = new Label();
            txtTelefonoEstudiante = new TextBox();
            lblTelefonoEstudiante = new Label();
            chkCambiarClave = new CheckBox();
            btnAceptarEstudiante = new Button();
            btnCancelarEstudiante = new Button();
            SuspendLayout();
            // 
            // lblNombreCompletoEstudiante
            // 
            lblNombreCompletoEstudiante.AutoSize = true;
            lblNombreCompletoEstudiante.Font = new Font("Agency FB", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point);
            lblNombreCompletoEstudiante.Location = new Point(30, 30);
            lblNombreCompletoEstudiante.Name = "lblNombreCompletoEstudiante";
            lblNombreCompletoEstudiante.Size = new Size(145, 28);
            lblNombreCompletoEstudiante.TabIndex = 11;
            lblNombreCompletoEstudiante.Text = "Nombre completo";
            // 
            // txtNombreCompletoEstudiante
            // 
            txtNombreCompletoEstudiante.Location = new Point(30, 61);
            txtNombreCompletoEstudiante.Name = "txtNombreCompletoEstudiante";
            txtNombreCompletoEstudiante.Size = new Size(275, 27);
            txtNombreCompletoEstudiante.TabIndex = 12;
            // 
            // txtDireccionEstudiante
            // 
            txtDireccionEstudiante.Location = new Point(30, 141);
            txtDireccionEstudiante.Name = "txtDireccionEstudiante";
            txtDireccionEstudiante.Size = new Size(275, 27);
            txtDireccionEstudiante.TabIndex = 14;
            // 
            // lblDireccionEstudiante
            // 
            lblDireccionEstudiante.AutoSize = true;
            lblDireccionEstudiante.Font = new Font("Agency FB", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point);
            lblDireccionEstudiante.Location = new Point(30, 110);
            lblDireccionEstudiante.Name = "lblDireccionEstudiante";
            lblDireccionEstudiante.Size = new Size(83, 28);
            lblDireccionEstudiante.TabIndex = 13;
            lblDireccionEstudiante.Text = "Dirección";
            // 
            // txtDniEstudiante
            // 
            txtDniEstudiante.Location = new Point(30, 221);
            txtDniEstudiante.Name = "txtDniEstudiante";
            txtDniEstudiante.Size = new Size(275, 27);
            txtDniEstudiante.TabIndex = 16;
            // 
            // lblDniEstudiante
            // 
            lblDniEstudiante.AutoSize = true;
            lblDniEstudiante.Font = new Font("Agency FB", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point);
            lblDniEstudiante.Location = new Point(30, 190);
            lblDniEstudiante.Name = "lblDniEstudiante";
            lblDniEstudiante.Size = new Size(36, 28);
            lblDniEstudiante.TabIndex = 15;
            lblDniEstudiante.Text = "DNI";
            // 
            // txtEmailEstudiante
            // 
            txtEmailEstudiante.Location = new Point(332, 61);
            txtEmailEstudiante.Name = "txtEmailEstudiante";
            txtEmailEstudiante.Size = new Size(275, 27);
            txtEmailEstudiante.TabIndex = 18;
            // 
            // lblEmailEstudiante
            // 
            lblEmailEstudiante.AutoSize = true;
            lblEmailEstudiante.Font = new Font("Agency FB", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point);
            lblEmailEstudiante.Location = new Point(332, 30);
            lblEmailEstudiante.Name = "lblEmailEstudiante";
            lblEmailEstudiante.Size = new Size(50, 28);
            lblEmailEstudiante.TabIndex = 17;
            lblEmailEstudiante.Text = "Email";
            // 
            // txtTelefonoEstudiante
            // 
            txtTelefonoEstudiante.Location = new Point(332, 141);
            txtTelefonoEstudiante.Name = "txtTelefonoEstudiante";
            txtTelefonoEstudiante.Size = new Size(275, 27);
            txtTelefonoEstudiante.TabIndex = 22;
            // 
            // lblTelefonoEstudiante
            // 
            lblTelefonoEstudiante.AutoSize = true;
            lblTelefonoEstudiante.Font = new Font("Agency FB", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point);
            lblTelefonoEstudiante.Location = new Point(332, 110);
            lblTelefonoEstudiante.Name = "lblTelefonoEstudiante";
            lblTelefonoEstudiante.Size = new Size(76, 28);
            lblTelefonoEstudiante.TabIndex = 21;
            lblTelefonoEstudiante.Text = "Teléfono";
            // 
            // chkCambiarClave
            // 
            chkCambiarClave.AutoSize = true;
            chkCambiarClave.Font = new Font("Agency FB", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            chkCambiarClave.Location = new Point(332, 215);
            chkCambiarClave.Name = "chkCambiarClave";
            chkCambiarClave.Size = new Size(213, 32);
            chkCambiarClave.TabIndex = 23;
            chkCambiarClave.Text = "Cambiar clave al iniciar";
            chkCambiarClave.UseVisualStyleBackColor = true;
            // 
            // btnAceptarEstudiante
            // 
            btnAceptarEstudiante.Anchor = AnchorStyles.None;
            btnAceptarEstudiante.Font = new Font("Agency FB", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnAceptarEstudiante.Location = new Point(137, 303);
            btnAceptarEstudiante.Name = "btnAceptarEstudiante";
            btnAceptarEstudiante.Size = new Size(342, 45);
            btnAceptarEstudiante.TabIndex = 24;
            btnAceptarEstudiante.Text = "ACEPTAR";
            btnAceptarEstudiante.UseMnemonic = false;
            btnAceptarEstudiante.UseVisualStyleBackColor = true;
            btnAceptarEstudiante.Click += btnAceptarEstudiante_Click;
            // 
            // btnCancelarEstudiante
            // 
            btnCancelarEstudiante.Anchor = AnchorStyles.None;
            btnCancelarEstudiante.BackColor = Color.Black;
            btnCancelarEstudiante.Font = new Font("Agency FB", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancelarEstudiante.ForeColor = Color.White;
            btnCancelarEstudiante.Location = new Point(137, 354);
            btnCancelarEstudiante.Name = "btnCancelarEstudiante";
            btnCancelarEstudiante.Size = new Size(342, 45);
            btnCancelarEstudiante.TabIndex = 25;
            btnCancelarEstudiante.Text = "CANCELAR";
            btnCancelarEstudiante.UseMnemonic = false;
            btnCancelarEstudiante.UseVisualStyleBackColor = false;
            btnCancelarEstudiante.Click += btnCancelarEstudiante_Click;
            // 
            // RegistroEstudianteForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(633, 447);
            ControlBox = false;
            Controls.Add(btnCancelarEstudiante);
            Controls.Add(btnAceptarEstudiante);
            Controls.Add(chkCambiarClave);
            Controls.Add(txtTelefonoEstudiante);
            Controls.Add(lblTelefonoEstudiante);
            Controls.Add(txtEmailEstudiante);
            Controls.Add(lblEmailEstudiante);
            Controls.Add(txtDniEstudiante);
            Controls.Add(lblDniEstudiante);
            Controls.Add(txtDireccionEstudiante);
            Controls.Add(lblDireccionEstudiante);
            Controls.Add(txtNombreCompletoEstudiante);
            Controls.Add(lblNombreCompletoEstudiante);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "RegistroEstudianteForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registro estudiante";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNombreCompletoEstudiante;
        private TextBox txtNombreCompletoEstudiante;
        private TextBox txtDireccionEstudiante;
        private Label lblDireccionEstudiante;
        private TextBox txtDniEstudiante;
        private Label lblDniEstudiante;
        private TextBox txtEmailEstudiante;
        private Label lblEmailEstudiante;
        private TextBox txtTelefonoEstudiante;
        private Label lblTelefonoEstudiante;
        private CheckBox chkCambiarClave;
        private Button btnAceptarEstudiante;
        private Button btnCancelarEstudiante;
    }
}