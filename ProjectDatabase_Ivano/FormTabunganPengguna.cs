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
        //FormUtama formUtama;
        FormDaftarTabungan formDaftarTabungan;

        public Pengguna p;

        public Tabungan t;

        public FormTabunganPengguna()
        {
            InitializeComponent();
        }

        private void FormTabunganPengguna_Load(object sender, EventArgs e)
        {
            formDaftarTabungan = (FormDaftarTabungan)this.Owner;

            p = formDaftarTabungan.pengguna;

            t = Tabungan.AmbilDataTabungan(formDaftarTabungan.dataGridViewTabungan.CurrentRow.Cells["NoRekening"].Value.ToString());
        }

        private void buttonTopUp_Click(object sender, EventArgs e)
        {
            FormTopUp formTopUp = new FormTopUp();
            formTopUp.Owner = this;
            CekSudahGantiPIN(t, formTopUp);
        }

        private void buttonTransfer_Click(object sender, EventArgs e)
        {
            FormTambahTransaksi formTambahTransaksi = new FormTambahTransaksi();
            formTambahTransaksi.Owner = this;
            CekSudahGantiPIN(t, formTambahTransaksi);
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            formDaftarTabungan.FormDaftarTabungan_Load(buttonKeluar, e);
            Close();
        }

        private void CekSudahGantiPIN(Tabungan t, Form form)
        {
            if (t.Status == "Aktif")
            {
                if (Pengguna.CekPIN(p) == true)
                {
                    form.ShowDialog();
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
                        formMasukkanPIN.buttonSimpan.Visible = true;
                        formMasukkanPIN.buttonCek.Visible = false;

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
    }
}
