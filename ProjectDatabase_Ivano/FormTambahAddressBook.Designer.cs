namespace ProjectDatabase_Ivano
{
    partial class FormTambahAddressBook
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
            this.labelInbox = new System.Windows.Forms.Label();
            this.textBoxPesan = new System.Windows.Forms.TextBox();
            this.buttonKeluar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxIdPengguna = new System.Windows.Forms.TextBox();
            this.textBoxNoRekening = new System.Windows.Forms.TextBox();
            this.labelNama = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonKosongi = new System.Windows.Forms.Button();
            this.buttonKirim = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelInbox
            // 
            this.labelInbox.BackColor = System.Drawing.Color.Navy;
            this.labelInbox.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInbox.ForeColor = System.Drawing.Color.Transparent;
            this.labelInbox.Location = new System.Drawing.Point(9, 16);
            this.labelInbox.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelInbox.Name = "labelInbox";
            this.labelInbox.Size = new System.Drawing.Size(537, 32);
            this.labelInbox.TabIndex = 44;
            this.labelInbox.Text = "TAMBAH ADDRESS BOOK";
            this.labelInbox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxPesan
            // 
            this.textBoxPesan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPesan.Location = new System.Drawing.Point(177, 117);
            this.textBoxPesan.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxPesan.Multiline = true;
            this.textBoxPesan.Name = "textBoxPesan";
            this.textBoxPesan.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxPesan.Size = new System.Drawing.Size(320, 76);
            this.textBoxPesan.TabIndex = 8;
            // 
            // buttonKeluar
            // 
            this.buttonKeluar.BackColor = System.Drawing.Color.Navy;
            this.buttonKeluar.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonKeluar.ForeColor = System.Drawing.Color.White;
            this.buttonKeluar.Location = new System.Drawing.Point(394, 291);
            this.buttonKeluar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonKeluar.Name = "buttonKeluar";
            this.buttonKeluar.Size = new System.Drawing.Size(152, 43);
            this.buttonKeluar.TabIndex = 46;
            this.buttonKeluar.Text = "&KELUAR";
            this.buttonKeluar.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(71, 119);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "Keterangan : ";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Lavender;
            this.panel1.Controls.Add(this.textBoxIdPengguna);
            this.panel1.Controls.Add(this.textBoxNoRekening);
            this.panel1.Controls.Add(this.labelNama);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBoxPesan);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(9, 61);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(537, 214);
            this.panel1.TabIndex = 45;
            // 
            // textBoxIdPengguna
            // 
            this.textBoxIdPengguna.Location = new System.Drawing.Point(177, 37);
            this.textBoxIdPengguna.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxIdPengguna.Name = "textBoxIdPengguna";
            this.textBoxIdPengguna.Size = new System.Drawing.Size(320, 20);
            this.textBoxIdPengguna.TabIndex = 22;
            // 
            // textBoxNoRekening
            // 
            this.textBoxNoRekening.Location = new System.Drawing.Point(177, 80);
            this.textBoxNoRekening.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxNoRekening.Name = "textBoxNoRekening";
            this.textBoxNoRekening.Size = new System.Drawing.Size(320, 20);
            this.textBoxNoRekening.TabIndex = 21;
            // 
            // labelNama
            // 
            this.labelNama.AutoSize = true;
            this.labelNama.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNama.Location = new System.Drawing.Point(175, 80);
            this.labelNama.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelNama.Name = "labelNama";
            this.labelNama.Size = new System.Drawing.Size(0, 15);
            this.labelNama.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(68, 80);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 15);
            this.label2.TabIndex = 19;
            this.label2.Text = "No Rekening : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(68, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 15);
            this.label1.TabIndex = 18;
            this.label1.Text = "ID Pengguna :";
            // 
            // buttonKosongi
            // 
            this.buttonKosongi.BackColor = System.Drawing.Color.Navy;
            this.buttonKosongi.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonKosongi.ForeColor = System.Drawing.Color.White;
            this.buttonKosongi.Location = new System.Drawing.Point(202, 291);
            this.buttonKosongi.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonKosongi.Name = "buttonKosongi";
            this.buttonKosongi.Size = new System.Drawing.Size(152, 43);
            this.buttonKosongi.TabIndex = 48;
            this.buttonKosongi.Text = "&KOSONGI";
            this.buttonKosongi.UseVisualStyleBackColor = false;
            this.buttonKosongi.Click += new System.EventHandler(this.buttonKosongi_Click);
            // 
            // buttonKirim
            // 
            this.buttonKirim.BackColor = System.Drawing.Color.Navy;
            this.buttonKirim.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonKirim.ForeColor = System.Drawing.Color.White;
            this.buttonKirim.Location = new System.Drawing.Point(12, 291);
            this.buttonKirim.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonKirim.Name = "buttonKirim";
            this.buttonKirim.Size = new System.Drawing.Size(152, 43);
            this.buttonKirim.TabIndex = 47;
            this.buttonKirim.Text = "&TAMBAH";
            this.buttonKirim.UseVisualStyleBackColor = false;
            this.buttonKirim.Click += new System.EventHandler(this.buttonKirim_Click);
            // 
            // FormTambahAddressBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 349);
            this.Controls.Add(this.labelInbox);
            this.Controls.Add(this.buttonKeluar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonKosongi);
            this.Controls.Add(this.buttonKirim);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormTambahAddressBook";
            this.Text = "Tambah Address Book";
            this.Load += new System.EventHandler(this.FormTambahAddressBook_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelInbox;
        private System.Windows.Forms.TextBox textBoxPesan;
        private System.Windows.Forms.Button buttonKeluar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxNoRekening;
        private System.Windows.Forms.Label labelNama;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonKosongi;
        private System.Windows.Forms.Button buttonKirim;
        private System.Windows.Forms.TextBox textBoxIdPengguna;
    }
}