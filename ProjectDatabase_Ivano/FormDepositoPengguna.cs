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
    public partial class FormDepositoPengguna : Form
    {
        FormDaftarDeposito formDaftarDeposito;

        public Deposito deposito;

        public Tabungan tabungan;

        public Pengguna pengguna;

        public FormDepositoPengguna()
        {
            InitializeComponent();
        }

        private void FormDepositoPengguna_Load(object sender, EventArgs e)
        {
            formDaftarDeposito = (FormDaftarDeposito)this.Owner;

            deposito = Deposito.AmbilDataDeposito(formDaftarDeposito.dataGridViewDeposito.CurrentRow.Cells["IDDeposito"].Value.ToString());

            tabungan = Tabungan.AmbilDataTabungan(deposito);

            pengguna = formDaftarDeposito.pengguna;
        }

        private void buttonCairkan_Click(object sender, EventArgs e)
        {
            if (tabungan.Status == "Aktif")
            {
                if (deposito.Status == "Aktif")
                {
                    FormPencairanDeposito formPencairanDeposito = new FormPencairanDeposito();
                    formPencairanDeposito.Owner = this;
                    formPencairanDeposito.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Maaf, status deposito anda tidak aktif." +
                                    "\nSilahkan hubungi pegawai kami untuk mengaktifkan deposito anda.", "Informasi");
                }
            }
            else
            {
                MessageBox.Show("Maaf, status tabungan anda tidak aktif." +
                               "\nSilahkan hubungi pegawai kami untuk mengaktifkan deposito anda.", "Informasi");
            }
        }
    }
}
