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
    public partial class FormUbahTabungan : Form
    {
        FormTabunganPengguna formTabunganPengguna;

        public Tabungan tabungan;

        public Pengguna pengguna;

        public FormUbahTabungan()
        {
            InitializeComponent();
        }

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi k = new Koneksi();
                DialogResult hasil = MessageBox.Show("Apakah anda yakin ingin mengubah keterangan tabungan?", 
                                                     "Konfirmasi", MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Question);

                if (hasil == DialogResult.Yes)
                {
                    Pengguna p = pengguna;
                    Tabungan t = new Tabungan(formTabunganPengguna.labelRekening.Text,
                                              p,
                                              double.Parse(formTabunganPengguna.labelSaldo.Text),
                                              tabungan.Status,
                                              textBoxKeterangan.Text,
                                              tabungan.Tgl_buat,
                                              DateTime.Now,
                                              tabungan.Verifikator);

                    Tabungan.UbahKeterangan(t, k);

                    MessageBox.Show("Data keterangan tabungan berhasil diubah", "Informasi");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Pengubahan gagal. Pesan kesalahan: " + ex.Message, "Kesalahan");
            }
        }

        private void FormUbahTabungan_Load(object sender, EventArgs e)
        {
            formTabunganPengguna = (FormTabunganPengguna)this.Owner;

            tabungan = formTabunganPengguna.t;

            pengguna = formTabunganPengguna.p;
        }
    }
}
