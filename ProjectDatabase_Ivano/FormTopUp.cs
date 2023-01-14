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
    public partial class FormTopUp : Form
    {
        //FormTabunganPengguna formTabunganPengguna;

        FormUtama formUtama;

        public Pengguna p;

        public Tabungan tabungan;

        public List<Tabungan> listTabungan = new List<Tabungan>();

        public FormTopUp()
        {
            InitializeComponent();
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxRekening.SelectedIndex > -1)
                {
                    tabungan = (Tabungan)comboBoxRekening.SelectedItem;
                }

                DialogResult hasil = MessageBox.Show("Apakah anda yakin ingin melakukan topup?", "Konfirmasi", MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Question);
                if (hasil == DialogResult.Yes)
                {
                    if (tabungan.Status == "Aktif")
                    {
                        FormMasukkanPIN formMasukkanPIN = new FormMasukkanPIN();

                        formMasukkanPIN.Owner = this;

                        formMasukkanPIN.buttonCek.Visible = true;
                        formMasukkanPIN.buttonSimpan.Visible = false;

                        formMasukkanPIN.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal topup. Pesan kesalahan: " + ex.Message, "Kesalahan");
            }
        }

        private void FormTopUp_Load(object sender, EventArgs e)
        {
            //formTabunganPengguna = (FormTabunganPengguna)this.Owner;
            formUtama = (FormUtama)this.MdiParent;

            p = formUtama.pengguna;

            listTabungan = Tabungan.BacaData("", "");

            comboBoxRekening.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxRekening.DataSource = listTabungan;
            comboBoxRekening.DisplayMember = "Rekening";

        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            //FormDaftarTabungan formDaftarTabungan = (FormDaftarTabungan)this.Owner;
            //formDaftarTabungan.FormDaftarTabungan_Load(buttonKeluar, e);
            Close();
        }

        private void comboBoxRekening_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxRekening.SelectedIndex > -1)
            {
                tabungan = (Tabungan)comboBoxRekening.SelectedItem;
            }    
        }
    }
}
