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
    public partial class FormPencairanDeposito : Form
    {
        //Deposito deposito;
        public FormPencairanDeposito()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            DialogResult hasil = MessageBox.Show("Apakah anda yakin ingin mencairkan deposito anda?", "Konfirmasi", MessageBoxButtons.YesNo,
                                                         MessageBoxIcon.Question);

            if (hasil == DialogResult.Yes)
            {
                if (Deposito.AmbilDataNoDeposito(textBoxNoDeposito.Text) == true)
                {
                    Koneksi k = new Koneksi();
                    Deposito d = new Deposito(textBoxNoDeposito.Text);

                    DateTime tanggal = d.Tgl_buat.AddMonths(d.Jatuh_tempo);
                    if (tanggal > DateTime.Now)
                    {
                        Deposito.UbahStatus(d, k);
                        MessageBox.Show("Pencairan deposito kurang dari tanggal jatuh tempo sehingga anda dikenai denda sebanyak 5% dan tidak mendapatkan bunga.");
                        Deposito.UbahNominal(d, k);
                    }
                    else
                    {
                        Deposito.UbahStatus(d, k);
                        Deposito.TambahNominal(d, k);
                        MessageBox.Show("Pencairan berhasil");
                    }
                }
                else
                {
                    MessageBox.Show("Data no deposito tidak dapat ditemukan", "Informasi");
                }
            }
            else
            {
                MessageBox.Show("Pencairan dibatalkan");
            }
  

        }
    }
}
