namespace Forms
{
    partial class PanelAdministradorForm
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
            panel1 = new Panel();
            label1 = new Label();
            btnRegistrarEstudiante = new Button();
            btnGestionarCursos = new Button();
            btnCerrarAdminEst = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Black;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(-2, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(790, 198);
            panel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Agency FB", 36F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(63, 61);
            label1.Name = "label1";
            label1.Size = new Size(671, 72);
            label1.TabIndex = 1;
            label1.Text = "ADMINISTRACIÓN ESTUDIANTES";
            // 
            // btnRegistrarEstudiante
            // 
            btnRegistrarEstudiante.Anchor = AnchorStyles.None;
            btnRegistrarEstudiante.Font = new Font("Agency FB", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnRegistrarEstudiante.Location = new Point(225, 236);
            btnRegistrarEstudiante.Name = "btnRegistrarEstudiante";
            btnRegistrarEstudiante.Size = new Size(342, 53);
            btnRegistrarEstudiante.TabIndex = 2;
            btnRegistrarEstudiante.Text = "REGISTRAR ESTUDIANTE";
            btnRegistrarEstudiante.UseMnemonic = false;
            btnRegistrarEstudiante.UseVisualStyleBackColor = true;
            btnRegistrarEstudiante.Click += btnRegistrarEstudiante_Click;
            // 
            // btnGestionarCursos
            // 
            btnGestionarCursos.Anchor = AnchorStyles.None;
            btnGestionarCursos.Font = new Font("Agency FB", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnGestionarCursos.Location = new Point(225, 305);
            btnGestionarCursos.Name = "btnGestionarCursos";
            btnGestionarCursos.Size = new Size(342, 53);
            btnGestionarCursos.TabIndex = 3;
            btnGestionarCursos.Text = "GESTIONAR CURSOS";
            btnGestionarCursos.UseMnemonic = false;
            btnGestionarCursos.UseVisualStyleBackColor = true;
            btnGestionarCursos.Click += btnGestionarCursos_Click;
            // 
            // btnCerrarAdminEst
            // 
            btnCerrarAdminEst.Anchor = AnchorStyles.None;
            btnCerrarAdminEst.BackColor = Color.Black;
            btnCerrarAdminEst.Font = new Font("Agency FB", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnCerrarAdminEst.ForeColor = Color.White;
            btnCerrarAdminEst.Location = new Point(225, 401);
            btnCerrarAdminEst.Name = "btnCerrarAdminEst";
            btnCerrarAdminEst.Size = new Size(342, 53);
            btnCerrarAdminEst.TabIndex = 4;
            btnCerrarAdminEst.Text = "CERRAR";
            btnCerrarAdminEst.UseMnemonic = false;
            btnCerrarAdminEst.UseVisualStyleBackColor = false;
            btnCerrarAdminEst.Click += btnCerrarAdminEst_Click;
            // 
            // AdministracionEstudiantesForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(787, 489);
            ControlBox = false;
            Controls.Add(btnCerrarAdminEst);
            Controls.Add(btnGestionarCursos);
            Controls.Add(btnRegistrarEstudiante);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "AdministracionEstudiantesForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Administración de estudiantes";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Button btnRegistrarEstudiante;
        private Button btnGestionarCursos;
        private Button btnCerrarAdminEst;
    }
}