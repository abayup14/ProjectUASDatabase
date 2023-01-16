namespace ProjectDatabase_Ivano
{
    partial class FormTambahPromo
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
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxNominalDiskon = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxNamaPromo = new System.Windows.Forms.TextBox();
            this.textBoxKeterangan = new System.Windows.Forms.TextBox();
            this.dateTimePickerTglAkhir = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerTglAwal = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
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
            this.labelInbox.Location = new System.Drawing.Point(15, 11);
            this.labelInbox.Name = "labelInbox";
            this.labelInbox.Size = new System.Drawing.Size(792, 53);
            this.labelInbox.TabIndex = 0;
            this.labelInbox.Text = "TAMBAH PROMO";
            this.labelInbox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonKeluar
            // 
            this.buttonKeluar.BackColor = System.Drawing.Color.Navy;
            this.buttonKeluar.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonKeluar.ForeColor = System.Drawing.Color.White;
            this.buttonKeluar.Location = new System.Drawing.Point(604, 448);
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
            this.label5.Location = new System.Drawing.Point(91, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 18);
            this.label5.TabIndex = 2;
            this.label5.Text = "Tanggal Awal : ";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Lavender;
            this.panel1.Controls.Add(this.textBoxNominalDiskon);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textBoxNamaPromo);
            this.panel1.Controls.Add(this.textBoxKeterangan);
            this.panel1.Controls.Add(this.dateTimePickerTglAkhir);
            this.panel1.Controls.Add(this.dateTimePickerTglAwal);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(15, 91);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(792, 336);
            this.panel1.TabIndex = 1;
            // 
            // textBoxNominalDiskon
            // 
            this.textBoxNominalDiskon.Location = new System.Drawing.Point(556, 96);
            this.textBoxNominalDiskon.Name = "textBoxNominalDiskon";
            this.textBoxNominalDiskon.Size = new System.Drawing.Size(202, 22);
            this.textBoxNominalDiskon.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(553, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 18);
            this.label4.TabIndex = 8;
            this.label4.Text = "Nominal Diskon :";
            // 
            // textBoxNamaPromo
            // 
            this.textBoxNamaPromo.Location = new System.Drawing.Point(259, 57);
            this.textBoxNamaPromo.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxNamaPromo.Name = "textBoxNamaPromo";
            this.textBoxNamaPromo.Size = new System.Drawing.Size(265, 22);
            this.textBoxNamaPromo.TabIndex = 1;
            // 
            // textBoxKeterangan
            // 
            this.textBoxKeterangan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxKeterangan.Location = new System.Drawing.Point(259, 192);
            this.textBoxKeterangan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxKeterangan.Multiline = true;
            this.textBoxKeterangan.Name = "textBoxKeterangan";
            this.textBoxKeterangan.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxKeterangan.Size = new System.Drawing.Size(425, 93);
            this.textBoxKeterangan.TabIndex = 7;
            // 
            // dateTimePickerTglAkhir
            // 
            this.dateTimePickerTglAkhir.Location = new System.Drawing.Point(259, 148);
            this.dateTimePickerTglAkhir.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePickerTglAkhir.Name = "dateTimePickerTglAkhir";
            this.dateTimePickerTglAkhir.Size = new System.Drawing.Size(265, 22);
            this.dateTimePickerTglAkhir.TabIndex = 5;
            // 
            // dateTimePickerTglAwal
            // 
            this.dateTimePickerTglAwal.Location = new System.Drawing.Point(259, 100);
            this.dateTimePickerTglAwal.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePickerTglAwal.Name = "dateTimePickerTglAwal";
            this.dateTimePickerTglAwal.Size = new System.Drawing.Size(265, 22);
            this.dateTimePickerTglAwal.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(107, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "Keterangan : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(88, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Tanggal Akhir : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(141, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nama :";
            // 
            // buttonKosongi
            // 
            this.buttonKosongi.BackColor = System.Drawing.Color.Navy;
            this.buttonKosongi.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonKosongi.ForeColor = System.Drawing.Color.White;
            this.buttonKosongi.Location = new System.Drawing.Point(317, 448);
            this.buttonKosongi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonKosongi.Name = "buttonKosongi";
            this.buttonKosongi.Size = new System.Drawing.Size(203, 53);
            this.buttonKosongi.TabIndex = 3;
            this.buttonKosongi.Text = "&KOSONGI";
            this.buttonKosongi.UseVisualStyleBackColor = false;
            this.buttonKosongi.Click += new System.EventHandler(this.buttonKosongi_Click);
            // 
            // buttonTambah
            // 
            this.buttonTambah.BackColor = System.Drawing.Color.Navy;
            this.buttonTambah.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTambah.ForeColor = System.Drawing.Color.White;
            this.buttonTambah.Location = new System.Drawing.Point(15, 448);
            this.buttonTambah.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonTambah.Name = "buttonTambah";
            this.buttonTambah.Size = new System.Drawing.Size(203, 53);
            this.buttonTambah.TabIndex = 2;
            this.buttonTambah.Text = "&TAMBAH";
            this.buttonTambah.UseVisualStyleBackColor = false;
            this.buttonTambah.Click += new System.EventHandler(this.buttonTambah_Click);
            // 
            // FormTambahPromo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 514);
            this.Controls.Add(this.labelInbox);
            this.Controls.Add(this.buttonKeluar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonKosongi);
            this.Controls.Add(this.buttonTambah);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormTambahPromo";
            this.Text = "Tambah Promo";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelInbox;
        private System.Windows.Forms.Button buttonKeluar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonKosongi;
        private System.Windows.Forms.Button buttonTambah;
        private System.Windows.Forms.DateTimePicker dateTimePickerTglAkhir;
        private System.Windows.Forms.DateTimePicker dateTimePickerTglAwal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxNamaPromo;
        private System.Windows.Forms.TextBox textBoxKeterangan;
        private System.Windows.Forms.TextBox textBoxNominalDiskon;
        private System.Windows.Forms.Label label4;
    }
}