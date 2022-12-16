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
            Close(); 
        }

        private void FormDaftarAddressBook_Load(object sender, EventArgs e)
        {
          
            listAddressBook = AddressBook.BacaData("", "");
            if (listAddressBook.Count > 0)
            {
                dataGridViewAddressBook.DataSource = listAddressBook;
                if (dataGridViewAddressBook.ColumnCount == 10)
                {

                    DataGridViewButtonColumn bcol2 = new DataGridViewButtonColumn();
                    bcol2.HeaderText = "Aksi";
                    bcol2.Text = "Hapus";
                    bcol2.Name = "buttonHapusGrid";
                    bcol2.UseColumnTextForButtonValue = true;
                    dataGridViewAddressBook.Columns.Add(bcol2);
                }
            }
            else
            {
                dataGridViewAddressBook.DataSource = null;
            }


        }

        private void dataGridViewAddressBook_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == dataGridViewAddressBook.Columns["buttonHapusGrid"].Index && e.RowIndex >= 0)
            {
                string id_pengguna = dataGridViewAddressBook.CurrentRow.Cells["id_pengguna"].Value.ToString();
                string no_rekening = dataGridViewAddressBook.CurrentRow.Cells["no_rekening"].Value.ToString();
                string keterangan = dataGridViewAddressBook.CurrentRow.Cells["keterangan"].Value.ToString();
                
                DialogResult hasil = MessageBox.Show("Data yang akan dihapus adalah : " +
                    "\nId Pengguna : " + id_pengguna+
                    "\nNo Rekening : " + no_rekening +
                    "\nKeterangan : " + keterangan +                   
                    "\n\nApakah anda yakin ingin menghapus data ini?", "Konfirmasi",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (hasil == DialogResult.Yes)
                {
                    Koneksi k = new Koneksi();
                    Pengguna p = new Pengguna(id_pengguna);
                    Tabungan t = new Tabungan(no_rekening);
                    AddressBook ab = new AddressBook(p,t, keterangan);
                    AddressBook.HapusData(ab, k);


                    MessageBox.Show("Data berhasil dihapus.", "Informasi");
                    FormDaftarAddressBook_Load(buttonKeluar, e);
                }
            }
        }
    }
}
