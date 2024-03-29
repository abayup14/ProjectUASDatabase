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
    public partial class FormUbahPromo : Form
    {
        public FormUbahPromo()
        {
            InitializeComponent();
        }

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi k = new Koneksi();

                FormDaftarPromo formDaftarPromo = (FormDaftarPromo)this.Owner;
                int id = int.Parse(formDaftarPromo.dataGridViewPromo.CurrentRow.Cells["idPromo"].Value.ToString());
                string nama = textBoxNamaJabatan.Text;
                int nominal = int.Parse(formDaftarPromo.dataGridViewPromo.CurrentRow.Cells["nominal_diskon"].Value.ToString());
                DateTime tglAwal = DateTime.Parse(formDaftarPromo.dataGridViewPromo.CurrentRow.Cells["tglAwal"].Value.ToString());
                DateTime tglAkhir = dateTimePicker1.Value;
                string keterangan = formDaftarPromo.dataGridViewPromo.CurrentRow.Cells["keterangan"].Value.ToString();
                
                Promo p = new Promo(id, nama, nominal, tglAwal, tglAkhir, keterangan);

                Promo.UbahData(p, k);

                MessageBox.Show("Data promo telah diubah.", "Info");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Pengubahan gagal. Pesan kesalahan: " + ex.Message, "Kesalahan");
            }
        }
    }
}
