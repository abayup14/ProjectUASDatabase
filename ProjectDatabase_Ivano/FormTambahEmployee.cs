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
    public partial class FormTambahEmployee : Form
    {
        public FormTambahEmployee()
        {
            InitializeComponent();
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                Position positionDipilih = (Position)comboBoxPosition.SelectedItem;

                int id = Employee.GenerateKode();

                Employee em = new Employee(id, textBoxNamaDepan.Text, textBoxNamaKeluarga.Text, positionDipilih, textBoxNIK.Text,
                                          textBoxEmail.Text, textBoxPassword.Text, DateTime.Now, DateTime.Now);

                Employee.TambahData(em);

                MessageBox.Show("Data employee berhasil ditambah.", "Informasi");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data employee gagal ditambahkan. Pesan kesalahan : " + ex.Message, "Kesalahan");
            }
        }

        private void FormTambahEmployee_Load(object sender, EventArgs e)
        {
            List<Position> listPosition = Position.BacaData("", "");

            comboBoxPosition.DataSource = listPosition;

            comboBoxPosition.DisplayMember = "Nama";
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            textBoxNIK.Clear();

            textBoxNamaDepan.Clear();

            textBoxNamaKeluarga.Clear();

            textBoxEmail.Clear();

            textBoxPassword.Clear();

            comboBoxPosition.SelectedIndex = 0;

            textBoxNIK.Focus();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            FormDaftarEmployee formDaftarEmployee = (FormDaftarEmployee)this.Owner;

            formDaftarEmployee.FormDaftarEmployee_Load(buttonKeluar, e);

            Close();
        }
    }
}
