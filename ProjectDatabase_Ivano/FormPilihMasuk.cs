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
        FormUtama formUtama;

        public FormLogin formLogin;

        public FormLoginPegawai formLoginPegawai;

        public FormPilihMasuk()
        {
            InitializeComponent();
        }

        private void buttonPegawai_Click(object sender, EventArgs e)
        {
            formLoginPegawai = new FormLoginPegawai();
            formLoginPegawai.Owner = formUtama;
            formLoginPegawai.ShowDialog();
            Close();
        }

        public void FormPilihMasuk_Load(object sender, EventArgs e)
        {
            formUtama = (FormUtama)this.Owner;
        }

        private void buttonPengguna_Click(object sender, EventArgs e)
        {
            formLogin = new FormLogin();
            formLogin.Owner = formUtama;
            formLogin.ShowDialog();
            Close();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            DialogResult hasil = MessageBox.Show("Apakah anda ingin keluar dari aplikasi?", 
                                                 "Konfirmasi",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Warning);

            if (hasil == DialogResult.Yes)
            {
                MessageBox.Show("Sampai berjumpa lagi.", "Goodbye", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
        }
    }
}
