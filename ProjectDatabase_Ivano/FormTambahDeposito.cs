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
    public partial class FormTambahDeposito : Form
    {
        List<int> bulanJatuhTempo = new List<int>() { 1, 3, 6, 12, 24, 36 };

        List<double> bungaJatuhTempo = new List<double>() { 0.03, 0.05, 0.06, 0.08, 0.08, 0.08 };

        List<Tabungan> listTabungan = new List<Tabungan>();

        FormDaftarDeposito formDaftarDeposito;

        Tabungan tabungan;

        //FormDepositoPengguna formDepositoPengguna;

        public FormTambahDeposito()
        {
            InitializeComponent();
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Hasil = MessageBox.Show("Apakah anda ingin menambah deposito ini ?",
                    "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Hasil == DialogResult.Yes)
                {
                    if (tabungan.Status != "Aktif")
                    {
                        MessageBox.Show("Maaf, status tabungan yang anda pilih tidak aktif" +
                                        "\nSilahkan hubungi pegawai kami untuk mengaktifkan tabungan anda.", "Informasi");
                    }
                    else
                    {
                        double sisaSaldo = tabungan.Saldo - double.Parse(textBoxNominal.Text);
                        if (sisaSaldo >= tabungan.Saldo)
                        {
                            Koneksi k = new Koneksi();

                            int indexJatuhTempoDipilih = comboBoxJatuhTempo.SelectedIndex;

                            string kode = Deposito.GenerateKode(tabungan.Rekening);

                            Tabungan t = tabungan;

                            int jatuhTempo = bulanJatuhTempo[indexJatuhTempoDipilih];

                            double nominal = double.Parse(textBoxNominal.Text);

                            double bunga = bungaJatuhTempo[indexJatuhTempoDipilih];

                            string status = "Unverified";

                            DateTime tgl_buat = DateTime.Now;

                            DateTime tgl_perubahan = DateTime.Now;

                            Employee verifikatorBuka = new Employee();

                            Employee verifikatorCair = new Employee();

                            Deposito d = new Deposito(kode, t, jatuhTempo, nominal, bunga, status, tgl_buat, tgl_perubahan, verifikatorBuka, verifikatorCair);

                            Deposito.TambahData(d, k);

                            Tabungan.UpdateSaldo(t, double.Parse(textBoxNominal.Text), k);

                            MessageBox.Show("Deposito berhasil ditambah");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Maaf, saldo anda tidak mencukupi untuk melakukan pembuatan deposito.", "Informasi");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormTambahDeposito_Load(object sender, EventArgs e)
        {
            formDaftarDeposito = (FormDaftarDeposito)this.Owner;

            listTabungan = Tabungan.BacaData("p.nik", formDaftarDeposito.pengguna.Nik);

            comboBoxRekening.DataSource = listTabungan;
            comboBoxRekening.DisplayMember = "Rekening";

            //formDepositoPengguna = (FormDepositoPengguna)this.Owner;

            //labelNoRekening.Text = Tabungan.AmbilDataNoRekening(formDaftarDeposito.pengguna.Nik);
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            //FormDaftarDeposito formDaftarDeposito = (FormDaftarDeposito)this.Owner;

            formDaftarDeposito.FormDaftarDeposito_Load(buttonKeluar, e);

            this.Close();
        }

        private void comboBoxRekening_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxRekening.SelectedIndex > -1)
            {
                tabungan = (Tabungan)comboBoxRekening.SelectedItem;
            }
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            textBoxNominal.Clear();
            comboBoxRekening.SelectedIndex = -1;
            comboBoxJatuhTempo.SelectedIndex = -1;
        }
    }
}
