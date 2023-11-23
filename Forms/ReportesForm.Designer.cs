namespace Forms
{
    partial class ReportesForm
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
            lblReportes = new Label();
            btnCerrarReportes = new Button();
            btnInformeInscripciones = new Button();
            btnInformeEstuCurs = new Button();
            btnInformeIngrConcepto = new Button();
            btnInformeEstInsc = new Button();
            btnInformeListaEspera = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Black;
            panel1.Controls.Add(lblReportes);
            panel1.Location = new Point(-2, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(790, 137);
            panel1.TabIndex = 2;
            // 
            // lblReportes
            // 
            lblReportes.AutoSize = true;
            lblReportes.Font = new Font("Agency FB", 36F, FontStyle.Bold, GraphicsUnit.Point);
            lblReportes.ForeColor = SystemColors.ButtonHighlight;
            lblReportes.Location = new Point(272, 32);
            lblReportes.Name = "lblReportes";
            lblReportes.Size = new Size(248, 72);
            lblReportes.TabIndex = 1;
            lblReportes.Text = "REPORTES";
            // 
            // btnCerrarReportes
            // 
            btnCerrarReportes.Anchor = AnchorStyles.None;
            btnCerrarReportes.BackColor = Color.Black;
            btnCerrarReportes.Font = new Font("Agency FB", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnCerrarReportes.ForeColor = Color.White;
            btnCerrarReportes.Location = new Point(215, 504);
            btnCerrarReportes.Name = "btnCerrarReportes";
            btnCerrarReportes.Size = new Size(342, 53);
            btnCerrarReportes.TabIndex = 5;
            btnCerrarReportes.Text = "CERRAR";
            btnCerrarReportes.UseMnemonic = false;
            btnCerrarReportes.UseVisualStyleBackColor = false;
            btnCerrarReportes.Click += btnCerrarReportes_Click;
            // 
            // btnInformeInscripciones
            // 
            btnInformeInscripciones.Anchor = AnchorStyles.None;
            btnInformeInscripciones.Font = new Font("Agency FB", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnInformeInscripciones.Location = new Point(193, 169);
            btnInformeInscripciones.Name = "btnInformeInscripciones";
            btnInformeInscripciones.Size = new Size(387, 53);
            btnInformeInscripciones.TabIndex = 6;
            btnInformeInscripciones.Text = "INFORME INSCRIPCIONES";
            btnInformeInscripciones.UseMnemonic = false;
            btnInformeInscripciones.UseVisualStyleBackColor = true;
            btnInformeInscripciones.Click += btnInformeInscripciones_Click;
            // 
            // btnInformeEstuCurs
            // 
            btnInformeEstuCurs.Anchor = AnchorStyles.None;
            btnInformeEstuCurs.Font = new Font("Agency FB", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnInformeEstuCurs.Location = new Point(193, 228);
            btnInformeEstuCurs.Name = "btnInformeEstuCurs";
            btnInformeEstuCurs.Size = new Size(387, 53);
            btnInformeEstuCurs.TabIndex = 7;
            btnInformeEstuCurs.Text = "INFORME ESTUDIANTES CURSO";
            btnInformeEstuCurs.UseMnemonic = false;
            btnInformeEstuCurs.UseVisualStyleBackColor = true;
            btnInformeEstuCurs.Click += btnInformeEstuCurs_Click;
            // 
            // btnInformeIngrConcepto
            // 
            btnInformeIngrConcepto.Anchor = AnchorStyles.None;
            btnInformeIngrConcepto.Font = new Font("Agency FB", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnInformeIngrConcepto.Location = new Point(193, 287);
            btnInformeIngrConcepto.Name = "btnInformeIngrConcepto";
            btnInformeIngrConcepto.Size = new Size(387, 53);
            btnInformeIngrConcepto.TabIndex = 8;
            btnInformeIngrConcepto.Text = "INFORME INGRESOS POR CONCEPTO";
            btnInformeIngrConcepto.UseMnemonic = false;
            btnInformeIngrConcepto.UseVisualStyleBackColor = true;
            // 
            // btnInformeEstInsc
            // 
            btnInformeEstInsc.Anchor = AnchorStyles.None;
            btnInformeEstInsc.Font = new Font("Agency FB", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnInformeEstInsc.Location = new Point(193, 346);
            btnInformeEstInsc.Name = "btnInformeEstInsc";
            btnInformeEstInsc.Size = new Size(387, 53);
            btnInformeEstInsc.TabIndex = 9;
            btnInformeEstInsc.Text = "INFORME ESTADISTICAS INSCRIPCION";
            btnInformeEstInsc.UseMnemonic = false;
            btnInformeEstInsc.UseVisualStyleBackColor = true;
            // 
            // btnInformeListaEspera
            // 
            btnInformeListaEspera.Anchor = AnchorStyles.None;
            btnInformeListaEspera.Font = new Font("Agency FB", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnInformeListaEspera.Location = new Point(193, 405);
            btnInformeListaEspera.Name = "btnInformeListaEspera";
            btnInformeListaEspera.Size = new Size(387, 53);
            btnInformeListaEspera.TabIndex = 10;
            btnInformeListaEspera.Text = "INFORME LISTA ESPERA";
            btnInformeListaEspera.UseMnemonic = false;
            btnInformeListaEspera.UseVisualStyleBackColor = true;
            // 
            // ReportesForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(781, 569);
            ControlBox = false;
            Controls.Add(btnInformeListaEspera);
            Controls.Add(btnInformeEstInsc);
            Controls.Add(btnInformeIngrConcepto);
            Controls.Add(btnInformeEstuCurs);
            Controls.Add(btnInformeInscripciones);
            Controls.Add(btnCerrarReportes);
            Controls.Add(panel1);
            Name = "ReportesForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Reportes";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lblReportes;
        private Button btnCerrarReportes;
        private Button btnInformeInscripciones;
        private Button btnInformeEstuCurs;
        private Button btnInformeIngrConcepto;
        private Button btnInformeEstInsc;
        private Button btnInformeListaEspera;
    }
}