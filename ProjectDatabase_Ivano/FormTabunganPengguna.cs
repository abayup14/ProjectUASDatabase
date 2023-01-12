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
    public partial class FormTabunganPengguna : Form
    {
        FormUtama formUtama;

        public Pengguna p;

        public Tabungan t;

        public FormTabunganPengguna()
        {
            InitializeComponent();
        }

        private void FormTabunganPengguna_Load(object sender, EventArgs e)
        {
            formUtama = (FormUtama)this.MdiParent;

            p = Pengguna.AmbilDataByKode(formUtama.pengguna.Nik);

            t = Tabungan.AmbilDataTabungan(p);

            labelRekening.Text = t.Rekening;

            labelSaldo.Text = "Rp. " + t.Saldo.ToString("N0");

            labelKeterangan.Text = t.Keterangan;

            labelTanggal.Text = t.Tgl_buat.ToShortDateString();

            labelStatus.Text = t.Status;

            DisplayStatusPicture(t.Status);
        }

        private void DisplayStatusPicture(string status)
        {
            PictureBox pictureBox = new PictureBox();

            pictureBox.Parent = panel1;
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
            pictureBox.Image = statusPicture;
            pictureBox.Size = new Size(75, 75);
            pictureBox.Location = new Point(400, 50);
            pictureBox.Visible = true;
            pictureBox.BringToFront();
        }

        private void buttonTopUp_Click(object sender, EventArgs e)
        {
            if (t.Status == "Aktif")
            {
                if (Pengguna.CekPIN(p) == true)
                {
                    FormTopUp formTopUp = new FormTopUp();

                    formTopUp.Owner = this;

                    formTopUp.ShowDialog();
                }
                else
                {
                    DialogResult hasil = MessageBox.Show("Tabungan anda sudah aktif, namun anda belum pernah membuat PIN." +
                                                         "\nSilahkan membuat PIN dengan menekan tombol \"OK\"", "Informasi",
                                                         MessageBoxButtons.OKCancel);

                    if (hasil == DialogResult.OK)
                    {
                        FormMasukkanPIN formMasukkanPIN = new FormMasukkanPIN();

                        formMasukkanPIN.Owner = this;

                        formMasukkanPIN.ShowDialog();
                    }
                }
            }
            else
            {
                MessageBox.Show("Maaf, status tabungan anda sedang tidak aktif." +
                                "\nSilahkan hubungi pegawai kami untuk mengaktifkan tabungan anda.", "Informasi");
            }
        }

        private void buttonTransfer_Click(object sender, EventArgs e)
        {
            if (t.Status == "Aktif")
            {
                FormTambahTransaksi formTambahTransaksi = new FormTambahTransaksi();

                formTambahTransaksi.Owner = this;

                formTambahTransaksi.ShowDialog();
            }
            else
            {
                MessageBox.Show("Maaf, status tabungan anda sedang tidak aktif." +
                                "\nSilahkan hubungi pegawai kami untuk mengaktifkan tabungan anda.", "Informasi");
            }
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
