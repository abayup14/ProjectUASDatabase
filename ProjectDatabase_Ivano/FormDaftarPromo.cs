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
using DiBa_LIB;

namespace ProjectDatabase_Ivano
{
    public partial class FormDaftarPromo : Form
    {
        public FormDaftarPromo()
        {
            InitializeComponent();
        }
        public List<Promo> listPromo = new List<Promo>();
        Koneksi k;
        private void FormDaftarPromo_Load(object sender, EventArgs e)
        {
            k = new Koneksi();
            listPromo = Promo.BacaData("", "");
            if (listPromo.Count > 0)
            {
                dataGridViewPromo.DataSource = listPromo;
                if (dataGridViewPromo.ColumnCount == 6)
                {
                    DataGridViewButtonColumn bcol1 = new DataGridViewButtonColumn();
                    bcol1.HeaderText = "Aksi";
                    bcol1.Text = "Ubah Data";
                    bcol1.Name = "buttonUbahGrid";
                    bcol1.UseColumnTextForButtonValue = true;
                    dataGridViewPromo.Columns.Add(bcol1);

                    DataGridViewButtonColumn bcol2 = new DataGridViewButtonColumn();
                    bcol2.HeaderText = "Aksi";
                    bcol2.Text = "Hapus Data";
                    bcol2.Name = "buttonHapusGrid";
                    bcol2.UseColumnTextForButtonValue = true;
                    dataGridViewPromo.Columns.Add(bcol2);
                }
            }
            else
            {
                dataGridViewPromo.DataSource = null;
            }
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahPromo formTambahPromo = new FormTambahPromo();
            formTambahPromo.Owner = this;
            formTambahPromo.Show();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewPromo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Koneksi k = new Koneksi();
            if (e.ColumnIndex == dataGridViewPromo.Columns["buttonUbahGrid"].Index && e.RowIndex >= 0)
            {
                
            }
            else if (e.ColumnIndex == dataGridViewPromo.Columns["buttonHapusGrid"].Index && e.RowIndex >= 0)
            {
                string nama = dataGridViewPromo.CurrentRow.Cells["NamaPromo"].Value.ToString();
                int id_Promo = int.Parse(dataGridViewPromo.CurrentRow.Cells["id"].Value.ToString());
                DateTime tgl_awal = DateTime.Parse(dataGridViewPromo.CurrentRow.Cells["tgl_awal"].Value.ToString());
                DateTime tgl_akhir = DateTime.Parse(dataGridViewPromo.CurrentRow.Cells["tgl_akhir"].Value.ToString());
                string keterangan = dataGridViewPromo.CurrentRow.Cells["keterangan"].Value.ToString();

                DialogResult hasil = MessageBox.Show("Data yang akan dihapus adalah " +
                                                     "\nID Pen : " + id_Promo +
                                                     "\nNama : " + nama +
                                                     "\nTanggal Awal: " + tgl_awal +
                                                     "\nTanggal Akhir : " + tgl_akhir +
                                                     "\n\nApakah anda yakin ingin menghapus data di atas?",
                                                     "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question); 
                if (hasil == DialogResult.Yes)
                {
                    Promo p = new Promo(nama);
                    Promo.HapusData(p, k);
                    MessageBox.Show("Data berhasil dihapus.", "Informasi");
                    FormDaftarPromo_Load(buttonKeluar, e);
                }
            }
        }
    }
}
