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
using DiBa_LIB;

namespace ProjectDatabase_Ivano
{
    public partial class FormPendaftaranPengguna : Form
    {
        public FormPendaftaranPengguna()
        {
            InitializeComponent();
        }

        private void buttonDaftar_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi k = new Koneksi();
                DialogResult hasil = MessageBox.Show("Apakah data yang anda masukkan sudah benar?", "Konfirmasi", MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Question);

                if (hasil == DialogResult.Yes)
                {
                    string pin = "";

                    Pengguna p = new Pengguna(textBoxNIK.Text, textBoxNamaDepan.Text, textBoxNamaKeluarga.Text, textBoxAlamat.Text,
                                              textBoxEmail.Text, textBoxNomorTelepon.Text, textBoxPassword.Text, pin, DateTime.Now, DateTime.Now);
                    Pengguna.TambahData(p, k);
                    MessageBox.Show("Selamat, anda sudah terdaftar.\nSilahkan masuk dengan email " +
                        "atau nomor telepon dan password anda.", "Informasi");
                    Employee em = new Employee(Employee.GenerateKode());
                    Tabungan t = new Tabungan(Tabungan.GenerateNomorRekening(), p, 0, "Unverifie", "", DateTime.Now, DateTime.Now, em);
                    Tabungan.TambahData(t, k);
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Maaf, terjadi kesalahan dalam pendaftaran. Pesan kesalahan : " + ex.Message, "Kesalahan");
            }
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormPendaftaranPengguna_Load(object sender, EventArgs e)
        {
            ActiveControl = label1;

            textBoxNIK.Text = "Wajib diisi";
            textBoxNIK.Font = new Font(textBoxNIK.Font, FontStyle.Italic);
            textBoxNIK.ForeColor = Color.Gray;

            textBoxNamaDepan.Text = "Wajib diisi";
            textBoxNamaDepan.Font = new Font(textBoxNamaDepan.Font, FontStyle.Italic);
            textBoxNamaDepan.ForeColor = Color.Gray;

            textBoxEmail.Text = "Wajib diisi";
            textBoxEmail.Font = new Font(textBoxEmail.Font, FontStyle.Italic);
            textBoxEmail.ForeColor = Color.Gray;

            textBoxNomorTelepon.Text = "Wajib diisi";
            textBoxNomorTelepon.Font = new Font(textBoxNomorTelepon.Font, FontStyle.Italic);
            textBoxNomorTelepon.ForeColor = Color.Gray;

            textBoxPassword.Text = "Wajib diisi";
            textBoxPassword.Font = new Font(textBoxPassword.Font, FontStyle.Italic);
            textBoxPassword.ForeColor = Color.Gray;
            textBoxPassword.UseSystemPasswordChar = false;
        }

        private void textBoxNIK_Enter(object sender, EventArgs e)
        {
            if (textBoxNIK.Text == "Wajib diisi")
            {
                textBoxNIK.Text = "";
                textBoxNIK.Font = new Font(textBoxNIK.Font, FontStyle.Regular);
                textBoxNIK.ForeColor = Color.Black;
            }
        }

        private void textBoxNIK_Leave(object sender, EventArgs e)
        {
            if (textBoxNIK.Text == "")
            {
                textBoxNIK.Text = "Wajib diisi";
                textBoxNIK.Font = new Font(textBoxNIK.Font, FontStyle.Italic);
                textBoxNIK.ForeColor = Color.Gray;
            }
        }

        private void textBoxNamaDepan_Enter(object sender, EventArgs e)
        {
            if (textBoxNamaDepan.Text == "Wajib diisi")
            {
                textBoxNamaDepan.Text = "";
                textBoxNamaDepan.Font = new Font(textBoxNamaDepan.Font, FontStyle.Regular);
                textBoxNamaDepan.ForeColor = Color.Black;
            }
        }

        private void textBoxNamaDepan_Leave(object sender, EventArgs e)
        {
            if (textBoxNamaDepan.Text == "")
            {
                textBoxNamaDepan.Text = "Wajib diisi";
                textBoxNamaDepan.Font = new Font(textBoxNamaDepan.Font, FontStyle.Italic);
                textBoxNamaDepan.ForeColor = Color.Gray;
            }
        }

        private void textBoxEmail_Enter(object sender, EventArgs e)
        {
            if (textBoxEmail.Text == "Wajib diisi")
            {
                textBoxEmail.Text = "";
                textBoxEmail.Font = new Font(textBoxEmail.Font, FontStyle.Regular);
                textBoxEmail.ForeColor = Color.Black;
            }
        }

        private void textBoxEmail_Leave(object sender, EventArgs e)
        {
            if (textBoxEmail.Text == "")
            {
                textBoxEmail.Text = "Wajib diisi";
                textBoxEmail.Font = new Font(textBoxEmail.Font, FontStyle.Italic);
                textBoxEmail.ForeColor = Color.Gray;
            }
        }

        private void textBoxNomorTelepon_Enter(object sender, EventArgs e)
        {
            if (textBoxNomorTelepon.Text == "Wajib diisi")
            {
                textBoxNomorTelepon.Text = "";
                textBoxNomorTelepon.Font = new Font(textBoxNomorTelepon.Font, FontStyle.Regular);
                textBoxNomorTelepon.ForeColor = Color.Black;
            }
        }

        private void textBoxNomorTelepon_Leave(object sender, EventArgs e)
        {
            if (textBoxNomorTelepon.Text == "")
            {
                textBoxNomorTelepon.Text = "Wajib diisi";
                textBoxNomorTelepon.Font = new Font(textBoxNomorTelepon.Font, FontStyle.Italic);
                textBoxNomorTelepon.ForeColor = Color.Gray;
            }
        }

        private void textBoxPassword_Enter(object sender, EventArgs e)
        {
            if (textBoxPassword.Text == "Wajib diisi")
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
                textBoxPassword.Text = "Wajib diisi";
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
                if (textBoxPassword.Text == "Wajib diisi")
                {
                    textBoxPassword.UseSystemPasswordChar = false;
                }
                else
                {
                    textBoxPassword.UseSystemPasswordChar = true;
                }
            }
        }
    }
}
