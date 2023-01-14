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
    public partial class FormTopUp : Form
    {
        FormTabunganPengguna formTabunganPengguna;

        public Pengguna p;

        public Tabungan tabungan;

        public FormTopUp()
        {
            InitializeComponent();
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult hasil = MessageBox.Show("Apakah anda yakin ingin melakukan topup?", "Konfirmasi", MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Question);
                if (hasil == DialogResult.Yes)
                {
                    if (tabungan.Status == "Aktif")
                    {
                        FormMasukkanPIN formMasukkanPIN = new FormMasukkanPIN();

                        formMasukkanPIN.Owner = this;

                        formMasukkanPIN.buttonCek.Visible = true;
                        formMasukkanPIN.buttonSimpan.Visible = false;

                        formMasukkanPIN.ShowDialog();
                    }
                    //Koneksi k = new Koneksi();
                    //string no_rekening = Tabungan.AmbilDataNoRekening(p.Nik);
                    //Tabungan t = new Tabungan(no_rekening);
                    //Tabungan.UbahSaldo(t, double.Parse(textBoxJumlah.Text), k);
                    //MessageBox.Show("Berhasil topup", "Informasi");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal topup. Pesan kesalahan: " + ex.Message, "Kesalahan");
            }
        }

        private void FormTopUp_Load(object sender, EventArgs e)
        {
            formTabunganPengguna = (FormTabunganPengguna)this.Owner;

            p = formTabunganPengguna.p;

            tabungan = formTabunganPengguna.t;
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            //FormDaftarTabungan formDaftarTabungan = (FormDaftarTabungan)this.Owner;
            //formDaftarTabungan.FormDaftarTabungan_Load(buttonKeluar, e);
            Close();
        }
    }
}
