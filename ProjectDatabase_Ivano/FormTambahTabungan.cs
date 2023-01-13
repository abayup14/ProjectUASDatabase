using DiBa_LIB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectDatabase_Ivano
{
    public partial class FormTambahTabungan : Form
    {
        FormDaftarTabungan formDaftarTabungan;

        public Pengguna pengguna;

        public FormTambahTabungan()
        {
            InitializeComponent();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult hasil = MessageBox.Show("Apakah anda ingin membuat tabungan ini?", "Konfirmasi",
                                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (hasil == DialogResult.Yes)
                {
                    Koneksi k = new Koneksi();

                    Employee verifikator = new Employee();

                    Tabungan t = new Tabungan(textBoxNoRekening.Text, pengguna, double.Parse(textBoxSaldoAwal.Text),
                                              "Unverified", textBoxKeterangan.Text, DateTime.Now, DateTime.Now, verifikator);

                    Tabungan.TambahData(t, k);

                    MessageBox.Show("Tabungan berhasil ditambah.", "Informasi");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Promo gagal ditambah. Pesan kesalahan : " + ex.Message, "Error");
            }
        }

        private void FormTambahTabungan_Load(object sender, EventArgs e)
        {
            formDaftarTabungan = (FormDaftarTabungan)this.Owner;

            pengguna = formDaftarTabungan.pengguna;
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            textBoxNoRekening.Text = Tabungan.GenerateNomorRekening();
            textBoxSaldoAwal.Clear();
            textBoxKeterangan.Clear();
            textBoxSaldoAwal.Focus();
        }
    }
}
