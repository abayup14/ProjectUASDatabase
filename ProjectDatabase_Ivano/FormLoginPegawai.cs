﻿using DiBa_LIB;
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
    public partial class FormLoginPegawai : Form
    {
        public FormLoginPegawai()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi koneksi = new Koneksi();

                if (textBoxEmailNomorTelepon.Text == "Masukkan email atau nomor telepon anda" && textBoxPassword.Text == "Masukkan password anda")
                {
                    MessageBox.Show("Maaf, email atau nomor telepon dan password harus diisi. Silahkan coba kembali", "Informasi");
                }
                else if (textBoxEmailNomorTelepon.Text == "Masukkan email atau nomor telepon anda")
                {
                    MessageBox.Show("Maaf, email atau nomor telepon harus diisi. Silahkan coba kembali", "Informasi");
                }
                else if (textBoxPassword.Text == "Masukkan password anda")
                {
                    MessageBox.Show("Maaf, password harus diisi. Silahkan coba kembali", "Informasi");
                }
                else
                {
                    Employee em = Employee.CekLogin(textBoxEmailNomorTelepon.Text, textBoxPassword.Text);

                    if (em != null)
                    {
                        FormUtama formUtama = (FormUtama)this.Owner;

                        formUtama.employee = em;

                        MessageBox.Show("Anda berhasil login ke aplikasi. Selamat menggunakan DiBa!", "Informasi");

                        //DialogResult = DialogResult.OK;

                        Close();
                    }
                    else
                    {
                        MessageBox.Show(this, "Username tidak ditemukan atau password salah.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Koneksi gagal. Pesan kesalahan : " + ex.Message, "Kesalahan");
            }
        }
    }
}
