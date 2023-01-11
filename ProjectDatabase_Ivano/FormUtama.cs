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

                //FormLogin formLogin = (FormLogin)this.Owner;

                //FormLoginPegawai formLoginPegawai = (FormLoginPegawai)this.Owner;

                //FormPilihMasuk formPilihMasuk = new FormPilihMasuk();

                //formPilihMasuk.Owner = this;

                //formPilihMasuk.Show();
                if (formLogin.ShowDialog() == DialogResult.OK)
                {
                    if (pengguna != null)
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

                //else if (employee != null)
                //{
                //    labelKode.Text = employee.Id.ToString();

                //    labelNama.Text = employee.Nama_depan + " " + employee.Nama_keluarga;

                //    MessageBox.Show("Halo, " + labelNama.Text + ". Selamat datang di aplikasi DiBa!", "Informasi");
                //}
                
                //MessageBox.Show("Halo, " + labelNama.Text + ". Selamat datang di aplikasi DiBa!", "Informasi");

                //if (formLogin.ShowDialog() == DialogResult.OK || formLoginPegawai.ShowDialog() == DialogResult.OK)
                //{

                //}

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

        private void riwayatTransaksiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormDaftarTransaksi"];

            if (form == null)
            {
                FormDaftarTransaksi formDaftarTransaksi = new FormDaftarTransaksi();

                formDaftarTransaksi.MdiParent = this;

                formDaftarTransaksi.Show();
            }
            else
            {
                form.Show();

                form.BringToFront();
            }
        }

        private void tabunganToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormDaftarTabungan"];

            if (form == null)
            {
                FormDaftarTabungan frmDaftarTabungan = new FormDaftarTabungan();

                frmDaftarTabungan.MdiParent = this;

                frmDaftarTabungan.Show();
            }
            else
            {
                form.Show();

                form.BringToFront();
            }
        }

        private void depositoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormDaftarDeposito"];

            if (form == null)
            {
                FormDaftarDeposito formDaftarDeposito = new FormDaftarDeposito();

                formDaftarDeposito.MdiParent = this;

                formDaftarDeposito.Show();
            }
            else
            {
                form.Show();

                form.BringToFront();
            }
        }

        private void addressBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormDaftarAddressBook"];

            if (form == null)
            {
                FormDaftarAddressBook formDaftarAddressBook = new FormDaftarAddressBook();

                formDaftarAddressBook.MdiParent = this;

                formDaftarAddressBook.Show();
            }
            else
            {
                form.Show();

                form.BringToFront();
            }
        }

        private void poinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormDaftarPoin"];
            if (form == null)
            {
                FormDaftarPoin frmDaftarPoin = new FormDaftarPoin();
                frmDaftarPoin.MdiParent = this;
                frmDaftarPoin.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
            
        }

        private void hadiahToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormDaftarHadiah"];
            if (form == null)
            {
                FormDaftarHadiah frmDaftarHadiah = new FormDaftarHadiah();
                frmDaftarHadiah.MdiParent = this;
                frmDaftarHadiah.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void jenisTagihanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormDaftarJenisTagihan"];
            if (form == null)
            {
                FormDaftarJenisTagihan frmDaftarJenisTagihan = new FormDaftarJenisTagihan();

                frmDaftarJenisTagihan.MdiParent = this;

                frmDaftarJenisTagihan.Show();
            }
            else
            {
                form.Show();

                form.BringToFront();
            }
        }

        private void topUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormTopUp"];
            if (form == null)
            {
                FormTopUp formTopUp = new FormTopUp();

                formTopUp.MdiParent = this;

                formTopUp.Show();
            }
            else
            {
                form.Show();

                form.BringToFront();
            }
        }
    }
}