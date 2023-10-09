namespace Forms
{
    partial class CursosForm
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
            codigoCurso = new DataGridViewTextBoxColumn();
            descripcionCurso = new DataGridViewTextBoxColumn();
            cupoMaximoCurso = new DataGridViewTextBoxColumn();
            btnAgregarCurso = new Button();
            btnEditarCurso = new Button();
            btnEliminarCurso = new Button();
            btnCerrar = new Button();
            pnlCursos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvListaCursos).BeginInit();
            SuspendLayout();
            // 
            // pnlCursos
            // 
            pnlCursos.BackColor = Color.Black;
            pnlCursos.Controls.Add(lblCursos);
            pnlCursos.Location = new Point(-2, 0);
            pnlCursos.Name = "pnlCursos";
            pnlCursos.Size = new Size(790, 63);
            pnlCursos.TabIndex = 1;
            // 
            // lblCursos
            // 
            lblCursos.AutoSize = true;
            lblCursos.Font = new Font("Agency FB", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point);
            lblCursos.ForeColor = SystemColors.ButtonHighlight;
            lblCursos.Location = new Point(331, 9);
            lblCursos.Name = "lblCursos";
            lblCursos.Size = new Size(114, 41);
            lblCursos.TabIndex = 1;
            lblCursos.Text = "CURSOS";
            // 
            // dgvListaCursos
            // 
            dgvListaCursos.AllowUserToAddRows = false;
            dgvListaCursos.AllowUserToDeleteRows = false;
            dgvListaCursos.AllowUserToResizeColumns = false;
            dgvListaCursos.AllowUserToResizeRows = false;
            dgvListaCursos.BackgroundColor = SystemColors.ButtonHighlight;
            dgvListaCursos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvListaCursos.Columns.AddRange(new DataGridViewColumn[] { nombreCurso, codigoCurso, descripcionCurso, cupoMaximoCurso });
            dgvListaCursos.Location = new Point(12, 69);
            dgvListaCursos.MultiSelect = false;
            dgvListaCursos.Name = "dgvListaCursos";
            dgvListaCursos.ReadOnly = true;
            dgvListaCursos.RowHeadersVisible = false;
            dgvListaCursos.RowHeadersWidth = 51;
            dgvListaCursos.RowTemplate.Height = 29;
            dgvListaCursos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvListaCursos.Size = new Size(761, 361);
            dgvListaCursos.TabIndex = 7;
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
            // codigoCurso
            // 
            codigoCurso.Frozen = true;
            codigoCurso.HeaderText = "Codigo";
            codigoCurso.MinimumWidth = 6;
            codigoCurso.Name = "codigoCurso";
            codigoCurso.ReadOnly = true;
            codigoCurso.Resizable = DataGridViewTriState.False;
            codigoCurso.Width = 125;
            // 
            // descripcionCurso
            // 
            descripcionCurso.Frozen = true;
            descripcionCurso.HeaderText = "Descripcion";
            descripcionCurso.MinimumWidth = 6;
            descripcionCurso.Name = "descripcionCurso";
            descripcionCurso.ReadOnly = true;
            descripcionCurso.Width = 270;
            // 
            // cupoMaximoCurso
            // 
            cupoMaximoCurso.Frozen = true;
            cupoMaximoCurso.HeaderText = "Cupo Máximo";
            cupoMaximoCurso.MinimumWidth = 6;
            cupoMaximoCurso.Name = "cupoMaximoCurso";
            cupoMaximoCurso.ReadOnly = true;
            cupoMaximoCurso.Width = 165;
            // 
            // btnAgregarCurso
            // 
            btnAgregarCurso.Anchor = AnchorStyles.None;
            btnAgregarCurso.Font = new Font("Agency FB", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnAgregarCurso.Location = new Point(12, 455);
            btnAgregarCurso.Name = "btnAgregarCurso";
            btnAgregarCurso.Size = new Size(228, 45);
            btnAgregarCurso.TabIndex = 25;
            btnAgregarCurso.Text = "AGREGAR";
            btnAgregarCurso.UseMnemonic = false;
            btnAgregarCurso.UseVisualStyleBackColor = true;
            btnAgregarCurso.Click += btnAgregarCurso_Click;
            // 
            // btnEditarCurso
            // 
            btnEditarCurso.Anchor = AnchorStyles.None;
            btnEditarCurso.Font = new Font("Agency FB", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnEditarCurso.Location = new Point(280, 455);
            btnEditarCurso.Name = "btnEditarCurso";
            btnEditarCurso.Size = new Size(228, 45);
            btnEditarCurso.TabIndex = 26;
            btnEditarCurso.Text = "EDITAR";
            btnEditarCurso.UseMnemonic = false;
            btnEditarCurso.UseVisualStyleBackColor = true;
            btnEditarCurso.Click += btnEditarCurso_Click;
            // 
            // btnEliminarCurso
            // 
            btnEliminarCurso.Anchor = AnchorStyles.None;
            btnEliminarCurso.Font = new Font("Agency FB", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnEliminarCurso.Location = new Point(545, 455);
            btnEliminarCurso.Name = "btnEliminarCurso";
            btnEliminarCurso.Size = new Size(228, 45);
            btnEliminarCurso.TabIndex = 27;
            btnEliminarCurso.Text = "ELIMINAR";
            btnEliminarCurso.UseMnemonic = false;
            btnEliminarCurso.UseVisualStyleBackColor = true;
            btnEliminarCurso.Click += btnEliminarCurso_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.Anchor = AnchorStyles.None;
            btnCerrar.BackColor = Color.Black;
            btnCerrar.Font = new Font("Agency FB", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnCerrar.ForeColor = Color.White;
            btnCerrar.Location = new Point(234, 528);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(315, 45);
            btnCerrar.TabIndex = 28;
            btnCerrar.Text = "CERRAR";
            btnCerrar.UseMnemonic = false;
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // CursosForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(785, 595);
            ControlBox = false;
            Controls.Add(btnCerrar);
            Controls.Add(btnEliminarCurso);
            Controls.Add(btnEditarCurso);
            Controls.Add(btnAgregarCurso);
            Controls.Add(dgvListaCursos);
            Controls.Add(pnlCursos);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "CursosForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cursos";
            Load += CursosForm_Load;
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
        private DataGridViewTextBoxColumn codigoCurso;
        private DataGridViewTextBoxColumn descripcionCurso;
        private DataGridViewTextBoxColumn cupoMaximoCurso;
        private Button btnAgregarCurso;
        private Button btnEditarCurso;
        private Button btnEliminarCurso;
        private Button btnCerrar;
    }
}