
namespace ProjectDatabase_Ivano
{
    partial class FormUbahJenisTransaksi
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxNamaJenisTransaksi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxKodeJenisTransaksi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonKosongi = new System.Windows.Forms.Button();
            this.buttonKeluar = new System.Windows.Forms.Button();
            this.buttonTambah = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Navy;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(12, 11);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(680, 82);
            this.panel2.TabIndex = 49;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(154, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(389, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "UBAH JENIS TRANSAKSI";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Lavender;
            this.panel1.Controls.Add(this.textBoxNamaJenisTransaksi);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBoxKodeJenisTransaksi);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(12, 108);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(680, 151);
            this.panel1.TabIndex = 48;
            // 
            // textBoxNamaJenisTransaksi
            // 
            this.textBoxNamaJenisTransaksi.Location = new System.Drawing.Point(174, 85);
            this.textBoxNamaJenisTransaksi.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxNamaJenisTransaksi.Name = "textBoxNamaJenisTransaksi";
            this.textBoxNamaJenisTransaksi.Size = new System.Drawing.Size(480, 22);
            this.textBoxNamaJenisTransaksi.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(31, 88);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nama Transaksi:";
            // 
            // textBoxKodeJenisTransaksi
            // 
            this.textBoxKodeJenisTransaksi.Location = new System.Drawing.Point(174, 41);
            this.textBoxKodeJenisTransaksi.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxKodeJenisTransaksi.Name = "textBoxKodeJenisTransaksi";
            this.textBoxKodeJenisTransaksi.Size = new System.Drawing.Size(132, 22);
            this.textBoxKodeJenisTransaksi.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(35, 42);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Kode Transaksi:";
            // 
            // buttonKosongi
            // 
            this.buttonKosongi.BackColor = System.Drawing.Color.Navy;
            this.buttonKosongi.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonKosongi.ForeColor = System.Drawing.Color.White;
            this.buttonKosongi.Location = new System.Drawing.Point(251, 280);
            this.buttonKosongi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonKosongi.Name = "buttonKosongi";
            this.buttonKosongi.Size = new System.Drawing.Size(203, 53);
            this.buttonKosongi.TabIndex = 52;
            this.buttonKosongi.Text = "&KOSONGI";
            this.buttonKosongi.UseVisualStyleBackColor = false;
            this.buttonKosongi.Click += new System.EventHandler(this.buttonKosongi_Click);
            // 
            // buttonKeluar
            // 
            this.buttonKeluar.BackColor = System.Drawing.Color.Navy;
            this.buttonKeluar.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonKeluar.ForeColor = System.Drawing.Color.White;
            this.buttonKeluar.Location = new System.Drawing.Point(489, 280);
            this.buttonKeluar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonKeluar.Name = "buttonKeluar";
            this.buttonKeluar.Size = new System.Drawing.Size(203, 53);
            this.buttonKeluar.TabIndex = 51;
            this.buttonKeluar.Text = "&KELUAR";
            this.buttonKeluar.UseVisualStyleBackColor = false;
            this.buttonKeluar.Click += new System.EventHandler(this.buttonKeluar_Click);
            // 
            // buttonTambah
            // 
            this.buttonTambah.BackColor = System.Drawing.Color.Navy;
            this.buttonTambah.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTambah.ForeColor = System.Drawing.Color.White;
            this.buttonTambah.Location = new System.Drawing.Point(12, 280);
            this.buttonTambah.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonTambah.Name = "buttonTambah";
            this.buttonTambah.Size = new System.Drawing.Size(203, 53);
            this.buttonTambah.TabIndex = 50;
            this.buttonTambah.Text = "&UBAH";
            this.buttonTambah.UseVisualStyleBackColor = false;
            this.buttonTambah.Click += new System.EventHandler(this.buttonTambah_Click);
            // 
            // FormUbahJenisTransaksi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 349);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonKosongi);
            this.Controls.Add(this.buttonKeluar);
            this.Controls.Add(this.buttonTambah);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormUbahJenisTransaksi";
            this.Text = "Ubah Jenis Transaksi";
            this.Load += new System.EventHandler(this.FormUbahJenisTransaksi_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.TextBox textBoxNamaJenisTransaksi;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox textBoxKodeJenisTransaksi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonKosongi;
        private System.Windows.Forms.Button buttonKeluar;
        private System.Windows.Forms.Button buttonTambah;
    }
}