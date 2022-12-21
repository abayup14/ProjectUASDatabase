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
    public partial class FormTambahAddressBook : Form
    {
        FormDaftarAddressBook formDaftarAddressBook;


        public FormTambahAddressBook()
        {
            InitializeComponent();
        }

        private void FormTambahAddressBook_Load(object sender, EventArgs e)
        {
            formDaftarAddressBook = (FormDaftarAddressBook)this.Owner;

            labelNamaPengguna.Text = Pengguna.AmbilNamaLengkap(formDaftarAddressBook.pengguna.Nik);
        }

        private void buttonKirim_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult hasil = MessageBox.Show("Apakah data yang anda masukkan sudah benar?", "Konfirmasi", MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Question);

                if (hasil == DialogResult.Yes)
                {
                    Tabungan a = new Tabungan(textBoxNoRekening.Text);

                    Pengguna p = new Pengguna(formDaftarAddressBook.pengguna.Nik);

                    AddressBook ab = new AddressBook(p, a, textBoxKeterangan.Text);

                    Koneksi k = new Koneksi();

                    AddressBook.TambahData(ab, k);

                    MessageBox.Show("Data Address Book berhasil disimpan.", "Informasi");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menambah address book. Pesan kesalahan : " + ex.Message, "Kesalahan");
            }
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            labelNamaPengguna.Text = "";
            textBoxNoRekening.Clear();
            textBoxKeterangan.Clear();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            FormDaftarAddressBook formDaftarAddressBook = (FormDaftarAddressBook)this.Owner;

            formDaftarAddressBook.FormDaftarAddressBook_Load(buttonKeluar, e);

            Close();
        }
    }
}
