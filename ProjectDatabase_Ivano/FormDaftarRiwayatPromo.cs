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
    public partial class FormDaftarRiwayatPromo : Form
    {
        public List<RiwayatPromo> listRiwayatPromo = new List<RiwayatPromo>();

        public FormDaftarRiwayatPromo()
        {
            InitializeComponent();
        }

        private void FormDaftarRiwayatPromo_Load(object sender, EventArgs e)
        {
            Koneksi k = new Koneksi();

            listRiwayatPromo = RiwayatPromo.BacaData("", "");

            if(listRiwayatPromo.Count > 0 )
            {
                dataGridViewRiwayatPromo.DataSource = listRiwayatPromo;
            }
            else
            {
                dataGridViewRiwayatPromo.DataSource = null;
            }
        }
    }
}
