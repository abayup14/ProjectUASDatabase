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
using DiBa_LIB;

namespace ProjectDatabase_Ivano
{
    public partial class FormUbahPengguna : Form
    {
        FormProfilPengguna formProfilPengguna;

        public Pengguna pengguna;
        public FormUbahPengguna()
        {
            InitializeComponent();
        }

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi k = new Koneksi();
                DialogResult hasil = MessageBox.Show("Apakah anda yakin ingin mengubah data anda?", "Konfirmasi", MessageBoxButtons.YesNo,
                                                         MessageBoxIcon.Question);
                
                if (hasil == DialogResult.Yes)
                {
                    //FormDaftarPengguna formDaftarPengguna = (FormDaftarPengguna)this.Owner;

                    string password = pengguna.Password;

                    string pin = pengguna.Pin;

                    DateTime tglBuat = pengguna.Tgl_buat;

                    Pengguna p = new Pengguna(textBoxNIK.Text, textBoxNamaDepan.Text, textBoxNamaKeluarga.Text, textBoxAlamat.Text, textBoxEmail.Text,
                                              textBoxNomorTelepon.Text, password, pin, tglBuat, DateTime.Now);

                    Pengguna.UbahData(p, k);

                    MessageBox.Show("Data pengguna berhasil diubah", "Informasi");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data pengguna gagal diubah. Pesan kesalahan : " + ex.Message, "Kesalahan");
            }
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            //FormDaftarPengguna formDaftarPengguna = (FormDaftarPengguna)this.Owner;

            //formDaftarPengguna.FormDaftarPengguna_Load(buttonKeluar, e);

            Close();
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            textBoxNamaDepan.Clear();

            textBoxNamaKeluarga.Clear();

            textBoxAlamat.Clear();

            textBoxEmail.Clear();

            textBoxNomorTelepon.Clear();

            textBoxNamaDepan.Focus();
        }

        private void FormUbahPengguna_Load(object sender, EventArgs e)
        {
            formProfilPengguna = (FormProfilPengguna)this.Owner;

            pengguna = Pengguna.AmbilDataByKode(formProfilPengguna.labelNIK.Text);

            textBoxNIK.Text = pengguna.Nik;

            textBoxNamaDepan.Text = pengguna.Nama_depan;

            textBoxNamaKeluarga.Text = pengguna.Nama_keluarga;

            textBoxAlamat.Text = pengguna.Alamat;

            textBoxEmail.Text = pengguna.Email;

            textBoxNomorTelepon.Text = pengguna.No_telepon;
        }
    }
}
