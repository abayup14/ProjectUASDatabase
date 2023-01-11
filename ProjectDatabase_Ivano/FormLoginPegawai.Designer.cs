namespace ProjectDatabase_Ivano
{
    partial class FormLoginPegawai
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
            this.buttonKeluar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBoxTunjukkan = new System.Windows.Forms.CheckBox();
            this.linkLabelLupaPassword = new System.Windows.Forms.LinkLabel();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxEmailNomorTelepon = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonKeluar
            // 
            this.buttonKeluar.BackColor = System.Drawing.Color.Navy;
            this.buttonKeluar.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonKeluar.ForeColor = System.Drawing.Color.White;
            this.buttonKeluar.Location = new System.Drawing.Point(494, 133);
            this.buttonKeluar.Name = "buttonKeluar";
            this.buttonKeluar.Size = new System.Drawing.Size(177, 53);
            this.buttonKeluar.TabIndex = 22;
            this.buttonKeluar.Text = "KELUAR";
            this.buttonKeluar.UseVisualStyleBackColor = false;
            this.buttonKeluar.Click += new System.EventHandler(this.buttonKeluar_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Lavender;
            this.panel1.Controls.Add(this.checkBoxTunjukkan);
            this.panel1.Controls.Add(this.linkLabelLupaPassword);
            this.panel1.Controls.Add(this.buttonKeluar);
            this.panel1.Controls.Add(this.buttonLogin);
            this.panel1.Controls.Add(this.textBoxPassword);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBoxEmailNomorTelepon);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(9, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(818, 208);
            this.panel1.TabIndex = 2;
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
            // linkLabelLupaPassword
            // 
            this.linkLabelLupaPassword.ActiveLinkColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.linkLabelLupaPassword.AutoSize = true;
            this.linkLabelLupaPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelLupaPassword.LinkColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.linkLabelLupaPassword.Location = new System.Drawing.Point(203, 97);
            this.linkLabelLupaPassword.Name = "linkLabelLupaPassword";
            this.linkLabelLupaPassword.Size = new System.Drawing.Size(202, 18);
            this.linkLabelLupaPassword.TabIndex = 24;
            this.linkLabelLupaPassword.TabStop = true;
            this.linkLabelLupaPassword.Text = "Lupa Password? Reset Disini";
            this.linkLabelLupaPassword.VisitedLinkColor = System.Drawing.SystemColors.ActiveCaptionText;
            // 
            // buttonLogin
            // 
            this.buttonLogin.BackColor = System.Drawing.Color.Navy;
            this.buttonLogin.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogin.ForeColor = System.Drawing.Color.White;
            this.buttonLogin.Location = new System.Drawing.Point(206, 133);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(177, 53);
            this.buttonLogin.TabIndex = 21;
            this.buttonLogin.Text = "LOGIN";
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
            // FormLoginPegawai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 229);
            this.Controls.Add(this.panel1);
            this.Name = "FormLoginPegawai";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login Pegawai";
            this.Load += new System.EventHandler(this.FormLoginPegawai_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonKeluar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkBoxTunjukkan;
        private System.Windows.Forms.LinkLabel linkLabelLupaPassword;
        private System.Windows.Forms.Button buttonLogin;
        public System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox textBoxEmailNomorTelepon;
        private System.Windows.Forms.Label label2;
    }
}