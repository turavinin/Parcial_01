namespace Forms
{
    partial class HorarioCursosForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            pnlCursos = new Panel();
            lblHorarios = new Label();
            dgvListaCursosEstudiante = new DataGridView();
            nombreCurso = new DataGridViewTextBoxColumn();
            codigoCurso = new DataGridViewTextBoxColumn();
            Turno = new DataGridViewTextBoxColumn();
            Horario = new DataGridViewTextBoxColumn();
            Aula = new DataGridViewTextBoxColumn();
            btnCerrarHorarios = new Button();
            pnlCursos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvListaCursosEstudiante).BeginInit();
            SuspendLayout();
            // 
            // pnlCursos
            // 
            pnlCursos.BackColor = Color.Black;
            pnlCursos.Controls.Add(lblHorarios);
            pnlCursos.Location = new Point(-2, 1);
            pnlCursos.Name = "pnlCursos";
            pnlCursos.Size = new Size(790, 63);
            pnlCursos.TabIndex = 3;
            // 
            // lblHorarios
            // 
            lblHorarios.AutoSize = true;
            lblHorarios.Font = new Font("Agency FB", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point);
            lblHorarios.ForeColor = SystemColors.ButtonHighlight;
            lblHorarios.Location = new Point(331, 9);
            lblHorarios.Name = "lblHorarios";
            lblHorarios.Size = new Size(135, 41);
            lblHorarios.TabIndex = 1;
            lblHorarios.Text = "HORARIOS";
            // 
            // dgvListaCursosEstudiante
            // 
            dgvListaCursosEstudiante.AllowUserToAddRows = false;
            dgvListaCursosEstudiante.AllowUserToDeleteRows = false;
            dgvListaCursosEstudiante.AllowUserToResizeColumns = false;
            dgvListaCursosEstudiante.AllowUserToResizeRows = false;
            dgvListaCursosEstudiante.BackgroundColor = SystemColors.ButtonHighlight;
            dgvListaCursosEstudiante.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvListaCursosEstudiante.Columns.AddRange(new DataGridViewColumn[] { nombreCurso, codigoCurso, Turno, Horario, Aula });
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgvListaCursosEstudiante.DefaultCellStyle = dataGridViewCellStyle1;
            dgvListaCursosEstudiante.Location = new Point(12, 70);
            dgvListaCursosEstudiante.MultiSelect = false;
            dgvListaCursosEstudiante.Name = "dgvListaCursosEstudiante";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = Color.Transparent;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvListaCursosEstudiante.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvListaCursosEstudiante.RowHeadersVisible = false;
            dgvListaCursosEstudiante.RowHeadersWidth = 51;
            dgvListaCursosEstudiante.RowTemplate.Height = 29;
            dgvListaCursosEstudiante.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvListaCursosEstudiante.Size = new Size(761, 361);
            dgvListaCursosEstudiante.TabIndex = 9;
            dgvListaCursosEstudiante.TabStop = false;
            // 
            // nombreCurso
            // 
            nombreCurso.Frozen = true;
            nombreCurso.HeaderText = "Curso";
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
            // Turno
            // 
            Turno.Frozen = true;
            Turno.HeaderText = "Turno";
            Turno.MinimumWidth = 6;
            Turno.Name = "Turno";
            Turno.ReadOnly = true;
            Turno.Width = 200;
            // 
            // Horario
            // 
            Horario.Frozen = true;
            Horario.HeaderText = "Dia";
            Horario.MinimumWidth = 6;
            Horario.Name = "Horario";
            Horario.ReadOnly = true;
            Horario.Width = 145;
            // 
            // Aula
            // 
            Aula.Frozen = true;
            Aula.HeaderText = "Aula";
            Aula.MinimumWidth = 6;
            Aula.Name = "Aula";
            Aula.ReadOnly = true;
            Aula.Width = 125;
            // 
            // btnCerrarHorarios
            // 
            btnCerrarHorarios.Anchor = AnchorStyles.None;
            btnCerrarHorarios.BackColor = Color.Black;
            btnCerrarHorarios.Font = new Font("Agency FB", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnCerrarHorarios.ForeColor = Color.White;
            btnCerrarHorarios.Location = new Point(233, 473);
            btnCerrarHorarios.Name = "btnCerrarHorarios";
            btnCerrarHorarios.Size = new Size(342, 45);
            btnCerrarHorarios.TabIndex = 42;
            btnCerrarHorarios.Text = "CERRAR";
            btnCerrarHorarios.UseMnemonic = false;
            btnCerrarHorarios.UseVisualStyleBackColor = false;
            btnCerrarHorarios.Click += btnCerrarHorarios_Click;
            // 
            // HorarioCursosForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(786, 562);
            ControlBox = false;
            Controls.Add(btnCerrarHorarios);
            Controls.Add(dgvListaCursosEstudiante);
            Controls.Add(pnlCursos);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "HorarioCursosForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Horarios";
            Load += HorarioCursosForm_Load;
            pnlCursos.ResumeLayout(false);
            pnlCursos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvListaCursosEstudiante).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlCursos;
        private Label lblHorarios;
        private DataGridView dgvListaCursosEstudiante;
        private Button btnCerrarHorarios;
        private DataGridViewTextBoxColumn nombreCurso;
        private DataGridViewTextBoxColumn codigoCurso;
        private DataGridViewTextBoxColumn Turno;
        private DataGridViewTextBoxColumn Horario;
        private DataGridViewTextBoxColumn Aula;
    }
}