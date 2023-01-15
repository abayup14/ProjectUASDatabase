namespace ProjectDatabase_Ivano
{
    partial class FormLogin
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
            this.checkBoxTunjukkan = new System.Windows.Forms.CheckBox();
            this.linkLabelDaftarPengguna = new System.Windows.Forms.LinkLabel();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxEmailNomorTelepon = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonKeluar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Lavender;
            this.panel1.Controls.Add(this.buttonKeluar);
            this.panel1.Controls.Add(this.checkBoxTunjukkan);
            this.panel1.Controls.Add(this.linkLabelDaftarPengguna);
            this.panel1.Controls.Add(this.buttonLogin);
            this.panel1.Controls.Add(this.textBoxPassword);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBoxEmailNomorTelepon);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(6, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(818, 238);
            this.panel1.TabIndex = 1;
            // 
            // checkBoxTunjukkan
            // 
            this.checkBoxTunjukkan.AutoSize = true;
            this.checkBoxTunjukkan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxTunjukkan.Location = new System.Drawing.Point(688, 62);
            this.checkBoxTunjukkan.Name = "checkBoxTunjukkan";
            this.checkBoxTunjukkan.Size = new System.Drawing.Size(107, 22);
            this.checkBoxTunjukkan.TabIndex = 25;
            this.checkBoxTunjukkan.Text = "Tunjukkan";
            this.checkBoxTunjukkan.UseVisualStyleBackColor = true;
            this.checkBoxTunjukkan.CheckedChanged += new System.EventHandler(this.checkBoxTunjukkan_CheckedChanged);
            // 
            // linkLabelDaftarPengguna
            // 
            this.linkLabelDaftarPengguna.ActiveLinkColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.linkLabelDaftarPengguna.AutoSize = true;
            this.linkLabelDaftarPengguna.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelDaftarPengguna.LinkColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.linkLabelDaftarPengguna.Location = new System.Drawing.Point(201, 193);
            this.linkLabelDaftarPengguna.Name = "linkLabelDaftarPengguna";
            this.linkLabelDaftarPengguna.Size = new System.Drawing.Size(362, 25);
            this.linkLabelDaftarPengguna.TabIndex = 23;
            this.linkLabelDaftarPengguna.TabStop = true;
            this.linkLabelDaftarPengguna.Text = "Belum Bergabung? Ayo Daftar Disini";
            this.linkLabelDaftarPengguna.VisitedLinkColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.linkLabelDaftarPengguna.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelDaftarPengguna_LinkClicked);
            // 
            // buttonLogin
            // 
            this.buttonLogin.BackColor = System.Drawing.Color.Navy;
            this.buttonLogin.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogin.ForeColor = System.Drawing.Color.White;
            this.buttonLogin.Location = new System.Drawing.Point(206, 116);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(177, 53);
            this.buttonLogin.TabIndex = 21;
            this.buttonLogin.Text = "&LOGIN";
            this.buttonLogin.UseVisualStyleBackColor = false;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPassword.Location = new System.Drawing.Point(206, 60);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(465, 24);
            this.textBoxPassword.TabIndex = 6;
            this.textBoxPassword.Enter += new System.EventHandler(this.textBoxPassword_Enter);
            this.textBoxPassword.Leave += new System.EventHandler(this.textBoxPassword_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(91, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "Password :";
            // 
            // textBoxEmailNomorTelepon
            // 
            this.textBoxEmailNomorTelepon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxEmailNomorTelepon.Location = new System.Drawing.Point(206, 17);
            this.textBoxEmailNomorTelepon.Name = "textBoxEmailNomorTelepon";
            this.textBoxEmailNomorTelepon.Size = new System.Drawing.Size(465, 24);
            this.textBoxEmailNomorTelepon.TabIndex = 4;
            this.textBoxEmailNomorTelepon.Enter += new System.EventHandler(this.textBoxEmailNomorTelepon_Enter);
            this.textBoxEmailNomorTelepon.Leave += new System.EventHandler(this.textBoxEmailNomorTelepon_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Email/No. Telepon :";
            // 
            // buttonKeluar
            // 
            this.buttonKeluar.BackColor = System.Drawing.Color.Navy;
            this.buttonKeluar.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonKeluar.ForeColor = System.Drawing.Color.White;
            this.buttonKeluar.Location = new System.Drawing.Point(494, 116);
            this.buttonKeluar.Name = "buttonKeluar";
            this.buttonKeluar.Size = new System.Drawing.Size(177, 53);
            this.buttonKeluar.TabIndex = 26;
            this.buttonKeluar.Text = "&KELUAR";
            this.buttonKeluar.UseVisualStyleBackColor = false;
            this.buttonKeluar.Click += new System.EventHandler(this.buttonKeluar_Click_1);
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 254);
            this.Controls.Add(this.panel1);
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login Pengguna DiBa";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkLabelDaftarPengguna;
        private System.Windows.Forms.CheckBox checkBoxTunjukkan;
        public System.Windows.Forms.TextBox textBoxPassword;
        public System.Windows.Forms.TextBox textBoxEmailNomorTelepon;
        private System.Windows.Forms.Button buttonKeluar;
    }
}