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
    public partial class FormDaftarPoin : Form
    {
        public List<Pengguna> listPengguna = new List<Pengguna>();
        public List<Poin> listPoin = new List<Poin>();
        Koneksi k;
        public FormDaftarPoin()
        {
            InitializeComponent();
        }

        private void FormDaftarPoin_Load(object sender, EventArgs e)
        {
            k = new Koneksi();
            listPoin = Poin.BacaData("", "");
            if (listPoin.Count > 0)
            {
                dataGridViewInbox.DataSource = listPoin;
                //if (dataGridViewInbox.ColumnCount == 2)
                //{
                //    DataGridViewButtonColumn bcol1 = new DataGridViewButtonColumn();
                //    bcol1.HeaderText = "Aksi";
                //    bcol1.Text = "Ubah Data";
                //    bcol1.Name = "buttonUbahGrid";
                //    bcol1.UseColumnTextForButtonValue = true;
                //    dataGridViewInbox.Columns.Add(bcol1);

                //    DataGridViewButtonColumn bcol2 = new DataGridViewButtonColumn();
                //    bcol2.HeaderText = "Aksi";
                //    bcol2.Text = "Hapus Data";
                //    bcol2.Name = "buttonHapusGrid";
                //    bcol2.UseColumnTextForButtonValue = true;
                //    dataGridViewInbox.Columns.Add(bcol2);
                //}
            }
            else
            {
                dataGridViewInbox.DataSource = null;
            }
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxNilaiKriteria_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxKriteria.Text == "id_pengguna")
            {
                listPoin = Poin.BacaData("id_pengguna", textBoxNilaiKriteria.Text);
            }
            else if (comboBoxKriteria.Text == "jumlah_poin")
            {
                listPoin = Poin.BacaData("jumlah_poin", textBoxNilaiKriteria.Text);
            }
            if (listPoin.Count > 0)
            {
                dataGridViewInbox.DataSource = listPoin;
            }
            else
            {
                dataGridViewInbox.DataSource = null;
            }
        }

        private void dataGridViewInbox_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
