namespace Forms
{
    partial class RequisitosForm
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
            dgvListaCursos = new DataGridView();
            nombreCurso = new DataGridViewTextBoxColumn();
            promedio = new DataGridViewTextBoxColumn();
            correlativas = new DataGridViewTextBoxColumn();
            credito = new DataGridViewTextBoxColumn();
            btnCerrar = new Button();
            btnEditarCurso = new Button();
            pnlCursos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvListaCursos).BeginInit();
            SuspendLayout();
            // 
            // pnlCursos
            // 
            pnlCursos.BackColor = Color.Black;
            pnlCursos.Controls.Add(lblCursos);
            pnlCursos.Location = new Point(-2, 1);
            pnlCursos.Name = "pnlCursos";
            pnlCursos.Size = new Size(904, 63);
            pnlCursos.TabIndex = 2;
            // 
            // lblCursos
            // 
            lblCursos.AutoSize = true;
            lblCursos.Font = new Font("Agency FB", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point);
            lblCursos.ForeColor = SystemColors.ButtonHighlight;
            lblCursos.Location = new Point(303, 8);
            lblCursos.Name = "lblCursos";
            lblCursos.Size = new Size(310, 41);
            lblCursos.TabIndex = 1;
            lblCursos.Text = "REQUISITOS ACADEMICOS";
            // 
            // dgvListaCursos
            // 
            dgvListaCursos.AllowUserToAddRows = false;
            dgvListaCursos.AllowUserToDeleteRows = false;
            dgvListaCursos.AllowUserToResizeColumns = false;
            dgvListaCursos.AllowUserToResizeRows = false;
            dgvListaCursos.BackgroundColor = SystemColors.ButtonHighlight;
            dgvListaCursos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvListaCursos.Columns.AddRange(new DataGridViewColumn[] { nombreCurso, promedio, correlativas, credito });
            dgvListaCursos.Location = new Point(12, 70);
            dgvListaCursos.MultiSelect = false;
            dgvListaCursos.Name = "dgvListaCursos";
            dgvListaCursos.ReadOnly = true;
            dgvListaCursos.RowHeadersVisible = false;
            dgvListaCursos.RowHeadersWidth = 51;
            dgvListaCursos.RowTemplate.Height = 29;
            dgvListaCursos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvListaCursos.Size = new Size(876, 361);
            dgvListaCursos.TabIndex = 8;
            // 
            // nombreCurso
            // 
            nombreCurso.Frozen = true;
            nombreCurso.HeaderText = "Nombre";
            nombreCurso.MinimumWidth = 6;
            nombreCurso.Name = "nombreCurso";
            nombreCurso.ReadOnly = true;
            nombreCurso.Width = 250;
            // 
            // promedio
            // 
            promedio.Frozen = true;
            promedio.HeaderText = "Promedio Minimo";
            promedio.MinimumWidth = 6;
            promedio.Name = "promedio";
            promedio.ReadOnly = true;
            promedio.Resizable = DataGridViewTriState.False;
            promedio.Width = 125;
            // 
            // correlativas
            // 
            correlativas.Frozen = true;
            correlativas.HeaderText = "Correlativas";
            correlativas.MinimumWidth = 6;
            correlativas.Name = "correlativas";
            correlativas.ReadOnly = true;
            correlativas.Width = 350;
            // 
            // credito
            // 
            credito.Frozen = true;
            credito.HeaderText = "Credito Minimo";
            credito.MinimumWidth = 6;
            credito.Name = "credito";
            credito.ReadOnly = true;
            credito.Width = 165;
            // 
            // btnCerrar
            // 
            btnCerrar.Anchor = AnchorStyles.None;
            btnCerrar.BackColor = Color.Black;
            btnCerrar.Font = new Font("Agency FB", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnCerrar.ForeColor = Color.White;
            btnCerrar.Location = new Point(282, 512);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(315, 45);
            btnCerrar.TabIndex = 32;
            btnCerrar.Text = "CERRAR";
            btnCerrar.UseMnemonic = false;
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // btnEditarCurso
            // 
            btnEditarCurso.Anchor = AnchorStyles.None;
            btnEditarCurso.Font = new Font("Agency FB", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnEditarCurso.Location = new Point(282, 461);
            btnEditarCurso.Name = "btnEditarCurso";
            btnEditarCurso.Size = new Size(315, 45);
            btnEditarCurso.TabIndex = 30;
            btnEditarCurso.Text = "EDITAR";
            btnEditarCurso.UseMnemonic = false;
            btnEditarCurso.UseVisualStyleBackColor = true;
            btnEditarCurso.Click += btnEditarCurso_Click;
            // 
            // RequisitosForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(898, 574);
            ControlBox = false;
            Controls.Add(btnCerrar);
            Controls.Add(btnEditarCurso);
            Controls.Add(dgvListaCursos);
            Controls.Add(pnlCursos);
            Name = "RequisitosForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Requisitos";
            Load += RequisitosForm_Load;
            pnlCursos.ResumeLayout(false);
            pnlCursos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvListaCursos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlCursos;
        private Label lblCursos;
        private DataGridView dgvListaCursos;
        private DataGridViewTextBoxColumn nombreCurso;
        private DataGridViewTextBoxColumn promedio;
        private DataGridViewTextBoxColumn correlativas;
        private DataGridViewTextBoxColumn credito;
        private Button btnCerrar;
        private Button btnEditarCurso;
    }
}