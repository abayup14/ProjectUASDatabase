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
    public partial class FormTambahPosition : Form
    {
        public FormTambahPosition()
        {
            InitializeComponent();
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Apakah data yang ada masukkan sudah benar?", "Konfirmasi", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    int id = Position.GenerateKode();

                    Position p = new Position(id, textBoxNamaJabatan.Text, textBoxKeterangan.Text);

                    Position.TambahData(p);

                    MessageBox.Show("Data position telah tersimpan.", "Info");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data position gagal disimpan. Pesan kesalahan: " + ex.Message, "Kesalahan");
            }
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            textBoxNamaJabatan.Clear();
            textBoxKeterangan.Clear();
            textBoxNamaJabatan.Focus();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            FormDaftarPosition formDaftarPosition = (FormDaftarPosition)this.Owner;

            formDaftarPosition.FormDaftarPosition_Load(buttonKeluar, e);

            this.Close();
        }

        private void FormTambahPosition_Load(object sender, EventArgs e)
        {

        }
    }
}
