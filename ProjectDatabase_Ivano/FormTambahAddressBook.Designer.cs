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
            this.textBoxKeterangan = new System.Windows.Forms.TextBox();
            this.buttonKeluar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxNoRekening = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonKosongi = new System.Windows.Forms.Button();
            this.buttonKirim = new System.Windows.Forms.Button();
            this.labelNamaPengguna = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelInbox
            // 
            this.labelInbox.BackColor = System.Drawing.Color.Navy;
            this.labelInbox.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInbox.ForeColor = System.Drawing.Color.Transparent;
            this.labelInbox.Location = new System.Drawing.Point(12, 20);
            this.labelInbox.Name = "labelInbox";
            this.labelInbox.Size = new System.Drawing.Size(716, 39);
            this.labelInbox.TabIndex = 0;
            this.labelInbox.Text = "TAMBAH ADDRESS BOOK";
            this.labelInbox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxKeterangan
            // 
            this.textBoxKeterangan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxKeterangan.Location = new System.Drawing.Point(236, 144);
            this.textBoxKeterangan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxKeterangan.Multiline = true;
            this.textBoxKeterangan.Name = "textBoxKeterangan";
            this.textBoxKeterangan.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxKeterangan.Size = new System.Drawing.Size(425, 93);
            this.textBoxKeterangan.TabIndex = 5;
            // 
            // buttonKeluar
            // 
            this.buttonKeluar.BackColor = System.Drawing.Color.Navy;
            this.buttonKeluar.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonKeluar.ForeColor = System.Drawing.Color.White;
            this.buttonKeluar.Location = new System.Drawing.Point(525, 358);
            this.buttonKeluar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonKeluar.Name = "buttonKeluar";
            this.buttonKeluar.Size = new System.Drawing.Size(203, 53);
            this.buttonKeluar.TabIndex = 4;
            this.buttonKeluar.Text = "&KELUAR";
            this.buttonKeluar.UseVisualStyleBackColor = false;
            this.buttonKeluar.Click += new System.EventHandler(this.buttonKeluar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(95, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 18);
            this.label5.TabIndex = 4;
            this.label5.Text = "Keterangan : ";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Lavender;
            this.panel1.Controls.Add(this.labelNamaPengguna);
            this.panel1.Controls.Add(this.textBoxNoRekening);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBoxKeterangan);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(12, 75);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(716, 264);
            this.panel1.TabIndex = 1;
            // 
            // textBoxNoRekening
            // 
            this.textBoxNoRekening.Location = new System.Drawing.Point(236, 87);
            this.textBoxNoRekening.Name = "textBoxNoRekening";
            this.textBoxNoRekening.Size = new System.Drawing.Size(425, 22);
            this.textBoxNoRekening.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "No Rekening Tujuan : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(62, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nama Pengguna :";
            // 
            // buttonKosongi
            // 
            this.buttonKosongi.BackColor = System.Drawing.Color.Navy;
            this.buttonKosongi.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonKosongi.ForeColor = System.Drawing.Color.White;
            this.buttonKosongi.Location = new System.Drawing.Point(269, 358);
            this.buttonKosongi.Name = "buttonKosongi";
            this.buttonKosongi.Size = new System.Drawing.Size(202, 53);
            this.buttonKosongi.TabIndex = 3;
            this.buttonKosongi.Text = "&KOSONGI";
            this.buttonKosongi.UseVisualStyleBackColor = false;
            this.buttonKosongi.Click += new System.EventHandler(this.buttonKosongi_Click);
            // 
            // buttonKirim
            // 
            this.buttonKirim.BackColor = System.Drawing.Color.Navy;
            this.buttonKirim.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonKirim.ForeColor = System.Drawing.Color.White;
            this.buttonKirim.Location = new System.Drawing.Point(16, 358);
            this.buttonKirim.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonKirim.Name = "buttonKirim";
            this.buttonKirim.Size = new System.Drawing.Size(203, 53);
            this.buttonKirim.TabIndex = 2;
            this.buttonKirim.Text = "&TAMBAH";
            this.buttonKirim.UseVisualStyleBackColor = false;
            this.buttonKirim.Click += new System.EventHandler(this.buttonKirim_Click);
            // 
            // labelNamaPengguna
            // 
            this.labelNamaPengguna.AutoSize = true;
            this.labelNamaPengguna.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNamaPengguna.Location = new System.Drawing.Point(233, 30);
            this.labelNamaPengguna.Name = "labelNamaPengguna";
            this.labelNamaPengguna.Size = new System.Drawing.Size(131, 18);
            this.labelNamaPengguna.TabIndex = 21;
            this.labelNamaPengguna.Text = "Nama Pengguna";
            // 
            // FormTambahAddressBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 430);
            this.Controls.Add(this.labelInbox);
            this.Controls.Add(this.buttonKeluar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonKosongi);
            this.Controls.Add(this.buttonKirim);
            this.Name = "FormTambahAddressBook";
            this.Text = "Tambah Address Book";
            this.Load += new System.EventHandler(this.FormTambahAddressBook_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelInbox;
        private System.Windows.Forms.TextBox textBoxKeterangan;
        private System.Windows.Forms.Button buttonKeluar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxNoRekening;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonKosongi;
        private System.Windows.Forms.Button buttonKirim;
        private System.Windows.Forms.Label labelNamaPengguna;
    }
}