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
    public partial class FormTabunganPengguna : Form
    {
        //FormUtama formUtama;
        FormDaftarTabungan formDaftarTabungan;

        public Pengguna p;

        public Tabungan t;

        public FormTabunganPengguna()
        {
            InitializeComponent();
        }

        private void FormTabunganPengguna_Load(object sender, EventArgs e)
        {
            formDaftarTabungan = (FormDaftarTabungan)this.Owner;

            p = formDaftarTabungan.pengguna;

            t = Tabungan.AmbilDataTabungan(formDaftarTabungan.dataGridViewTabungan.CurrentRow.Cells["NoRekening"].Value.ToString());
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            formDaftarTabungan.FormDaftarTabungan_Load(buttonKeluar, e);
            Close();
        }

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            if (t.Status != "Aktif")
            {
                MessageBox.Show("Maaf, status tabungan anda sedang tidak aktif." +
                                "\nSilahkan hubungi pegawai kami untuk mengaktifkan tabungan anda.", "Informasi");
            }
            else
            {
                FormUbahTabungan formUbahTabungan = new FormUbahTabungan();

                formUbahTabungan.Owner = this;

                formUbahTabungan.textBoxKeterangan.Text = labelKeterangan.Text;

                formUbahTabungan.ShowDialog();
            }
        }
    }
}
