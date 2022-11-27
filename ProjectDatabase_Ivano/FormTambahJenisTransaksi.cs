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
    public partial class FormTambahJenisTransaksi : Form
    {
        public List<JenisTransaksi> listJenisTransaksi = new List<JenisTransaksi>();

        public FormTambahJenisTransaksi()
        {
            InitializeComponent();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Apakah data yang ada masukkan sudah benar?", "Konfirmasi", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    int id_jenis_transaksi = JenisTransaksi.GenerateKode();
                    JenisTransaksi j = new JenisTransaksi(id_jenis_transaksi, textBoxKodeJenisTransaksi.Text, textBoxNamaJenisTransaksi.Text);
                    JenisTransaksi.TambahData(j);

                    MessageBox.Show("Data jenis transaksi berhasil ditambahkan.", "Informasi");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data jenis transaksi gagal ditambahkan. Pesan kesalahan: " + ex.Message, "Kesalahan");
            }
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            FormDaftarJenisTransaksi formDaftarJenisTransaksi = (FormDaftarJenisTransaksi)this.Owner;
            formDaftarJenisTransaksi.FormDaftarJenisTransaksi_Load(buttonKeluar, e);
            Close();
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            textBoxKodeJenisTransaksi.Clear();
            textBoxNamaJenisTransaksi.Clear();
        }
    }
}
