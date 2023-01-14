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
    public partial class FormTabunganPengguna : Form
    {
        //FormUtama formUtama;
        FormDaftarTabungan formDaftarTabungan;

        public Pengguna p;

        public Tabungan t;

        public FormTabunganPengguna()
        {
            InitializeComponent();
        }

        private void FormTabunganPengguna_Load(object sender, EventArgs e)
        {
            formDaftarTabungan = (FormDaftarTabungan)this.Owner;

            p = formDaftarTabungan.pengguna;

            t = Tabungan.AmbilDataTabungan(formDaftarTabungan.dataGridViewTabungan.CurrentRow.Cells["NoRekening"].Value.ToString());
        }

        private void buttonTopUp_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonTransfer_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            formDaftarTabungan.FormDaftarTabungan_Load(buttonKeluar, e);
            Close();
        }
    }
}
