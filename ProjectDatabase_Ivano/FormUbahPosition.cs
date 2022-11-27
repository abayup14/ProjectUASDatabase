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
    public partial class FormUbahPosition : Form
    {
        public FormUbahPosition()
        {
            InitializeComponent();
        }

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            try
            {
                Position p = new Position(int.Parse(textBoxIdJabatan.Text), textBoxNamaJabatan.Text, textBoxKeterangan.Text);

                Position.UbahData(p);

                MessageBox.Show("Data jabatan telah diubah.", "Info");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Pengubahan gagal. Pesan kesalahan: " + ex.Message, "Kesalahan");
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
