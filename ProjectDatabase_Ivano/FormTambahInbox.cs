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
    public partial class FormTambahInbox : Form
    {
        public List<Pengguna> listPengguna = new List<Pengguna>();

        public FormTambahInbox()
        {
            InitializeComponent();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            FormDaftarInbox formDaftarInbox = (FormDaftarInbox)this.Owner;
            formDaftarInbox.FormDaftarInbox_Load(buttonKeluar, e);
            this.Close();
        }

        private void buttonKirim_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi k = new Koneksi();
                DialogResult hasil = MessageBox.Show("Apakah data yang anda masukkan sudah benar?", "Konfirmasi", MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Question);

                if (hasil == DialogResult.Yes)
                {
                    Pengguna pengguna = (Pengguna)comboBoxPengguna.SelectedItem;

                    int id = Inbox.GenerateKode();

                    Inbox i = new Inbox(pengguna, id, textBoxPesan.Text, DateTime.Now, "Belum Terbaca", DateTime.Now);

                    Inbox.TambahData(i, k);

                    MessageBox.Show("Inbox berhasil dikirim", "Informasi");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Inbox gagal dikirim. Pesan kesalahan : " + ex.Message, "Error");
            }
        }

        private void FormTambahInbox_Load(object sender, EventArgs e)
        {
            listPengguna = Pengguna.BacaData("", "");

            comboBoxPengguna.DataSource = listPengguna;

            comboBoxPengguna.DisplayMember = "nik";
        }

        private void comboBoxPengguna_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxPengguna.SelectedIndex > -1)
            {
                Pengguna pengguna = (Pengguna)comboBoxPengguna.SelectedItem;

                labelNama.Text = pengguna.Nama_depan + " " + pengguna.Nama_keluarga;
            }
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            comboBoxPengguna.SelectedIndex = -1;

            labelNama.Text = "";

            textBoxPesan.Clear();
        }
    }
}
