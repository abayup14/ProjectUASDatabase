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
    public partial class FormDaftarPosition : Form
    {
        public List<Position> listPosition = new List<Position>();

        Koneksi k;
        public FormDaftarPosition()
        {
            InitializeComponent();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahPosition formTambahPosition = new FormTambahPosition();

            formTambahPosition.Owner = this;

            formTambahPosition.Show();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void FormDaftarPosition_Load(object sender, EventArgs e)
        {
            k = new Koneksi();
            listPosition = Position.BacaData("", "");

            if (listPosition.Count > 0)
            {
                dataGridViewJabatan.DataSource = listPosition;

                if (dataGridViewJabatan.ColumnCount < 4)
                {
                    if (!dataGridViewJabatan.Columns.Contains("buttonUbahGrid") && !dataGridViewJabatan.Columns.Contains("buttonHapusGrid"))
                    {
                        DataGridViewButtonColumn bcol = new DataGridViewButtonColumn();
                        bcol.HeaderText = "Aksi";
                        bcol.Text = "Ubah";
                        bcol.Name = "buttonUbahGrid";
                        bcol.UseColumnTextForButtonValue = true;
                        dataGridViewJabatan.Columns.Add(bcol);

                        DataGridViewButtonColumn bcol2 = new DataGridViewButtonColumn();
                        bcol2.HeaderText = "Aksi";
                        bcol2.Text = "Hapus";
                        bcol2.Name = "buttonHapusGrid";
                        bcol2.UseColumnTextForButtonValue = true;
                        dataGridViewJabatan.Columns.Add(bcol2);
                    }
                }
            }
            else
            {
                dataGridViewJabatan = null;
            }
        }

        private void textBoxKriteria_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxKriteria.Text == "id")
            {
                listPosition = Position.BacaData("id", textBoxKriteria.Text);
            }
            else if (comboBoxKriteria.Text == "nama")
            {
                listPosition = Position.BacaData("nama", textBoxKriteria.Text);
            }

            if (listPosition.Count > 0)
            {
                dataGridViewJabatan.DataSource = listPosition;
            }
            else
            {
                dataGridViewJabatan = null;
            }
        }

        private void dataGridViewJabatan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewJabatan.Columns["buttonUbahGrid"].Index && e.RowIndex >= 0)
            {
                FormUbahPosition form = new FormUbahPosition();
                form.Owner = this;
                int pKodeKategori = int.Parse(dataGridViewJabatan.CurrentRow.Cells["PositionID"].Value.ToString());
                form.textBoxNamaJabatan.Text = dataGridViewJabatan.CurrentRow.Cells["nama"].Value.ToString();
                form.textBoxKeterangan.Text = dataGridViewJabatan.CurrentRow.Cells["keterangan"].Value.ToString();
                form.Show();
                //ambil kode kategori dari kolom dengan nama KodeKategori pada row yang sedang diklik
                

                //buat objek kategori baru untuk menampung hasil pengambilan data kategori sesuai kode yang dikirim
                //Position p = Position.AmbilDataByCode(pKodeKategori);

                //if (p != null)
                //{
                    
                //}
                //else
                //{
                //    MessageBox.Show("Terdapat kesalahan pada data");
                //}
            }

            //dataGridViewKategori.Columns["buttonHapusGrid"].Index --> periksa tombol hapus yang diklik
            //e.RowIndex >= 0 --> pastikan baris yang diklik ada datanya
            if (e.ColumnIndex == dataGridViewJabatan.Columns["buttonHapusGrid"].Index && e.RowIndex >= 0)
            {
                string idHapus = dataGridViewJabatan.CurrentRow.Cells["PositionID"].Value.ToString();
                string namaHapus = dataGridViewJabatan.CurrentRow.Cells["Nama"].Value.ToString();
                string keteranganHapus = dataGridViewJabatan.CurrentRow.Cells["Keterangan"].Value.ToString();

                //konfirmasi
                DialogResult konfirmasi = MessageBox.Show(this, 
                                                          "Data yang akan dihapus adalah : " +
                                                          "\nId Position : " + idHapus + 
                                                          "\nNama Poition : " + namaHapus + 
                                                          "\nKeterangan : " + keteranganHapus + 
                                                          "\n\nAnda yakin ingin menghapus data di atas?", "HAPUS", 
                                                          MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (konfirmasi == DialogResult.Yes)
                {
                    //bentuk objek dihapus
                    Position jabatanHapus = new Position(int.Parse(idHapus));

                    //panggil method hapus data
                    Position.HapusData(jabatanHapus, k);

                    //informasi bahwa berhasil menghapus
                    MessageBox.Show("Penghapusan data berhasil");

                    FormDaftarPosition_Load(buttonKeluar, e);
                }
            }
        }
    }
}
