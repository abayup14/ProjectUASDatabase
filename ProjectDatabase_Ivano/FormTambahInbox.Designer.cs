﻿namespace ProjectDatabase_Ivano
{
    partial class FormTambahInbox
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxPengguna = new System.Windows.Forms.ComboBox();
            this.buttonKirim = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.labelNama = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelInbox
            // 
            this.labelInbox.BackColor = System.Drawing.Color.Navy;
            this.labelInbox.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInbox.ForeColor = System.Drawing.Color.Transparent;
            this.labelInbox.Location = new System.Drawing.Point(17, 9);
            this.labelInbox.Name = "labelInbox";
            this.labelInbox.Size = new System.Drawing.Size(716, 39);
            this.labelInbox.TabIndex = 38;
            this.labelInbox.Text = "TAMBAH INBOX";
            this.labelInbox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxPesan
            // 
            this.textBoxPesan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPesan.Location = new System.Drawing.Point(236, 144);
            this.textBoxPesan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxPesan.Multiline = true;
            this.textBoxPesan.Name = "textBoxPesan";
            this.textBoxPesan.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxPesan.Size = new System.Drawing.Size(425, 93);
            this.textBoxPesan.TabIndex = 8;
            // 
            // buttonKeluar
            // 
            this.buttonKeluar.BackColor = System.Drawing.Color.Navy;
            this.buttonKeluar.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonKeluar.ForeColor = System.Drawing.Color.White;
            this.buttonKeluar.Location = new System.Drawing.Point(530, 347);
            this.buttonKeluar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonKeluar.Name = "buttonKeluar";
            this.buttonKeluar.Size = new System.Drawing.Size(203, 53);
            this.buttonKeluar.TabIndex = 41;
            this.buttonKeluar.Text = "&KELUAR";
            this.buttonKeluar.UseVisualStyleBackColor = false;
            this.buttonKeluar.Click += new System.EventHandler(this.buttonKeluar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(133, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 18);
            this.label5.TabIndex = 7;
            this.label5.Text = "Pesan : ";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Lavender;
            this.panel1.Controls.Add(this.labelNama);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.comboBoxPengguna);
            this.panel1.Controls.Add(this.textBoxPesan);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(17, 64);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(716, 264);
            this.panel1.TabIndex = 39;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(90, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 18);
            this.label1.TabIndex = 18;
            this.label1.Text = "ID Pengguna :";
            // 
            // comboBoxPengguna
            // 
            this.comboBoxPengguna.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPengguna.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxPengguna.FormattingEnabled = true;
            this.comboBoxPengguna.Location = new System.Drawing.Point(236, 42);
            this.comboBoxPengguna.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxPengguna.Name = "comboBoxPengguna";
            this.comboBoxPengguna.Size = new System.Drawing.Size(425, 26);
            this.comboBoxPengguna.TabIndex = 17;
            this.comboBoxPengguna.SelectedIndexChanged += new System.EventHandler(this.comboBoxPengguna_SelectedIndexChanged);
            // 
            // buttonKirim
            // 
            this.buttonKirim.BackColor = System.Drawing.Color.Navy;
            this.buttonKirim.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonKirim.ForeColor = System.Drawing.Color.White;
            this.buttonKirim.Location = new System.Drawing.Point(17, 347);
            this.buttonKirim.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonKirim.Name = "buttonKirim";
            this.buttonKirim.Size = new System.Drawing.Size(203, 53);
            this.buttonKirim.TabIndex = 42;
            this.buttonKirim.Text = "&KIRIM";
            this.buttonKirim.UseVisualStyleBackColor = false;
            this.buttonKirim.Click += new System.EventHandler(this.buttonKirim_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(141, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 18);
            this.label2.TabIndex = 19;
            this.label2.Text = "Nama :";
            // 
            // labelNama
            // 
            this.labelNama.AutoSize = true;
            this.labelNama.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNama.Location = new System.Drawing.Point(233, 99);
            this.labelNama.Name = "labelNama";
            this.labelNama.Size = new System.Drawing.Size(62, 18);
            this.labelNama.TabIndex = 20;
            this.labelNama.Text = "Nama :";
            // 
            // FormTambahInbox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 411);
            this.Controls.Add(this.buttonKirim);
            this.Controls.Add(this.labelInbox);
            this.Controls.Add(this.buttonKeluar);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormTambahInbox";
            this.Text = "Tambah Inbox";
            this.Load += new System.EventHandler(this.FormTambahInbox_Load);
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
        private System.Windows.Forms.Button buttonKirim;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxPengguna;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelNama;
    }
}