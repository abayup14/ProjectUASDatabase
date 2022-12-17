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
    public partial class FormDaftarDeposito : Form
    {
        public List<Deposito> listDeposito = new List<Deposito>();

        FormUtama formUtama;

        public Pengguna pengguna;

        public FormDaftarDeposito()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahDeposito formTambahDeposito = new FormTambahDeposito();
            formTambahDeposito.Owner = this;
            formTambahDeposito.Show();
        }

        public void FormDaftarDeposito_Load(object sender, EventArgs e)
        {
            formUtama = (FormUtama)this.MdiParent;

            pengguna = formUtama.pengguna;

            listDeposito = Deposito.BacaData("", "");

            if(listDeposito.Count > 0)
            {
                dataGridViewDeposito.DataSource = listDeposito;
                if(dataGridViewDeposito.ColumnCount == 10)
                {
                    DataGridViewButtonColumn bcol = new DataGridViewButtonColumn();
                    bcol.HeaderText = "Aksi";
                    bcol.Text = "Cairkan";
                    bcol.Name = "buttonCairkanGrid";
                    bcol.UseColumnTextForButtonValue = true;
                    dataGridViewDeposito.Columns.Add(bcol);

                    DataGridViewButtonColumn bcol2 = new DataGridViewButtonColumn();
                    bcol2.HeaderText = "Aksi";
                    bcol2.Text = "Hapus";
                    bcol2.Name = "buttonHapusGrid";
                    bcol2.UseColumnTextForButtonValue = true;
                    dataGridViewDeposito.Columns.Add(bcol2);

                    DataGridViewButtonColumn bcol3 = new DataGridViewButtonColumn();
                    bcol3.HeaderText = "Aksi";
                    bcol3.Text = "Aktifkan";
                    bcol3.Name = "buttonAktifGrid";
                    bcol3.UseColumnTextForButtonValue = true;
                    dataGridViewDeposito.Columns.Add(bcol3);
                }
            }
            else
            {
                dataGridViewDeposito.DataSource = null;
            }
        }

        private void dataGridViewDeposito_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewDeposito.Columns["buttonCairkanGrid"].Index && e.RowIndex >= 0)
            {
                listDeposito = Deposito.BacaData("", "");
                FormPencairanDeposito formPencairanDeposito = new FormPencairanDeposito();
                formPencairanDeposito.Owner = this;
                //formUbahDeposito.textBoxJatuhTempo.Text = dataGridViewDeposito.CurrentRow.Cells["jatuh_tempo"].Value.ToString();
                //formUbahDeposito.textBoxNominal.Text = dataGridViewDeposito.CurrentRow.Cells["nominal"].Value.ToString();
                //formUbahDeposito.textBoxBunga.Text = dataGridViewDeposito.CurrentRow.Cells["bunga"].Value.ToString();
                //formUbahDeposito.textBoxStatus.Text = dataGridViewDeposito.CurrentRow.Cells["status"].Value.ToString();
                formPencairanDeposito.Show();
            }
            else if (e.ColumnIndex == dataGridViewDeposito.Columns["buttonHapusGrid"].Index && e.RowIndex >= 0)
            {
                string id_deposito = dataGridViewDeposito.CurrentRow.Cells["id_deposito"].Value.ToString();
                string no_rekening = dataGridViewDeposito.CurrentRow.Cells["no_rekening"].Value.ToString();
                int jatuh_tempo = int.Parse(dataGridViewDeposito.CurrentRow.Cells["jatuh_tempo"].Value.ToString());
                double nominal = double.Parse(dataGridViewDeposito.CurrentRow.Cells["nominal"].Value.ToString());
                double bunga = double.Parse(dataGridViewDeposito.CurrentRow.Cells["bunga"].Value.ToString());

                DialogResult hasil = MessageBox.Show("Data yang akan dihapus adalah : " +
                    "\nId Deposito : " + id_deposito +
                    "\nNo Rekening : " + no_rekening +
                    "\nJatuh Tempo : " + jatuh_tempo +
                    "\nNominal : " + nominal +
                    "\nBunga : " + bunga +
                    "\n\nApakah anda yakin ingin menghapus data ini?", "Konfirmasi",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if(hasil == DialogResult.Yes)
                {
                    Koneksi k = new Koneksi();
                    Deposito d = new Deposito(id_deposito);
                    Deposito.HapusData(d, k);

                    MessageBox.Show("Data berhasil dihapus.", "Informasi");
                    FormDaftarDeposito_Load(buttonKeluar, e);
                }
            }
        }

        private void textBoxNilaiKriteria_TextChanged(object sender, EventArgs e)
        {
            if(comboBoxKriteria.Text == "Id Deposito")
            {
                listDeposito = Deposito.BacaData("d.id_deposito", textBoxNilaiKriteria.Text);
            }
            else if(comboBoxKriteria.Text == "No Rekening")
            {
                listDeposito = Deposito.BacaData("t.no_rekening", textBoxNilaiKriteria.Text);
            }
            else if(comboBoxKriteria.Text == "Jatuh Tempo")
            {
                listDeposito = Deposito.BacaData("d.jatuh_tempo", textBoxNilaiKriteria.Text);
            }
            else if(comboBoxKriteria.Text == "Nominal")
            {
                listDeposito = Deposito.BacaData("d.nominal", textBoxNilaiKriteria.Text);
            }
            else if(comboBoxKriteria.Text == "Bunga")
            {
                listDeposito = Deposito.BacaData("d.bunga", textBoxNilaiKriteria.Text);
            }
            else if(comboBoxKriteria.Text == "Status")
            {
                listDeposito = Deposito.BacaData("d.status", textBoxNilaiKriteria.Text);
            }
            else if(comboBoxKriteria.Text == "Tanggal Buat")
            {
                listDeposito = Deposito.BacaData("d.tgl_buat", textBoxNilaiKriteria.Text);
            }
            else if(comboBoxKriteria.Text == "Tanggal Perubahan")
            {
                listDeposito = Deposito.BacaData("d.tgl_perubahan", textBoxNilaiKriteria.Text);
            }

            if(listDeposito.Count > 0)
            {
                dataGridViewDeposito.DataSource = listDeposito;
            }
            else
            {
                dataGridViewDeposito.DataSource = null;
            }
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
