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
    public partial class FormTambahPromo : Form
    {
        public FormTambahPromo()
        {
            InitializeComponent();
        }

        public List<Promo> listPromo = new List<Promo>();

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonKirim_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi k = new Koneksi();
                DialogResult hasil = MessageBox.Show("Apakah data yang anda masukkan sudah benar?", "Konfirmasi", MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Question);

                if (hasil == DialogResult.Yes)
                {
                    Promo p = new Promo(Promo.GenerateKode(), textBoxNamaPromo.Text, dateTimePickerTglAwal.Value, dateTimePickerTglAwal.Value, textBoxKeterangan.Text); 

                    

                    Promo.TambahData(p, k);

                    MessageBox.Show("Promo berhasil dotambah", "Informasi");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Promo gagal ditambah. Pesan kesalahan : " + ex.Message, "Error");
            }
        }

        private void FormTambahPromo_Load(object sender, EventArgs e)
        {

        }
    }
    
}
