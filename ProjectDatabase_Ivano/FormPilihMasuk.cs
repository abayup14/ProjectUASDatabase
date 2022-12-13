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
    public partial class FormPilihMasuk : Form
    {
        public FormPilihMasuk()
        {
            InitializeComponent();
        }

        private void buttonPengguna_Click(object sender, EventArgs e)
        {
            FormLogin formLogin = new FormLogin();

            formLogin.Owner = this;

            formLogin.ShowDialog();
        }

        private void buttonPegawai_Click(object sender, EventArgs e)
        {
            FormLoginPegawai formLoginPegawai = new FormLoginPegawai();

            formLoginPegawai.Owner = this;

            formLoginPegawai.ShowDialog();
        }
    }
}
