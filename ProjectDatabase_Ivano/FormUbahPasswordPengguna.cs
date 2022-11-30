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
    public partial class FormUbahPasswordPengguna : Form
    {
        public FormUbahPasswordPengguna()
        {
            InitializeComponent();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            FormDaftarPengguna formDaftarPengguna = (FormDaftarPengguna)this.Owner;

            formDaftarPengguna.FormDaftarPengguna_Load(buttonKeluar, e);

            Close();
        }

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxKonfirmasiPasswordBaru.Text != textBoxPasswordBaru.Text)
                {
                    MessageBox.Show("Password baru anda tidak sesuai dengan konfirmasi password baru. Coba lagi.");
                }
                else
                {
                    DialogResult hasil = MessageBox.Show("Apakah anda yakin ingin mengubah password anda?", "Konfirmasi", MessageBoxButtons.YesNo,
                                                         MessageBoxIcon.Question);

                    if (hasil == DialogResult.Yes)
                    {
                        FormDaftarPengguna formDaftarPengguna = (FormDaftarPengguna)this.Owner;

                        string nik = formDaftarPengguna.dataGridViewPengguna.CurrentRow.Cells["nik"].Value.ToString();

                        string namaDepan = formDaftarPengguna.dataGridViewPengguna.CurrentRow.Cells["nama_depan"].Value.ToString();

                        string namaKeluarga = formDaftarPengguna.dataGridViewPengguna.CurrentRow.Cells["nama_keluarga"].Value.ToString();

                        string alamat = formDaftarPengguna.dataGridViewPengguna.CurrentRow.Cells["alamat"].Value.ToString();

                        string email = formDaftarPengguna.dataGridViewPengguna.CurrentRow.Cells["email"].Value.ToString();

                        string noTelepon = formDaftarPengguna.dataGridViewPengguna.CurrentRow.Cells["no_telepon"].Value.ToString();

                        string password = formDaftarPengguna.dataGridViewPengguna.CurrentRow.Cells["password"].Value.ToString();

                        string pin = formDaftarPengguna.dataGridViewPengguna.CurrentRow.Cells["pin"].Value.ToString();

                        DateTime tglBuat = DateTime.Parse(formDaftarPengguna.dataGridViewPengguna.CurrentRow.Cells["tgl_buat"].Value.ToString());

                        Pengguna p = new Pengguna(nik, namaDepan, namaKeluarga, alamat, email, noTelepon, password, pin, tglBuat, DateTime.Now);

                        Pengguna.UbahPassword(p, textBoxPasswordLama.Text, textBoxKonfirmasiPasswordBaru.Text);

                        MessageBox.Show("Password anda berhasil diubah.", "Informasi");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mengubah password anda. Pesan kesalahan : " + ex.Message, "Kesalahan");
            }
            
        }

        private void FormUbahPassword_Load(object sender, EventArgs e)
        {
            ActiveControl = label1;

            textBoxPasswordLama.Text = "Masukkan password lama anda";
            textBoxPasswordLama.Font = new Font(textBoxPasswordLama.Font, FontStyle.Italic);
            textBoxPasswordLama.ForeColor = Color.Gray;

            textBoxPasswordBaru.Text = "Masukkan password baru anda";
            textBoxPasswordBaru.Font = new Font(textBoxPasswordBaru.Font, FontStyle.Italic);
            textBoxPasswordBaru.ForeColor = Color.Gray;

            textBoxKonfirmasiPasswordBaru.Text = "Masukkan kembali password baru anda";
            textBoxKonfirmasiPasswordBaru.Font = new Font(textBoxKonfirmasiPasswordBaru.Font, FontStyle.Italic);
            textBoxKonfirmasiPasswordBaru.ForeColor = Color.Gray;
        }

        private void textBoxPasswordLama_Enter(object sender, EventArgs e)
        {
            if (textBoxPasswordLama.Text == "Masukkan password lama anda")
            {
                textBoxPasswordLama.Text = "";
                textBoxPasswordLama.Font = new Font(textBoxPasswordLama.Font, FontStyle.Regular);
                textBoxPasswordLama.UseSystemPasswordChar = true;
                textBoxPasswordLama.ForeColor = Color.Black;
            }
        }

        private void textBoxPasswordLama_Leave(object sender, EventArgs e)
        {
            if (textBoxPasswordLama.Text == "")
            {
                textBoxPasswordLama.Text = "Masukkan password lama anda";
                textBoxPasswordLama.Font = new Font(textBoxPasswordLama.Font, FontStyle.Italic);
                textBoxPasswordLama.UseSystemPasswordChar = false;
                textBoxPasswordLama.ForeColor = Color.Gray;
            }
        }

        private void textBoxPasswordBaru_Enter(object sender, EventArgs e)
        {
            if (textBoxPasswordBaru.Text == "Masukkan password baru anda")
            {
                textBoxPasswordBaru.Text = "";
                textBoxPasswordBaru.Font = new Font(textBoxPasswordBaru.Font, FontStyle.Regular);
                textBoxPasswordBaru.UseSystemPasswordChar = true;
                textBoxPasswordBaru.ForeColor = Color.Black;
            }
        }

        private void textBoxPasswordBaru_Leave(object sender, EventArgs e)
        {
            if (textBoxPasswordBaru.Text == "")
            {
                textBoxPasswordBaru.Text = "Masukkan password baru anda";
                textBoxPasswordBaru.Font = new Font(textBoxPasswordBaru.Font, FontStyle.Italic);
                textBoxPasswordBaru.UseSystemPasswordChar = false;
                textBoxPasswordBaru.ForeColor = Color.Gray;
            }
        }

        private void textBoxKonfirmasiPasswordBaru_Enter(object sender, EventArgs e)
        {
            if (textBoxKonfirmasiPasswordBaru.Text == "Masukkan kembali password baru anda")
            {
                textBoxKonfirmasiPasswordBaru.Text = "";
                textBoxKonfirmasiPasswordBaru.Font = new Font(textBoxKonfirmasiPasswordBaru.Font, FontStyle.Regular);
                textBoxKonfirmasiPasswordBaru.UseSystemPasswordChar = true;
                textBoxKonfirmasiPasswordBaru.ForeColor = Color.Black;
            }
        }

        private void textBoxKonfirmasiPasswordBaru_Leave(object sender, EventArgs e)
        {
            if (textBoxKonfirmasiPasswordBaru.Text == "")
            {
                textBoxKonfirmasiPasswordBaru.Text = "Masukkan kembali password baru anda";
                textBoxKonfirmasiPasswordBaru.Font = new Font(textBoxKonfirmasiPasswordBaru.Font, FontStyle.Italic);
                textBoxKonfirmasiPasswordBaru.UseSystemPasswordChar = false;
                textBoxKonfirmasiPasswordBaru.ForeColor = Color.Gray;
            }
        }
    }
}
