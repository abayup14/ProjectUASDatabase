﻿using System;
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
    public partial class FormUbahPasswordPegawai : Form
    {
        public FormUbahPasswordPegawai()
        {
            InitializeComponent();
        }

        private void FormUbahPasswordPegawai_Load(object sender, EventArgs e)
        {
            textBoxPasswordLama.Text = "Masukkan password lama anda";
            textBoxPasswordLama.Font = new Font(textBoxPasswordLama.Font, FontStyle.Italic);
            textBoxPasswordLama.ForeColor = Color.Gray;

            textBoxPasswordBaru.Text = "Masukkan password baru anda";
            textBoxPasswordBaru.Font = new Font(textBoxPasswordBaru.Font, FontStyle.Italic);
            textBoxPasswordBaru.ForeColor = Color.Gray;

            textBoxKonfirmasiPasswordBaru.Text = "Masukkan kembali password baru anda";
            textBoxKonfirmasiPasswordBaru.Font = new Font(textBoxKonfirmasiPasswordBaru.Font, FontStyle.Italic);
            textBoxKonfirmasiPasswordBaru.ForeColor = Color.Gray;
        }

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            try
            {
                if(textBoxKonfirmasiPasswordBaru.Text != textBoxPasswordBaru.Text)
                {
                    MessageBox.Show("Password baru anda tidak sesuai dengan konfirmasi password baru. Coba lagi.", "Error");
                }
                else
                {
                    DialogResult hasil = MessageBox.Show("Apakah anda yakin ingin mengubah password anda?", "Konfirmasi", MessageBoxButtons.YesNo,
                                                         MessageBoxIcon.Question);
                    if(DialogResult == DialogResult.Yes)
                    {
                        FormDaftarEmployee formDaftarEmployee = (FormDaftarEmployee)this.Owner;

                        int id = (int)formDaftarEmployee.dataGridViewEmployee.CurrentRow.Cells["id"].Value;
                        string namaDepan = formDaftarEmployee.dataGridViewEmployee.CurrentRow.Cells["nama_depan"].Value.ToString();
                        string namaKeluarga = formDaftarEmployee.dataGridViewEmployee.CurrentRow.Cells["nama_keluarga"].Value.ToString();
                        Position position = new Position(formDaftarEmployee.dataGridViewEmployee.CurrentRow.Cells["position"].Value.ToString());
                        string nik = formDaftarEmployee.dataGridViewEmployee.CurrentRow.Cells["nik"].Value.ToString();
                        string email = formDaftarEmployee.dataGridViewEmployee.CurrentRow.Cells["email"].Value.ToString();
                        string password = formDaftarEmployee.dataGridViewEmployee.CurrentRow.Cells["password"].Value.ToString();
                        DateTime tglBuat = DateTime.Parse(formDaftarEmployee.dataGridViewEmployee.CurrentRow.Cells["tgl_buat"].Value.ToString());

                        Employee em = new Employee(id, namaDepan, namaKeluarga, position, nik, email, password, tglBuat, DateTime.Now);

                        Employee.UbahPassword(em, textBoxPasswordLama.Text, textBoxPasswordBaru.Text);
                        MessageBox.Show("Password anda berhasil diubah.", "Informasi");
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Gagal mengubah password anda. Pesan kesalahan : " + ex.Message, "Kesalahan");
            }
        }
    }
}
