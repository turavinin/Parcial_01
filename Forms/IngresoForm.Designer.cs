namespace Forms
{
    partial class IngresoForm
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
            pnlIngreso = new Panel();
            lblTituloIngreso = new Label();
            txtUsuario = new TextBox();
            txtClave = new TextBox();
            btnIngresar = new Button();
            lblUsuario = new Label();
            lblClave = new Label();
            pnlIngreso.SuspendLayout();
            SuspendLayout();
            // 
            // pnlIngreso
            // 
            pnlIngreso.BackColor = Color.Black;
            pnlIngreso.Controls.Add(lblTituloIngreso);
            pnlIngreso.Location = new Point(-2, 2);
            pnlIngreso.Name = "pnlIngreso";
            pnlIngreso.Size = new Size(790, 164);
            pnlIngreso.TabIndex = 1;
            // 
            // lblTituloIngreso
            // 
            lblTituloIngreso.AutoSize = true;
            lblTituloIngreso.Font = new Font("Agency FB", 36F, FontStyle.Bold, GraphicsUnit.Point);
            lblTituloIngreso.ForeColor = SystemColors.ButtonHighlight;
            lblTituloIngreso.Location = new Point(293, 45);
            lblTituloIngreso.Name = "lblTituloIngreso";
            lblTituloIngreso.Size = new Size(213, 72);
            lblTituloIngreso.TabIndex = 1;
            lblTituloIngreso.Text = "INGRESO";
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(215, 227);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(358, 27);
            txtUsuario.TabIndex = 2;
            // 
            // txtClave
            // 
            txtClave.Location = new Point(215, 296);
            txtClave.Name = "txtClave";
            txtClave.Size = new Size(358, 27);
            txtClave.TabIndex = 4;
            // 
            // btnIngresar
            // 
            btnIngresar.Anchor = AnchorStyles.None;
            btnIngresar.Font = new Font("Agency FB", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnIngresar.Location = new Point(215, 363);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(358, 53);
            btnIngresar.TabIndex = 5;
            btnIngresar.Text = "INGRESAR";
            btnIngresar.UseMnemonic = false;
            btnIngresar.UseVisualStyleBackColor = true;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Franklin Gothic Medium Cond", 13F, FontStyle.Bold, GraphicsUnit.Point);
            lblUsuario.Location = new Point(215, 196);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(81, 28);
            lblUsuario.TabIndex = 1;
            lblUsuario.Text = "Usuario";
            // 
            // lblClave
            // 
            lblClave.AutoSize = true;
            lblClave.Font = new Font("Franklin Gothic Medium Cond", 13F, FontStyle.Bold, GraphicsUnit.Point);
            lblClave.Location = new Point(215, 267);
            lblClave.Name = "lblClave";
            lblClave.Size = new Size(62, 28);
            lblClave.TabIndex = 3;
            lblClave.Text = "Clave";
            // 
            // IngresoForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 450);
            Controls.Add(lblClave);
            Controls.Add(lblUsuario);
            Controls.Add(btnIngresar);
            Controls.Add(txtClave);
            Controls.Add(txtUsuario);
            Controls.Add(pnlIngreso);
            Name = "IngresoForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ingreso";
            Load += IngresoForm_Load;
            pnlIngreso.ResumeLayout(false);
            pnlIngreso.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlIngreso;
        private Label lblTituloIngreso;
        private TextBox txtUsuario;
        private TextBox txtClave;
        private Button btnIngresar;
        private Label lblUsuario;
        private Label lblClave;
    }
}