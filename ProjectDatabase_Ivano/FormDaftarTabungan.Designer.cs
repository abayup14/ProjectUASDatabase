
namespace ProjectDatabase_Ivano
{
    partial class FormDaftarTabungan
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
            this.dataGridViewTabungan = new System.Windows.Forms.DataGridView();
            this.buttonKeluar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTabungan)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Lavender;
            this.panel1.Controls.Add(this.textBoxNilaiKriteria);
            this.panel1.Controls.Add(this.comboBoxKriteria);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(11, 52);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(829, 59);
            this.panel1.TabIndex = 47;
            // 
            // textBoxNilaiKriteria
            // 
            this.textBoxNilaiKriteria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNilaiKriteria.Location = new System.Drawing.Point(477, 20);
            this.textBoxNilaiKriteria.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxNilaiKriteria.Name = "textBoxNilaiKriteria";
            this.textBoxNilaiKriteria.Size = new System.Drawing.Size(335, 24);
            this.textBoxNilaiKriteria.TabIndex = 2;
            // 
            // comboBoxKriteria
            // 
            this.comboBoxKriteria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxKriteria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxKriteria.FormattingEnabled = true;
            this.comboBoxKriteria.Items.AddRange(new object[] {
            "ID Pengguna",
            "ID Pesan",
            "Pesan",
            "Tanggal Kirim",
            "Status",
            "Tanggal Perubahan"});
            this.comboBoxKriteria.Location = new System.Drawing.Point(193, 20);
            this.comboBoxKriteria.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxKriteria.Name = "comboBoxKriteria";
            this.comboBoxKriteria.Size = new System.Drawing.Size(268, 26);
            this.comboBoxKriteria.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Cari Berdasarkan:";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Navy;
            this.label1.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(829, 39);
            this.label1.TabIndex = 46;
            this.label1.Text = "DAFTAR TABUNGAN";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridViewTabungan
            // 
            this.dataGridViewTabungan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTabungan.Location = new System.Drawing.Point(11, 115);
            this.dataGridViewTabungan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewTabungan.Name = "dataGridViewTabungan";
            this.dataGridViewTabungan.RowHeadersWidth = 51;
            this.dataGridViewTabungan.RowTemplate.Height = 24;
            this.dataGridViewTabungan.Size = new System.Drawing.Size(829, 279);
            this.dataGridViewTabungan.TabIndex = 50;
            this.dataGridViewTabungan.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTabungan_CellContentClick);
            // 
            // buttonKeluar
            // 
            this.buttonKeluar.BackColor = System.Drawing.Color.Navy;
            this.buttonKeluar.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonKeluar.ForeColor = System.Drawing.Color.White;
            this.buttonKeluar.Location = new System.Drawing.Point(639, 400);
            this.buttonKeluar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonKeluar.Name = "buttonKeluar";
            this.buttonKeluar.Size = new System.Drawing.Size(203, 53);
            this.buttonKeluar.TabIndex = 49;
            this.buttonKeluar.Text = "&KELUAR";
            this.buttonKeluar.UseVisualStyleBackColor = false;
            // 
            // FormDaftarTabungan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 462);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewTabungan);
            this.Controls.Add(this.buttonKeluar);
            this.Name = "FormDaftarTabungan";
            this.Text = "Daftar Tabungan";
            this.Load += new System.EventHandler(this.FormDaftarTabungan_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTabungan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxNilaiKriteria;
        private System.Windows.Forms.ComboBox comboBoxKriteria;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.DataGridView dataGridViewTabungan;
        private System.Windows.Forms.Button buttonKeluar;
    }
}