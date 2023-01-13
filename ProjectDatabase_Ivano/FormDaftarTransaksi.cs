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
    public partial class FormDaftarTransaksi : Form
    {
        public FormDaftarTransaksi()
        {
            InitializeComponent();
        }

        List<Transaksi> listTransaksi = new List<Transaksi>();

        FormUtama formUtama;

        public Pengguna pengguna;

        public void FormDaftarTransaksi_Load(object sender, EventArgs e)
        {
            formUtama = (FormUtama)this.MdiParent;

            pengguna = formUtama.pengguna;

            listTransaksi = Transaksi.BacaData("", "");
            if (listTransaksi.Count > 0)
            {
                dataGridViewTransaksi.DataSource = listTransaksi;
            }
            else
            {
                dataGridViewTransaksi.DataSource = null;
            }
        }

        private void dataGridViewTransaksi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
