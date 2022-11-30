
namespace ProjectDatabase_Ivano
{
    partial class FormUtama
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.penggunaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jenisTransaksiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PositionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transaksiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.topUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transferToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.daftarNomorRekeningToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.riwayatTransaksiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keluarSistemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label4 = new System.Windows.Forms.Label();
            this.labelNama = new System.Windows.Forms.Label();
            this.labelKode = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.employeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuToolStripMenuItem,
            this.transaksiToolStripMenuItem,
            this.keluarSistemToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(979, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MenuToolStripMenuItem
            // 
            this.MenuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.penggunaToolStripMenuItem,
            this.jenisTransaksiToolStripMenuItem,
            this.PositionToolStripMenuItem,
            this.employeeToolStripMenuItem});
            this.MenuToolStripMenuItem.Name = "MenuToolStripMenuItem";
            this.MenuToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
            this.MenuToolStripMenuItem.Text = "Master";
            // 
            // penggunaToolStripMenuItem
            // 
            this.penggunaToolStripMenuItem.Name = "penggunaToolStripMenuItem";
            this.penggunaToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.penggunaToolStripMenuItem.Text = "Pengguna";
            this.penggunaToolStripMenuItem.Click += new System.EventHandler(this.penggunaToolStripMenuItem_Click);
            // 
            // jenisTransaksiToolStripMenuItem
            // 
            this.jenisTransaksiToolStripMenuItem.Name = "jenisTransaksiToolStripMenuItem";
            this.jenisTransaksiToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.jenisTransaksiToolStripMenuItem.Text = "Jenis Transaksi";
            this.jenisTransaksiToolStripMenuItem.Click += new System.EventHandler(this.jenisTransaksiToolStripMenuItem_Click);
            // 
            // PositionToolStripMenuItem
            // 
            this.PositionToolStripMenuItem.Name = "PositionToolStripMenuItem";
            this.PositionToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.PositionToolStripMenuItem.Text = "Position";
            this.PositionToolStripMenuItem.Click += new System.EventHandler(this.PositionToolStripMenuItem_Click);
            // 
            // transaksiToolStripMenuItem
            // 
            this.transaksiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.topUpToolStripMenuItem,
            this.transferToolStripMenuItem,
            this.daftarNomorRekeningToolStripMenuItem,
            this.riwayatTransaksiToolStripMenuItem});
            this.transaksiToolStripMenuItem.Name = "transaksiToolStripMenuItem";
            this.transaksiToolStripMenuItem.Size = new System.Drawing.Size(82, 24);
            this.transaksiToolStripMenuItem.Text = "Transaksi";
            // 
            // topUpToolStripMenuItem
            // 
            this.topUpToolStripMenuItem.Name = "topUpToolStripMenuItem";
            this.topUpToolStripMenuItem.Size = new System.Drawing.Size(250, 26);
            this.topUpToolStripMenuItem.Text = "Top Up";
            // 
            // transferToolStripMenuItem
            // 
            this.transferToolStripMenuItem.Name = "transferToolStripMenuItem";
            this.transferToolStripMenuItem.Size = new System.Drawing.Size(250, 26);
            this.transferToolStripMenuItem.Text = "Transfer";
            // 
            // daftarNomorRekeningToolStripMenuItem
            // 
            this.daftarNomorRekeningToolStripMenuItem.Name = "daftarNomorRekeningToolStripMenuItem";
            this.daftarNomorRekeningToolStripMenuItem.Size = new System.Drawing.Size(250, 26);
            this.daftarNomorRekeningToolStripMenuItem.Text = "Daftar Nomor Rekening";
            // 
            // riwayatTransaksiToolStripMenuItem
            // 
            this.riwayatTransaksiToolStripMenuItem.Name = "riwayatTransaksiToolStripMenuItem";
            this.riwayatTransaksiToolStripMenuItem.Size = new System.Drawing.Size(250, 26);
            this.riwayatTransaksiToolStripMenuItem.Text = "Riwayat Transaksi";
            // 
            // keluarSistemToolStripMenuItem
            // 
            this.keluarSistemToolStripMenuItem.Name = "keluarSistemToolStripMenuItem";
            this.keluarSistemToolStripMenuItem.Size = new System.Drawing.Size(113, 24);
            this.keluarSistemToolStripMenuItem.Text = "Keluar Sistem";
            this.keluarSistemToolStripMenuItem.Click += new System.EventHandler(this.keluarSistemToolStripMenuItem_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(700, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "-";
            // 
            // labelNama
            // 
            this.labelNama.AutoSize = true;
            this.labelNama.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNama.Location = new System.Drawing.Point(721, 9);
            this.labelNama.Name = "labelNama";
            this.labelNama.Size = new System.Drawing.Size(49, 20);
            this.labelNama.TabIndex = 7;
            this.labelNama.Text = "Nama";
            // 
            // labelKode
            // 
            this.labelKode.AutoSize = true;
            this.labelKode.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelKode.Location = new System.Drawing.Point(593, 9);
            this.labelKode.Name = "labelKode";
            this.labelKode.Size = new System.Drawing.Size(44, 20);
            this.labelKode.TabIndex = 6;
            this.labelKode.Text = "Kode";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(442, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Anda login sebagai :";
            // 
            // employeeToolStripMenuItem
            // 
            this.employeeToolStripMenuItem.Name = "employeeToolStripMenuItem";
            this.employeeToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.employeeToolStripMenuItem.Text = "Employee";
            this.employeeToolStripMenuItem.Click += new System.EventHandler(this.employeeToolStripMenuItem_Click);
            // 
            // FormUtama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 526);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelNama);
            this.Controls.Add(this.labelKode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormUtama";
            this.Text = "Digital Bank!";
            this.Load += new System.EventHandler(this.FormUtama_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem penggunaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jenisTransaksiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PositionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transaksiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem topUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transferToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem daftarNomorRekeningToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem riwayatTransaksiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keluarSistemToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelNama;
        private System.Windows.Forms.Label labelKode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem employeeToolStripMenuItem;
    }
}

