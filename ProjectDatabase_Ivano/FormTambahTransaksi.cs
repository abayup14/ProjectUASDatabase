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
        List<AddressBook> listTabunganTujuan = new List<AddressBook>();
        public List<Promo> listPromo = new List<Promo>();
        public List<JenisTagihan> listJenisTagihan = new List<JenisTagihan>();
        public Tabungan tabunganSumber;
        public Tabungan tabunganTujuan;
        FormUtama formUtama;
        public Pengguna pengguna;

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxRekeningSumber.SelectedIndex > -1)
                {
                    tabunganSumber = (Tabungan)comboBoxRekeningSumber.SelectedItem;
                }
                if (comboBoxRekeningTujuan.SelectedIndex > -1)
                {
                    string no_rekening = comboBoxRekeningTujuan.Text;
                    tabunganTujuan = Tabungan.AmbilDataTabungan(no_rekening);
                }

                DialogResult hasil = MessageBox.Show("Apakah anda yakin ingin melakukan transaksi?", "Konfirmasi", MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Question);
                if (hasil == DialogResult.Yes)
                {
                    if (tabunganSumber.Status == "Aktif" && tabunganTujuan.Status == "Aktif")
                    {
                        FormMasukkanPIN formMasukkanPIN = new FormMasukkanPIN();

                        formMasukkanPIN.Owner = this;

                        formMasukkanPIN.buttonCekTopUp.Visible = false;
                        formMasukkanPIN.buttonCekTransaksi.Visible = true;
                        formMasukkanPIN.buttonSimpan.Visible = false;

                        formMasukkanPIN.ShowDialog();
                    }
                    else
                    {
                        if (tabunganSumber.Status != "Aktif")
                        {
                            MessageBox.Show("Tabungan asal berstatus tidak aktif." +
                                        "\nSilahkan hubungi pegawai kami untuk mengaktifkan tabungan ini.");
                        }
                        else if (tabunganTujuan.Status != "Aktif")
                        {
                            MessageBox.Show("Tabungan tujuan berstatus tidak aktif." +
                                        "\nSilahkan hubungi pegawai kami untuk mengaktifkan tabungan ini.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal topup. Pesan kesalahan: " + ex.Message, "Kesalahan");
            }
        }

        private void FormTambahTransaksi_Load(object sender, EventArgs e)
        {
            formUtama = (FormUtama)this.MdiParent;
            pengguna = formUtama.pengguna;
            listTabunganSumber = Tabungan.BacaData("p.nik", formUtama.pengguna.Nik);
            comboBoxRekeningSumber.DataSource = listTabunganSumber;
            comboBoxRekeningSumber.DisplayMember = "no_rekening";
            comboBoxRekeningSumber.DropDownStyle = ComboBoxStyle.DropDownList;

            //listJenisTransaksi = JenisTransaksi.ReadData("", "");
            //comboBoxJenisTransaksi.DataSource = listJenisTransaksi;
            //comboBoxJenisTransaksi.DisplayMember = "nama";
            //comboBoxJenisTransaksi.DropDownStyle = ComboBoxStyle.DropDownList;
            listPromo = Promo.BacaData("id not", "0");
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
            //FormDaftarTransaksi formDaftarTransaksi = new FormDaftarTransaksi();

            //formDaftarTransaksi.FormDaftarTransaksi_Load(buttonKeluar, e);

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
                //listTabunganTujuan = Tabungan.BacaData("t.no_rekening not", comboBoxRekeningSumber.Text);
                listTabunganTujuan = AddressBook.BacaData("p.nik", pengguna.Nik);
                comboBoxRekeningTujuan.DataSource = listTabunganTujuan;
                comboBoxRekeningTujuan.DisplayMember = "no_rekening";
                comboBoxRekeningTujuan.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }
    }
}
