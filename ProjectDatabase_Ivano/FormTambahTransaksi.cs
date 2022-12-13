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
    public partial class FormTambahTransaksi : Form
    {
        public FormTambahTransaksi()
        {
            InitializeComponent();
        }
        List<Transaksi> listTransaksi = new List<Transaksi>();
        List<JenisTransaksi> listJenisTransaksi = new List<JenisTransaksi>();
        List<Tabungan> listTabungan = new List<Tabungan>();

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi k = new Koneksi();

                DialogResult result = MessageBox.Show("Apakah data yang ada masukkan sudah benar?", "Konfirmasi", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    
                    Tabungan tabungan = new Tabungan(labelNoRekening.Text);
                    JenisTransaksi jt = new JenisTransaksi(int.Parse(comboBoxJenisTransaksi.Text));
                    Transaksi t = new Transaksi(tabungan,Transaksi.GenerateKode().ToString(), DateTime.Now, jt, tabungan, double.Parse(textBoxNominal.Text), textBoxKeterangan.Text);

                    Transaksi.TambahData(t, k);


                    MessageBox.Show("Data position telah tersimpan.", "Info");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data position gagal disimpan. Pesan kesalahan: " + ex.Message, "Kesalahan");
            }
        }

        private void FormTambahTransaksi_Load(object sender, EventArgs e)
        {
            comboBoxJenisTransaksi.DataSource = listJenisTransaksi;
            comboBoxJenisTransaksi.DisplayMember = "nama";
            comboBoxJenisTransaksi.DropDownStyle = ComboBoxStyle.DropDownList;

            comboBoxRekeningTujuan.DataSource = listTabungan;
            comboBoxRekeningTujuan.DisplayMember = "no_rekening";
            comboBoxRekeningTujuan.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            labelNoRekening.Text = "";

            textBoxNominal.Clear();
        }
    }
}
