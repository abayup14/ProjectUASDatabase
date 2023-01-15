using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
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
            labelKode.Visible = false;
            labelNama.Visible = false;
            labelStrip.Visible = false;
            labelAndaLogin.Visible = false;
            MenuToolStripMenuItem.Visible = false;
            penggunaToolStripMenuItem1.Visible = false;
            transaksiToolStripMenuItem.Visible = false;
            this.WindowState = FormWindowState.Maximized;
            this.IsMdiContainer = true;

            try
            {
                Koneksi koneksi = new Koneksi();

                FormPilihMasuk frmPilihMasuk = new FormPilihMasuk();

                frmPilihMasuk.Owner = this;

                frmPilihMasuk.ShowDialog();

                //FormLogin formLogin = (FormLogin)this.Owner;
                if (frmPilihMasuk.formLogin != null)
                {
                    if (frmPilihMasuk.formLogin.DialogResult == DialogResult.OK)
                    {
                        if (pengguna != null)
                        {
                            SetHakAkses();
                        }
                    }
                }
                else
                {
                    if (frmPilihMasuk.formLoginPegawai != null)
                    {
                        if (frmPilihMasuk.formLoginPegawai.DialogResult == DialogResult.OK)
                        {
                            if (employee != null)
                            {
                                SetHakAkses();
                            }
                        }
                    }
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Koneksi gagal. Pesan Kesalahan : " + ex.Message, "Kesalahan");
                Application.Exit();
            }
        }

        private void SetHakAkses()
        {
            labelNama.Visible = true;
            labelKode.Visible = true;
            labelStrip.Visible = true;
            labelAndaLogin.Visible = true;

            if (pengguna != null)
            {
                labelKode.Text = pengguna.Nik;
                labelNama.Text = pengguna.Nama_depan + " " + pengguna.Nama_keluarga;

                
                MenuToolStripMenuItem.Visible = false;
                transaksiToolStripMenuItem.Visible = true;
                penggunaToolStripMenuItem1.Visible = true;
            }
            else if (employee != null)
            {
                labelKode.Text = employee.Id.ToString();
                labelNama.Text = employee.Nama_depan + " " + employee.Nama_keluarga;
                MenuToolStripMenuItem.Visible = true;
            }
            MessageBox.Show("Selamat datang di aplikasi DiBa, " + labelNama.Text +
                            "\nSemoga harimu menyenangkan", "Selamat Datang!");
        }

        public void DisplayStatusPicture(string status, Panel panel)
        {
            PictureBox pictureBox = new PictureBox();

            pictureBox.Parent = panel;
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.BackColor = Color.Transparent;
            Image statusPicture = null;
            if (status == "Unverified")
            {
                statusPicture = new Bitmap(Properties.Resources.silang);
            }
            else if (status == "Aktif")
            {
                statusPicture = new Bitmap(Properties.Resources.centang);
            }
            else if (status == "Suspend")
            {
                statusPicture = new Bitmap(Properties.Resources.suspend);
            }
            pictureBox.Image = statusPicture;
            pictureBox.Size = new Size(75, 75);
            pictureBox.Location = new Point(400, 50);
            pictureBox.Visible = true;
            pictureBox.BringToFront();
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

        private void profilPenggunaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormProfilPengguna"];
            if (form == null)
            {
                FormProfilPengguna formProfilPengguna = new FormProfilPengguna();

                formProfilPengguna.MdiParent = this;

                formProfilPengguna.Show();
            }
            else
            {
                form.Show();

                form.BringToFront();
            }
        }

        private void tabunganPenggunaToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void depositoPenggunaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormDepositoPengguna"];
            if (form == null)
            {
                //FormDepositoPengguna formDepositoPengguna = new FormDepositoPengguna();
                //formDepositoPengguna.MdiParent = this;
                //formDepositoPengguna.Show();
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

        private void addressBookPenggunaToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void transferToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void transaksiTransferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormTambahTransaksi"];

            if (form == null)
            {
                FormTambahTransaksi formTambahTransaksi = new FormTambahTransaksi();
                formTambahTransaksi.MdiParent = this;
                formTambahTransaksi.Show();
            }
            else
            {
                form.Show();

                form.BringToFront();
            }
        }

        private void aktivitasToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void riwayatHadiahToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormRiwayatHadiah"];

            if (form == null)
            {
                FormRiwayatHadiah frmRiwayatHadiah = new FormRiwayatHadiah();
                frmRiwayatHadiah.MdiParent = this;
                frmRiwayatHadiah.Show();
            }
            else
            {
                form.Show();

                form.BringToFront();
            }
        }

        private void riwayatHadiahToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormRiwayatHadiah"];

            if (form == null)
            {
                FormRiwayatHadiah frmRiwayatHadiah = new FormRiwayatHadiah();
                frmRiwayatHadiah.MdiParent = this;
                frmRiwayatHadiah.Show();
            }
            else
            {
                form.Show();

                form.BringToFront();
            }
        }

        private void beliHadiahToolStripMenuItem_Click(object sender, EventArgs e)
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
    }
}