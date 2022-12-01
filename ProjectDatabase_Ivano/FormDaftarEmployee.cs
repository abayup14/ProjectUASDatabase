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
    public partial class FormDaftarEmployee : Form
    {
        public List<Employee> listEmployee = new List<Employee>();

        public FormDaftarEmployee()
        {
            InitializeComponent();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahEmployee formTambahEmployee = new FormTambahEmployee();

            formTambahEmployee.Owner = this;

            formTambahEmployee.Show();
        }

        public void FormDaftarEmployee_Load(object sender, EventArgs e)
        {
            listEmployee = Employee.BacaData("", "");

            if (listEmployee.Count > 0)
            {
                dataGridViewEmployee.DataSource = listEmployee;

                if (dataGridViewEmployee.ColumnCount == 9)
                {
                    DataGridViewButtonColumn bcol = new DataGridViewButtonColumn();
                    bcol.HeaderText = "Aksi";
                    bcol.Text = "Ubah";
                    bcol.Name = "buttonUbahGrid";
                    bcol.UseColumnTextForButtonValue = true;
                    dataGridViewEmployee.Columns.Add(bcol);

                    DataGridViewButtonColumn bcol2 = new DataGridViewButtonColumn();
                    bcol2.HeaderText = "Aksi";
                    bcol2.Text = "Ubah Password";
                    bcol2.Name = "buttonUbahPasswordGrid";
                    bcol2.UseColumnTextForButtonValue = true;
                    dataGridViewEmployee.Columns.Add(bcol2);

                    DataGridViewButtonColumn bcol3 = new DataGridViewButtonColumn();
                    bcol3.HeaderText = "Aksi";
                    bcol3.Text = "Hapus";
                    bcol3.Name = "buttonHapusGrid";
                    bcol3.UseColumnTextForButtonValue = true;
                    dataGridViewEmployee.Columns.Add(bcol3);
                }
            }
            else
            {
                dataGridViewEmployee.DataSource = null;
            }
        }

        private void dataGridViewEmployee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewEmployee.Columns["buttonUbahGrid"].Index && e.RowIndex >= 0)
            {
                FormUbahEmployee formUbahEmployee = new FormUbahEmployee();

                formUbahEmployee.Owner = this;

                formUbahEmployee.textBoxNIK.Text = dataGridViewEmployee.CurrentRow.Cells["nik"].Value.ToString();

                formUbahEmployee.textBoxNamaDepan.Text = dataGridViewEmployee.CurrentRow.Cells["nama_depan"].Value.ToString();

                formUbahEmployee.textBoxNamaKeluarga.Text = dataGridViewEmployee.CurrentRow.Cells["nama_keluarga"].Value.ToString();

                formUbahEmployee.textBoxEmail.Text = dataGridViewEmployee.CurrentRow.Cells["email"].Value.ToString();

                formUbahEmployee.ShowDialog();
            }
            else if (e.ColumnIndex == dataGridViewEmployee.Columns["buttonUbahPasswordGrid"].Index && e.RowIndex >= 0)
            {
                FormUbahPasswordPegawai formUbahPassword = new FormUbahPasswordPegawai();

                formUbahPassword.Owner = this;

                formUbahPassword.Show();
            }
            else if (e.ColumnIndex == dataGridViewEmployee.Columns["buttonHapusGrid"].Index && e.RowIndex >= 0)
            {
                int id = int.Parse(dataGridViewEmployee.CurrentRow.Cells["id"].Value.ToString());

                string nik = dataGridViewEmployee.CurrentRow.Cells["nik"].Value.ToString();

                string namaDepan = dataGridViewEmployee.CurrentRow.Cells["nama_depan"].Value.ToString();

                string namaKeluarga = dataGridViewEmployee.CurrentRow.Cells["nama_keluarga"].Value.ToString();

                string email = dataGridViewEmployee.CurrentRow.Cells["email"].Value.ToString();

                string position = dataGridViewEmployee.CurrentRow.Cells["position"].Value.ToString();

                DialogResult hasil = MessageBox.Show("Data yang akan dihapus adalah : " +
                                                     "\nId Pegawai : " + id +
                                                     "\nNIK : " + nik +
                                                     "\nNama Depan : " + namaDepan + 
                                                     "\nNama Keluarga : " + namaKeluarga +
                                                     "\nEmail : " + email + 
                                                     "\nPosition : " + position + 
                                                     "\n\nApakah anda yakin ingin menghapus data di atas ?", "Konfirmasi", 
                                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (hasil == DialogResult.Yes)
                {
                    Employee em = new Employee(id);

                    Employee.HapusData(em);
                   
                    MessageBox.Show("Data berhasil dihapus.", "Informasi");

                    FormDaftarEmployee_Load(buttonKeluar, e);
                }
            }
        }

        private void textBoxNilaiKriteria_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxKriteria.Text == "Id Employee")
            {
                listEmployee = Employee.BacaData("e.id", textBoxNilaiKriteria.Text);
            }
            else if (comboBoxKriteria.Text == "Nama Depan")
            {
                listEmployee = Employee.BacaData("e.nama_depan", textBoxNilaiKriteria.Text);
            }
            else if (comboBoxKriteria.Text == "Nama Keluarga")
            {
                listEmployee = Employee.BacaData("e.nama_keluarga", textBoxNilaiKriteria.Text);
            }
            else if (comboBoxKriteria.Text == "Nama Position")
            {
                listEmployee = Employee.BacaData("p.nama", textBoxNilaiKriteria.Text);
            }
            else if (comboBoxKriteria.Text == "NIK")
            {
                listEmployee = Employee.BacaData("e.nik", textBoxNilaiKriteria.Text);
            }
            else if (comboBoxKriteria.Text == "Email")
            {
                listEmployee = Employee.BacaData("e.email", textBoxNilaiKriteria.Text);
            }
            else if (comboBoxKriteria.Text == "Tanggal Buat")
            {
                listEmployee = Employee.BacaData("e.tgl_buat", textBoxNilaiKriteria.Text);
            }
            else if (comboBoxKriteria.Text == "Tanggal Perubahan")
            {
                listEmployee = Employee.BacaData("e.tgl_perubahan", textBoxNilaiKriteria.Text);
            }

            if (listEmployee.Count > 0)
            {
                dataGridViewEmployee.DataSource = listEmployee;
            }
            else
            {
                dataGridViewEmployee.DataSource = null;
            }
        }
    }
}
