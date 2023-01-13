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
        FormUtama formUtama;

        public Pengguna pengguna;

        public FormDepositoPengguna()
        {
            InitializeComponent();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahDeposito formTambahDeposito = new FormTambahDeposito();
            formTambahDeposito.Owner = this;
            formTambahDeposito.ShowDialog();
        }

        private void FormDepositoPengguna_Load(object sender, EventArgs e)
        {
            formUtama = (FormUtama)this.MdiParent;

            pengguna = formUtama.pengguna;
        }

        private void buttonCairkan_Click(object sender, EventArgs e)
        {
            FormPencairanDeposito formPencairanDeposito = new FormPencairanDeposito();
            formPencairanDeposito.Owner = this;
            formPencairanDeposito.Show();
        }
    }
}
