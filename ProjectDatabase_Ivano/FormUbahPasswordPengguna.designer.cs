namespace ProjectDatabase_Ivano
{
    partial class FormUbahPasswordPengguna
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
            this.label2 = new System.Windows.Forms.Label();
            this.buttonKeluar = new System.Windows.Forms.Button();
            this.buttonUbah = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxKonfirmasiPasswordBaru = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxPasswordBaru = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPasswordLama = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Navy;
            this.label2.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(5, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(799, 39);
            this.label2.TabIndex = 34;
            this.label2.Text = "UBAH PASSWORD PENGGUNA";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonKeluar
            // 
            this.buttonKeluar.BackColor = System.Drawing.Color.Navy;
            this.buttonKeluar.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonKeluar.ForeColor = System.Drawing.Color.White;
            this.buttonKeluar.Location = new System.Drawing.Point(597, 267);
            this.buttonKeluar.Name = "buttonKeluar";
            this.buttonKeluar.Size = new System.Drawing.Size(202, 53);
            this.buttonKeluar.TabIndex = 42;
            this.buttonKeluar.Text = "&KELUAR";
            this.buttonKeluar.UseVisualStyleBackColor = false;
            this.buttonKeluar.Click += new System.EventHandler(this.buttonKeluar_Click);
            // 
            // buttonUbah
            // 
            this.buttonUbah.BackColor = System.Drawing.Color.Navy;
            this.buttonUbah.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUbah.ForeColor = System.Drawing.Color.White;
            this.buttonUbah.Location = new System.Drawing.Point(11, 267);
            this.buttonUbah.Name = "buttonUbah";
            this.buttonUbah.Size = new System.Drawing.Size(202, 53);
            this.buttonUbah.TabIndex = 41;
            this.buttonUbah.Text = "&UBAH";
            this.buttonUbah.UseVisualStyleBackColor = false;
            this.buttonUbah.Click += new System.EventHandler(this.buttonUbah_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Lavender;
            this.panel1.Controls.Add(this.textBoxKonfirmasiPasswordBaru);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBoxPasswordBaru);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBoxPasswordLama);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Location = new System.Drawing.Point(11, 69);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(788, 181);
            this.panel1.TabIndex = 43;
            // 
            // textBoxKonfirmasiPasswordBaru
            // 
            this.textBoxKonfirmasiPasswordBaru.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxKonfirmasiPasswordBaru.Location = new System.Drawing.Point(306, 118);
            this.textBoxKonfirmasiPasswordBaru.Name = "textBoxKonfirmasiPasswordBaru";
            this.textBoxKonfirmasiPasswordBaru.Size = new System.Drawing.Size(421, 24);
            this.textBoxKonfirmasiPasswordBaru.TabIndex = 46;
            this.textBoxKonfirmasiPasswordBaru.Enter += new System.EventHandler(this.textBoxKonfirmasiPasswordBaru_Enter);
            this.textBoxKonfirmasiPasswordBaru.Leave += new System.EventHandler(this.textBoxKonfirmasiPasswordBaru_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(40, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(219, 18);
            this.label3.TabIndex = 45;
            this.label3.Text = "Konfirmasi Password Baru :";
            // 
            // textBoxPasswordBaru
            // 
            this.textBoxPasswordBaru.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPasswordBaru.Location = new System.Drawing.Point(306, 69);
            this.textBoxPasswordBaru.Name = "textBoxPasswordBaru";
            this.textBoxPasswordBaru.Size = new System.Drawing.Size(421, 24);
            this.textBoxPasswordBaru.TabIndex = 44;
            this.textBoxPasswordBaru.Enter += new System.EventHandler(this.textBoxPasswordBaru_Enter);
            this.textBoxPasswordBaru.Leave += new System.EventHandler(this.textBoxPasswordBaru_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(126, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 18);
            this.label1.TabIndex = 43;
            this.label1.Text = "Password Baru :";
            // 
            // textBoxPasswordLama
            // 
            this.textBoxPasswordLama.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPasswordLama.Location = new System.Drawing.Point(306, 20);
            this.textBoxPasswordLama.Name = "textBoxPasswordLama";
            this.textBoxPasswordLama.Size = new System.Drawing.Size(421, 24);
            this.textBoxPasswordLama.TabIndex = 42;
            this.textBoxPasswordLama.Enter += new System.EventHandler(this.textBoxPasswordLama_Enter);
            this.textBoxPasswordLama.Leave += new System.EventHandler(this.textBoxPasswordLama_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(120, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(139, 18);
            this.label8.TabIndex = 41;
            this.label8.Text = "Password Lama :";
            // 
            // FormUbahPasswordPengguna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 333);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonKeluar);
            this.Controls.Add(this.buttonUbah);
            this.Controls.Add(this.label2);
            this.Name = "FormUbahPasswordPengguna";
            this.Text = "Ubah Password";
            this.Load += new System.EventHandler(this.FormUbahPassword_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonKeluar;
        private System.Windows.Forms.Button buttonUbah;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxKonfirmasiPasswordBaru;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox textBoxPasswordLama;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox textBoxPasswordBaru;
    }
}