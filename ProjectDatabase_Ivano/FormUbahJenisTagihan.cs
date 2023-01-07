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
    public partial class FormUbahJenisTagihan : Form
    {
        public FormUbahJenisTagihan()
        {
            InitializeComponent();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi k = new Koneksi();
                DialogResult hasil = MessageBox.Show("Apakah anda ingin mengubah data anda?", "Konfirmasi", MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Question);

                if (hasil == DialogResult.Yes)
                {
                    FormDaftarJenisTagihan formDaftarJenisTagihan = (FormDaftarJenisTagihan)this.Owner;

                    int id = int.Parse(formDaftarJenisTagihan.dataGridViewJenisTagihan.CurrentRow.Cells["id"].Value.ToString());

                    JenisTagihan jt = new JenisTagihan(id, textBoxNamaTagihan.Text);

                    JenisTagihan.UbahData(jt, k);

                    MessageBox.Show("Data jenis tagihan berhasil diubah", "Informasi");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data jenis tagihan gagal di ubah. Pesan kesalahan: " + ex.Message, "Kesalahan");
            }
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            textBoxNamaTagihan.Clear();
            textBoxNamaTagihan.Focus();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            FormDaftarJenisTagihan formDaftarJenisTagihan = (FormDaftarJenisTagihan)this.Owner;
            formDaftarJenisTagihan.FormDaftarJenisTagihan_Load(buttonKeluar, e);
            Close();
        }
    }
}
