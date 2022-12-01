
namespace ProjectDatabase_Ivano
{
    partial class FormUbahInbox
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
            this.textBoxIdPesan = new System.Windows.Forms.TextBox();
            this.textBoxPesan = new System.Windows.Forms.TextBox();
            this.dateTimePickerTanggal_Kirim = new System.Windows.Forms.DateTimePicker();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.dateTimePickertgl_Perubahan = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // textBoxIdPesan
            // 
            this.textBoxIdPesan.Location = new System.Drawing.Point(74, 35);
            this.textBoxIdPesan.Name = "textBoxIdPesan";
            this.textBoxIdPesan.Size = new System.Drawing.Size(100, 22);
            this.textBoxIdPesan.TabIndex = 0;
            // 
            // textBoxPesan
            // 
            this.textBoxPesan.Location = new System.Drawing.Point(52, 91);
            this.textBoxPesan.Name = "textBoxPesan";
            this.textBoxPesan.Size = new System.Drawing.Size(100, 22);
            this.textBoxPesan.TabIndex = 1;
            // 
            // dateTimePickerTanggal_Kirim
            // 
            this.dateTimePickerTanggal_Kirim.Location = new System.Drawing.Point(-27, 186);
            this.dateTimePickerTanggal_Kirim.Name = "dateTimePickerTanggal_Kirim";
            this.dateTimePickerTanggal_Kirim.Size = new System.Drawing.Size(200, 22);
            this.dateTimePickerTanggal_Kirim.TabIndex = 2;
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.Location = new System.Drawing.Point(350, 214);
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.Size = new System.Drawing.Size(100, 22);
            this.textBoxStatus.TabIndex = 3;
            // 
            // dateTimePickertgl_Perubahan
            // 
            this.dateTimePickertgl_Perubahan.Location = new System.Drawing.Point(98, 295);
            this.dateTimePickertgl_Perubahan.Name = "dateTimePickertgl_Perubahan";
            this.dateTimePickertgl_Perubahan.Size = new System.Drawing.Size(200, 22);
            this.dateTimePickertgl_Perubahan.TabIndex = 4;
            // 
            // FormUbahInbox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dateTimePickertgl_Perubahan);
            this.Controls.Add(this.textBoxStatus);
            this.Controls.Add(this.dateTimePickerTanggal_Kirim);
            this.Controls.Add(this.textBoxPesan);
            this.Controls.Add(this.textBoxIdPesan);
            this.Name = "FormUbahInbox";
            this.Text = "Ubah Inbox";
            this.Load += new System.EventHandler(this.FormUbahInbox_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox textBoxIdPesan;
        public System.Windows.Forms.TextBox textBoxPesan;
        public System.Windows.Forms.DateTimePicker dateTimePickerTanggal_Kirim;
        public System.Windows.Forms.TextBox textBoxStatus;
        public System.Windows.Forms.DateTimePicker dateTimePickertgl_Perubahan;
    }
}