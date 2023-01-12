using DiBa_LIB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectDatabase_Ivano
{
    public partial class FormMasukkanPIN : Form
    {
        FormTabunganPengguna formTabunganPengguna;

        public Pengguna pengguna;

        public FormMasukkanPIN()
        {
            InitializeComponent();
        }

        private void FormMasukkanPIN_Load(object sender, EventArgs e)
        {
            ActiveControl = label1;

            textBoxPIN.Text = "Wajib diisi";
            textBoxPIN.Font = new Font(textBoxPIN.Font, FontStyle.Italic);
            textBoxPIN.ForeColor = Color.Gray;
            textBoxPIN.UseSystemPasswordChar = false;

            formTabunganPengguna = (FormTabunganPengguna)this.Owner;

            pengguna = formTabunganPengguna.p;
        }

        private void checkBoxTunjukkan_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTunjukkan.Checked == true)
            {
                textBoxPIN.UseSystemPasswordChar = false;
            }
            else
            {
                if (textBoxPIN.Text == "Wajib diisi")
                {
                    textBoxPIN.UseSystemPasswordChar = false;
                }
                else
                {
                    textBoxPIN.UseSystemPasswordChar = true;
                }
            }
        }

        private void textBoxPIN_Enter(object sender, EventArgs e)
        {
            if (textBoxPIN.Text == "Wajib diisi")
            {
                textBoxPIN.Text = "";
                textBoxPIN.Font = new Font(textBoxPIN.Font, FontStyle.Regular);
                textBoxPIN.ForeColor = Color.Black;
                textBoxPIN.UseSystemPasswordChar = true;
            }
        }

        private void textBoxPIN_Leave(object sender, EventArgs e)
        {
            if (textBoxPIN.Text == "")
            {
                textBoxPIN.Text = "Wajib diisi";
                textBoxPIN.Font = new Font(textBoxPIN.Font, FontStyle.Italic);
                textBoxPIN.ForeColor = Color.Gray;
                textBoxPIN.UseSystemPasswordChar = false;
            }
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi k = new Koneksi();

                if (textBoxPIN.Text == "Wajib diisi")
                {
                    MessageBox.Show("Anda harus mengisi PIN anda untuk melanjutkan aktivitas di aplikasi ini", "Informasi");
                }
                else
                {
                    DialogResult hasil = MessageBox.Show("Apakah anda yakin dengan PIN yang anda masukkan?", "Konfirmasi",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (hasil == DialogResult.Yes)
                    {
                        Pengguna.UbahPIN(pengguna, textBoxPIN.Text, k);

                        MessageBox.Show("Berhasil melakukan aktivitas", "Informasi");

                        Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal melakukan aktivitas. Pesan kesalahan: " + ex.Message, "Informasi");
            }
        }
    }
}
