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
    public partial class FormUbahPromo : Form
    {
        public FormUbahPromo()
        {
            InitializeComponent();
        }

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi k = new Koneksi();

                FormDaftarPromo formDaftarPromo = (FormDaftarPromo)this.Owner;
                int id = int.Parse(formDaftarPromo.dataGridViewPromo.CurrentRow.Cells["id"].Value.ToString());
                string nama = formDaftarPromo.dataGridViewPromo.CurrentRow.Cells["nama"].Value.ToString();
                Promo p = new Promo(nama);

                Promo.UbahData(p, k);

                MessageBox.Show("Data position telah diubah.", "Info");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Pengubahan gagal. Pesan kesalahan: " + ex.Message, "Kesalahan");
            }
        }
    }
}
