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
    public partial class FormRiwayatHadiah : Form
    {
        List<Pengguna_has_Hadiah> listOfPenggunaHasHadiah = new List<Pengguna_has_Hadiah>();
        public FormRiwayatHadiah()
        {
            InitializeComponent();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormRiwayatHadiah_Load(object sender, EventArgs e)
        {
            Koneksi k = new Koneksi();
            listOfPenggunaHasHadiah = Pengguna_has_Hadiah.BacaData("", "");
            if (listOfPenggunaHasHadiah.Count > 0)
            {
                dataGridViewRwayat.DataSource = listOfPenggunaHasHadiah;
                if (dataGridViewRwayat.ColumnCount == 2)
                {
                    DataGridViewButtonColumn bcol1 = new DataGridViewButtonColumn();
                    bcol1.HeaderText = "Aksi";
                    bcol1.Text = "Ubah Data";
                    bcol1.Name = "buttonUbahGrid";
                    bcol1.UseColumnTextForButtonValue = true;
                    dataGridViewRwayat.Columns.Add(bcol1);

                    DataGridViewButtonColumn bcol2 = new DataGridViewButtonColumn();
                    bcol2.HeaderText = "Aksi";
                    bcol2.Text = "Hapus Data";
                    bcol2.Name = "buttonHapusGrid";
                    bcol2.UseColumnTextForButtonValue = true;
                    dataGridViewRwayat.Columns.Add(bcol2);
                }
            }
            else
            {
                dataGridViewRwayat.DataSource = null;
            }
        }

        private void dataGridViewRwayat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewRwayat.Columns["buttonUbahGrid"].Index && e.RowIndex >= 0)
            {
                FormUbahPengguna formUbahPengguna = new FormUbahPengguna();
                formUbahPengguna.Owner = this;
                formUbahPengguna.textBoxNIK.Text = dataGridViewRwayat.CurrentRow.Cells["pengguna"].Value.ToString();
                formUbahPengguna.textBoxNamaDepan.Text = dataGridViewRwayat.CurrentRow.Cells["hadiah"].Value.ToString();
                formUbahPengguna.ShowDialog();
            }
            else if (e.ColumnIndex == dataGridViewRwayat.Columns["buttonHapusGrid"].Index && e.RowIndex >= 0)
            { 
                string pengguna = dataGridViewRwayat.CurrentRow.Cells["pengguna"].Value.ToString();
                string hadiah = dataGridViewRwayat.CurrentRow.Cells["hadiah"].Value.ToString();
                DialogResult hasil = MessageBox.Show("Berikut merupakan data yang akan dihapus : " +
                    "\nPengguna = " + pengguna +
                    "\nHadiah = " + hadiah +
                    " Apakah anda yakin menghapus data tersebut ?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (hasil == DialogResult.Yes)
                {
                    Koneksi k = new Koneksi();
                    Pengguna pengguna2 = new Pengguna(pengguna);
                    Hadiah hadiah2 = new Hadiah(int.Parse(hadiah));
                    Pengguna_has_Hadiah ph = new Pengguna_has_Hadiah(pengguna2, hadiah2);
                    Pengguna_has_Hadiah.HapusData(ph, k);
                    MessageBox.Show("Data berhasil dihapus.", "Informasi");
                    FormRiwayatHadiah_Load(buttonKeluar, e);
                }
            }
        }
    }
}
