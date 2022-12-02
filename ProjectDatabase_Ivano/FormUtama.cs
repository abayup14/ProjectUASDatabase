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
    public partial class FormUtama : Form
    {
        public Pengguna pengguna;

        public Employee employee;

        public FormUtama()
        {
            InitializeComponent();
        }

        private void FormUtama_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.IsMdiContainer = true;
            try
            {
                Koneksi koneksi = new Koneksi();

                FormLogin formLogin = new FormLogin();

                formLogin.Owner = this;

                if (formLogin.ShowDialog() == DialogResult.OK)
                {
                    labelKode.Text = pengguna.Nik;

                    labelNama.Text = pengguna.Nama_depan + " " + pengguna.Nama_keluarga;

                    MessageBox.Show("Halo, " + labelNama.Text + ". Selamat datang di aplikasi DiBa!", "Informasi");
                }
                else
                {
                    MessageBox.Show("Maaf, anda tidak dapat masuk ke dalam aplikasi.", "Kesalahan");
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Koneksi gagal. Pesan Kesalahan : " + ex.Message, "Kesalahan");
            }
        }

        private void penggunaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormDaftarPengguna"];
            if (form == null)
            {
                FormDaftarPengguna formDaftarPengguna = new FormDaftarPengguna();

                formDaftarPengguna.MdiParent = this;

                formDaftarPengguna.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void jenisTransaksiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormDaftarJenisTransaksi"];
            if (form == null)
            {
                FormDaftarJenisTransaksi formDaftarJenisTransaksi = new FormDaftarJenisTransaksi();

                formDaftarJenisTransaksi.MdiParent = this;

                formDaftarJenisTransaksi.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void PositionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormDaftarJabatan"];
            if (form == null)
            {
                FormDaftarPosition formDaftarJabatan = new FormDaftarPosition();

                formDaftarJabatan.MdiParent = this;

                formDaftarJabatan.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void keluarSistemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormDaftarEmployee"];
            if (form == null)
            {
                FormDaftarEmployee formDaftarEmployee = new FormDaftarEmployee();

                formDaftarEmployee.MdiParent = this;

                formDaftarEmployee.Show();
            }
            else
            {
                form.Show();

                form.BringToFront();
            }
        }

        private void inboxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormDaftarInbox"];
            if (form == null)
            {
                FormDaftarInbox formDaftarInbox = new FormDaftarInbox();

                formDaftarInbox.MdiParent = this;

                formDaftarInbox.Show();
            }
            else
            {
                form.Show();

                form.BringToFront();
            }
        }
    }
}
