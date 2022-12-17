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

        private void FormDaftarTransaksi_Load(object sender, EventArgs e)
        {
            formUtama = (FormUtama)this.MdiParent;

            pengguna = formUtama.pengguna;

            listTransaksi = Transaksi.BacaData("", "");
            if (listTransaksi.Count > 0)
            {
                dataGridViewTransaksi.DataSource =listTransaksi;
                if (dataGridViewTransaksi.ColumnCount == 6)
                {
                    DataGridViewButtonColumn bcol1 = new DataGridViewButtonColumn();
                    bcol1.HeaderText = "Aksi";
                    bcol1.Text = "Ubah Data";
                    bcol1.Name = "buttonUbahGrid";
                    bcol1.UseColumnTextForButtonValue = true;
                    dataGridViewTransaksi.Columns.Add(bcol1);

                    DataGridViewButtonColumn bcol2 = new DataGridViewButtonColumn();
                    bcol2.HeaderText = "Aksi";
                    bcol2.Text = "Hapus Data";
                    bcol2.Name = "buttonHapusGrid";
                    bcol2.UseColumnTextForButtonValue = true;
                    dataGridViewTransaksi.Columns.Add(bcol2);
                }
            }
            else
            {
                dataGridViewTransaksi.DataSource = null;
            }
        }

        private void dataGridViewTransaksi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == dataGridViewTransaksi.Columns["buttonUbahGrid"].Index && e.RowIndex == 0)
            {
                FormUbahTransaksi formUbahTransaksi = new FormUbahTransaksi();
                formUbahTransaksi.Owner = this;
                formUbahTransaksi.Show();

                //fo
            }
            else
            {

            }
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahTransaksi formTambahTransaksi = new FormTambahTransaksi();
            formTambahTransaksi.Owner = this;
            formTambahTransaksi.Show();
        }
    }
}
