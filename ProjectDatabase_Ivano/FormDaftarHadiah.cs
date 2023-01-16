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
    public partial class FormDaftarHadiah : Form
    {
        List<Hadiah> listHadiah = new List<Hadiah>();
        FormUtama formUtama;
        Koneksi k;
        Hadiah h;
        public Pengguna p;
        public Employee em;
        public FormDaftarHadiah()
        {
            InitializeComponent();
        }

        public void FormDaftarHadiah_Load(object sender, EventArgs e)
        {
            formUtama = (FormUtama)this.MdiParent;
            k = new Koneksi();
            p = formUtama.pengguna;
            em = formUtama.employee;
            if (p != null)
            {
                buttonTambah.Visible = false;
            }    
            listHadiah = Hadiah.BacaData("", "");
            if (listHadiah.Count > 0)
            {
                if (p != null)
                {
                    FormatDataGridHadiah();
                    foreach (Hadiah hadiah in listHadiah)
                    {
                        dataGridViewHadiah.Rows.Add(hadiah.Nama_hadiah, hadiah.Harga_hadiah);
                    }
                }
                else if (em != null)
                {
                    dataGridViewHadiah.DataSource = listHadiah;
                }

                if (dataGridViewHadiah.ColumnCount < 10)
                {
                    if (em != null)
                    {
                        if (!dataGridViewHadiah.Columns.Contains("buttonUbahGrid") && !dataGridViewHadiah.Columns.Contains("bittonHapusGrid"))
                        {
                            DataGridViewButtonColumn bcol1 = new DataGridViewButtonColumn();
                            bcol1.HeaderText = "Aksi";
                            bcol1.Text = "Ubah Data";
                            bcol1.Name = "buttonUbahGrid";
                            bcol1.UseColumnTextForButtonValue = true;
                            dataGridViewHadiah.Columns.Add(bcol1);

                            DataGridViewButtonColumn bcol2 = new DataGridViewButtonColumn();
                            bcol2.HeaderText = "Aksi";
                            bcol2.Text = "Hapus Data";
                            bcol2.Name = "buttonHapusGrid";
                            bcol2.UseColumnTextForButtonValue = true;
                            dataGridViewHadiah.Columns.Add(bcol2);
                        }
                    }    
                    else if (p != null)
                    {
                        if (!dataGridViewHadiah.Columns.Contains("buttonBeliGrid"))
                        {
                            DataGridViewButtonColumn bcol3 = new DataGridViewButtonColumn();
                            bcol3.HeaderText = "Aksi";
                            bcol3.Text = "Beli";
                            bcol3.Name = "buttonBeliGrid";
                            bcol3.UseColumnTextForButtonValue = true;
                            dataGridViewHadiah.Columns.Add(bcol3);
                        }
                    }
                }
            }
            else
            {
                dataGridViewHadiah.DataSource = null;
            }
        }
        private void FormatDataGridHadiah()
        {
            dataGridViewHadiah.Rows.Clear();
            dataGridViewHadiah.Columns.Clear();
            dataGridViewHadiah.Columns.Add("Nama", "Nama Hadiah");
            dataGridViewHadiah.Columns.Add("Harga", "Harga Hadiah");
                
            dataGridViewHadiah.Columns["Nama"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewHadiah.Columns["Harga"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridViewHadiah.AllowUserToAddRows = false;
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
                dataGridViewHadiah.DataSource = listHadiah;
            }
            else
            {
                dataGridViewHadiah.DataSource = null;
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
            if (p != null)
            {
                if (e.ColumnIndex == dataGridViewHadiah.Columns["buttonBeliGrid"].Index && e.RowIndex >= 0)
                {
                    DialogResult result = MessageBox.Show("Apakah barang yang dipilih sudah tepat ?", "Konfirmasi",
                                          MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        if (Poin.CekPoin(p) >= int.Parse(dataGridViewHadiah.CurrentRow.Cells["Harga"].Value.ToString()))
                        {
                            for (int i = 0; i < listHadiah.Count; i++)
                            {
                                if (e.RowIndex == i)
                                {
                                    Hadiah h = new Hadiah(int.Parse(listHadiah[i].Id.ToString()));
                                    RiwayatHadiah phh = new RiwayatHadiah(RiwayatHadiah.GenerateKode(), p, h, DateTime.Now);
                                    RiwayatHadiah.TambahData(phh, k);
                                    Poin po = new Poin(phh.Pengguna, int.Parse(listHadiah[i].Harga_hadiah));
                                    Poin.UpdateBeliHadiah(po, k);
                                    Inbox inbox = new Inbox(phh.Pengguna,
                                                        Inbox.GenerateKode(),
                                                        "Berhasil beli " + listHadiah[i].Nama_hadiah + " dengan harga " +
                                                        listHadiah[i].Harga_hadiah + " poin.",
                                                        DateTime.Now,
                                                        "Belum Terbaca",
                                                        DateTime.Now);
                                    Inbox.TambahData(inbox, k);
                                    MessageBox.Show("Pembelian Berhasil", "Informasi");
                                    FormDaftarHadiah_Load(buttonKeluar, e);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Pembelian Gagal, Poin anda sekarang " + Poin.CekPoin(p).ToString() + 
                                            "\nLakukan topup atau transaksi untuk meningkatkan poin anda", "Informasi");
                        }
                    }
                }
            }
            else if (em != null)
            {
                if (e.ColumnIndex == dataGridViewHadiah.Columns["buttonUbahGrid"].Index && e.RowIndex >= 0)
                {
                    FormUbahHadiah frmUbahHadiah = new FormUbahHadiah();
                    frmUbahHadiah.Owner = this;
                    //frmUbahHadiah.Show();
                    frmUbahHadiah.textBoxNamaHadiah.Text = dataGridViewHadiah.CurrentRow.Cells["nama_hadiah"].Value.ToString();
                    frmUbahHadiah.textBoxHargaHadiah.Text = dataGridViewHadiah.CurrentRow.Cells["harga_hadiah"].Value.ToString();
                    frmUbahHadiah.Show();
                }
                else if (e.ColumnIndex == dataGridViewHadiah.Columns["buttonHapusGrid"].Index && e.RowIndex >= 0)
                {
                    if (em != null)
                    {
                        int id = int.Parse(dataGridViewHadiah.CurrentRow.Cells["id"].Value.ToString());
                        string nama_hadiah = dataGridViewHadiah.CurrentRow.Cells["nama_hadiah"].Value.ToString();
                        int harga_hadiah = int.Parse(dataGridViewHadiah.CurrentRow.Cells["harga_hadiah"].Value.ToString());

                        DialogResult hasil = MessageBox.Show("Data yang ingin dihapus : " +
                                                                            "\nnama_hadiah : " + nama_hadiah +
                                                                            "\nharga_hadiah : " + harga_hadiah +
                                                                            "\nApakah anda yakin menghapus data tersebut ?", "Konfirmasi",
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
    }
}
