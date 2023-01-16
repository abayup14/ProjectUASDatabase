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
    public partial class FormDaftarJenisTagihan : Form
    {
        FormUtama formUtama;

        Koneksi k;

        public List<JenisTagihan> listJenisTagihan = new List<JenisTagihan>();

        public FormDaftarJenisTagihan()
        {
            InitializeComponent();
        }

        public void FormDaftarJenisTagihan_Load(object sender, EventArgs e)
        {
            k = new Koneksi();

            formUtama = (FormUtama)this.MdiParent;

            listJenisTagihan = JenisTagihan.BacaData("id not", "0");

            if (listJenisTagihan.Count > 0)
            {
                dataGridViewJenisTagihan.DataSource = listJenisTagihan;
                if (dataGridViewJenisTagihan.ColumnCount < 10)
                {
                    if (!dataGridViewJenisTagihan.Columns.Contains("buttonUbahGrid") && !dataGridViewJenisTagihan.Columns.Contains("buttonHapusGrid"))
                    {
                        DataGridViewButtonColumn bcol = new DataGridViewButtonColumn();
                        bcol.HeaderText = "Aksi";
                        bcol.Text = "Ubah";
                        bcol.Name = "buttonUbahGrid";
                        bcol.UseColumnTextForButtonValue = true;
                        dataGridViewJenisTagihan.Columns.Add(bcol);

                        DataGridViewButtonColumn bcol2 = new DataGridViewButtonColumn();
                        bcol2.HeaderText = "Aksi";
                        bcol2.Text = "Hapus";
                        bcol2.Name = "buttonHapusGrid";
                        bcol2.UseColumnTextForButtonValue = true;
                        dataGridViewJenisTagihan.Columns.Add(bcol2);
                    }
                }
            }
            else
            {
                dataGridViewJenisTagihan.DataSource = null;
            }
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahJenisTagihan formTambahJenisTagihan = new FormTambahJenisTagihan();

            formTambahJenisTagihan.Owner = this;

            formTambahJenisTagihan.Show();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridViewJenisTagihan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewJenisTagihan.Columns["buttonUbahGrid"].Index && e.RowIndex >= 0)
            {
                FormUbahJenisTagihan formUbahJenisTagihan = new FormUbahJenisTagihan();

                formUbahJenisTagihan.Owner = this;

                formUbahJenisTagihan.textBoxNamaTagihan.Text = dataGridViewJenisTagihan.CurrentRow.Cells["nama"].Value.ToString();

                formUbahJenisTagihan.ShowDialog();
            }
            else if (e.ColumnIndex == dataGridViewJenisTagihan.Columns["buttonHapusGrid"].Index && e.RowIndex >= 0)
            {
                int id = int.Parse(dataGridViewJenisTagihan.CurrentRow.Cells["id"].Value.ToString());

                string nama = dataGridViewJenisTagihan.CurrentRow.Cells["nama"].Value.ToString();

                DialogResult hasil = MessageBox.Show("Data yang akan dihpus adalah: " +
                                                     "\nID : " + id.ToString() +
                                                     "\nNama Tagihan : " + nama +
                                                     "\n\nApakah anda ingin menghapus data ini?", "Konfirmasi",
                                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (hasil == DialogResult.Yes)
                {
                    JenisTagihan jt = new JenisTagihan(id);
                    JenisTagihan.HapusData(jt, k);
                    MessageBox.Show("Data berhasil dihapus", "Informasi");
                    FormDaftarJenisTagihan_Load(buttonKeluar, e);
                }
            }
        }

        private void textBoxNilaiKriteria_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxKriteria.Text == "ID Jenis Tagihan")
            {
                listJenisTagihan = JenisTagihan.BacaData("id", textBoxNilaiKriteria.Text);
            }
            else if (comboBoxKriteria.Text == "Nama Tagihan")
            {
                listJenisTagihan = JenisTagihan.BacaData("nama", textBoxNilaiKriteria.Text);
            }

            if (listJenisTagihan.Count > 0)
            {
                dataGridViewJenisTagihan.DataSource = listJenisTagihan;
            }
            else
            {
                dataGridViewJenisTagihan.DataSource = null;
            }
        }
    }
}
