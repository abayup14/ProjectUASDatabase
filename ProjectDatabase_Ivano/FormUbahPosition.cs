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
                FormDaftarPosition formDaftarPosition = (FormDaftarPosition)this.Owner;

                int id = int.Parse(formDaftarPosition.dataGridViewJabatan.CurrentRow.Cells["id"].Value.ToString());

                Position p = new Position(id, textBoxNamaJabatan.Text, textBoxKeterangan.Text);

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
    }
}
