namespace ProjectDatabase_Ivano
{
    partial class FormPilihMasuk
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
            this.label1 = new System.Windows.Forms.Label();
            this.buttonPengguna = new System.Windows.Forms.Button();
            this.buttonPegawai = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(120, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(292, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pilih Masuk Sebagai";
            // 
            // buttonPengguna
            // 
            this.buttonPengguna.BackColor = System.Drawing.Color.Navy;
            this.buttonPengguna.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPengguna.ForeColor = System.Drawing.Color.White;
            this.buttonPengguna.Location = new System.Drawing.Point(12, 125);
            this.buttonPengguna.Name = "buttonPengguna";
            this.buttonPengguna.Size = new System.Drawing.Size(222, 53);
            this.buttonPengguna.TabIndex = 37;
            this.buttonPengguna.Text = "PENGGUNA";
            this.buttonPengguna.UseVisualStyleBackColor = false;
            this.buttonPengguna.Click += new System.EventHandler(this.buttonPengguna_Click);
            // 
            // buttonPegawai
            // 
            this.buttonPegawai.BackColor = System.Drawing.Color.Navy;
            this.buttonPegawai.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPegawai.ForeColor = System.Drawing.Color.White;
            this.buttonPegawai.Location = new System.Drawing.Point(300, 125);
            this.buttonPegawai.Name = "buttonPegawai";
            this.buttonPegawai.Size = new System.Drawing.Size(222, 53);
            this.buttonPegawai.TabIndex = 38;
            this.buttonPegawai.Text = "PEGAWAI";
            this.buttonPegawai.UseVisualStyleBackColor = false;
            this.buttonPegawai.Click += new System.EventHandler(this.buttonPegawai_Click);
            // 
            // FormPilihMasuk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(534, 193);
            this.Controls.Add(this.buttonPegawai);
            this.Controls.Add(this.buttonPengguna);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormPilihMasuk";
            this.Text = "Pilih Masuk";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button buttonPengguna;
        public System.Windows.Forms.Button buttonPegawai;
    }
}