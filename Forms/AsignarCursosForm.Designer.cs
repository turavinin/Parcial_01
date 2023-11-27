namespace Forms
{
    partial class AsignarCursosForm
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
            dgvListaCursos = new DataGridView();
            establecer = new DataGridViewCheckBoxColumn();
            Curso = new DataGridViewTextBoxColumn();
            label1 = new Label();
            btnAceptarCurso = new Button();
            btnCancelarCurso = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvListaCursos).BeginInit();
            SuspendLayout();
            // 
            // dgvListaCursos
            // 
            dgvListaCursos.AllowUserToAddRows = false;
            dgvListaCursos.AllowUserToDeleteRows = false;
            dgvListaCursos.AllowUserToResizeColumns = false;
            dgvListaCursos.AllowUserToResizeRows = false;
            dgvListaCursos.BackgroundColor = SystemColors.ButtonHighlight;
            dgvListaCursos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvListaCursos.Columns.AddRange(new DataGridViewColumn[] { establecer, Curso });
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgvListaCursos.DefaultCellStyle = dataGridViewCellStyle1;
            dgvListaCursos.Location = new Point(12, 54);
            dgvListaCursos.MultiSelect = false;
            dgvListaCursos.Name = "dgvListaCursos";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = Color.Transparent;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvListaCursos.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvListaCursos.RowHeadersVisible = false;
            dgvListaCursos.RowHeadersWidth = 51;
            dgvListaCursos.RowTemplate.Height = 29;
            dgvListaCursos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvListaCursos.Size = new Size(407, 206);
            dgvListaCursos.TabIndex = 29;
            dgvListaCursos.TabStop = false;
            // 
            // establecer
            // 
            establecer.Frozen = true;
            establecer.HeaderText = "Establecer";
            establecer.MinimumWidth = 6;
            establecer.Name = "establecer";
            establecer.Resizable = DataGridViewTriState.False;
            establecer.Width = 125;
            // 
            // Curso
            // 
            Curso.Frozen = true;
            Curso.HeaderText = "Curso";
            Curso.MinimumWidth = 6;
            Curso.Name = "Curso";
            Curso.ReadOnly = true;
            Curso.Width = 300;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Agency FB", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(12, 23);
            label1.Name = "label1";
            label1.Size = new Size(128, 28);
            label1.TabIndex = 30;
            label1.Text = "Asignar cursos";
            // 
            // btnAceptarCurso
            // 
            btnAceptarCurso.Anchor = AnchorStyles.None;
            btnAceptarCurso.Font = new Font("Agency FB", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnAceptarCurso.Location = new Point(42, 276);
            btnAceptarCurso.Name = "btnAceptarCurso";
            btnAceptarCurso.Size = new Size(342, 45);
            btnAceptarCurso.TabIndex = 44;
            btnAceptarCurso.Text = "ACEPTAR";
            btnAceptarCurso.UseMnemonic = false;
            btnAceptarCurso.UseVisualStyleBackColor = true;
            btnAceptarCurso.Click += btnAceptarCurso_Click;
            // 
            // btnCancelarCurso
            // 
            btnCancelarCurso.Anchor = AnchorStyles.None;
            btnCancelarCurso.BackColor = Color.Black;
            btnCancelarCurso.Font = new Font("Agency FB", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancelarCurso.ForeColor = Color.White;
            btnCancelarCurso.Location = new Point(42, 327);
            btnCancelarCurso.Name = "btnCancelarCurso";
            btnCancelarCurso.Size = new Size(342, 45);
            btnCancelarCurso.TabIndex = 43;
            btnCancelarCurso.Text = "CANCELAR";
            btnCancelarCurso.UseMnemonic = false;
            btnCancelarCurso.UseVisualStyleBackColor = false;
            btnCancelarCurso.Click += btnCancelarCurso_Click;
            // 
            // AsignarCursosForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(433, 385);
            Controls.Add(btnAceptarCurso);
            Controls.Add(btnCancelarCurso);
            Controls.Add(label1);
            Controls.Add(dgvListaCursos);
            Name = "AsignarCursosForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Asignar cursos";
            Load += AsignarCursosForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvListaCursos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvListaCursos;
        private DataGridViewCheckBoxColumn establecer;
        private DataGridViewTextBoxColumn Curso;
        private Label label1;
        private Button btnAceptarCurso;
        private Button btnCancelarCurso;
    }
}