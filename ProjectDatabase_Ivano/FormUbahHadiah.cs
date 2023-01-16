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
    public partial class FormUbahHadiah : Form
    {
        FormDaftarHadiah formDaftarHadiah;

        public FormUbahHadiah()
        {
            InitializeComponent();
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult hasil = MessageBox.Show("Apakah data yanga anda ingin ubah sudah benar?", "Konfirmasi",
                                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (hasil == DialogResult.Yes)
                {
                    Koneksi k = new Koneksi();
                    int id = int.Parse(formDaftarHadiah.dataGridViewHadiah.CurrentRow.Cells[id].Value.ToString());
                    Hadiah h = new Hadiah(id, textBoxNamaHadiah.Text, textBoxHargaHadiah.Text);
                    Hadiah.UbahData(h, k);
                    MessageBox.Show("Berhasil ubah data hadiah", "Informasi");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Data hadiah gagal diubah. Pesan kesalahan: " + ex.Message, "Kesalahan");
            }
        }

        private void FormUbahHadiah_Load(object sender, EventArgs e)
        {
            formDaftarHadiah = (FormDaftarHadiah)this.Owner;
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            textBoxNamaHadiah.Clear();
            textBoxHargaHadiah.Clear();
            textBoxNamaHadiah.Focus();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            formDaftarHadiah.FormDaftarHadiah_Load(buttonKeluar, e);
            Close();
        }
    }
}
