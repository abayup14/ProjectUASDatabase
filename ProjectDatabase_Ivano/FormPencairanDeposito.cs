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
        FormDepositoPengguna formDepositoPengguna;
        
        public Deposito deposito;
        public FormPencairanDeposito()
        {
            InitializeComponent();
        }

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            DialogResult hasil = MessageBox.Show("Apakah anda yakin ingin mencairkan deposito anda?", "Konfirmasi", MessageBoxButtons.YesNo,
                                                         MessageBoxIcon.Question);

            if (hasil == DialogResult.Yes)
            {
                Koneksi k = new Koneksi();
                Tabungan tabunganDeposito = Tabungan.AmbilDataTabungan(deposito);
                if (Deposito.AmbilDataNoDeposito(textBoxNoDeposito.Text) == true)
                {
                    
                    //Deposito d = new Deposito(textBoxNoDeposito.Text);

                    DateTime tanggal = deposito.Tgl_buat.AddMonths(deposito.Jatuh_tempo);
                    if (tanggal > DateTime.Now)
                    {
                        double saldo_akhir = 0;
                        double biaya_penalti = 0;
                        biaya_penalti = Deposito.BiayaPenalti(deposito);
                        MessageBox.Show("Pencairan deposito kurang dari tanggal jatuh tempo sehingga anda dikenai denda sebanyak 5% dan tidak mendapatkan bunga." + 
                                        "\nAnda mendapatkan penalti sebesar Rp. " + biaya_penalti.ToString());
                        saldo_akhir = deposito.Nominal - biaya_penalti;
                        Tabungan t = new Tabungan(tabunganDeposito.Rekening, saldo_akhir);
                        Tabungan.UpdateSaldo(t, k);
                        MessageBox.Show("Berhasil menambah Rp. " + saldo_akhir.ToString() + " ke tabungan.", "Informasi");
                        Deposito.HapusData(deposito, k);
                    }
                    else
                    {
                        double bunga_deposito = 0;
                        double saldo_akhir = 0;
                        bunga_deposito = Deposito.TambahBunga(deposito);
                        MessageBox.Show("Anda mendapatkan bunga sebesar Rp. " + bunga_deposito.ToString(), "Informasi");
                        saldo_akhir = deposito.Nominal + bunga_deposito;
                        Tabungan t = new Tabungan(tabunganDeposito.Rekening, saldo_akhir);
                        Tabungan.UpdateSaldo(t, k);
                        MessageBox.Show("Berhasil melakukan pencairan sebesar Rp. " + saldo_akhir.ToString() + 
                                        " dan ditambahkan ke tabungan", "Informasi");
                        Deposito.HapusData(deposito, k);
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

        private void FormPencairanDeposito_Load(object sender, EventArgs e)
        {
            formDepositoPengguna = (FormDepositoPengguna)this.Owner;

            deposito = formDepositoPengguna.deposito;
        }
    }
}
