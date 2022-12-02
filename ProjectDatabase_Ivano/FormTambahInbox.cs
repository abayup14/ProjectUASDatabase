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
    public partial class FormTambahInbox : Form
    {
        public FormTambahInbox()
        {
            InitializeComponent();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            FormDaftarInbox formDaftarInbox = (FormDaftarInbox)this.Owner;
            formDaftarInbox.FormDaftarInbox_Load(buttonKeluar, e);
            this.Close();
        }

        private void buttonKirim_Click(object sender, EventArgs e)
        {
            try
            {
                Pengguna pengguna = (Pengguna)comboBoxPengguna.SelectedItem;

                int id = Inbox.GenerateKode();
                Inbox i = new Inbox(pengguna, id, textBoxPesan.Text, DateTime.Now, "Belum Terbaca", DateTime.Now);

                Inbox.TambahData(i);
                MessageBox.Show("Inbox telah berhasil dikirim.", "Informasi");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Inbox gagal dikirim. Pesan kesalahan : " + ex.Message, "Error");
            }
        }

        private void FormTambahInbox_Load(object sender, EventArgs e)
        {
            List<Pengguna> listPengguna = Pengguna.BacaData("", "");

            comboBoxPengguna.DataSource = listPengguna;

            comboBoxPengguna.DisplayMember = "nama_depan";
        }
    }
}
