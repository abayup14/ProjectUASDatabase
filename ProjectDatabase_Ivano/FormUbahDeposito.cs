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
    public partial class FormUbahDeposito : Form
    {
        Deposito deposito;
        public FormUbahDeposito()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            DialogResult hasil = MessageBox.Show("Apakah anda yakin ingin mengubah data anda?", "Konfirmasi", MessageBoxButtons.YesNo,
                                                         MessageBoxIcon.Question);

            if (hasil == DialogResult.Yes)
            {
                Deposito d = new Deposito(deposito.Id_deposito);

                DateTime tanggal = deposito.Tgl_buat.AddMonths(deposito.Jatuh_tempo);
                if (tanggal > DateTime.Now)
                {
                    Deposito.UbahStatus(d);
                    MessageBox.Show("Pencairan deposito kurang dari tanggal jatuh tempo sehingga anda dikenai denda sebanyak 5% dan tidak mendapatkan bunga.");
                    Deposito.UbahNominal(d);
                }
                else
                {
                    Deposito.UbahStatus(d);
                    Deposito.TambahNominal(d);
                    MessageBox.Show("Pencairan berhasil");
                }


            }
            else
            {
                MessageBox.Show("Pencairan dibatalkan");
            }
  

        }
    }
}
