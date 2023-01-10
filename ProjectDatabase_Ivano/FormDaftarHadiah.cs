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
    public partial class FormDaftarHadiah : Form
    {
        List<Hadiah> listHadiah = new List<Hadiah>();
        FormUtama formUtama;
        Koneksi k;
        Hadiah h;
        public Pengguna p;
        public FormDaftarHadiah()
        {
            InitializeComponent();
        }

        private void FormDaftarHadiah_Load(object sender, EventArgs e)
        {
            formUtama = (FormUtama)this.MdiParent;
            k = new Koneksi();
            p = formUtama.pengguna;
            listHadiah = Hadiah.BacaData("", "");
            if (listHadiah.Count > 0)
            {
                dataGridViewInbox.DataSource = listHadiah;
                if (dataGridViewInbox.ColumnCount == 3)
                {
                    DataGridViewButtonColumn bcol1 = new DataGridViewButtonColumn();
                    bcol1.HeaderText = "Aksi";
                    bcol1.Text = "Ubah Data";
                    bcol1.Name = "buttonUbahGrid";
                    bcol1.UseColumnTextForButtonValue = true;
                    dataGridViewInbox.Columns.Add(bcol1);

                    DataGridViewButtonColumn bcol2 = new DataGridViewButtonColumn();
                    bcol2.HeaderText = "Aksi";
                    bcol2.Text = "Hapus Data";
                    bcol2.Name = "buttonHapusGrid";
                    bcol2.UseColumnTextForButtonValue = true;
                    dataGridViewInbox.Columns.Add(bcol2);

                    DataGridViewButtonColumn bcol3 = new DataGridViewButtonColumn();
                    bcol3.HeaderText = "Aksi";
                    bcol3.Text = "Beli";
                    bcol3.Name = "buttonBeliGrid";
                    bcol3.UseColumnTextForButtonValue = true;
                    dataGridViewInbox.Columns.Add(bcol3);
                }
            }
            else
            {
                dataGridViewInbox.DataSource = null;
            }
            
            
        }

        private void textBoxNilaiKriteria_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxKriteria.Text == "id")
            {
                listHadiah = Hadiah.BacaData("id", textBoxNilaiKriteria.Text);
            }
            else if (comboBoxKriteria.Text == "nama_hadiah")
            {
                listHadiah = Hadiah.BacaData("nama_hadiah", textBoxNilaiKriteria.Text);
            }
            else if (comboBoxKriteria.Text == "harga_hadiah")
            {
                listHadiah = Hadiah.BacaData("harga_hadiah", textBoxNilaiKriteria.Text);
            }
            if (listHadiah.Count > 0)
            {
                dataGridViewInbox.DataSource = listHadiah;
            }
            else
            {
                dataGridViewInbox.DataSource = null;
            }
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahHadiah frmTambahHadiah = new FormTambahHadiah();
            frmTambahHadiah.Owner = this;
            frmTambahHadiah.Show();
        }

        private void dataGridViewInbox_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewInbox.Columns["buttonBeliGrid"].Index && e.RowIndex >= 0)
            {
                DialogResult result = MessageBox.Show("Apakah barang yang dipilih sudah tepat ?", "Konfirmasi",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (Poin.CekPoin(p, k) >= int.Parse(dataGridViewInbox.CurrentRow.Cells["harga_hadiah"].Value.ToString()))
                    {
                        Pengguna_has_Hadiah phh = new Pengguna_has_Hadiah(p, h);
                        Pengguna_has_Hadiah.TambahData(phh, k);
                        MessageBox.Show("Pembelian Berhasil", "Informasi");
                    }
                    else
                    {
                        MessageBox.Show("Pembelian Gagal, cek kembali saldo anda", "Informasi");
                    }
                }
            }
            else if (e.ColumnIndex == dataGridViewInbox.Columns["buttonUbahGrid"].Index && e.RowIndex >= 0)
            {
                FormUbahHadiah frmUbahHadiah = new FormUbahHadiah();
                frmUbahHadiah.Owner = this;
                //frmUbahHadiah.Show();
                frmUbahHadiah.textBoxNamaHadiah.Text = dataGridViewInbox.CurrentRow.Cells["nama_hadiah"].Value.ToString();
                frmUbahHadiah.textBoxHargaHadiah.Text = dataGridViewInbox.CurrentRow.Cells["harga_hadiah"].Value.ToString();
                frmUbahHadiah.Show();
            }
            else if (e.ColumnIndex == dataGridViewInbox.Columns["buttonHapusGrid"].Index && e.RowIndex >= 0)
            {
                int id = int.Parse(dataGridViewInbox.CurrentRow.Cells["id"].Value.ToString());
                string nama_hadiah = dataGridViewInbox.CurrentRow.Cells["nama_hadiah"].Value.ToString();
                int harga_hadiah = int.Parse(dataGridViewInbox.CurrentRow.Cells["harga_hadiah"].Value.ToString());

                DialogResult hasil = MessageBox.Show("Data yang ingin dihapus : " +
                                                                    "\nnama_hadiah : " + nama_hadiah +
                                                                    "\nharga_hadiah : " + harga_hadiah +
                                                                    "Apakah anda yakin menghapus data tersebut ?", "Konfirmasi",
                                                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (hasil == DialogResult.Yes)
                {
                    h = new Hadiah(id);
                    Hadiah.HapusData(h, k);
                    MessageBox.Show("Data berhasil dihapus.", "Informasi");
                    FormDaftarHadiah_Load(buttonKeluar, e);
                }
            }
        }
    }
}