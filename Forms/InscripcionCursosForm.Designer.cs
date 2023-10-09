namespace Forms
{
    partial class InscripcionCursosForm
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            pnlCursos = new Panel();
            lblCursosEstudiante = new Label();
            dgvListaCursosEstudiante = new DataGridView();
            Seleccionar = new DataGridViewCheckBoxColumn();
            nombreCurso = new DataGridViewTextBoxColumn();
            codigoCurso = new DataGridViewTextBoxColumn();
            descripcionCurso = new DataGridViewTextBoxColumn();
            cupoMaximoCurso = new DataGridViewTextBoxColumn();
            btnInscribirse = new Button();
            btnCancelarInscripcion = new Button();
            pnlCursos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvListaCursosEstudiante).BeginInit();
            SuspendLayout();
            // 
            // pnlCursos
            // 
            pnlCursos.BackColor = Color.Black;
            pnlCursos.Controls.Add(lblCursosEstudiante);
            pnlCursos.Location = new Point(-2, 0);
            pnlCursos.Name = "pnlCursos";
            pnlCursos.Size = new Size(790, 63);
            pnlCursos.TabIndex = 2;
            // 
            // lblCursosEstudiante
            // 
            lblCursosEstudiante.AutoSize = true;
            lblCursosEstudiante.Font = new Font("Agency FB", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point);
            lblCursosEstudiante.ForeColor = SystemColors.ButtonHighlight;
            lblCursosEstudiante.Location = new Point(331, 9);
            lblCursosEstudiante.Name = "lblCursosEstudiante";
            lblCursosEstudiante.Size = new Size(114, 41);
            lblCursosEstudiante.TabIndex = 1;
            lblCursosEstudiante.Text = "CURSOS";
            // 
            // dgvListaCursosEstudiante
            // 
            dgvListaCursosEstudiante.AllowUserToAddRows = false;
            dgvListaCursosEstudiante.AllowUserToDeleteRows = false;
            dgvListaCursosEstudiante.AllowUserToResizeColumns = false;
            dgvListaCursosEstudiante.AllowUserToResizeRows = false;
            dgvListaCursosEstudiante.BackgroundColor = SystemColors.ButtonHighlight;
            dgvListaCursosEstudiante.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvListaCursosEstudiante.Columns.AddRange(new DataGridViewColumn[] { Seleccionar, nombreCurso, codigoCurso, descripcionCurso, cupoMaximoCurso });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvListaCursosEstudiante.DefaultCellStyle = dataGridViewCellStyle3;
            dgvListaCursosEstudiante.Location = new Point(13, 69);
            dgvListaCursosEstudiante.MultiSelect = false;
            dgvListaCursosEstudiante.Name = "dgvListaCursosEstudiante";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = Color.Transparent;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvListaCursosEstudiante.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvListaCursosEstudiante.RowHeadersVisible = false;
            dgvListaCursosEstudiante.RowHeadersWidth = 51;
            dgvListaCursosEstudiante.RowTemplate.Height = 29;
            dgvListaCursosEstudiante.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvListaCursosEstudiante.Size = new Size(761, 361);
            dgvListaCursosEstudiante.TabIndex = 8;
            dgvListaCursosEstudiante.TabStop = false;
            dgvListaCursosEstudiante.CellContentClick += dgvListaCursosEstudiante_CellContentClick;
            dgvListaCursosEstudiante.CellEndEdit += dgvListaCursosEstudiante_CellEndEdit;
            dgvListaCursosEstudiante.CurrentCellDirtyStateChanged += dgvListaCursosEstudiante_CurrentCellDirtyStateChanged;
            // 
            // Seleccionar
            // 
            Seleccionar.Frozen = true;
            Seleccionar.HeaderText = "";
            Seleccionar.MinimumWidth = 6;
            Seleccionar.Name = "Seleccionar";
            Seleccionar.Resizable = DataGridViewTriState.False;
            Seleccionar.Width = 50;
            // 
            // nombreCurso
            // 
            nombreCurso.Frozen = true;
            nombreCurso.HeaderText = "Nombre";
            nombreCurso.MinimumWidth = 6;
            nombreCurso.Name = "nombreCurso";
            nombreCurso.ReadOnly = true;
            nombreCurso.Width = 200;
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
            descripcionCurso.Width = 250;
            // 
            // cupoMaximoCurso
            // 
            cupoMaximoCurso.Frozen = true;
            cupoMaximoCurso.HeaderText = "Cupo";
            cupoMaximoCurso.MinimumWidth = 6;
            cupoMaximoCurso.Name = "cupoMaximoCurso";
            cupoMaximoCurso.ReadOnly = true;
            cupoMaximoCurso.Width = 145;
            // 
            // btnInscribirse
            // 
            btnInscribirse.Anchor = AnchorStyles.None;
            btnInscribirse.Font = new Font("Agency FB", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnInscribirse.Location = new Point(211, 461);
            btnInscribirse.Name = "btnInscribirse";
            btnInscribirse.Size = new Size(342, 45);
            btnInscribirse.TabIndex = 40;
            btnInscribirse.Text = "INSCRIBIRSE";
            btnInscribirse.UseMnemonic = false;
            btnInscribirse.UseVisualStyleBackColor = true;
            btnInscribirse.Click += btnInscribirse_Click;
            // 
            // btnCancelarInscripcion
            // 
            btnCancelarInscripcion.Anchor = AnchorStyles.None;
            btnCancelarInscripcion.BackColor = Color.Black;
            btnCancelarInscripcion.Font = new Font("Agency FB", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancelarInscripcion.ForeColor = Color.White;
            btnCancelarInscripcion.Location = new Point(211, 512);
            btnCancelarInscripcion.Name = "btnCancelarInscripcion";
            btnCancelarInscripcion.Size = new Size(342, 45);
            btnCancelarInscripcion.TabIndex = 41;
            btnCancelarInscripcion.Text = "CERRAR";
            btnCancelarInscripcion.UseMnemonic = false;
            btnCancelarInscripcion.UseVisualStyleBackColor = false;
            btnCancelarInscripcion.Click += btnCancelarInscripcion_Click;
            // 
            // InscripcionCursosForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(770, 588);
            ControlBox = false;
            Controls.Add(btnCancelarInscripcion);
            Controls.Add(btnInscribirse);
            Controls.Add(dgvListaCursosEstudiante);
            Controls.Add(pnlCursos);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "InscripcionCursosForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Inscripción cursos";
            Load += InscripcionCursosForm_Load;
            pnlCursos.ResumeLayout(false);
            pnlCursos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvListaCursosEstudiante).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlCursos;
        private Label lblCursosEstudiante;
        private DataGridView dgvListaCursosEstudiante;
        private DataGridViewCheckBoxColumn Seleccionar;
        private DataGridViewTextBoxColumn nombreCurso;
        private DataGridViewTextBoxColumn codigoCurso;
        private DataGridViewTextBoxColumn descripcionCurso;
        private DataGridViewTextBoxColumn cupoMaximoCurso;
        private Button btnInscribirse;
        private Button btnCancelarInscripcion;
    }
}