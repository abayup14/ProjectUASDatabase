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
    public partial class FormDaftarAddressBook : Form
    {
        List<AddressBook> listAddressBook = new List<AddressBook>();

        FormUtama formUtama;

        public Pengguna pengguna;

        public Employee employee;

        public FormDaftarAddressBook()
        {
            InitializeComponent();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahAddressBook formTambahAddressBook = new FormTambahAddressBook();
            formTambahAddressBook.Owner = this;
            formTambahAddressBook.Show();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        public void FormDaftarAddressBook_Load(object sender, EventArgs e)
        {
            formUtama = (FormUtama)this.MdiParent;

            pengguna = formUtama.pengguna;

            employee = formUtama.employee;



            if (pengguna != null)
            {
                FormatDataGridAddressBook();
                listAddressBook = AddressBook.BacaData("ab.id_pengguna", pengguna.Nik);
            }
            else if (employee != null)
            {
                buttonTambah.Visible = false;
                listAddressBook = AddressBook.BacaData("", "");
            }
            
            if (listAddressBook.Count > 0)
            {
                if (pengguna != null)
                {
                    foreach (AddressBook addressBook in listAddressBook)
                    {
                        string nama = addressBook.Pengguna.Nama_depan + " " + addressBook.Pengguna.Nama_keluarga;
                        dataGridViewAddressBook.Rows.Add(addressBook.No_rekening.Rekening, nama, addressBook.Keterangan);
                    }
                }
                else if (employee != null)
                {
                    dataGridViewAddressBook.DataSource = listAddressBook;
                }

                if (dataGridViewAddressBook.ColumnCount < 10)
                {
                    if (!dataGridViewAddressBook.Columns.Contains("buttonHapusGrid"))
                    {
                        DataGridViewButtonColumn bcol2 = new DataGridViewButtonColumn();
                        bcol2.HeaderText = "Aksi";
                        bcol2.Text = "Hapus";
                        bcol2.Name = "buttonHapusGrid";
                        bcol2.UseColumnTextForButtonValue = true;
                        dataGridViewAddressBook.Columns.Add(bcol2);
                    }
                }
            }
            else
            {
                dataGridViewAddressBook.DataSource = null;
            }
        }

        private void FormatDataGridAddressBook()
        {
            dataGridViewAddressBook.Rows.Clear();
            dataGridViewAddressBook.Columns.Clear();
            dataGridViewAddressBook.Columns.Add("NoRekening", "No. Rekening");
            dataGridViewAddressBook.Columns.Add("Nama", "Nama");
            dataGridViewAddressBook.Columns.Add("Keterangan", "Keterangan");

            dataGridViewAddressBook.Columns["NoRekening"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewAddressBook.Columns["Nama"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewAddressBook.Columns["Keterangan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void dataGridViewAddressBook_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Koneksi k = new Koneksi();
            if (e.ColumnIndex == dataGridViewAddressBook.Columns["buttonHapusGrid"].Index && e.RowIndex >= 0)
            {
                if (employee != null)
                {
                    string id_pengguna = dataGridViewAddressBook.CurrentRow.Cells["pengguna"].Value.ToString();
                    string no_rekening = dataGridViewAddressBook.CurrentRow.Cells["no_rekening"].Value.ToString();
                    string keterangan = dataGridViewAddressBook.CurrentRow.Cells["keterangan"].Value.ToString();
                    DialogResult hasil = MessageBox.Show("Data yang akan dihapus adalah : " +
                                                         "\nId Pengguna : " + id_pengguna +
                                                         "\nNo Rekening : " + no_rekening +
                                                         "\nKeterangan : " + keterangan +
                                                         "\n\nApakah anda yakin ingin menghapus data ini?", "Konfirmasi",
                                                         MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (hasil == DialogResult.Yes)
                    {
                        Pengguna p = new Pengguna(id_pengguna);
                        Tabungan t = new Tabungan(no_rekening);
                        AddressBook ab = new AddressBook(p, t, keterangan);
                        AddressBook.HapusData(ab, k);

                        MessageBox.Show("Data berhasil dihapus.", "Informasi");
                        FormDaftarAddressBook_Load(buttonKeluar, e);
                    }
                }
                else if (pengguna != null)
                {
                    DialogResult hasil = MessageBox.Show("Apakah anda yakin ingin menghapus data ini?", "Konfirmasi",
                                                         MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (hasil == DialogResult.Yes)
                    {
                        Pengguna p = pengguna;
                        Tabungan t = Tabungan.AmbilDataTabungan(dataGridViewAddressBook.CurrentRow.Cells["NoRekening"].Value.ToString());
                        string keterangan = dataGridViewAddressBook.CurrentRow.Cells["Keterangan"].Value.ToString();

                        AddressBook ab = new AddressBook(p, t, keterangan);
                        AddressBook.HapusData(ab, k);

                        MessageBox.Show("Data berhasil dihapus.", "Informasi");
                        FormDaftarAddressBook_Load(buttonKeluar, e);
                    }
                }
            }
        }
    }
}
