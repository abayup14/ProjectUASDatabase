using System;
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
    public partial class FormDaftarInbox : Form
    {
        public List<Inbox> listInbox = new List<Inbox>();

        public List<Pengguna> listPengguna = new List<Pengguna>();

        Koneksi k;

        FormUtama formUtama;

        public Pengguna pengguna;

        public Employee employee;
        public FormDaftarInbox()
        {
            InitializeComponent();
        }

        public void FormDaftarInbox_Load(object sender, EventArgs e)
        {
            formUtama = (FormUtama)this.MdiParent;
            pengguna = formUtama.pengguna;
            employee = formUtama.employee;
            k = new Koneksi();
            if (employee != null)
            {
                buttonTambah.Visible = false;
                listInbox = Inbox.BacaData("", "");
            }
            else if (pengguna != null)
            {
                panel1.Visible = false;
                FormatDataGridInboxPengguna();
                listInbox = Inbox.BacaData("p.nik", pengguna.Nik);
            }
            if (listInbox.Count > 0)
            {
                if (employee != null)
                {
                    dataGridViewInbox.DataSource = listInbox;
                }
                else if (pengguna != null)
                {
                    foreach (Inbox inbox in listInbox)
                    {
                        dataGridViewInbox.Rows.Add(inbox.Pesan, inbox.Tanggal_kirim.ToShortDateString());
                    }
                }
                
                if (dataGridViewInbox.ColumnCount < 10)
                {
                    if (pengguna != null)
                    {
                        DataGridViewButtonColumn bcol = new DataGridViewButtonColumn();
                        bcol.HeaderText = "Aksi";
                        bcol.Text = "Baca";
                        bcol.Name = "buttonBacaGrid";
                        bcol.UseColumnTextForButtonValue = true;
                        dataGridViewInbox.Columns.Add(bcol);
                    }
                    if (employee != null)
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
                    }
                }
            }
            else
            {
                dataGridViewInbox.DataSource = null;
            }
        }

        private void FormatDataGridInboxPengguna()
        {
            dataGridViewInbox.Rows.Clear();
            dataGridViewInbox.Columns.Clear();
            dataGridViewInbox.Columns.Add("Pesan", "Pesan");
            dataGridViewInbox.Columns.Add("TglTerima", "Tanggal Terima");
        }

        private void ButtonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahInbox frmTambahInbox = new FormTambahInbox();
            frmTambahInbox.Owner = this;
            frmTambahInbox.Show();
        }

        private void dataGridViewInbox_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (pengguna != null)
            {
                if (e.ColumnIndex == dataGridViewInbox.Columns["buttonBacaGrid"].Index && e.RowIndex >= 0)
                {
                    for (int i = 0; i < listInbox.Count; i++)
                    {
                        if (e.RowIndex == i)
                        {
                            MessageBox.Show(listInbox[i].Pesan, "Informasi");
                            Inbox.UbahStatusPesan(listInbox[i], k);
                            break;
                        }
                    }
                }
            }
            else if (employee != null)
            {
                if (e.ColumnIndex == dataGridViewInbox.Columns["buttonUbahGrid"].Index && e.RowIndex >= 0)
                {
                    FormUbahInbox frmUbahInbox = new FormUbahInbox();
                    frmUbahInbox.Owner = this;

                    listPengguna = Pengguna.BacaData("", "");
                    frmUbahInbox.comboBoxPengguna.DataSource = listPengguna;
                    frmUbahInbox.comboBoxPengguna.DisplayMember = "Nik";

                    frmUbahInbox.comboBoxPengguna.Text = dataGridViewInbox.CurrentRow.Cells["pengguna"].Value.ToString();
                    frmUbahInbox.textBoxPesan.Text = dataGridViewInbox.CurrentRow.Cells["pesan"].Value.ToString();
                    frmUbahInbox.ShowDialog();
                }
                else if (e.ColumnIndex == dataGridViewInbox.Columns["buttonHapusGrid"].Index && e.RowIndex >= 0)
                {
                    string nik = dataGridViewInbox.CurrentRow.Cells["pengguna"].Value.ToString();
                    string nama = Pengguna.AmbilNamaLengkap(nik);
                    int id_pesan = int.Parse(dataGridViewInbox.CurrentRow.Cells["id"].Value.ToString());
                    string pesan = dataGridViewInbox.CurrentRow.Cells["pesan"].Value.ToString();
                    DateTime tanggal_kirim = DateTime.Parse(dataGridViewInbox.CurrentRow.Cells["tanggal_kirim"].Value.ToString());
                    string status = dataGridViewInbox.CurrentRow.Cells["status"].Value.ToString();

                    DialogResult hasil = MessageBox.Show("Data yang akan dihapus adalah " +
                                                         "\nID Pengguna : " + nik +
                                                         "\nNama : " + nama +
                                                         "\nPesan : " + pesan +
                                                         "\nTanggal Kirim : " + tanggal_kirim.ToShortDateString() +
                                                         "\nStatus : " + status +
                                                         "\n\nApakah anda yakin ingin menghapus data di atas?",
                                                         "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (hasil == DialogResult.Yes)
                    {
                        Inbox i = new Inbox(id_pesan);
                        Inbox.HapusData(i, k);
                        MessageBox.Show("Data berhasil dihapus.", "Informasi");
                        dataGridViewInbox.Rows.Clear();
                        dataGridViewInbox.Columns.Clear();
                        FormDaftarInbox_Load(buttonKeluar, e);
                    }
                }
            }
        }

        private void textBoxNilaiKriteria_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxKriteria.Text == "ID Pengguna")
            {
                listInbox = Inbox.BacaData("id_pengguna", textBoxNilaiKriteria.Text);
            }
            else if (comboBoxKriteria.Text == "ID Pesan")
            {
                listInbox = Inbox.BacaData("id_pesan", textBoxNilaiKriteria.Text);
            }
            else if (comboBoxKriteria.Text == "Pesan")
            {
                listInbox = Inbox.BacaData("pesan", textBoxNilaiKriteria.Text);
            }
            else if (comboBoxKriteria.Text == "Tanggal Kirim")
            {
                listInbox = Inbox.BacaData("tanggal_kirim", textBoxNilaiKriteria.Text);
            }
            else if (comboBoxKriteria.Text == "Status")
            {
                listInbox = Inbox.BacaData("status", textBoxNilaiKriteria.Text);
            }
            else if (comboBoxKriteria.Text == "Tanggal Perubahan")
            {
                listInbox = Inbox.BacaData("tgl_perubahan", textBoxNilaiKriteria.Text);
            }

            if (listInbox.Count > 0)
            {
                dataGridViewInbox.DataSource = listInbox;
            }
            else
            {
                dataGridViewInbox.DataSource = null;
            }
        }

        private void comboBoxKriteria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
