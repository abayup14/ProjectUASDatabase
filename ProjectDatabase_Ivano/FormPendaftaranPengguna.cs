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

                if (textBoxNamaDepan.Text == "Wajib diisi" || textBoxNIK.Text == "Wajib diisi")
                {
                    MessageBox.Show("Anda harus mengisi bagian yang bertuliskan \"wajib diisi\". Silahkan isi terlebih dahulu");
                }
                else
                {
                    DialogResult hasil = MessageBox.Show("Apakah data yang anda masukkan sudah benar?", "Konfirmasi", MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Question);

                    if (hasil == DialogResult.Yes)
                    {
                        if (Pengguna.CekEmailSama(textBoxEmail.Text) == true && Pengguna.CekNoTeleponSama(textBoxNomorTelepon.Text) == true)
                        {
                            MessageBox.Show("Terdapat email atau nomor telepon yang sudah terdaftar. Coba gunakan email atau nomor telepon yang lain.", "informasi");
                        }
                        else if (Pengguna.CekEmailSama(textBoxEmail.Text) == true)
                        {
                            MessageBox.Show("Email yang anda masukkan sudah terdaftar. Coba gunakan email yang lain.", "Informasi");
                        }
                        else if (Pengguna.CekNoTeleponSama(textBoxNomorTelepon.Text) == true)
                        {
                            MessageBox.Show("Nomor telepon yang anda masukkan sudah terdaftar. Coba gunakan nomor telepon yang lain.", "Informasi");
                        }    
                        else
                        {
                            string pin = "";

                            Pengguna p = new Pengguna(textBoxNIK.Text, textBoxNamaDepan.Text, textBoxNamaKeluarga.Text, textBoxAlamat.Text,
                                                      textBoxEmail.Text, textBoxNomorTelepon.Text, textBoxPassword.Text, pin, DateTime.Now, DateTime.Now);

                            Pengguna.TambahData(p, k);

                            Employee em = new Employee();

                            string no_rekening = Tabungan.GenerateNomorRekening();

                            Tabungan t = new Tabungan(no_rekening, p, 0, "Unverified", "", DateTime.Now, DateTime.Now, em);

                            Tabungan.TambahData(t, k);

                            MessageBox.Show("Selamat, anda sudah terdaftar di aplikasi ini. " +
                                            "\nAnda juga sudah dibuatkan tabungan dengan nomor rekening " + no_rekening +
                                            "\n Status tabungan anda adalah \"Unverified\". Silahkan hubungin pegawai terkait untuk mengaktifkan tabungan anda.",
                                            "Berhasil Membuat Akun");

                            MessageBox.Show("Silahkan masuk dengan email atau nomor telepon dan password anda.", "Informasi");

                            Close();
                        }
                    }
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
