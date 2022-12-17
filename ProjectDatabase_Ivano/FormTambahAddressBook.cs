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
        public FormTambahAddressBook()
        {
            InitializeComponent();
        }
        Pengguna pengguna;

        private void FormTambahAddressBook_Load(object sender, EventArgs e)
        {
          
        }

        private void buttonKirim_Click(object sender, EventArgs e)
        {
            Tabungan a = new Tabungan(textBoxNoRekening.Text);
            Pengguna p = new Pengguna(textBoxIdPengguna.Text);
            AddressBook ab = new AddressBook(p,a, textBoxPesan.Text);
            Koneksi k = new Koneksi();
            AddressBook.TambahData(ab, k);
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            textBoxIdPengguna.Clear();
            textBoxNoRekening.Clear();
            textBoxPesan.Clear();
        }
    }
}
