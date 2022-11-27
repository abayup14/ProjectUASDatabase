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
    public partial class FormTambahPenggguna : Form
    {
        public List<Pengguna> listPengguna = new List<Pengguna>();

        public FormTambahPenggguna()
        {
            InitializeComponent();
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult hasil = MessageBox.Show("Apakah data yang anda masukkan sudah benar?", "Konfirmasi", MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Question);

                if (hasil == DialogResult.Yes)
                {
                    string pin = "";

                    Pengguna p = new Pengguna(textBoxNIK.Text, textBoxNamaDepan.Text, textBoxNamaKeluarga.Text, textBoxAlamat.Text,
                                              textBoxEmail.Text, textBoxNomorTelepon.Text, textBoxPassword.Text, pin, DateTime.Now, DateTime.Now);

                    Pengguna.TambahData(p);

                    MessageBox.Show("Data pengguna berhasil ditambahkan.", "Informasi");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data pengguna gagal ditambahkan. Pesan kesalahan : " + ex.Message, "Kesalahan");
            }
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            FormDaftarPengguna formDaftarPengguna = (FormDaftarPengguna)this.Owner;

            formDaftarPengguna.FormDaftarPengguna_Load(buttonKeluar, e);

            Close();
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            textBoxNIK.Clear();

            textBoxNamaDepan.Clear();

            textBoxNamaKeluarga.Clear();

            textBoxAlamat.Clear();

            textBoxEmail.Clear();

            textBoxNomorTelepon.Clear();

            textBoxPassword.Clear();

            textBoxNIK.Focus();
        }
    }
}
