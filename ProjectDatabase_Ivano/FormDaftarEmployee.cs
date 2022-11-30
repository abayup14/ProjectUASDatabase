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
        List<Employee> listEmployee;

        List<Position> listPosition;

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
                listPosition = Position.BacaData("", "");

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

                DialogResult hasil = MessageBox.Show("Apakah anda yakin ingin menghapus data di atas ?", "Konfirmasi", MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Question);

                if (hasil == DialogResult.Yes)
                {
                    Employee em = new Employee(id);

                    Employee.HapusData(em);
                   
                    MessageBox.Show("Data berhasil dihapus.", "Informasi");

                    FormDaftarEmployee_Load(buttonKeluar, e);
                }
            }
        }
    }
}
