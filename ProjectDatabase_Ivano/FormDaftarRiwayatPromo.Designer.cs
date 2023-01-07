namespace ProjectDatabase_Ivano
{
    partial class FormDaftarRiwayatPromo
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxNilaiKriteria = new System.Windows.Forms.TextBox();
            this.comboBoxKriteria = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonKeluar = new System.Windows.Forms.Button();
            this.buttonTambah = new System.Windows.Forms.Button();
            this.dataGridViewRiwayatPromo = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRiwayatPromo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Lavender;
            this.panel1.Controls.Add(this.textBoxNilaiKriteria);
            this.panel1.Controls.Add(this.comboBoxKriteria);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(10, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(910, 66);
            this.panel1.TabIndex = 40;
            // 
            // textBoxNilaiKriteria
            // 
            this.textBoxNilaiKriteria.Location = new System.Drawing.Point(440, 21);
            this.textBoxNilaiKriteria.Name = "textBoxNilaiKriteria";
            this.textBoxNilaiKriteria.Size = new System.Drawing.Size(460, 20);
            this.textBoxNilaiKriteria.TabIndex = 3;
            // 
            // comboBoxKriteria
            // 
            this.comboBoxKriteria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxKriteria.FormattingEnabled = true;
            this.comboBoxKriteria.Items.AddRange(new object[] {
            "Id Employee",
            "Nama Depan",
            "Nama Keluarga",
            "Nama Position",
            "NIK",
            "Email",
            "Tanggal Buat",
            "Tanggal Perubahan"});
            this.comboBoxKriteria.Location = new System.Drawing.Point(131, 22);
            this.comboBoxKriteria.Name = "comboBoxKriteria";
            this.comboBoxKriteria.Size = new System.Drawing.Size(291, 21);
            this.comboBoxKriteria.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cari Berdasarkan:";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Navy;
            this.label1.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(910, 32);
            this.label1.TabIndex = 44;
            this.label1.Text = "DAFTAR RIWAYAT PROMO";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonKeluar
            // 
            this.buttonKeluar.BackColor = System.Drawing.Color.Navy;
            this.buttonKeluar.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonKeluar.ForeColor = System.Drawing.Color.White;
            this.buttonKeluar.Location = new System.Drawing.Point(769, 415);
            this.buttonKeluar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonKeluar.Name = "buttonKeluar";
            this.buttonKeluar.Size = new System.Drawing.Size(151, 43);
            this.buttonKeluar.TabIndex = 43;
            this.buttonKeluar.Text = "&KELUAR";
            this.buttonKeluar.UseVisualStyleBackColor = false;
            // 
            // buttonTambah
            // 
            this.buttonTambah.BackColor = System.Drawing.Color.Navy;
            this.buttonTambah.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTambah.ForeColor = System.Drawing.Color.White;
            this.buttonTambah.Location = new System.Drawing.Point(9, 415);
            this.buttonTambah.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonTambah.Name = "buttonTambah";
            this.buttonTambah.Size = new System.Drawing.Size(151, 43);
            this.buttonTambah.TabIndex = 42;
            this.buttonTambah.Text = "&TAMBAH";
            this.buttonTambah.UseVisualStyleBackColor = false;
            // 
            // dataGridViewRiwayatPromo
            // 
            this.dataGridViewRiwayatPromo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRiwayatPromo.Location = new System.Drawing.Point(10, 121);
            this.dataGridViewRiwayatPromo.Name = "dataGridViewRiwayatPromo";
            this.dataGridViewRiwayatPromo.RowHeadersWidth = 51;
            this.dataGridViewRiwayatPromo.Size = new System.Drawing.Size(910, 287);
            this.dataGridViewRiwayatPromo.TabIndex = 41;
            // 
            // FormDaftarRiwayatPromo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 466);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonKeluar);
            this.Controls.Add(this.buttonTambah);
            this.Controls.Add(this.dataGridViewRiwayatPromo);
            this.Name = "FormDaftarRiwayatPromo";
            this.Text = "FormDaftarRiwayatPromo";
            this.Load += new System.EventHandler(this.FormDaftarRiwayatPromo_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRiwayatPromo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxNilaiKriteria;
        private System.Windows.Forms.ComboBox comboBoxKriteria;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonKeluar;
        private System.Windows.Forms.Button buttonTambah;
        public System.Windows.Forms.DataGridView dataGridViewRiwayatPromo;
    }
}