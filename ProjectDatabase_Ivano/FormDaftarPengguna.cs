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
    public partial class FormDaftarPengguna : Form
    {
        public List<Pengguna> listPengguna = new List<Pengguna>();

        Koneksi k;

        public FormDaftarPengguna()
        {
            InitializeComponent();
        }

        public void FormDaftarPengguna_Load(object sender, EventArgs e)
        {
            k = new Koneksi();
            listPengguna = Pengguna.BacaData("", "");

            if (listPengguna.Count > 0)
            {
                dataGridViewPengguna.DataSource = listPengguna;

                if (dataGridViewPengguna.ColumnCount == 10)
                {
                    //if (!dataGridViewPengguna.Columns.Contains("buttonHapusGrid"))
                    //{
                    //    DataGridViewButtonColumn bcol3 = new DataGridViewButtonColumn();

                    //    bcol3.HeaderText = "Aksi";

                    //    bcol3.Text = "Hapus";

                    //    bcol3.Name = "buttonHapusGrid";

                    //    bcol3.UseColumnTextForButtonValue = true;

                    //    dataGridViewPengguna.Columns.Add(bcol3);
                    //}
                    //DataGridViewButtonColumn bcol1 = new DataGridViewButtonColumn();

                    //bcol1.HeaderText = "Aksi";

                    //bcol1.Text = "Ubah Data";

                    //bcol1.Name = "buttonUbahGrid";

                    //bcol1.UseColumnTextForButtonValue = true;

                    //dataGridViewPengguna.Columns.Add(bcol1);

                    //DataGridViewButtonColumn bcol2 = new DataGridViewButtonColumn();

                    //bcol2.HeaderText = "Aksi";

                    //bcol2.Text = "Ubah Password";

                    //bcol2.Name = "buttonUbahPasswordGrid";

                    //bcol2.UseColumnTextForButtonValue = true;

                    //dataGridViewPengguna.Columns.Add(bcol2);
                }
            }
            else
            {
                dataGridViewPengguna.DataSource = null;
            }
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridViewPengguna_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == dataGridViewPengguna.Columns["buttonUbahGrid"].Index && e.RowIndex >= 0)
            //{
            //    FormUbahPengguna formUbahPengguna = new FormUbahPengguna();

            //    formUbahPengguna.Owner = this;

            //    formUbahPengguna.textBoxNIK.Text = dataGridViewPengguna.CurrentRow.Cells["nik"].Value.ToString();

            //    formUbahPengguna.textBoxNamaDepan.Text = dataGridViewPengguna.CurrentRow.Cells["nama_depan"].Value.ToString();

            //    formUbahPengguna.textBoxNamaKeluarga.Text = dataGridViewPengguna.CurrentRow.Cells["nama_keluarga"].Value.ToString();

            //    formUbahPengguna.textBoxAlamat.Text = dataGridViewPengguna.CurrentRow.Cells["alamat"].Value.ToString();

            //    formUbahPengguna.textBoxEmail.Text = dataGridViewPengguna.CurrentRow.Cells["email"].Value.ToString();

            //    formUbahPengguna.textBoxNomorTelepon.Text = dataGridViewPengguna.CurrentRow.Cells["no_telepon"].Value.ToString();

            //    formUbahPengguna.ShowDialog();
            //}
            //else if (e.ColumnIndex == dataGridViewPengguna.Columns["buttonUbahPasswordGrid"].Index && e.RowIndex >= 0)
            //{
            //    FormUbahPasswordPengguna formUbahPassword = new FormUbahPasswordPengguna();

            //    formUbahPassword.Owner = this;

            //    formUbahPassword.Show();
            //}
            //if (e.ColumnIndex == dataGridViewPengguna.Columns["buttonHapusGrid"].Index && e.RowIndex >= 0)
            //{
            //    string nik = dataGridViewPengguna.CurrentRow.Cells["nik"].Value.ToString();

            //    string namaDepan = dataGridViewPengguna.CurrentRow.Cells["nama_depan"].Value.ToString();

            //    string namaKeluarga = dataGridViewPengguna.CurrentRow.Cells["nama_keluarga"].Value.ToString();

            //    string alamat = dataGridViewPengguna.CurrentRow.Cells["alamat"].Value.ToString();

            //    string email = dataGridViewPengguna.CurrentRow.Cells["email"].Value.ToString();

            //    string noTelepon = dataGridViewPengguna.CurrentRow.Cells["no_telepon"].Value.ToString();

            //    string password = dataGridViewPengguna.CurrentRow.Cells["password"].Value.ToString();

            //    string pin = dataGridViewPengguna.CurrentRow.Cells["pin"].Value.ToString();

            //    //DateTime tglBuat = DateTime.Parse(dataGridViewPengguna.CurrentRow.Cells["tgl_buat"].Value.ToString());

            //    //DateTime tglPerubahan = DateTime.Parse(dataGridViewPengguna.CurrentRow.Cells["tgl_perubahan"].Value.ToString());

            //    DialogResult hasil = MessageBox.Show("Data yang akan dihapus adalah :" +
            //                                         "\nNIK : " + nik +
            //                                         "\nNama Depan : " + namaDepan +
            //                                         "\nNama Keluarga : " + namaKeluarga +
            //                                         "\nAlamat : " + alamat +
            //                                         "\nEmail : " + email +
            //                                         "\nNo Telepon : " + noTelepon +
            //                                         "\n\nApakah anda yakin ingin menghapus data di atas ?", "Konfirmasi", 
            //                                         MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //    if (hasil == DialogResult.Yes)
            //    {
            //        Pengguna p = new Pengguna(nik);

            //        Pengguna.HapusData(p, k);

            //        MessageBox.Show("Data berhasil dihapus.", "Informasi");

            //        FormDaftarPengguna_Load(buttonKeluar, e);
            //    }
            //}
        }

        private void textBoxNilaiKriteria_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxKriteria.Text == "NIK")
            {
                listPengguna = Pengguna.BacaData("nik", textBoxNilaiKriteria.Text);
            }
            else if (comboBoxKriteria.Text == "Nama Depan")
            {
                listPengguna = Pengguna.BacaData("nama_depan", textBoxNilaiKriteria.Text);
            }
            else if (comboBoxKriteria.Text == "Nama Keluarga")
            {
                listPengguna = Pengguna.BacaData("nama_belakang", textBoxNilaiKriteria.Text);
            }
            else if (comboBoxKriteria.Text == "Alamat")
            {
                listPengguna = Pengguna.BacaData("alamat", textBoxNilaiKriteria.Text);
            }
            else if (comboBoxKriteria.Text == "Email")
            {
                listPengguna = Pengguna.BacaData("email", textBoxNilaiKriteria.Text);
            }
            else if (comboBoxKriteria.Text == "Nomor Telepon")
            {
                listPengguna = Pengguna.BacaData("no_telepon", textBoxNilaiKriteria.Text);
            }
            else if (comboBoxKriteria.Text == "Tanggal Buat")
            {
                listPengguna = Pengguna.BacaData("tgl_buat", textBoxNilaiKriteria.Text);
            }
            else if (comboBoxKriteria.Text == "Tanggal Perubahan")
            {
                listPengguna = Pengguna.BacaData("tgl_perubahan", textBoxNilaiKriteria.Text);
            }

            if (listPengguna.Count > 0)
            {
                dataGridViewPengguna.DataSource = listPengguna;
            }
            else
            {
                dataGridViewPengguna.DataSource = null;
            }
        }
    }
}
