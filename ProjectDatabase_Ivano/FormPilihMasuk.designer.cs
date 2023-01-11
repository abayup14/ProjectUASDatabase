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
            this.buttonPengguna = new System.Windows.Forms.Button();
            this.buttonPegawai = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonPengguna
            // 
            this.buttonPengguna.BackColor = System.Drawing.Color.Navy;
            this.buttonPengguna.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPengguna.ForeColor = System.Drawing.Color.White;
            this.buttonPengguna.Location = new System.Drawing.Point(284, 97);
            this.buttonPengguna.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonPengguna.Name = "buttonPengguna";
            this.buttonPengguna.Size = new System.Drawing.Size(203, 53);
            this.buttonPengguna.TabIndex = 50;
            this.buttonPengguna.Text = "&PENGGUNA";
            this.buttonPengguna.UseVisualStyleBackColor = false;
            this.buttonPengguna.Click += new System.EventHandler(this.buttonPengguna_Click);
            // 
            // buttonPegawai
            // 
            this.buttonPegawai.BackColor = System.Drawing.Color.Navy;
            this.buttonPegawai.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPegawai.ForeColor = System.Drawing.Color.White;
            this.buttonPegawai.Location = new System.Drawing.Point(12, 97);
            this.buttonPegawai.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonPegawai.Name = "buttonPegawai";
            this.buttonPegawai.Size = new System.Drawing.Size(203, 53);
            this.buttonPegawai.TabIndex = 49;
            this.buttonPegawai.Text = "&PEGAWAI";
            this.buttonPegawai.UseVisualStyleBackColor = false;
            this.buttonPegawai.Click += new System.EventHandler(this.buttonPegawai_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Navy;
            this.label2.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(12, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(475, 39);
            this.label2.TabIndex = 51;
            this.label2.Text = "MASUK SEBAGAI";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormPilihMasuk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 171);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonPengguna);
            this.Controls.Add(this.buttonPegawai);
            this.Name = "FormPilihMasuk";
            this.Text = "Masuk Sebagai";
            this.Load += new System.EventHandler(this.FormPilihMasuk_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonPengguna;
        private System.Windows.Forms.Button buttonPegawai;
        private System.Windows.Forms.Label label2;
    }
}