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

        public FormTabunganPengguna()
        {
            InitializeComponent();
        }

        private void FormTabunganPengguna_Load(object sender, EventArgs e)
        {
            formUtama = (FormUtama)this.MdiParent;

            p = Pengguna.AmbilDataByKode(formUtama.pengguna.Nik);

            Tabungan t = Tabungan.AmbilDataTabungan(p);

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
            FormTopUp formTopUp = new FormTopUp();

            formTopUp.Owner = this;

            formTopUp.ShowDialog();
        }

        private void buttonTransfer_Click(object sender, EventArgs e)
        {
            FormTambahTransaksi formTambahTransaksi = new FormTambahTransaksi();

            formTambahTransaksi.Owner = this;

            formTambahTransaksi.ShowDialog();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
