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
            this.comboBoxRekeningSumber = new System.Windows.Forms.ComboBox();
            this.checkBoxTagihan = new System.Windows.Forms.CheckBox();
            this.checkBoxPromo = new System.Windows.Forms.CheckBox();
            this.comboBoxPromo = new System.Windows.Forms.ComboBox();
            this.comboBoxJenisTagihan = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxKeterangan = new System.Windows.Forms.TextBox();
            this.comboBoxRekeningTujuan = new System.Windows.Forms.ComboBox();
            this.comboBoxJenisTransaksi = new System.Windows.Forms.ComboBox();
            this.textBoxNominal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonKosongi = new System.Windows.Forms.Button();
            this.buttonTambah = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelInbox
            // 
            this.labelInbox.BackColor = System.Drawing.Color.Navy;
            this.labelInbox.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInbox.ForeColor = System.Drawing.Color.Transparent;
            this.labelInbox.Location = new System.Drawing.Point(12, 9);
            this.labelInbox.Name = "labelInbox";
            this.labelInbox.Size = new System.Drawing.Size(833, 39);
            this.labelInbox.TabIndex = 44;
            this.labelInbox.Text = "TAMBAH TRANSAKSI";
            this.labelInbox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonKeluar
            // 
            this.buttonKeluar.BackColor = System.Drawing.Color.Navy;
            this.buttonKeluar.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonKeluar.ForeColor = System.Drawing.Color.White;
            this.buttonKeluar.Location = new System.Drawing.Point(642, 462);
            this.buttonKeluar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonKeluar.Name = "buttonKeluar";
            this.buttonKeluar.Size = new System.Drawing.Size(203, 53);
            this.buttonKeluar.TabIndex = 46;
            this.buttonKeluar.Text = "&KELUAR";
            this.buttonKeluar.UseVisualStyleBackColor = false;
            this.buttonKeluar.Click += new System.EventHandler(this.buttonKeluar_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Lavender;
            this.panel1.Controls.Add(this.comboBoxRekeningSumber);
            this.panel1.Controls.Add(this.checkBoxTagihan);
            this.panel1.Controls.Add(this.checkBoxPromo);
            this.panel1.Controls.Add(this.comboBoxPromo);
            this.panel1.Controls.Add(this.comboBoxJenisTagihan);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.textBoxKeterangan);
            this.panel1.Controls.Add(this.comboBoxRekeningTujuan);
            this.panel1.Controls.Add(this.comboBoxJenisTransaksi);
            this.panel1.Controls.Add(this.textBoxNominal);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 62);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(833, 379);
            this.panel1.TabIndex = 45;
            // 
            // comboBoxRekeningSumber
            // 
            this.comboBoxRekeningSumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRekeningSumber.FormattingEnabled = true;
            this.comboBoxRekeningSumber.Location = new System.Drawing.Point(291, 37);
            this.comboBoxRekeningSumber.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxRekeningSumber.Name = "comboBoxRekeningSumber";
            this.comboBoxRekeningSumber.Size = new System.Drawing.Size(259, 24);
            this.comboBoxRekeningSumber.TabIndex = 36;
            this.comboBoxRekeningSumber.SelectedIndexChanged += new System.EventHandler(this.comboBoxRekeningSumber_SelectedIndexChanged);
            // 
            // checkBoxTagihan
            // 
            this.checkBoxTagihan.AutoSize = true;
            this.checkBoxTagihan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.checkBoxTagihan.Location = new System.Drawing.Point(576, 328);
            this.checkBoxTagihan.Name = "checkBoxTagihan";
            this.checkBoxTagihan.Size = new System.Drawing.Size(158, 22);
            this.checkBoxTagihan.TabIndex = 35;
            this.checkBoxTagihan.Text = "Apakah Tagihan?";
            this.checkBoxTagihan.UseVisualStyleBackColor = true;
            this.checkBoxTagihan.CheckedChanged += new System.EventHandler(this.checkBoxTagihan_CheckedChanged);
            // 
            // checkBoxPromo
            // 
            this.checkBoxPromo.AutoSize = true;
            this.checkBoxPromo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.checkBoxPromo.Location = new System.Drawing.Point(576, 281);
            this.checkBoxPromo.Name = "checkBoxPromo";
            this.checkBoxPromo.Size = new System.Drawing.Size(150, 22);
            this.checkBoxPromo.TabIndex = 34;
            this.checkBoxPromo.Text = "Apakah Promo?";
            this.checkBoxPromo.UseVisualStyleBackColor = true;
            this.checkBoxPromo.CheckedChanged += new System.EventHandler(this.checkBoxPromo_CheckedChanged);
            // 
            // comboBoxPromo
            // 
            this.comboBoxPromo.Enabled = false;
            this.comboBoxPromo.FormattingEnabled = true;
            this.comboBoxPromo.Location = new System.Drawing.Point(291, 278);
            this.comboBoxPromo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxPromo.Name = "comboBoxPromo";
            this.comboBoxPromo.Size = new System.Drawing.Size(259, 24);
            this.comboBoxPromo.TabIndex = 33;
            // 
            // comboBoxJenisTagihan
            // 
            this.comboBoxJenisTagihan.Enabled = false;
            this.comboBoxJenisTagihan.FormattingEnabled = true;
            this.comboBoxJenisTagihan.Location = new System.Drawing.Point(291, 328);
            this.comboBoxJenisTagihan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxJenisTagihan.Name = "comboBoxJenisTagihan";
            this.comboBoxJenisTagihan.Size = new System.Drawing.Size(259, 24);
            this.comboBoxJenisTagihan.TabIndex = 32;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(140, 329);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 18);
            this.label6.TabIndex = 31;
            this.label6.Text = "Jenis Tagihan :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(190, 279);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 18);
            this.label7.TabIndex = 30;
            this.label7.Text = "Promo :";
            // 
            // textBoxKeterangan
            // 
            this.textBoxKeterangan.Location = new System.Drawing.Point(291, 230);
            this.textBoxKeterangan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxKeterangan.Name = "textBoxKeterangan";
            this.textBoxKeterangan.Size = new System.Drawing.Size(505, 22);
            this.textBoxKeterangan.TabIndex = 28;
            // 
            // comboBoxRekeningTujuan
            // 
            this.comboBoxRekeningTujuan.FormattingEnabled = true;
            this.comboBoxRekeningTujuan.Location = new System.Drawing.Point(291, 130);
            this.comboBoxRekeningTujuan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxRekeningTujuan.Name = "comboBoxRekeningTujuan";
            this.comboBoxRekeningTujuan.Size = new System.Drawing.Size(259, 24);
            this.comboBoxRekeningTujuan.TabIndex = 27;
            // 
            // comboBoxJenisTransaksi
            // 
            this.comboBoxJenisTransaksi.FormattingEnabled = true;
            this.comboBoxJenisTransaksi.Location = new System.Drawing.Point(291, 180);
            this.comboBoxJenisTransaksi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxJenisTransaksi.Name = "comboBoxJenisTransaksi";
            this.comboBoxJenisTransaksi.Size = new System.Drawing.Size(259, 24);
            this.comboBoxJenisTransaksi.TabIndex = 26;
            // 
            // textBoxNominal
            // 
            this.textBoxNominal.Location = new System.Drawing.Point(291, 82);
            this.textBoxNominal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxNominal.Name = "textBoxNominal";
            this.textBoxNominal.Size = new System.Drawing.Size(259, 22);
            this.textBoxNominal.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(156, 231);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 18);
            this.label5.TabIndex = 23;
            this.label5.Text = "Keterangan :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(125, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 18);
            this.label4.TabIndex = 22;
            this.label4.Text = "Jenis Transaksi :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(117, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 18);
            this.label3.TabIndex = 21;
            this.label3.Text = "Rekening Tujuan : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(185, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 18);
            this.label2.TabIndex = 19;
            this.label2.Text = "Nominal :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(113, 38);
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
            this.buttonKosongi.Location = new System.Drawing.Point(327, 459);
            this.buttonKosongi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonKosongi.Name = "buttonKosongi";
            this.buttonKosongi.Size = new System.Drawing.Size(203, 53);
            this.buttonKosongi.TabIndex = 48;
            this.buttonKosongi.Text = "&KOSONGI";
            this.buttonKosongi.UseVisualStyleBackColor = false;
            this.buttonKosongi.Click += new System.EventHandler(this.buttonKosongi_Click);
            // 
            // buttonTambah
            // 
            this.buttonTambah.BackColor = System.Drawing.Color.Navy;
            this.buttonTambah.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTambah.ForeColor = System.Drawing.Color.White;
            this.buttonTambah.Location = new System.Drawing.Point(12, 459);
            this.buttonTambah.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonTambah.Name = "buttonTambah";
            this.buttonTambah.Size = new System.Drawing.Size(203, 53);
            this.buttonTambah.TabIndex = 47;
            this.buttonTambah.Text = "&TAMBAH";
            this.buttonTambah.UseVisualStyleBackColor = false;
            this.buttonTambah.Click += new System.EventHandler(this.buttonTambah_Click);
            // 
            // FormTambahTransaksi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 526);
            this.Controls.Add(this.labelInbox);
            this.Controls.Add(this.buttonKeluar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonKosongi);
            this.Controls.Add(this.buttonTambah);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormTambahTransaksi";
            this.Text = "Tambah Transaksi";
            this.Load += new System.EventHandler(this.FormTambahTransaksi_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelInbox;
        private System.Windows.Forms.Button buttonKeluar;
        private System.Windows.Forms.Panel panel1;
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
        private System.Windows.Forms.ComboBox comboBoxPromo;
        private System.Windows.Forms.ComboBox comboBoxJenisTagihan;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox checkBoxTagihan;
        private System.Windows.Forms.CheckBox checkBoxPromo;
        private System.Windows.Forms.ComboBox comboBoxRekeningSumber;
    }
}