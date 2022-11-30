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
    public partial class FormUbahEmployee : Form
    {
        public FormUbahEmployee()
        {
            InitializeComponent();
        }

        private void FormUbahEmployee_Load(object sender, EventArgs e)
        {
            List<Position> listPosition = Position.BacaData("", "");

            comboBoxPosition.DataSource = listPosition;

            comboBoxPosition.DisplayMember = "Nama";
        }

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult hasil = MessageBox.Show("Apakah anda yakin ingin mengubah data anda?", "Konfirmasi", MessageBoxButtons.YesNo,
                                                         MessageBoxIcon.Question);

                if (hasil == DialogResult.Yes)
                {

                    FormDaftarEmployee formDaftarEmployee = (FormDaftarEmployee)this.Owner;

                    int id = int.Parse(formDaftarEmployee.dataGridViewEmployee.CurrentRow.Cells["id"].Value.ToString());

                    Position positionDipilih = (Position)comboBoxPosition.SelectedItem;

                    string password = formDaftarEmployee.dataGridViewEmployee.CurrentRow.Cells["password"].Value.ToString();

                    DateTime tglBuat = DateTime.Parse(formDaftarEmployee.dataGridViewEmployee.CurrentRow.Cells["tgl_buat"].Value.ToString());

                    Employee em = new Employee(id, textBoxNamaDepan.Text, textBoxNamaKeluarga.Text, positionDipilih, textBoxNIK.Text,
                                               textBoxEmail.Text, password, tglBuat, DateTime.Now);

                    Employee.UbahData(em);

                    MessageBox.Show("Data pegawai berhasil diubah", "Informasi");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data pegawai gagal diubah. Pesan kesalahan : " + ex.Message, "Kesalahan");
            }
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            textBoxNIK.Clear();

            textBoxNamaDepan.Clear();

            textBoxNamaKeluarga.Clear();

            textBoxEmail.Clear();

            comboBoxPosition.SelectedIndex = 0;
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            FormDaftarEmployee formDaftarEmployee = (FormDaftarEmployee)this.Owner;

            formDaftarEmployee.FormDaftarEmployee_Load(buttonKeluar, e);

            Close();
        }
    }
}
