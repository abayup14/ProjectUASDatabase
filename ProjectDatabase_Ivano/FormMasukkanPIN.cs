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

        int countMistake = 0;

        public FormMasukkanPIN()
        {
            InitializeComponent();
        }

        private void FormMasukkanPIN_Load(object sender, EventArgs e)
        {
            ActiveControl = label1;
            textBoxPIN.Text = "Masukkan PIN anda";
            textBoxPIN.Font = new Font(textBoxPIN.Font, FontStyle.Italic);
            textBoxPIN.ForeColor = Color.Gray;
            textBoxPIN.UseSystemPasswordChar = false;
        }

        private void checkBoxTunjukkan_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTunjukkan.Checked == true)
            {
                textBoxPIN.UseSystemPasswordChar = false;
            }
            else
            {
                if (textBoxPIN.Text == "Masukkan PIN anda")
                {
                    textBoxPIN.UseSystemPasswordChar = false;
                }
                else
                {
                    textBoxPIN.UseSystemPasswordChar = true;
                }
            }
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi k = new Koneksi();

                FormUtama formUtama = (FormUtama)this.MdiParent;

                FormDaftarTabungan formDaftarTabungan = (FormDaftarTabungan)this.Owner;

                Pengguna pengguna = null;
                if (formUtama != null)
                {
                    pengguna = formUtama.pengguna;
                }
                else if (formDaftarTabungan != null)
                {
                    pengguna = formDaftarTabungan.pengguna;
                }
                
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

                        DialogResult = DialogResult.OK;

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

                if (textBoxPIN.Text == "Masukkan PIN anda")
                {
                    MessageBox.Show("Anda harus mengisi PIN anda untuk melanjutkan aktivitas di aplikasi ini", "Informasi");
                }
                else
                {
                    if (Pengguna.CekPIN(pengguna, textBoxPIN.Text) == true)
                    {
                        if (formTopUp != null)
                        {
                            if (tabungan.Status == "Aktif")
                            {
                                JenisTransaksi jt = new JenisTransaksi(1);
                                Promo pr = new Promo();
                                JenisTagihan jtg = new JenisTagihan();
                                Transaksi tr = new Transaksi(tabungan, 
                                                             Transaksi.GenerateKode(), 
                                                             DateTime.Now,
                                                             jt, 
                                                             tabungan, 
                                                             double.Parse(formTopUp.textBoxJumlah.Text),
                                                             "Top Up", 
                                                             pr, 
                                                             jtg);
                                Inbox i = new Inbox(pengguna,
                                                    Inbox.GenerateKode(),
                                                    "Berhasil topup ke rekening " + tabungan.Rekening + " sebesar Rp. " + formTopUp.textBoxJumlah.Text,
                                                    DateTime.Now,
                                                    "Belum Terbaca",
                                                    DateTime.Now);
                                Transaksi.TambahTransaksiTopUp(tr, k);
                                Tabungan.UpdateSaldoTopUp(tabungan, double.Parse(formTopUp.textBoxJumlah.Text), k);
                                Inbox.TambahData(i, k);
                                Poin poin = new Poin(pengguna, 50);
                                Poin.UpdatePoin(poin, k);
                                MessageBox.Show("Berhasil topup sebesar Rp. " + formTopUp.textBoxJumlah.Text + 
                                                "\nAnda Mendapatkan 50 poin dari transaksi ini.", "Informasi");
                            }
                            else
                            {
                                MessageBox.Show("Maaf, tabungan yang anda pilih belum aktif." +
                                                "\nSilahkan hubungi pegawai kami untuk mengaktifkan tabungan.", "Informasi");
                            }
                        }
                        countMistake = 0;
                        Close();
                    }
                    else
                    {
                        countMistake++;
                        if (countMistake <= 2)
                        {
                            MessageBox.Show("Maaf, PIN yang anda masukkan salah. Silahkan coba lagi");
                            textBoxPIN.Clear();
                        }
                        else
                        {
                            Tabungan.UbahStatusSuspend(tabungan, k);
                            MessageBox.Show("Anda memasukkan PIN 3x berturut-turut dan gagal. Tabungan anda diblokir." +
                                            "\nSilahkan hubungi pegawai kami untuk mengaktifkan kembali", "Informasi");
                            countMistake = 0;
                            Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal melakukan aktivitas. Pesan kesalahan: " + ex.Message, "Informasi");
            }
        }
        private void buttonCekTransaksi_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi k = new Koneksi();

                FormTambahTransaksi formTambahTransaksi = (FormTambahTransaksi)this.Owner;

                Pengguna pengguna = formTambahTransaksi.pengguna;

                Tabungan tabunganSumber = formTambahTransaksi.tabunganSumber;

                Tabungan tabunganTujuan = formTambahTransaksi.tabunganTujuan;

                if (textBoxPIN.Text == "Masukkan PIN anda")
                {
                    MessageBox.Show("Anda harus mengisi PIN anda untuk melanjutkan aktivitas di aplikasi ini", "Informasi");
                }
                else
                {
                    if (Pengguna.CekPIN(pengguna, textBoxPIN.Text) == true)
                    {
                        if (formTambahTransaksi != null)
                        {
                            if (tabunganSumber.Status == "Aktif" && tabunganTujuan.Status == "Aktif")
                            {
                                Promo p = null;
                                if (formTambahTransaksi.checkBoxPromo.Checked == true)
                                {
                                    p = (Promo)formTambahTransaksi.comboBoxPromo.SelectedItem;
                                }
                                else
                                {
                                    p = new Promo();
                                }

                                JenisTagihan j = null;
                                if (formTambahTransaksi.checkBoxTagihan.Checked == true)
                                {
                                    j = (JenisTagihan)formTambahTransaksi.comboBoxJenisTagihan.SelectedItem;
                                }
                                else
                                {
                                    j = new JenisTagihan();
                                }


                                Transaksi tS = new Transaksi(tabunganSumber,
                                                            Transaksi.GenerateKode(),
                                                            DateTime.Now,
                                                            tabunganTujuan,
                                                            double.Parse(formTambahTransaksi.textBoxNominal.Text),
                                                            formTambahTransaksi.textBoxKeterangan.Text,
                                                            p,
                                                            j);
                                
                                Transaksi.TambahTransaksiSumber(tS, k);

                                Transaksi tT = new Transaksi(tabunganTujuan,
                                                            Transaksi.GenerateKode(),
                                                            DateTime.Now,
                                                            tabunganSumber,
                                                            double.Parse(formTambahTransaksi.textBoxNominal.Text),
                                                            formTambahTransaksi.textBoxKeterangan.Text,
                                                            p,
                                                            j);
                                Transaksi.TambahTransaksiTujuan(tT, k);

                                Transaksi.UpdateSaldoTransaksi(tS, k);
                                
                                if (formTambahTransaksi.comboBoxPromo.Text != "")
                                {
                                    RiwayatPromo rp = new RiwayatPromo(RiwayatPromo.GenerateKode(),
                                                                       p,
                                                                       tabunganSumber.Pengguna,
                                                                       DateTime.Now);
                                    RiwayatPromo.TambahData(rp, k);
                                }

                                Inbox inboxSumber = new Inbox(tabunganSumber.Pengguna,
                                                              Inbox.GenerateKode(),
                                                              "Berhasil transfer ke rekening " + tabunganTujuan.Rekening +
                                                              " sebesar Rp. " + formTambahTransaksi.textBoxNominal.Text +
                                                              "\nKeterangan: " + formTambahTransaksi.textBoxKeterangan.Text,
                                                              DateTime.Now,
                                                              "Belum Terbaca",
                                                              DateTime.Now);
                                Inbox.TambahData(inboxSumber, k);

                                Inbox inboxTujuan = new Inbox(tabunganTujuan.Pengguna,
                                                              Inbox.GenerateKode(),
                                                              "Mendapatkan transfer dari rekening " + tabunganSumber.Rekening +
                                                              " sebesar Rp. " + formTambahTransaksi.textBoxNominal.Text +
                                                              "\nKeterangan: " + formTambahTransaksi.textBoxKeterangan.Text,
                                                              DateTime.Now,
                                                              "Belum Terbaca",
                                                              DateTime.Now);
                                Inbox.TambahData(inboxTujuan, k);

                                Poin poin = new Poin(pengguna, 100);
                                Poin.UpdatePoin(poin, k);

                                MessageBox.Show("Transaksi berhasil dilakukan." +
                                                "\nAnda mendapatkan 100 poin dari transaksi ini.", "Informasi");
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
                        countMistake = 0;
                        Close();
                    }
                    else
                    {
                        countMistake++;
                        if (countMistake <= 2)
                        {
                            MessageBox.Show("Maaf, PIN yang anda masukkan salah. Silahkan coba lagi");
                            textBoxPIN.Clear();
                        }
                        else
                        {
                            Tabungan.UbahStatusSuspend(tabunganSumber, k);
                            MessageBox.Show("Anda memasukkan PIN 3x berturut-turut dan gagal. Tabungan anda diblokir." +
                                            "\nSilahkan hubungi pegawai kami untuk mengaktifkan kembali", "Informasi");
                            countMistake = 0;
                            Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal melakukan aktivitas. Pesan kesalahan: " + ex.Message, "Informasi");
            }
        }
        private void textBoxPIN_Enter(object sender, EventArgs e)
        {
            if (textBoxPIN.Text == "Masukkan PIN anda")
            {
                textBoxPIN.Text = "";
                textBoxPIN.Font = new Font(textBoxPIN.Font, FontStyle.Regular);
                textBoxPIN.ForeColor = Color.Black;
                textBoxPIN.UseSystemPasswordChar = true;
            }
        }

        private void textBoxPIN_Leave(object sender, EventArgs e)
        {
            if (textBoxPIN.Text == "")
            {
                textBoxPIN.Text = "Masukkan PIN anda";
                textBoxPIN.Font = new Font(textBoxPIN.Font, FontStyle.Italic);
                textBoxPIN.ForeColor = Color.Gray;
                textBoxPIN.UseSystemPasswordChar = false;
            }
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
