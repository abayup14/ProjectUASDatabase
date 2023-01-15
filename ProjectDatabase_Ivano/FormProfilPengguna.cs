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
    public partial class FormProfilPengguna : Form
    {
        FormUtama formUtama;

        public Pengguna pengguna; 

        public FormProfilPengguna()
        {
            InitializeComponent();
        }

        private void FormProfilPengguna_Load(object sender, EventArgs e)
        {
            formUtama = (FormUtama)this.MdiParent;

            pengguna = Pengguna.AmbilDataByKode(formUtama.labelKode.Text);

            labelNIK.Text = pengguna.Nik;

            labelNama.Text = Pengguna.AmbilNamaLengkap(formUtama.labelKode.Text);

            labelAlamat.Text = pengguna.Alamat;

            labelEMail.Text = pengguna.Email;

            labelNoTelepon.Text = pengguna.No_telepon;
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            FormUbahPengguna formUbahPengguna = new FormUbahPengguna();

            formUbahPengguna.Owner = this;

            formUbahPengguna.Show();
        }

        private void buttonPassword_Click(object sender, EventArgs e)
        {
            FormUbahPasswordPengguna formUbahPasswordPengguna = new FormUbahPasswordPengguna();

            formUbahPasswordPengguna.Owner = this;

            formUbahPasswordPengguna.Show();
        }
    }
}
