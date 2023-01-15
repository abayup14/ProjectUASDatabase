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
        List<RiwayatHadiah> listOfPenggunaHasHadiah = new List<RiwayatHadiah>();
        FormUtama frmUtama;
        public Pengguna pengguna;
        public Employee employee;
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
            frmUtama = (FormUtama)this.MdiParent;
            pengguna = frmUtama.pengguna;
            employee = frmUtama.employee;
            Koneksi k = new Koneksi();
            FormatDataGridRiwayatHadiah();
            if (pengguna != null)
            {
                listOfPenggunaHasHadiah = RiwayatHadiah.BacaData("p.nik", pengguna.Nik);
            }
            else if (employee != null)
            {
                listOfPenggunaHasHadiah = RiwayatHadiah.BacaData("", "");
            }
            if (listOfPenggunaHasHadiah.Count > 0)
            {
                foreach (RiwayatHadiah phh in listOfPenggunaHasHadiah)
                {
                    string nama = phh.Pengguna.Nama_depan + " " + phh.Pengguna.Nama_keluarga;
                    dataGridViewRiwayat.Rows.Add(nama, phh.Hadiah.Nama_hadiah, phh.Hadiah.Harga_hadiah);
                }

                //dataGridViewRiwayat.DataSource = listOfPenggunaHasHadiah;
                if (dataGridViewRiwayat.ColumnCount < 10)
                {
                    if (employee != null)
                    {
                        DataGridViewButtonColumn bcol1 = new DataGridViewButtonColumn();
                        bcol1.HeaderText = "Aksi";
                        bcol1.Text = "Ubah Data";
                        bcol1.Name = "buttonUbahGrid";
                        bcol1.UseColumnTextForButtonValue = true;
                        dataGridViewRiwayat.Columns.Add(bcol1);

                        DataGridViewButtonColumn bcol2 = new DataGridViewButtonColumn();
                        bcol2.HeaderText = "Aksi";
                        bcol2.Text = "Hapus Data";
                        bcol2.Name = "buttonHapusGrid";
                        bcol2.UseColumnTextForButtonValue = true;
                        dataGridViewRiwayat.Columns.Add(bcol2);
                    }
                }
            }
            else
            {
                dataGridViewRiwayat.DataSource = null;
            }
        }
        private void FormatDataGridRiwayatHadiah()
        {
            dataGridViewRiwayat.Rows.Clear();
            dataGridViewRiwayat.Columns.Clear();
            dataGridViewRiwayat.Columns.Add("NamaPengguna", "Nama Pengguna");
            dataGridViewRiwayat.Columns.Add("NamaHadiah", "Nama Hadiah");
            dataGridViewRiwayat.Columns.Add("Harga", "Harga Hadiah");

            dataGridViewRiwayat.Columns["NamaPengguna"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewRiwayat.Columns["NamaHadiah"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewRiwayat.Columns["Harga"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridViewRiwayat.AllowUserToAddRows = false;
        }

        private void dataGridViewRwayat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (employee != null)
            {
                if (e.ColumnIndex == dataGridViewRiwayat.Columns["buttonUbahGrid"].Index && e.RowIndex >= 0)
                {
                    FormUbahPengguna formUbahPengguna = new FormUbahPengguna();
                    formUbahPengguna.Owner = this;
                    formUbahPengguna.textBoxNIK.Text = dataGridViewRiwayat.CurrentRow.Cells["pengguna"].Value.ToString();
                    formUbahPengguna.textBoxNamaDepan.Text = dataGridViewRiwayat.CurrentRow.Cells["hadiah"].Value.ToString();
                    formUbahPengguna.ShowDialog();
                }
                else if (e.ColumnIndex == dataGridViewRiwayat.Columns["buttonHapusGrid"].Index && e.RowIndex >= 0)
                {
                    string id_pengguna = dataGridViewRiwayat.CurrentRow.Cells["pengguna"].Value.ToString();
                    string id_hadiah = dataGridViewRiwayat.CurrentRow.Cells["hadiah"].Value.ToString();
                    DialogResult hasil = MessageBox.Show("Berikut merupakan data yang akan dihapus : " +
                        "\nPengguna = " + id_pengguna +
                        "\nHadiah = " + id_hadiah +
                        " Apakah anda yakin menghapus data tersebut ?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (hasil == DialogResult.Yes)
                    {
                        Koneksi k = new Koneksi();
                        Pengguna pengguna = new Pengguna(id_pengguna);
                        Hadiah hadiah = new Hadiah(int.Parse(id_hadiah));
                        RiwayatHadiah ph = new RiwayatHadiah(pengguna, hadiah);
                        RiwayatHadiah.HapusData(ph, k);
                        MessageBox.Show("Data berhasil dihapus.", "Informasi");
                        dataGridViewRiwayat.Rows.Clear();
                        dataGridViewRiwayat.Columns.Clear();
                        FormRiwayatHadiah_Load(buttonKeluar, e);
                    }
                }
            }
        }
    }
}
