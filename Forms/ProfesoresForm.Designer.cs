namespace Forms
{
    partial class ProfesoresForm
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
            dgvListaProfesores = new DataGridView();
            nombreCurso = new DataGridViewTextBoxColumn();
            direccion = new DataGridViewTextBoxColumn();
            telefono = new DataGridViewTextBoxColumn();
            email = new DataGridViewTextBoxColumn();
            Areas = new DataGridViewTextBoxColumn();
            btnCerrar = new Button();
            btnEliminar = new Button();
            btnEditar = new Button();
            btnAgregar = new Button();
            btnAsginarCursos = new Button();
            pnlCursos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvListaProfesores).BeginInit();
            SuspendLayout();
            // 
            // pnlCursos
            // 
            pnlCursos.BackColor = Color.Black;
            pnlCursos.Controls.Add(lblCursos);
            pnlCursos.Location = new Point(-2, 0);
            pnlCursos.Name = "pnlCursos";
            pnlCursos.Size = new Size(1123, 63);
            pnlCursos.TabIndex = 2;
            // 
            // lblCursos
            // 
            lblCursos.AutoSize = true;
            lblCursos.Font = new Font("Agency FB", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point);
            lblCursos.ForeColor = SystemColors.ButtonHighlight;
            lblCursos.Location = new Point(472, 9);
            lblCursos.Name = "lblCursos";
            lblCursos.Size = new Size(168, 41);
            lblCursos.TabIndex = 1;
            lblCursos.Text = "PROFESORES";
            // 
            // dgvListaProfesores
            // 
            dgvListaProfesores.AllowUserToAddRows = false;
            dgvListaProfesores.AllowUserToDeleteRows = false;
            dgvListaProfesores.AllowUserToResizeColumns = false;
            dgvListaProfesores.AllowUserToResizeRows = false;
            dgvListaProfesores.BackgroundColor = SystemColors.ButtonHighlight;
            dgvListaProfesores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvListaProfesores.Columns.AddRange(new DataGridViewColumn[] { nombreCurso, direccion, telefono, email, Areas });
            dgvListaProfesores.Location = new Point(12, 69);
            dgvListaProfesores.MultiSelect = false;
            dgvListaProfesores.Name = "dgvListaProfesores";
            dgvListaProfesores.ReadOnly = true;
            dgvListaProfesores.RowHeadersVisible = false;
            dgvListaProfesores.RowHeadersWidth = 51;
            dgvListaProfesores.RowTemplate.Height = 29;
            dgvListaProfesores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvListaProfesores.Size = new Size(1086, 361);
            dgvListaProfesores.TabIndex = 8;
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
            // direccion
            // 
            direccion.Frozen = true;
            direccion.HeaderText = "Direccion";
            direccion.MinimumWidth = 6;
            direccion.Name = "direccion";
            direccion.ReadOnly = true;
            direccion.Resizable = DataGridViewTriState.False;
            direccion.Width = 250;
            // 
            // telefono
            // 
            telefono.Frozen = true;
            telefono.HeaderText = "Telefono";
            telefono.MinimumWidth = 6;
            telefono.Name = "telefono";
            telefono.ReadOnly = true;
            telefono.Width = 200;
            // 
            // email
            // 
            email.Frozen = true;
            email.HeaderText = "Email";
            email.MinimumWidth = 6;
            email.Name = "email";
            email.ReadOnly = true;
            email.Resizable = DataGridViewTriState.True;
            email.Width = 200;
            // 
            // Areas
            // 
            Areas.Frozen = true;
            Areas.HeaderText = "Areas";
            Areas.MinimumWidth = 6;
            Areas.Name = "Areas";
            Areas.ReadOnly = true;
            Areas.Resizable = DataGridViewTriState.True;
            Areas.Width = 200;
            // 
            // btnCerrar
            // 
            btnCerrar.Anchor = AnchorStyles.None;
            btnCerrar.BackColor = Color.Black;
            btnCerrar.Font = new Font("Agency FB", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnCerrar.ForeColor = Color.White;
            btnCerrar.Location = new Point(403, 548);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(315, 45);
            btnCerrar.TabIndex = 29;
            btnCerrar.Text = "CERRAR";
            btnCerrar.UseMnemonic = false;
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Anchor = AnchorStyles.None;
            btnEliminar.Font = new Font("Agency FB", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnEliminar.Location = new Point(845, 461);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(228, 45);
            btnEliminar.TabIndex = 32;
            btnEliminar.Text = "ELIMINAR";
            btnEliminar.UseMnemonic = false;
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Anchor = AnchorStyles.None;
            btnEditar.Font = new Font("Agency FB", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnEditar.Location = new Point(306, 461);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(228, 45);
            btnEditar.TabIndex = 31;
            btnEditar.Text = "EDITAR";
            btnEditar.UseMnemonic = false;
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Anchor = AnchorStyles.None;
            btnAgregar.Font = new Font("Agency FB", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnAgregar.Location = new Point(38, 461);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(228, 45);
            btnAgregar.TabIndex = 30;
            btnAgregar.Text = "AGREGAR";
            btnAgregar.UseMnemonic = false;
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnAsginarCursos
            // 
            btnAsginarCursos.Anchor = AnchorStyles.None;
            btnAsginarCursos.Font = new Font("Agency FB", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnAsginarCursos.Location = new Point(571, 461);
            btnAsginarCursos.Name = "btnAsginarCursos";
            btnAsginarCursos.Size = new Size(228, 45);
            btnAsginarCursos.TabIndex = 33;
            btnAsginarCursos.Text = "ASIGNAR CURSOS";
            btnAsginarCursos.UseMnemonic = false;
            btnAsginarCursos.UseVisualStyleBackColor = true;
            btnAsginarCursos.Click += btnAsginarCursos_Click;
            // 
            // ProfesoresForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1110, 615);
            ControlBox = false;
            Controls.Add(btnAsginarCursos);
            Controls.Add(btnEliminar);
            Controls.Add(btnEditar);
            Controls.Add(btnAgregar);
            Controls.Add(btnCerrar);
            Controls.Add(dgvListaProfesores);
            Controls.Add(pnlCursos);
            Name = "ProfesoresForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Profesores";
            Load += ProfesoresForm_Load;
            pnlCursos.ResumeLayout(false);
            pnlCursos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvListaProfesores).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlCursos;
        private Label lblCursos;
        private DataGridView dgvListaProfesores;
        private DataGridViewTextBoxColumn nombreCurso;
        private DataGridViewTextBoxColumn direccion;
        private DataGridViewTextBoxColumn telefono;
        private DataGridViewTextBoxColumn email;
        private DataGridViewTextBoxColumn Areas;
        private Button btnCerrar;
        private Button btnEliminar;
        private Button btnEditar;
        private Button btnAgregar;
        private Button btnAsginarCursos;
    }
}