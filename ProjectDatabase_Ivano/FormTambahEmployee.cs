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
                Koneksi k = new Koneksi();
                DialogResult hasil = MessageBox.Show("Apakah data yang anda masukkan sudah benar?", "Konfirmasi", MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Question);

                if (hasil == DialogResult.Yes)
                {
                    Position positionDipilih = (Position)comboBoxPosition.SelectedItem;

                    int id = Employee.GenerateKode();

                    Employee em = new Employee(id, textBoxNamaDepan.Text, textBoxNamaKeluarga.Text, positionDipilih, textBoxNIK.Text,
                                              textBoxEmail.Text, textBoxPassword.Text, DateTime.Now, DateTime.Now);

                    Employee.TambahData(em, k);

                    MessageBox.Show("Data employee berhasil ditambah.", "Informasi");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data employee gagal ditambahkan. Pesan kesalahan : " + ex.Message, "Kesalahan");
            }
        }

        private void FormTambahEmployee_Load(object sender, EventArgs e)
        {
            ActiveControl = label1;

            textBoxNIK.Text = "Wajib diisi";
            textBoxNIK.Font = new Font(textBoxNIK.Font, FontStyle.Italic);
            textBoxNIK.ForeColor = Color.Gray;

            textBoxNamaDepan.Text = "Wajib diisi";
            textBoxNamaDepan.Font = new Font(textBoxNamaDepan.Font, FontStyle.Italic);
            textBoxNamaDepan.ForeColor = Color.Gray;

            textBoxEmail.Text = "Wajib diisi";
            textBoxEmail.Font = new Font(textBoxEmail.Font, FontStyle.Italic);
            textBoxEmail.ForeColor = Color.Gray;

            textBoxPassword.Text = "Wajib diisi";
            textBoxPassword.Font = new Font(textBoxPassword.Font, FontStyle.Italic);
            textBoxPassword.ForeColor = Color.Gray;
            textBoxPassword.UseSystemPasswordChar = false;

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

            comboBoxPosition.SelectedIndex = -1;

            textBoxNIK.Focus();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            FormDaftarEmployee formDaftarEmployee = (FormDaftarEmployee)this.Owner;

            formDaftarEmployee.FormDaftarEmployee_Load(buttonKeluar, e);

            Close();
        }

        private void checkBoxTunjukkan_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTunjukkan.Checked == true)
            {
                textBoxPassword.UseSystemPasswordChar = false;
            }
            else
            {
                if (textBoxPassword.Text == "Wajib diisi")
                {
                    textBoxPassword.UseSystemPasswordChar = false;
                }
                else
                {
                    textBoxPassword.UseSystemPasswordChar = true;
                }
            }
        }

        private void textBoxNIK_Enter(object sender, EventArgs e)
        {
            if (textBoxNIK.Text == "Wajib diisi")
            {
                textBoxNIK.Text = "";
                textBoxNIK.Font = new Font(textBoxNIK.Font, FontStyle.Regular);
                textBoxNIK.ForeColor = Color.Black;
            }
        }

        private void textBoxNIK_Leave(object sender, EventArgs e)
        {
            if (textBoxNIK.Text == "")
            {
                textBoxNIK.Text = "Wajib diisi";
                textBoxNIK.Font = new Font(textBoxNIK.Font, FontStyle.Italic);
                textBoxNIK.ForeColor = Color.Gray;
            }
        }

        private void textBoxNamaDepan_Enter(object sender, EventArgs e)
        {
            if (textBoxNamaDepan.Text == "Wajib diisi")
            {
                textBoxNamaDepan.Text = "";
                textBoxNamaDepan.Font = new Font(textBoxNamaDepan.Font, FontStyle.Regular);
                textBoxNamaDepan.ForeColor = Color.Black;
            }
        }

        private void textBoxNamaDepan_Leave(object sender, EventArgs e)
        {
            if (textBoxNamaDepan.Text == "")
            {
                textBoxNamaDepan.Text = "Wajib diisi";
                textBoxNamaDepan.Font = new Font(textBoxNamaDepan.Font, FontStyle.Italic);
                textBoxNamaDepan.ForeColor = Color.Gray;
            }
        }

        private void textBoxEmail_Enter(object sender, EventArgs e)
        {
            if (textBoxEmail.Text == "Wajib diisi")
            {
                textBoxEmail.Text = "";
                textBoxEmail.Font = new Font(textBoxEmail.Font, FontStyle.Regular);
                textBoxEmail.ForeColor = Color.Black;
            }
        }

        private void textBoxEmail_Leave(object sender, EventArgs e)
        {
            if (textBoxEmail.Text == "")
            {
                textBoxEmail.Text = "Wajib diisi";
                textBoxEmail.Font = new Font(textBoxEmail.Font, FontStyle.Italic);
                textBoxEmail.ForeColor = Color.Gray;
            }
        }

        private void textBoxPassword_Enter(object sender, EventArgs e)
        {
            if (textBoxPassword.Text == "Wajib diisi")
            {
                textBoxPassword.Text = "";
                textBoxPassword.Font = new Font(textBoxPassword.Font, FontStyle.Regular);
                textBoxPassword.ForeColor = Color.Black;
                textBoxPassword.UseSystemPasswordChar = true;
            }
        }

        private void textBoxPassword_Leave(object sender, EventArgs e)
        {
            if (textBoxPassword.Text == "")
            {
                textBoxPassword.Text = "Wajib diisi";
                textBoxPassword.Font = new Font(textBoxPassword.Font, FontStyle.Italic);
                textBoxPassword.ForeColor = Color.Gray;
                textBoxPassword.UseSystemPasswordChar = false;
            }
        }
    }
}
