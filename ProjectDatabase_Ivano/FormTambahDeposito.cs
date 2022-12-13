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
    public partial class FormTambahDeposito : Form
    {
        public FormTambahDeposito()
        {
            InitializeComponent();
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            FormUtama formUtama = (FormUtama)this.Owner;
            string no_rekening = Tabungan.AmbilDataNoRekening(formUtama.pengguna.Nik);
            string kode = Deposito.GenerateKode(no_rekening);
            double nominal = double.Parse(textBoxNominal.Text);
            
        }
    }
}
