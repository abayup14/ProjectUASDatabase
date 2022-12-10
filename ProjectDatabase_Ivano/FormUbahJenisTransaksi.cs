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
    public partial class FormUbahJenisTransaksi : Form
    {
        public FormUbahJenisTransaksi()
        {
            InitializeComponent();
        }

        public void FormUbahJenisTransaksi_Load(object sender, EventArgs e)
        {

        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi k = new Koneksi();
                DialogResult result = MessageBox.Show("Apakah anda yakin ingin mengubah data?", "Konfirmasi",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    FormDaftarJenisTransaksi formDaftarJenisTransaksi = (FormDaftarJenisTransaksi)this.Owner;

                    int id = int.Parse(formDaftarJenisTransaksi.dataGridViewJenisTransaksi.CurrentRow.Cells["id_jenis_transaksi"].Value.ToString());

                    JenisTransaksi j = new JenisTransaksi(id, textBoxKodeJenisTransaksi.Text, textBoxNamaJenisTransaksi.Text);
                    JenisTransaksi.UbahData(j, k);

                    MessageBox.Show("Data jenis transaksi berhasil di ubah.", "Informasi");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data jenis transaksi gagal di ubah. Pesan kesalahan: " + ex.Message, "Kesalahan");
            }
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            textBoxKodeJenisTransaksi.Clear();
            textBoxNamaJenisTransaksi.Clear();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            FormDaftarJenisTransaksi formDaftarJenisTransaksi = (FormDaftarJenisTransaksi)this.Owner;
            formDaftarJenisTransaksi.FormDaftarJenisTransaksi_Load(buttonKeluar, e);
            this.Close();
        }
    }
}
