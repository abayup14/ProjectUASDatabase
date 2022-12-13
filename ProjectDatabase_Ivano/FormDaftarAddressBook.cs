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
    }
}
