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
    public partial class FormTambahJenisTagihan : Form
    {
        public List<JenisTagihan> listJenisTagihan = new List<JenisTagihan>();

        public FormTambahJenisTagihan()
        {
            InitializeComponent();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi k = new Koneksi();

                DialogResult hasil = MessageBox.Show("Apakah data yang anda masukkan sudah benar?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (hasil == DialogResult.Yes)
                {
                    int id = JenisTagihan.GenerateKode();
                    JenisTagihan jt = new JenisTagihan(id, textBoxNamaJenisTagihan.Text);
                    JenisTagihan.TambahData(jt, k);

                    MessageBox.Show("Data jenis tagihan berhasil ditambahkan.", "Informasi");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data jenis tagihan gagal ditambahkan. Pesan kesalahan: " + ex.Message, "Kesalahan");
            }
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            textBoxNamaJenisTagihan.Clear();
            textBoxNamaJenisTagihan.Focus();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            FormDaftarJenisTagihan formDaftarJenisTagihan = (FormDaftarJenisTagihan)this.Owner;
            formDaftarJenisTagihan.FormDaftarJenisTagihan_Load(buttonKeluar, e);
            Close();
        }
    }
}
