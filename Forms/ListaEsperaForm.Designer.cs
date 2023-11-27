namespace Forms
{
    partial class ListaEsperaForm
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
            pnlCursos = new Panel();
            lblCursos = new Label();
            dgvListaEspera = new DataGridView();
            nombreCurso = new DataGridViewTextBoxColumn();
            btnCerrar = new Button();
            btnGestionarLista = new Button();
            pnlCursos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvListaEspera).BeginInit();
            SuspendLayout();
            // 
            // pnlCursos
            // 
            pnlCursos.BackColor = Color.Black;
            pnlCursos.Controls.Add(lblCursos);
            pnlCursos.Location = new Point(-2, 1);
            pnlCursos.Name = "pnlCursos";
            pnlCursos.Size = new Size(388, 63);
            pnlCursos.TabIndex = 2;
            // 
            // lblCursos
            // 
            lblCursos.AutoSize = true;
            lblCursos.Font = new Font("Agency FB", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point);
            lblCursos.ForeColor = SystemColors.ButtonHighlight;
            lblCursos.Location = new Point(103, 8);
            lblCursos.Name = "lblCursos";
            lblCursos.Size = new Size(174, 41);
            lblCursos.TabIndex = 1;
            lblCursos.Text = "LISTA ESPERA";
            // 
            // dgvListaEspera
            // 
            dgvListaEspera.AllowUserToAddRows = false;
            dgvListaEspera.AllowUserToDeleteRows = false;
            dgvListaEspera.AllowUserToResizeColumns = false;
            dgvListaEspera.AllowUserToResizeRows = false;
            dgvListaEspera.BackgroundColor = SystemColors.ButtonHighlight;
            dgvListaEspera.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvListaEspera.Columns.AddRange(new DataGridViewColumn[] { nombreCurso });
            dgvListaEspera.Location = new Point(12, 70);
            dgvListaEspera.MultiSelect = false;
            dgvListaEspera.Name = "dgvListaEspera";
            dgvListaEspera.ReadOnly = true;
            dgvListaEspera.RowHeadersVisible = false;
            dgvListaEspera.RowHeadersWidth = 51;
            dgvListaEspera.RowTemplate.Height = 29;
            dgvListaEspera.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvListaEspera.Size = new Size(356, 361);
            dgvListaEspera.TabIndex = 8;
            // 
            // nombreCurso
            // 
            nombreCurso.Frozen = true;
            nombreCurso.HeaderText = "Curso";
            nombreCurso.MinimumWidth = 6;
            nombreCurso.Name = "nombreCurso";
            nombreCurso.ReadOnly = true;
            nombreCurso.Width = 350;
            // 
            // btnCerrar
            // 
            btnCerrar.Anchor = AnchorStyles.None;
            btnCerrar.BackColor = Color.Black;
            btnCerrar.Font = new Font("Agency FB", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnCerrar.ForeColor = Color.White;
            btnCerrar.Location = new Point(29, 505);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(315, 45);
            btnCerrar.TabIndex = 29;
            btnCerrar.Text = "CERRAR";
            btnCerrar.UseMnemonic = false;
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // btnGestionarLista
            // 
            btnGestionarLista.Anchor = AnchorStyles.None;
            btnGestionarLista.Font = new Font("Agency FB", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnGestionarLista.Location = new Point(29, 454);
            btnGestionarLista.Name = "btnGestionarLista";
            btnGestionarLista.Size = new Size(315, 45);
            btnGestionarLista.TabIndex = 30;
            btnGestionarLista.Text = "GESTIONAR";
            btnGestionarLista.UseMnemonic = false;
            btnGestionarLista.UseVisualStyleBackColor = true;
            btnGestionarLista.Click += btnGestionarLista_Click;
            // 
            // ListaEsperaForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(380, 573);
            ControlBox = false;
            Controls.Add(btnGestionarLista);
            Controls.Add(btnCerrar);
            Controls.Add(dgvListaEspera);
            Controls.Add(pnlCursos);
            Name = "ListaEsperaForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lista espera";
            Load += ListaEsperaForm_Load;
            pnlCursos.ResumeLayout(false);
            pnlCursos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvListaEspera).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlCursos;
        private Label lblCursos;
        private DataGridView dgvListaEspera;
        private Button btnCerrar;
        private Button btnGestionarLista;
        private DataGridViewTextBoxColumn nombreCurso;
    }
}