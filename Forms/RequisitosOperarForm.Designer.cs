namespace Forms
{
    partial class RequisitosOperarForm
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
            lblNombreCurso = new Label();
            dgvListaCursos = new DataGridView();
            establecer = new DataGridViewCheckBoxColumn();
            Curso = new DataGridViewTextBoxColumn();
            label1 = new Label();
            label2 = new Label();
            txtPromedio = new TextBox();
            label3 = new Label();
            txtCredito = new TextBox();
            btnCancelarCurso = new Button();
            btnAceptarCurso = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvListaCursos).BeginInit();
            SuspendLayout();
            // 
            // lblNombreCurso
            // 
            lblNombreCurso.AutoSize = true;
            lblNombreCurso.Font = new Font("Agency FB", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point);
            lblNombreCurso.Location = new Point(12, 9);
            lblNombreCurso.Name = "lblNombreCurso";
            lblNombreCurso.Size = new Size(71, 28);
            lblNombreCurso.TabIndex = 27;
            lblNombreCurso.Text = "Nombre";
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
            dgvListaCursos.Location = new Point(12, 93);
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
            dgvListaCursos.TabIndex = 28;
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
            label1.Location = new Point(12, 62);
            label1.Name = "label1";
            label1.Size = new Size(201, 28);
            label1.TabIndex = 29;
            label1.Text = "Correlativas obligatorias";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Agency FB", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(26, 318);
            label2.Name = "label2";
            label2.Size = new Size(143, 28);
            label2.TabIndex = 30;
            label2.Text = "Promedio minimo";
            // 
            // txtPromedio
            // 
            txtPromedio.Location = new Point(26, 349);
            txtPromedio.Name = "txtPromedio";
            txtPromedio.Size = new Size(143, 27);
            txtPromedio.TabIndex = 31;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Agency FB", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(258, 318);
            label3.Name = "label3";
            label3.Size = new Size(126, 28);
            label3.TabIndex = 32;
            label3.Text = "Credito minimo";
            // 
            // txtCredito
            // 
            txtCredito.Location = new Point(258, 349);
            txtCredito.Name = "txtCredito";
            txtCredito.Size = new Size(143, 27);
            txtCredito.TabIndex = 33;
            // 
            // btnCancelarCurso
            // 
            btnCancelarCurso.Anchor = AnchorStyles.None;
            btnCancelarCurso.BackColor = Color.Black;
            btnCancelarCurso.Font = new Font("Agency FB", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancelarCurso.ForeColor = Color.White;
            btnCancelarCurso.Location = new Point(42, 486);
            btnCancelarCurso.Name = "btnCancelarCurso";
            btnCancelarCurso.Size = new Size(342, 45);
            btnCancelarCurso.TabIndex = 41;
            btnCancelarCurso.Text = "CANCELAR";
            btnCancelarCurso.UseMnemonic = false;
            btnCancelarCurso.UseVisualStyleBackColor = false;
            btnCancelarCurso.Click += btnCancelarCurso_Click;
            // 
            // btnAceptarCurso
            // 
            btnAceptarCurso.Anchor = AnchorStyles.None;
            btnAceptarCurso.Font = new Font("Agency FB", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnAceptarCurso.Location = new Point(42, 435);
            btnAceptarCurso.Name = "btnAceptarCurso";
            btnAceptarCurso.Size = new Size(342, 45);
            btnAceptarCurso.TabIndex = 42;
            btnAceptarCurso.Text = "ACEPTAR";
            btnAceptarCurso.UseMnemonic = false;
            btnAceptarCurso.UseVisualStyleBackColor = true;
            btnAceptarCurso.Click += btnAceptarCurso_Click;
            // 
            // RequisitosOperarForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(435, 543);
            Controls.Add(btnAceptarCurso);
            Controls.Add(btnCancelarCurso);
            Controls.Add(txtCredito);
            Controls.Add(label3);
            Controls.Add(txtPromedio);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvListaCursos);
            Controls.Add(lblNombreCurso);
            Name = "RequisitosOperarForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Editar Requisitos";
            Load += RequisitosOperarForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvListaCursos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNombreCurso;
        private DataGridView dgvListaCursos;
        private Label label1;
        private DataGridViewCheckBoxColumn establecer;
        private DataGridViewTextBoxColumn Curso;
        private Label label2;
        private TextBox txtPromedio;
        private Label label3;
        private TextBox txtCredito;
        private Button btnCancelarCurso;
        private Button btnAceptarCurso;
    }
}