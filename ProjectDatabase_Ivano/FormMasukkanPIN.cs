using DiBa_LIB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectDatabase_Ivano
{
    public partial class FormMasukkanPIN : Form
    {
        //public Pengguna pengguna;

        //public Tabungan tabungan;

        public FormMasukkanPIN()
        {
            InitializeComponent();
        }

        private void FormMasukkanPIN_Load(object sender, EventArgs e)
        {
            textBoxPIN.UseSystemPasswordChar = true;
        }

        private void checkBoxTunjukkan_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTunjukkan.Checked == true)
            {
                textBoxPIN.UseSystemPasswordChar = false;
            }
            else
            {
                textBoxPIN.UseSystemPasswordChar = true;
            }
        }

        private void textBoxPIN_Enter(object sender, EventArgs e)
        {
            
        }

        private void textBoxPIN_Leave(object sender, EventArgs e)
        {
            
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi k = new Koneksi();

                FormTabunganPengguna formTabunganPengguna = (FormTabunganPengguna)this.Owner;

                Pengguna pengguna = formTabunganPengguna.p;

                if (textBoxPIN.Text == "Wajib diisi")
                {
                    MessageBox.Show("Anda harus mengisi PIN anda untuk melanjutkan aktivitas di aplikasi ini", "Informasi");
                }
                else
                {
                    DialogResult hasil = MessageBox.Show("Apakah anda yakin dengan PIN yang anda masukkan?", "Konfirmasi",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (hasil == DialogResult.Yes)
                    {
                        Pengguna.UbahPIN(pengguna, textBoxPIN.Text, k);

                        MessageBox.Show("Berhasil melakukan aktivitas", "Informasi");

                        Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal melakukan aktivitas. Pesan kesalahan: " + ex.Message, "Informasi");
            }
        }

        private void buttonCek_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi k = new Koneksi();

                FormTopUp formTopUp = (FormTopUp)this.Owner;

                Pengguna pengguna = formTopUp.p;

                Tabungan tabungan = formTopUp.tabungan;

                if (textBoxPIN.Text == "Wajib diisi")
                {
                    MessageBox.Show("Anda harus mengisi PIN anda untuk melanjutkan aktivitas di aplikasi ini", "Informasi");
                }
                else
                {
                    DialogResult hasil = MessageBox.Show("Apakah anda yakin dengan PIN yang anda masukkan?", "Konfirmasi",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (hasil == DialogResult.Yes)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            if (Pengguna.CekPIN(pengguna, textBoxPIN.Text) == true && i <= 2)
                            {
                                string no_rekening = Tabungan.AmbilDataNoRekening(pengguna.Nik);
                                Tabungan t = new Tabungan(no_rekening);
                                Tabungan.UbahSaldo(t, double.Parse(formTopUp.textBoxJumlah.Text), k);
                                MessageBox.Show("Berhasil topup", "Informasi");
                                Close();
                            }
                            else if (Pengguna.CekPIN(pengguna, textBoxPIN.Text) == false && i > 2)
                            {
                                Tabungan.UbahStatusSuspend(tabungan, k);
                                MessageBox.Show("Anda memasukkan PIN 3x berturut-turut dan gagal. Tabungan anda diblokir.");
                                Close();
                            }
                            else if (Pengguna.CekPIN(pengguna, textBoxPIN.Text) == false && i <= 2)
                            {
                                MessageBox.Show("Maaf, PIN yang anda masukkan salah. Silahkan coba lagi");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal melakukan aktivitas. Pesan kesalahan: " + ex.Message, "Informasi");
            }
        }
    }
}
