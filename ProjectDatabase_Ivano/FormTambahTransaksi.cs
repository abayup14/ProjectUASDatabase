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
        List<Promo> listPromo = new List<Promo>();
        List<JenisTagihan> listJenisTagihan = new List<JenisTagihan>();
        FormDaftarTransaksi formDaftarTransaksi;

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi k = new Koneksi();

                DialogResult result = MessageBox.Show("Apakah data yang ada masukkan sudah benar?", "Konfirmasi", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    Tabungan rekening_sumber = new Tabungan(labelNoRekening.Text);
                    JenisTransaksi jt = new JenisTransaksi(comboBoxJenisTransaksi.SelectedIndex + 1);
                    Tabungan rekening_tujuan = (Tabungan)comboBoxRekeningTujuan.SelectedItem;
                    Promo p = (Promo)comboBoxPromo.SelectedItem;
                    JenisTagihan j = (JenisTagihan)comboBoxJenisTagihan.SelectedItem;
                    Transaksi t = new Transaksi(rekening_sumber, Transaksi.GenerateKode().ToString(), DateTime.Now, jt, rekening_tujuan, double.Parse(textBoxNominal.Text), textBoxKeterangan.Text, p, j);

                    Transaksi.TambahData(t, k);

                    MessageBox.Show("Data transaksi telah tersimpan.", "Info");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data transaksi gagal disimpan. Pesan kesalahan: " + ex.Message, "Kesalahan");
            }
        }

        private void FormTambahTransaksi_Load(object sender, EventArgs e)
        {
            formDaftarTransaksi = (FormDaftarTransaksi)this.Owner;
            labelNoRekening.Text = Tabungan.AmbilDataNoRekening(formDaftarTransaksi.pengguna.Nik);

            listJenisTransaksi = JenisTransaksi.ReadData("", "");
            listTabungan = Tabungan.BacaData("", ""); 

            comboBoxJenisTransaksi.DataSource = listJenisTransaksi;
            comboBoxJenisTransaksi.DisplayMember = "nama";
            comboBoxJenisTransaksi.DropDownStyle = ComboBoxStyle.DropDownList;

            comboBoxRekeningTujuan.DataSource = listTabungan;
            comboBoxRekeningTujuan.DisplayMember = "no_rekening";
            comboBoxRekeningTujuan.DropDownStyle = ComboBoxStyle.DropDownList;

            comboBoxPromo.DataSource = listPromo;
            comboBoxPromo.DisplayMember = "namaPromo";
            comboBoxPromo.DropDownStyle = ComboBoxStyle.DropDownList;

            comboBoxJenisTagihan.DataSource = listJenisTagihan;
            comboBoxJenisTagihan.DisplayMember = "nama";
            comboBoxJenisTagihan.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            labelNoRekening.Text = "";

            textBoxNominal.Clear();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            FormDaftarTransaksi formDaftarTransaksi = new FormDaftarTransaksi();

            formDaftarTransaksi.FormDaftarTransaksi_Load(buttonKeluar, e);

            this.Close();
        }
    }
}
