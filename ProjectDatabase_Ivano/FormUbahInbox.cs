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
    public partial class FormUbahInbox : Form
    {
        public FormUbahInbox()
        {
            InitializeComponent();
        }

        private void FormUbahInbox_Load(object sender, EventArgs e)
        {
            List<Pengguna> listPosition = Pengguna.BacaData("", "");

            comboBoxPengguna.DataSource = listPosition;

            comboBoxPengguna.DisplayMember = "nama_depan";
        }

        private void buttonKirim_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Apakah anda yakin ingin mengubah data?", "Konfirmasi",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    Pengguna pengguna = (Pengguna)comboBoxPengguna.SelectedItem;
                    FormDaftarInbox formDaftarInbox = (FormDaftarInbox)this.Owner;

                    int id = int.Parse(formDaftarInbox.dataGridViewInbox.CurrentRow.Cells["id_pesan"].Value.ToString());

                    Inbox i = new Inbox(pengguna, id, textBoxPesan.Text, DateTime.Now, "Belum Terbaca", DateTime.Now);
                    Inbox.UbahData(i);

                    MessageBox.Show("Data inbox berhasil diubah.", "Informasi");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Data inbox gagal diubah. Pesan kesalahan: " + ex.Message, "Kesalahan");
            }
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            FormDaftarInbox formDaftarInbox = (FormDaftarInbox)this.Owner;
            formDaftarInbox.FormDaftarInbox_Load(buttonKeluar, e);
            this.Close();
        }
    }
}
