namespace ProjectDatabase_Ivano
{
    partial class FormTambahTransaksi
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
            this.buttonKeluar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelNama = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonKosongi = new System.Windows.Forms.Button();
            this.buttonTambah = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxNominal = new System.Windows.Forms.TextBox();
            this.comboBoxJenisTransaksi = new System.Windows.Forms.ComboBox();
            this.comboBoxRekeningTujuan = new System.Windows.Forms.ComboBox();
            this.textBoxKeterangan = new System.Windows.Forms.TextBox();
            this.labelNoRekening = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelInbox
            // 
            this.labelInbox.BackColor = System.Drawing.Color.Navy;
            this.labelInbox.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInbox.ForeColor = System.Drawing.Color.Transparent;
            this.labelInbox.Location = new System.Drawing.Point(25, 25);
            this.labelInbox.Name = "labelInbox";
            this.labelInbox.Size = new System.Drawing.Size(716, 39);
            this.labelInbox.TabIndex = 44;
            this.labelInbox.Text = "TAMBAH TRANSAKSI";
            this.labelInbox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonKeluar
            // 
            this.buttonKeluar.BackColor = System.Drawing.Color.Navy;
            this.buttonKeluar.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonKeluar.ForeColor = System.Drawing.Color.White;
            this.buttonKeluar.Location = new System.Drawing.Point(549, 481);
            this.buttonKeluar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonKeluar.Name = "buttonKeluar";
            this.buttonKeluar.Size = new System.Drawing.Size(203, 53);
            this.buttonKeluar.TabIndex = 46;
            this.buttonKeluar.Text = "&KELUAR";
            this.buttonKeluar.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Lavender;
            this.panel1.Controls.Add(this.labelNoRekening);
            this.panel1.Controls.Add(this.textBoxKeterangan);
            this.panel1.Controls.Add(this.comboBoxRekeningTujuan);
            this.panel1.Controls.Add(this.comboBoxJenisTransaksi);
            this.panel1.Controls.Add(this.textBoxNominal);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.labelNama);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(25, 80);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(716, 397);
            this.panel1.TabIndex = 45;
            // 
            // labelNama
            // 
            this.labelNama.AutoSize = true;
            this.labelNama.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNama.Location = new System.Drawing.Point(233, 99);
            this.labelNama.Name = "labelNama";
            this.labelNama.Size = new System.Drawing.Size(0, 18);
            this.labelNama.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(141, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 18);
            this.label2.TabIndex = 19;
            this.label2.Text = "Nominal";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(90, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 18);
            this.label1.TabIndex = 18;
            this.label1.Text = "Rekening Sumber : ";
            // 
            // buttonKosongi
            // 
            this.buttonKosongi.BackColor = System.Drawing.Color.Navy;
            this.buttonKosongi.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonKosongi.ForeColor = System.Drawing.Color.White;
            this.buttonKosongi.Location = new System.Drawing.Point(293, 481);
            this.buttonKosongi.Name = "buttonKosongi";
            this.buttonKosongi.Size = new System.Drawing.Size(202, 53);
            this.buttonKosongi.TabIndex = 48;
            this.buttonKosongi.Text = "&KOSONGI";
            this.buttonKosongi.UseVisualStyleBackColor = false;
            // 
            // buttonTambah
            // 
            this.buttonTambah.BackColor = System.Drawing.Color.Navy;
            this.buttonTambah.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTambah.ForeColor = System.Drawing.Color.White;
            this.buttonTambah.Location = new System.Drawing.Point(36, 481);
            this.buttonTambah.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonTambah.Name = "buttonTambah";
            this.buttonTambah.Size = new System.Drawing.Size(203, 53);
            this.buttonTambah.TabIndex = 47;
            this.buttonTambah.Text = "&TAMBAH";
            this.buttonTambah.UseVisualStyleBackColor = false;
            this.buttonTambah.Click += new System.EventHandler(this.buttonTambah_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(115, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 16);
            this.label3.TabIndex = 21;
            this.label3.Text = "Rekening Tujuan : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(131, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 16);
            this.label4.TabIndex = 22;
            this.label4.Text = "Jenis Transaksi :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(134, 245);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 16);
            this.label5.TabIndex = 23;
            this.label5.Text = "Keterangan :";
            // 
            // textBoxNominal
            // 
            this.textBoxNominal.Location = new System.Drawing.Point(268, 95);
            this.textBoxNominal.Name = "textBoxNominal";
            this.textBoxNominal.Size = new System.Drawing.Size(259, 22);
            this.textBoxNominal.TabIndex = 25;
            // 
            // comboBoxJenisTransaksi
            // 
            this.comboBoxJenisTransaksi.FormattingEnabled = true;
            this.comboBoxJenisTransaksi.Location = new System.Drawing.Point(268, 196);
            this.comboBoxJenisTransaksi.Name = "comboBoxJenisTransaksi";
            this.comboBoxJenisTransaksi.Size = new System.Drawing.Size(259, 24);
            this.comboBoxJenisTransaksi.TabIndex = 26;
            // 
            // comboBoxRekeningTujuan
            // 
            this.comboBoxRekeningTujuan.FormattingEnabled = true;
            this.comboBoxRekeningTujuan.Location = new System.Drawing.Point(268, 148);
            this.comboBoxRekeningTujuan.Name = "comboBoxRekeningTujuan";
            this.comboBoxRekeningTujuan.Size = new System.Drawing.Size(259, 24);
            this.comboBoxRekeningTujuan.TabIndex = 27;
            // 
            // textBoxKeterangan
            // 
            this.textBoxKeterangan.Location = new System.Drawing.Point(268, 245);
            this.textBoxKeterangan.Name = "textBoxKeterangan";
            this.textBoxKeterangan.Size = new System.Drawing.Size(259, 22);
            this.textBoxKeterangan.TabIndex = 28;
            // 
            // labelNoRekening
            // 
            this.labelNoRekening.AutoSize = true;
            this.labelNoRekening.Location = new System.Drawing.Point(265, 47);
            this.labelNoRekening.Name = "labelNoRekening";
            this.labelNoRekening.Size = new System.Drawing.Size(44, 16);
            this.labelNoRekening.TabIndex = 29;
            this.labelNoRekening.Text = "label6";
            // 
            // FormTambahTransaksi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 562);
            this.Controls.Add(this.labelInbox);
            this.Controls.Add(this.buttonKeluar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonKosongi);
            this.Controls.Add(this.buttonTambah);
            this.Name = "FormTambahTransaksi";
            this.Text = "FormTambahTransaksi";
            this.Load += new System.EventHandler(this.FormTambahTransaksi_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelInbox;
        private System.Windows.Forms.Button buttonKeluar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelNama;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonKosongi;
        private System.Windows.Forms.Button buttonTambah;
        private System.Windows.Forms.ComboBox comboBoxRekeningTujuan;
        private System.Windows.Forms.ComboBox comboBoxJenisTransaksi;
        private System.Windows.Forms.TextBox textBoxNominal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxKeterangan;
        private System.Windows.Forms.Label labelNoRekening;
    }
}