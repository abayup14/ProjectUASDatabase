using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
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

        //public List<Promo> listPromo = new List<Promo>();

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi k = new Koneksi();
                DialogResult hasil = MessageBox.Show("Apakah data yang anda masukkan sudah benar?", "Konfirmasi", MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Question);

                if (hasil == DialogResult.Yes)
                {
                    Promo p = new Promo(Promo.GenerateKode(), textBoxNamaPromo.Text, int.Parse(textBoxNominalDiskon.Text), dateTimePickerTglAwal.Value, dateTimePickerTglAwal.Value, textBoxKeterangan.Text);



                    Promo.TambahData(p, k);

                    MessageBox.Show("Promo berhasil ditambah", "Informasi");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Promo gagal ditambah. Pesan kesalahan : " + ex.Message, "Error");
            }
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    
}
