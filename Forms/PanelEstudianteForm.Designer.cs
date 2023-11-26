namespace Forms
{
    partial class PanelEstudianteForm
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
            lblInscripcionesTitulo = new Label();
            btnInscripcionCursos = new Button();
            btnConsultarHorario = new Button();
            btnCerrarAdminInscr = new Button();
            btnRealizarPagos = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Black;
            panel1.Controls.Add(lblInscripcionesTitulo);
            panel1.Location = new Point(-2, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(790, 198);
            panel1.TabIndex = 2;
            // 
            // lblInscripcionesTitulo
            // 
            lblInscripcionesTitulo.AutoSize = true;
            lblInscripcionesTitulo.Font = new Font("Agency FB", 36F, FontStyle.Bold, GraphicsUnit.Point);
            lblInscripcionesTitulo.ForeColor = SystemColors.ButtonHighlight;
            lblInscripcionesTitulo.Location = new Point(34, 61);
            lblInscripcionesTitulo.Name = "lblInscripcionesTitulo";
            lblInscripcionesTitulo.Size = new Size(717, 72);
            lblInscripcionesTitulo.TabIndex = 1;
            lblInscripcionesTitulo.Text = "ADMINISTRACIÓN INSCRIPCIONES";
            // 
            // btnInscripcionCursos
            // 
            btnInscripcionCursos.Anchor = AnchorStyles.None;
            btnInscripcionCursos.Font = new Font("Agency FB", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnInscripcionCursos.Location = new Point(224, 232);
            btnInscripcionCursos.Name = "btnInscripcionCursos";
            btnInscripcionCursos.Size = new Size(342, 53);
            btnInscripcionCursos.TabIndex = 3;
            btnInscripcionCursos.Text = "INSCRIPCIÓN CURSOS";
            btnInscripcionCursos.UseMnemonic = false;
            btnInscripcionCursos.UseVisualStyleBackColor = true;
            btnInscripcionCursos.Click += btnInscripcionCursos_Click;
            // 
            // btnConsultarHorario
            // 
            btnConsultarHorario.Anchor = AnchorStyles.None;
            btnConsultarHorario.Font = new Font("Agency FB", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnConsultarHorario.Location = new Point(224, 301);
            btnConsultarHorario.Name = "btnConsultarHorario";
            btnConsultarHorario.Size = new Size(342, 53);
            btnConsultarHorario.TabIndex = 4;
            btnConsultarHorario.Text = "CONSULTAR HORARIO";
            btnConsultarHorario.UseMnemonic = false;
            btnConsultarHorario.UseVisualStyleBackColor = true;
            btnConsultarHorario.Click += btnConsultarHorario_Click;
            // 
            // btnCerrarAdminInscr
            // 
            btnCerrarAdminInscr.Anchor = AnchorStyles.None;
            btnCerrarAdminInscr.BackColor = Color.Black;
            btnCerrarAdminInscr.Font = new Font("Agency FB", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnCerrarAdminInscr.ForeColor = Color.White;
            btnCerrarAdminInscr.Location = new Point(224, 474);
            btnCerrarAdminInscr.Name = "btnCerrarAdminInscr";
            btnCerrarAdminInscr.Size = new Size(342, 53);
            btnCerrarAdminInscr.TabIndex = 5;
            btnCerrarAdminInscr.Text = "CERRAR";
            btnCerrarAdminInscr.UseMnemonic = false;
            btnCerrarAdminInscr.UseVisualStyleBackColor = false;
            btnCerrarAdminInscr.Click += btnCerrarAdminInscr_Click;
            // 
            // btnRealizarPagos
            // 
            btnRealizarPagos.Anchor = AnchorStyles.None;
            btnRealizarPagos.Font = new Font("Agency FB", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnRealizarPagos.Location = new Point(224, 376);
            btnRealizarPagos.Name = "btnRealizarPagos";
            btnRealizarPagos.Size = new Size(342, 53);
            btnRealizarPagos.TabIndex = 6;
            btnRealizarPagos.Text = "REALIZAR PAGOS";
            btnRealizarPagos.UseMnemonic = false;
            btnRealizarPagos.UseVisualStyleBackColor = true;
            btnRealizarPagos.Click += btnRealizarPagos_Click;
            // 
            // PanelEstudianteForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(786, 551);
            ControlBox = false;
            Controls.Add(btnRealizarPagos);
            Controls.Add(btnCerrarAdminInscr);
            Controls.Add(btnConsultarHorario);
            Controls.Add(btnInscripcionCursos);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "PanelEstudianteForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Administración inscripciones";
            Load += PanelEstudianteForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lblInscripcionesTitulo;
        private Button btnInscripcionCursos;
        private Button btnConsultarHorario;
        private Button btnCerrarAdminInscr;
        private Button btnRealizarPagos;
    }
}