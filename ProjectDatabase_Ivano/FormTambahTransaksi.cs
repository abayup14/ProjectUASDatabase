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
    public partial class FormTambahTransaksi : Form
    {
        public FormTambahTransaksi()
        {
            InitializeComponent();
        }
        List<Transaksi> listTransaksi = new List<Transaksi>();
        List<JenisTransaksi> listJenisTransaksi = new List<JenisTransaksi>();
        List<Tabungan> listTabunganSumber = new List<Tabungan>();
        List<Tabungan> listTabunganTujuan = new List<Tabungan>();
        public List<Promo> listPromo = new List<Promo>();
        public List<JenisTagihan> listJenisTagihan = new List<JenisTagihan>();
        //FormDaftarTransaksi formDaftarTransaksi;
        //FormTabunganPengguna formTabunganPengguna;
        FormUtama formUtama;

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi k = new Koneksi();

                DialogResult result = MessageBox.Show("Apakah data yang ada masukkan sudah benar?", "Konfirmasi", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    Tabungan rekening_sumber = new Tabungan(comboBoxRekeningSumber.Text);
                    JenisTransaksi jt = new JenisTransaksi(comboBoxJenisTransaksi.SelectedIndex + 1);
                    Tabungan rekening_tujuan = (Tabungan)comboBoxRekeningTujuan.SelectedItem;
                    Promo p = (Promo)comboBoxPromo.SelectedItem;
                    JenisTagihan j = (JenisTagihan)comboBoxJenisTagihan.SelectedItem;
                    Transaksi t = new Transaksi(rekening_sumber, Transaksi.GenerateKode().ToString(), DateTime.Now, jt, rekening_tujuan, double.Parse(textBoxNominal.Text), textBoxKeterangan.Text, p, j);

                    if(comboBoxPromo.Text != "")
                    {
                        RiwayatPromo rp = new RiwayatPromo(p, rekening_sumber.Pengguna);
                    }

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
            formUtama = (FormUtama)this.MdiParent;
            //formTabunganPengguna = (FormTabunganPengguna)this.Owner;
            //formDaftarTransaksi = (FormDaftarTransaksi)this.Owner;
            listTabunganSumber = Tabungan.BacaData("", "");
            comboBoxRekeningSumber.DataSource = listTabunganSumber;
            comboBoxRekeningSumber.DisplayMember = "no_rekening";
            comboBoxRekeningSumber.DropDownStyle = ComboBoxStyle.DropDownList;

            listJenisTransaksi = JenisTransaksi.ReadData("", "");
            comboBoxJenisTransaksi.DataSource = listJenisTransaksi;
            comboBoxJenisTransaksi.DisplayMember = "nama";
            comboBoxJenisTransaksi.DropDownStyle = ComboBoxStyle.DropDownList;

            comboBoxPromo.DataSource = listPromo;
            comboBoxPromo.DisplayMember = "namaPromo";
            comboBoxPromo.DropDownStyle = ComboBoxStyle.DropDownList;

            comboBoxJenisTagihan.DataSource = listJenisTagihan;
            comboBoxJenisTagihan.DisplayMember = "nama";
            comboBoxJenisTagihan.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            textBoxNominal.Clear();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            FormDaftarTransaksi formDaftarTransaksi = new FormDaftarTransaksi();

            formDaftarTransaksi.FormDaftarTransaksi_Load(buttonKeluar, e);

            this.Close();
        }

        private void checkBoxPromo_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPromo.Checked == true)
            {
                comboBoxPromo.Enabled = true;
            }
            else
            {
                comboBoxPromo.Enabled = false;
            }
        }

        private void checkBoxTagihan_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTagihan.Checked == true)
            {
                comboBoxJenisTagihan.Enabled = true;
            }
            else
            {
                comboBoxJenisTagihan.Enabled = false;
            }
        }

        private void comboBoxRekeningSumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxRekeningSumber.SelectedIndex > -1)
            {
                listTabunganTujuan.Clear();
                listTabunganTujuan = Tabungan.BacaData("t.no_rekening not", comboBoxRekeningSumber.Text);
                comboBoxRekeningTujuan.DataSource = listTabunganTujuan;
                comboBoxRekeningTujuan.DisplayMember = "no_rekening";
                comboBoxRekeningTujuan.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }
    }
}
