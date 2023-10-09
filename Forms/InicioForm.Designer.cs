namespace Forms
{
    partial class InicioForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InicioForm));
            panel1 = new Panel();
            label1 = new Label();
            btnIngresoAdmin = new Button();
            btnIngresoEstudiante = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Black;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, -2);
            panel1.Name = "panel1";
            panel1.Size = new Size(790, 198);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Agency FB", 36F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(289, 58);
            label1.Name = "label1";
            label1.Size = new Size(221, 72);
            label1.TabIndex = 1;
            label1.Text = "SYSACAD";
            // 
            // btnIngresoAdmin
            // 
            btnIngresoAdmin.Anchor = AnchorStyles.None;
            btnIngresoAdmin.Font = new Font("Agency FB", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnIngresoAdmin.Location = new Point(224, 237);
            btnIngresoAdmin.Name = "btnIngresoAdmin";
            btnIngresoAdmin.Size = new Size(342, 53);
            btnIngresoAdmin.TabIndex = 1;
            btnIngresoAdmin.Text = "INGRESO ADMINISTRADOR";
            btnIngresoAdmin.UseMnemonic = false;
            btnIngresoAdmin.UseVisualStyleBackColor = true;
            btnIngresoAdmin.Click += btnIngresoAdmin_Click;
            // 
            // btnIngresoEstudiante
            // 
            btnIngresoEstudiante.Font = new Font("Agency FB", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnIngresoEstudiante.Location = new Point(224, 318);
            btnIngresoEstudiante.Name = "btnIngresoEstudiante";
            btnIngresoEstudiante.Size = new Size(342, 53);
            btnIngresoEstudiante.TabIndex = 2;
            btnIngresoEstudiante.Text = "INGRESO ESTUDIANTE";
            btnIngresoEstudiante.UseMnemonic = false;
            btnIngresoEstudiante.UseVisualStyleBackColor = true;
            btnIngresoEstudiante.Click += btnIngresoEstudiante_Click;
            // 
            // InicioForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(213, 216, 247);
            ClientSize = new Size(784, 425);
            Controls.Add(btnIngresoEstudiante);
            Controls.Add(btnIngresoAdmin);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "InicioForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sysacad";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Button btnIngresoAdmin;
        private Button btnIngresoEstudiante;
    }
}