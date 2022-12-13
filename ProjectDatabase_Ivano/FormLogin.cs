using DiBa_LIB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectDatabase_Ivano
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi koneksi = new Koneksi();

                if (textBoxEmailNomorTelepon.Text == "Masukkan email atau nomor telepon anda" && textBoxPassword.Text == "Masukkan password anda")
                {
                    MessageBox.Show("Maaf, email atau nomor telepon dan password harus diisi. Silahkan coba kembali", "Informasi");
                }
                else if (textBoxEmailNomorTelepon.Text == "Masukkan email atau nomor telepon anda")
                {
                    MessageBox.Show("Maaf, email atau nomor telepon harus diisi. Silahkan coba kembali", "Informasi");
                }
                else if (textBoxPassword.Text == "Masukkan password anda")
                {
                    MessageBox.Show("Maaf, password harus diisi. Silahkan coba kembali", "Informasi");
                }
                else
                {
                    Pengguna p = Pengguna.CekLogin(textBoxEmailNomorTelepon.Text, textBoxPassword.Text);

                    if (p != null)
                    {
                        FormUtama formUtama = (FormUtama)this.Owner;

                        formUtama.pengguna = p;

                        MessageBox.Show("Anda berhasil login ke aplikasi. Selamat menggunakan DiBa!", "Informasi");

                        //DialogResult = DialogResult.OK;

                        Close();
                    }
                    else
                    {
                        MessageBox.Show(this, "Username tidak ditemukan atau password salah.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Koneksi gagal. Pesan kesalahan : " + ex.Message, "Kesalahan");
            }
        }

        private void linkLabelDaftarPengguna_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormPendaftaranPengguna formPendaftaranPengguna = new FormPendaftaranPengguna();

            formPendaftaranPengguna.Owner = this;

            formPendaftaranPengguna.Show();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            ActiveControl = label1;

            textBoxEmailNomorTelepon.Text = "Masukkan email atau nomor telepon anda";
            textBoxEmailNomorTelepon.Font = new Font(textBoxEmailNomorTelepon.Font, FontStyle.Italic);
            textBoxEmailNomorTelepon.ForeColor = Color.Gray;

            textBoxPassword.Text = "Masukkan password anda";
            textBoxPassword.Font = new Font(textBoxPassword.Font, FontStyle.Italic);
            textBoxPassword.ForeColor = Color.Gray;
        }

        private void textBoxEmailNomorTelepon_Enter(object sender, EventArgs e)
        {
            if (textBoxEmailNomorTelepon.Text == "Masukkan email atau nomor telepon anda")
            {
                textBoxEmailNomorTelepon.Text = "";
                textBoxEmailNomorTelepon.Font = new Font(textBoxEmailNomorTelepon.Font, FontStyle.Regular);
                textBoxEmailNomorTelepon.ForeColor = Color.Black;
            }
        }

        private void textBoxEmailNomorTelepon_Leave(object sender, EventArgs e)
        {
            if (textBoxEmailNomorTelepon.Text == "")
            {
                textBoxEmailNomorTelepon.Text = "Masukkan email atau nomor telepon anda";
                textBoxEmailNomorTelepon.Font = new Font(textBoxEmailNomorTelepon.Font, FontStyle.Italic);
                textBoxEmailNomorTelepon.ForeColor = Color.Gray;
            }
        }

        private void textBoxPassword_Enter(object sender, EventArgs e)
        {
            if (textBoxPassword.Text == "Masukkan password anda")
            {
                textBoxPassword.Text = "";
                textBoxPassword.Font = new Font(textBoxPassword.Font, FontStyle.Regular);
                textBoxPassword.ForeColor = Color.Black;
                textBoxPassword.UseSystemPasswordChar = true;
            }
        }

        private void textBoxPassword_Leave(object sender, EventArgs e)
        {
            if (textBoxPassword.Text == "")
            {
                textBoxPassword.Text = "Masukkan password anda";
                textBoxPassword.Font = new Font(textBoxPassword.Font, FontStyle.Italic);
                textBoxPassword.ForeColor = Color.Gray;
                textBoxPassword.UseSystemPasswordChar = false;
            }
        }

        private void checkBoxTunjukkan_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTunjukkan.Checked == true)
            {
                textBoxPassword.UseSystemPasswordChar = false;
            }
            else
            {
                if (textBoxPassword.Text == "Masukkan password anda")
                {
                    textBoxPassword.UseSystemPasswordChar = false;
                }
                else
                {
                    textBoxPassword.UseSystemPasswordChar = true;
                }
            }
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}