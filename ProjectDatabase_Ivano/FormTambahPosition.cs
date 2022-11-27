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
                
                Position p = new Position(int.Parse(textBoxIdJabatan.Text), textBoxNamaJabatan.Text, textBoxKeterangan.Text);

                Position.TambahData(p);

                MessageBox.Show("Data jabatan telah tersimpan.", "Info");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Penyimpanan gagal. Pesan kesalahan: " + ex.Message, "Kesalahan");
            }
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            textBoxIdJabatan.Clear();
            textBoxNamaJabatan.Clear();
            textBoxIdJabatan.Focus();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            FormDaftarPosition formDaftarPosition = new FormDaftarPosition();
            formDaftarPosition.FormDaftarPosition_Load(buttonKeluar, e);

            this.Close();
        }
    }
}
