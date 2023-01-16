using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiBa_LIB;

namespace ProjectDatabase_Ivano
{
    public partial class FormTambahHadiah : Form
    {
        Koneksi k;
        public FormTambahHadiah()
        {
            InitializeComponent();
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                k = new Koneksi();
                DialogResult result = MessageBox.Show("Apakah hadiah yang ditambah sudah tepat ?", "Konfirmasi",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {

                    int id = Hadiah.GenerateKode();
                    Hadiah h = new Hadiah(id, textBoxNamaHadiah.Text, textBoxHargaHadiah.Text);
                    Hadiah.TambahData(h, k);
                    
                    MessageBox.Show("Berhasil", "Informasi");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Pembelian Gagal : ;" + ex.Message, "Kesalahan");
            }
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            textBoxNamaHadiah.Text = "";
            textBoxHargaHadiah.Text = "";
        }
    }
}
