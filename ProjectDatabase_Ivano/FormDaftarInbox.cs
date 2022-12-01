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
    public partial class FormDaftarInbox : Form
    {
        public List<Inbox> listInbox = new List<Inbox>();
        public FormDaftarInbox()
        {
            InitializeComponent();
        }

        private void FormDaftarInbox_Load(object sender, EventArgs e)
        {
            listInbox = Inbox.BacaData("", "");
            if (listInbox.Count > 0)
            {
                if (dataGridViewInbox.ColumnCount == 6)
                {
                    DataGridViewButtonColumn bcol1 = new DataGridViewButtonColumn();
                    bcol1.HeaderText = "Aksi";
                    bcol1.Text = "Ubah Data";
                    bcol1.Name = "buttonUbahGrid";
                    bcol1.UseColumnTextForButtonValue = true;
                    dataGridViewInbox.Columns.Add(bcol1);

                    DataGridViewButtonColumn bcol2 = new DataGridViewButtonColumn();
                    bcol2.HeaderText = "Aksi";
                    bcol2.Text = "Hapus Data";
                    bcol2.Name = "buttonHapusGrid";
                    bcol2.UseColumnTextForButtonValue = true;
                    dataGridViewInbox.Columns.Add(bcol2);
                }
            }
            else
            {
                dataGridViewInbox.DataSource = null;
            }
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormDaftarInbox frmTambahInbox = new FormDaftarInbox();
            frmTambahInbox.Owner = this;
            frmTambahInbox.Show();
        }

        private void dataGridViewInbox_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewInbox.Columns["buttonUbahGrid"].Index && e.RowIndex >= 0)
            {
                FormUbahInbox frmUbahInbox = new FormUbahInbox();
                frmUbahInbox.Owner = this;
                frmUbahInbox.textBoxIdPesan.Text = dataGridViewInbox.CurrentRow.Cells["id_pesan"].Value.ToString();
                frmUbahInbox.textBoxPesan.Text = dataGridViewInbox.CurrentRow.Cells["pesan"].Value.ToString();
                frmUbahInbox.dateTimePickerTanggal_Kirim.Text = dataGridViewInbox.CurrentRow.Cells["tanggal_kirim"].Value.ToString();
                frmUbahInbox.textBoxStatus.Text = dataGridViewInbox.CurrentRow.Cells["status"].Value.ToString();
                frmUbahInbox.dateTimePickertgl_Perubahan.Text = dataGridViewInbox.CurrentRow.Cells["tgl_perubahan"].Value.ToString();
                frmUbahInbox.ShowDialog();
            }
            else if (e.ColumnIndex == dataGridViewInbox.Columns["buttonHapusGrid"].Index && e.RowIndex >= 0)
            {
                string id_pesan = dataGridViewInbox.CurrentRow.Cells["id_pesan"].Value.ToString();
                string pesan= dataGridViewInbox.CurrentRow.Cells["pesan"].Value.ToString();
                DateTime tanggal_kirim = DateTime.Parse(dataGridViewInbox.CurrentRow.Cells["tanggal_kirim"].Value.ToString());
                string status = dataGridViewInbox.CurrentRow.Cells["status"].Value.ToString();
                DateTime tgl_perubahan= DateTime.Parse(dataGridViewInbox.CurrentRow.Cells["tgl_perubahan"].Value.ToString());
                DialogResult hasil = MessageBox.Show("Apakah anda ingin menghapus " +
                    "\nid_pesan = " + id_pesan + "\npesan = " + pesan + "\ntanggal_kirim" + tanggal_kirim +
                    "\nstatus = " + status + "\ntgl_perubahan" + tgl_perubahan, "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
        }
    }
}
