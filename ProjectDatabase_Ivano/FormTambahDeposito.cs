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

        FormDaftarDeposito formDaftarDeposito;

        //FormDepositoPengguna formDepositoPengguna;

        public FormTambahDeposito()
        {
            InitializeComponent();
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi k = new Koneksi();

                int indexJatuhTempoDipilih = comboBoxJatuhTempo.SelectedIndex;

                string nik = formDaftarDeposito.pengguna.Nik;

                string no_rekening = Tabungan.AmbilDataNoRekening(nik);

                string kode = Deposito.GenerateKode(no_rekening);

                Tabungan t = new Tabungan(no_rekening);

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

                MessageBox.Show("Deposito berhasil ditambah");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormTambahDeposito_Load(object sender, EventArgs e)
        {
            formDaftarDeposito = (FormDaftarDeposito)this.Owner;

            //formDepositoPengguna = (FormDepositoPengguna)this.Owner;

            //labelNoRekening.Text = Tabungan.AmbilDataNoRekening(formDaftarDeposito.pengguna.Nik);
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            FormDaftarDeposito formDaftarDeposito = (FormDaftarDeposito)this.Owner;

            formDaftarDeposito.FormDaftarDeposito_Load(buttonKeluar, e);

            this.Close();
        }
    }
}
