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
    public partial class FormDaftarTransaksi : Form
    {
        public FormDaftarTransaksi()
        {
            InitializeComponent();
        }

        private void FormDaftarTransaksi_Load(object sender, EventArgs e)
        {
            listInbox = Inbox.BacaData("", "");
            if (listInbox.Count > 0)
            {
                dataGridViewInbox.DataSource = listInbox;
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
    }
}
