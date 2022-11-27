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
    public partial class FormDaftarJenisTransaksi : Form
    {
        public List<JenisTransaksi> listJenisTransaksi = new List<JenisTransaksi>();
        public FormDaftarJenisTransaksi()
        {
            InitializeComponent();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahJenisTransaksi formTambahJenisTransaksi = new FormTambahJenisTransaksi();

            formTambahJenisTransaksi.Owner = this;

            formTambahJenisTransaksi.Show();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void FormDaftarJenisTransaksi_Load(object sender, EventArgs e)
        {
            listJenisTransaksi = JenisTransaksi.ReadData("", "");

            if (listJenisTransaksi.Count > 0)
            {
                dataGridViewJenisTransaksi.DataSource = listJenisTransaksi;

                if (dataGridViewJenisTransaksi.ColumnCount == 3)
                {
                    DataGridViewButtonColumn bcol1 = new DataGridViewButtonColumn();
                    bcol1.HeaderText = "Aksi";
                    bcol1.Text = "Ubah Data";
                    bcol1.Name = "buttonUbahGrid";
                    bcol1.UseColumnTextForButtonValue = true;
                    dataGridViewJenisTransaksi.Columns.Add(bcol1);

                    DataGridViewButtonColumn bcol2 = new DataGridViewButtonColumn();
                    bcol2.HeaderText = "Aksi";
                    bcol2.Text = "Hapus Data";
                    bcol2.Name = "buttonHapusGrid";
                    bcol2.UseColumnTextForButtonValue = true;
                    dataGridViewJenisTransaksi.Columns.Add(bcol2);
                }
            }
            else
            {
                dataGridViewJenisTransaksi.DataSource = null;
            }
        }
        private void dataGridViewJenisTransaksi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewJenisTransaksi.Columns["buttonUbahGrid"].Index && e.RowIndex >= 0)
            {
                FormUbahJenisTransaksi formUbahJenisTransaksi = new FormUbahJenisTransaksi();
                formUbahJenisTransaksi.Owner = this;

                formUbahJenisTransaksi.textBoxKodeJenisTransaksi.Text = dataGridViewJenisTransaksi.CurrentRow.Cells["kode"].Value.ToString();
                formUbahJenisTransaksi.textBoxNamaJenisTransaksi.Text = dataGridViewJenisTransaksi.CurrentRow.Cells["nama"].Value.ToString();

                formUbahJenisTransaksi.ShowDialog();
            }
            else if (e.ColumnIndex == dataGridViewJenisTransaksi.Columns["buttonHapusGrid"].Index && e.RowIndex >= 0)
            {
                int id = int.Parse(dataGridViewJenisTransaksi.CurrentRow.Cells["id_jenis_transaksi"].Value.ToString());
                string kode = dataGridViewJenisTransaksi.CurrentRow.Cells["kode"].Value.ToString();
                string nama = dataGridViewJenisTransaksi.CurrentRow.Cells["nama"].Value.ToString();

                DialogResult result = MessageBox.Show("Data yang akan dihapus adalah: " +
                    "\nId Jenis Transaksi: " + id +
                    "\nKode Jenis Transaksi: " + kode +
                    "\nNama Jenis Transaksi: " + nama +
                    "\n\nApakah anda yakin ingin menghapus data di atas?", "Konfirmasi", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    JenisTransaksi j = new JenisTransaksi(id, kode, nama);
                    JenisTransaksi.HapusData(j);
                    MessageBox.Show("Data berhasil dihapus.", "Informasi");
                    FormDaftarJenisTransaksi_Load(buttonKeluar, e);
                }
            }
        }

        private void comboBoxKriteria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxKriteria.Text == "Id Jenis Transaksi")
            {
                listJenisTransaksi = JenisTransaksi.ReadData("id_jenis_transaksi", textBoxKriteria.Text);
            }
            else if (comboBoxKriteria.Text == "Kode Jenis Transaksi")
            {
                listJenisTransaksi = JenisTransaksi.ReadData("kode", textBoxKriteria.Text);
            }
            else if (comboBoxKriteria.Text == "Nama Jenis Transaksi")
            {
                listJenisTransaksi = JenisTransaksi.ReadData("nama", textBoxKriteria.Text);
            }

            if (listJenisTransaksi.Count > 0)
            {
                dataGridViewJenisTransaksi.DataSource = listJenisTransaksi;
            }
            else
            {
                dataGridViewJenisTransaksi.DataSource = null;
            }
        }

        private void dataGridViewJenisTransaksi_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewJenisTransaksi.Columns["buttonUbahGrid"].Index && e.RowIndex >= 0)
            {
                FormUbahJenisTransaksi formUbahJenisTransaksi = new FormUbahJenisTransaksi();
                formUbahJenisTransaksi.Owner = this;

                formUbahJenisTransaksi.textBoxKodeJenisTransaksi.Text = dataGridViewJenisTransaksi.CurrentRow.Cells["kode"].Value.ToString();
                formUbahJenisTransaksi.textBoxNamaJenisTransaksi.Text = dataGridViewJenisTransaksi.CurrentRow.Cells["nama"].Value.ToString();

                formUbahJenisTransaksi.ShowDialog();
            }
            else if (e.ColumnIndex == dataGridViewJenisTransaksi.Columns["buttonHapusGrid"].Index && e.RowIndex >= 0)
            {
                int id = int.Parse(dataGridViewJenisTransaksi.CurrentRow.Cells["id_jenis_transaksi"].Value.ToString());
                string kode = dataGridViewJenisTransaksi.CurrentRow.Cells["kode"].Value.ToString();
                string nama = dataGridViewJenisTransaksi.CurrentRow.Cells["nama"].Value.ToString();

                DialogResult result = MessageBox.Show("Data yang akan dihapus adalah: " +
                    "\nKode Jenis Transaksi: " + kode +
                    "\nNama Jenis Transaksi: " + nama +
                    "\n\nApakah anda yakin ingin menghapus data di atas?", "Konfirmasi", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    JenisTransaksi j = new JenisTransaksi(id, kode, nama);
                    JenisTransaksi.HapusData(j);
                    MessageBox.Show("Data berhasil dihapus.", "Informasi");
                    FormDaftarJenisTransaksi_Load(buttonKeluar, e);
                }
            }
        }
    }
}
