namespace Forms
{
    partial class GestionarListaEsperaForm
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
            lblGestionarListaEspera = new Label();
            dgvListaEspera = new DataGridView();
            establecer = new DataGridViewCheckBoxColumn();
            estudiante = new DataGridViewTextBoxColumn();
            btnCancelarCurso = new Button();
            btnAceptarCurso = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvListaEspera).BeginInit();
            SuspendLayout();
            // 
            // lblGestionarListaEspera
            // 
            lblGestionarListaEspera.AutoSize = true;
            lblGestionarListaEspera.Font = new Font("Agency FB", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point);
            lblGestionarListaEspera.Location = new Point(12, 9);
            lblGestionarListaEspera.Name = "lblGestionarListaEspera";
            lblGestionarListaEspera.Size = new Size(311, 28);
            lblGestionarListaEspera.TabIndex = 31;
            lblGestionarListaEspera.Text = "Gestionar alumnos para lista de espera";
            // 
            // dgvListaEspera
            // 
            dgvListaEspera.AllowUserToAddRows = false;
            dgvListaEspera.AllowUserToDeleteRows = false;
            dgvListaEspera.AllowUserToResizeColumns = false;
            dgvListaEspera.AllowUserToResizeRows = false;
            dgvListaEspera.BackgroundColor = SystemColors.ButtonHighlight;
            dgvListaEspera.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvListaEspera.Columns.AddRange(new DataGridViewColumn[] { establecer, estudiante });
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgvListaEspera.DefaultCellStyle = dataGridViewCellStyle1;
            dgvListaEspera.Location = new Point(12, 49);
            dgvListaEspera.MultiSelect = false;
            dgvListaEspera.Name = "dgvListaEspera";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = Color.Transparent;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvListaEspera.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvListaEspera.RowHeadersVisible = false;
            dgvListaEspera.RowHeadersWidth = 51;
            dgvListaEspera.RowTemplate.Height = 29;
            dgvListaEspera.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvListaEspera.Size = new Size(380, 206);
            dgvListaEspera.TabIndex = 32;
            dgvListaEspera.TabStop = false;
            // 
            // establecer
            // 
            establecer.Frozen = true;
            establecer.HeaderText = "Agregar";
            establecer.MinimumWidth = 6;
            establecer.Name = "establecer";
            establecer.Resizable = DataGridViewTriState.False;
            establecer.Width = 125;
            // 
            // estudiante
            // 
            estudiante.HeaderText = "Estudiante";
            estudiante.MinimumWidth = 6;
            estudiante.Name = "estudiante";
            estudiante.ReadOnly = true;
            estudiante.Width = 250;
            // 
            // btnCancelarCurso
            // 
            btnCancelarCurso.Anchor = AnchorStyles.None;
            btnCancelarCurso.BackColor = Color.Black;
            btnCancelarCurso.Font = new Font("Agency FB", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancelarCurso.ForeColor = Color.White;
            btnCancelarCurso.Location = new Point(27, 323);
            btnCancelarCurso.Name = "btnCancelarCurso";
            btnCancelarCurso.Size = new Size(342, 45);
            btnCancelarCurso.TabIndex = 44;
            btnCancelarCurso.Text = "CANCELAR";
            btnCancelarCurso.UseMnemonic = false;
            btnCancelarCurso.UseVisualStyleBackColor = false;
            btnCancelarCurso.Click += btnCancelarCurso_Click;
            // 
            // btnAceptarCurso
            // 
            btnAceptarCurso.Anchor = AnchorStyles.None;
            btnAceptarCurso.Font = new Font("Agency FB", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnAceptarCurso.Location = new Point(27, 272);
            btnAceptarCurso.Name = "btnAceptarCurso";
            btnAceptarCurso.Size = new Size(342, 45);
            btnAceptarCurso.TabIndex = 45;
            btnAceptarCurso.Text = "ACEPTAR";
            btnAceptarCurso.UseMnemonic = false;
            btnAceptarCurso.UseVisualStyleBackColor = true;
            btnAceptarCurso.Click += btnAceptarCurso_Click;
            // 
            // GestionarListaEsperaForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(408, 381);
            ControlBox = false;
            Controls.Add(btnAceptarCurso);
            Controls.Add(btnCancelarCurso);
            Controls.Add(dgvListaEspera);
            Controls.Add(lblGestionarListaEspera);
            Name = "GestionarListaEsperaForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestionar lista de espera";
            Load += GestionarListaEsperaForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvListaEspera).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblGestionarListaEspera;
        private DataGridView dgvListaEspera;
        private Button btnCancelarCurso;
        private Button btnAceptarCurso;
        private DataGridViewCheckBoxColumn establecer;
        private DataGridViewTextBoxColumn estudiante;
    }
}