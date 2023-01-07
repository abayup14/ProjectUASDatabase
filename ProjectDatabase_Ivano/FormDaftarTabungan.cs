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
    public partial class FormDaftarTabungan : Form
    {
        public List<Tabungan> listTabungan = new List<Tabungan>();

        Koneksi k;

        public FormDaftarTabungan()
        {
            InitializeComponent();
        }

        public void FormDaftarTabungan_Load(object sender, EventArgs e)
        {
            k = new Koneksi();
            listTabungan = Tabungan.BacaData("", "");

            if (listTabungan.Count > 0)
            {
                dataGridViewTabungan.DataSource = listTabungan;
                if (dataGridViewTabungan.ColumnCount == 8)
                {
                    DataGridViewButtonColumn bcol1 = new DataGridViewButtonColumn();
                    bcol1.HeaderText = "Aksi";
                    bcol1.Text = "Ubah Status";
                    bcol1.Name = "buttonUbahStatusGrid";
                    bcol1.UseColumnTextForButtonValue = true;
                    dataGridViewTabungan.Columns.Add(bcol1);

                    DataGridViewButtonColumn bcol2 = new DataGridViewButtonColumn();
                    bcol2.HeaderText = "Aksi";
                    bcol2.Text = "Hapus Data";
                    bcol2.Name = "buttonHapusGrid";
                    bcol2.UseColumnTextForButtonValue = true;
                    dataGridViewTabungan.Columns.Add(bcol2);
                }
            }
            else
            {
                dataGridViewTabungan.DataSource = null;
            }
        }

        private void dataGridViewTabungan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == dataGridViewTabungan.Columns["buttonHapusGrid"].Index && e.RowIndex >= 0)
            {
                string nik = dataGridViewTabungan.CurrentRow.Cells["pengguna"].Value.ToString();
                string id_pengguna = Pengguna.AmbilNamaLengkap(nik);
                string no_rekening = dataGridViewTabungan.CurrentRow.Cells["rekening"].Value.ToString();
                double saldo = double.Parse(dataGridViewTabungan.CurrentRow.Cells["saldo"].Value.ToString());
                string status = dataGridViewTabungan.CurrentRow.Cells["status"].Value.ToString();
                string keterangan = dataGridViewTabungan.CurrentRow.Cells["keterangan"].Value.ToString();
                DateTime tgl_buat = DateTime.Parse(dataGridViewTabungan.CurrentRow.Cells["tgl_buat"].Value.ToString());
                DateTime tgl_perubahan = DateTime.Parse(dataGridViewTabungan.CurrentRow.Cells["tgl_perubahan"].Value.ToString());
                string id = dataGridViewTabungan.CurrentRow.Cells["verifikator"].Value.ToString();
                string verifikator = Employee.AmbilNamaLengkap(id);

                DialogResult hasil = MessageBox.Show("Data yang akan dihapus adalah " +
                                                     "\nNo Rekening : " + no_rekening +
                                                     "\nNama Pengguna : " + id_pengguna +
                                                     "\nSaldo : " + saldo +
                                                     "\nStatus : " + status +
                                                     "\nKeterangan : " + keterangan +
                                                     "\ntgl_buat : " + tgl_buat +
                                                     "\ntgl_perubahan : " + tgl_perubahan +
                                                     "\nVerifikator : " + verifikator +
                                                     "\n\nApakah anda yakin ingin menghapus data di atas?",
                                                     "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (hasil == DialogResult.Yes)
                {
                    Tabungan t = new Tabungan(no_rekening);
                    Tabungan.HapusData(t, k);
                    MessageBox.Show("Data Berhasil Dihapus.", "Informasi");
                    FormDaftarTabungan_Load(buttonKeluar, e);

                }
            }
            else if (e.ColumnIndex == dataGridViewTabungan.Columns["buttonUbahStatusGrid"].Index && e.RowIndex >= 0)
            {
                FormUtama formUtama = (FormUtama)this.MdiParent;
                string nik = dataGridViewTabungan.CurrentRow.Cells["pengguna"].Value.ToString();
                Pengguna id_pengguna = Pengguna.AmbilDataByKode(nik);
                string no_rekening = dataGridViewTabungan.CurrentRow.Cells["rekening"].Value.ToString();
                double saldo = double.Parse(dataGridViewTabungan.CurrentRow.Cells["saldo"].Value.ToString());
                string status = dataGridViewTabungan.CurrentRow.Cells["status"].Value.ToString();
                string keterangan = dataGridViewTabungan.CurrentRow.Cells["keterangan"].Value.ToString();
                DateTime tgl_buat = DateTime.Parse(dataGridViewTabungan.CurrentRow.Cells["tgl_buat"].Value.ToString());
                //DateTime tgl_perubahan = DateTime.Parse(dataGridViewTabungan.CurrentRow.Cells["tgl_perubahan"].Value.ToString());
                int id = int.Parse(dataGridViewTabungan.CurrentRow.Cells["verifikator"].Value.ToString());
                Employee verifikator = formUtama.employee;

                Tabungan t = new Tabungan(no_rekening, id_pengguna, saldo, status, keterangan, tgl_buat, 
                    DateTime.Now, verifikator);
                Tabungan.UbahData(t, verifikator, k);
                MessageBox.Show("Data Berhasil Dirubah.", "Informasi");
                FormDaftarTabungan_Load(buttonKeluar, e);
            }
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
