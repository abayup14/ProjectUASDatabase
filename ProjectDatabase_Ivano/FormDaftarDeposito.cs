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

        public Employee employee;

        public FormDaftarDeposito()
        {
            InitializeComponent();
        }

        public void FormDaftarDeposito_Load(object sender, EventArgs e)
        {
            formUtama = (FormUtama)this.MdiParent;

            pengguna = formUtama.pengguna;

            employee = formUtama.employee;

            if (employee != null)
            {
                listDeposito = Deposito.BacaData("", "");
                buttonTambah.Visible = false;
            }    
            else if (pengguna != null)
            {
                panel1.Visible = false;

                FormatDataGridDeposito();
                listDeposito = Deposito.BacaData("t.id_pengguna", pengguna.Nik);
            }

            if(listDeposito.Count > 0)
            { 
                if (pengguna != null)
                {
                    foreach (Deposito deposito in listDeposito)
                    {
                        dataGridViewDeposito.Rows.Add(deposito.Id_deposito, deposito.No_rekening.Rekening, deposito.Nominal.ToString(), deposito.Tgl_buat.ToShortDateString());
                    }
                }
                else
                {
                    dataGridViewDeposito.DataSource = listDeposito;
                }
                if (dataGridViewDeposito.ColumnCount < 20)
                {
                    if (pengguna != null)
                    {
                        if (!dataGridViewDeposito.Columns.Contains("buttonDetailGrid"))
                        {
                            DataGridViewButtonColumn bcol = new DataGridViewButtonColumn();
                            bcol.HeaderText = "Aksi";
                            bcol.Text = "Detail";
                            bcol.Name = "buttonDetailGrid";
                            bcol.UseColumnTextForButtonValue = true;
                            dataGridViewDeposito.Columns.Add(bcol);
                        }
                    }

                    if (employee != null)
                    {
                        if (!dataGridViewDeposito.Columns.Contains("buttonAktifGrid") && !dataGridViewDeposito.Columns.Contains("buttonHapusGrid"))
                        {
                            DataGridViewButtonColumn bcol2 = new DataGridViewButtonColumn();
                            bcol2.HeaderText = "Aksi";
                            bcol2.Text = "Aktifkan";
                            bcol2.Name = "buttonAktifGrid";
                            bcol2.UseColumnTextForButtonValue = true;
                            dataGridViewDeposito.Columns.Add(bcol2);

                            DataGridViewButtonColumn bcol3 = new DataGridViewButtonColumn();
                            bcol3.HeaderText = "Aksi";
                            bcol3.Text = "Hapus";
                            bcol3.Name = "buttonHapusGrid";
                            bcol3.UseColumnTextForButtonValue = true;
                            dataGridViewDeposito.Columns.Add(bcol3);
                        }
                    }
                }
            }
            else
            {
                dataGridViewDeposito.DataSource = null;
            }
        }

        private void FormatDataGridDeposito()
        {
            dataGridViewDeposito.Rows.Clear();
            dataGridViewDeposito.Columns.Clear();
            dataGridViewDeposito.Columns.Add("IDDeposito", "ID Deposito");
            dataGridViewDeposito.Columns.Add("NoRekening", "Nomor Rekening");
            dataGridViewDeposito.Columns.Add("Nominal", "Nominal");
            dataGridViewDeposito.Columns.Add("TanggalBuat", "Tanggal Pembuatan");

            dataGridViewDeposito.Columns["IDDeposito"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewDeposito.Columns["NoRekening"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewDeposito.Columns["Nominal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewDeposito.Columns["TanggalBuat"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridViewDeposito.AllowUserToAddRows = false;
        }

        private void dataGridViewDeposito_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Koneksi k = new Koneksi();
            if (pengguna != null)
            {
                if (e.ColumnIndex == dataGridViewDeposito.Columns["buttonDetailGrid"].Index && e.RowIndex >= 0)
                {
                    Deposito d = Deposito.AmbilDataDeposito(dataGridViewDeposito.CurrentRow.Cells["IDDeposito"].Value.ToString());
                    FormDepositoPengguna formDepositoPengguna = new FormDepositoPengguna();
                    formDepositoPengguna.Owner = this;
                    formDepositoPengguna.labelIDDeposito.Text = dataGridViewDeposito.CurrentRow.Cells["IDDeposito"].Value.ToString();
                    formDepositoPengguna.labelNominal.Text = dataGridViewDeposito.CurrentRow.Cells["Nominal"].Value.ToString();
                    formDepositoPengguna.labelBunga.Text = (d.Bunga * 100).ToString() + " %";
                    formDepositoPengguna.labelStatus.Text = d.Status;
                    formDepositoPengguna.labelJatuhTempo.Text = d.Jatuh_tempo.ToString() + " bulan";
                    formDepositoPengguna.labelTanggal.Text = d.Tgl_buat.ToShortDateString();
                    formUtama.DisplayStatusPicture(d.Status, formDepositoPengguna.panel1);
                    formDepositoPengguna.ShowDialog();
                }
            }
            else if (employee != null)
            {
                if (e.ColumnIndex == dataGridViewDeposito.Columns["buttonHapusGrid"].Index && e.RowIndex >= 0)
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

                    if (hasil == DialogResult.Yes)
                    {
                        Deposito d = new Deposito(id_deposito);
                        Deposito.HapusData(d, k);

                        MessageBox.Show("Data berhasil dihapus.", "Informasi");

                        FormDaftarDeposito_Load(buttonKeluar, e);
                    }
                }
                else if (e.ColumnIndex == dataGridViewDeposito.Columns["buttonAktifGrid"].Index && e.RowIndex >= 0)
                {
                    if (dataGridViewDeposito.CurrentRow.Cells["Status"].Value.ToString() == "Aktif")
                    {
                        MessageBox.Show("Deposito sudah berstatus aktif. Anda tidak perlu mengaktifkannya lagi.");
                    }
                    else
                    {
                        DialogResult hasil = MessageBox.Show("Apakah anda ingin mengaktifkan deposito ini?", "Konfirmasi",
                                                          MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (hasil == DialogResult.Yes)
                        {
                            string id_deposito = dataGridViewDeposito.CurrentRow.Cells["id_deposito"].Value.ToString();
                            Tabungan t = new Tabungan(dataGridViewDeposito.CurrentRow.Cells["no_rekening"].Value.ToString());
                            int jatuh_tempo = int.Parse(dataGridViewDeposito.CurrentRow.Cells["jatuh_tempo"].Value.ToString());
                            double nominal = double.Parse(dataGridViewDeposito.CurrentRow.Cells["nominal"].Value.ToString());
                            double bunga = double.Parse(dataGridViewDeposito.CurrentRow.Cells["bunga"].Value.ToString());
                            string status = dataGridViewDeposito.CurrentRow.Cells["status"].Value.ToString();
                            DateTime tgl_buat = DateTime.Parse(dataGridViewDeposito.CurrentRow.Cells["tgl_buat"].Value.ToString());
                            Employee verifikatorBuka = employee;
                            Employee verifikatorCair = new Employee(int.Parse(dataGridViewDeposito.CurrentRow.Cells["verifikator_cair"].Value.ToString()));

                            Deposito d = new Deposito(id_deposito, t, jatuh_tempo, nominal, bunga, status, tgl_buat, DateTime.Now, verifikatorBuka, verifikatorCair);

                            Deposito.UbahStatus(d, employee, k);

                            MessageBox.Show("Deposito berhasil diaktifkan");

                            FormDaftarDeposito_Load(buttonKeluar, e);
                        }
                    }
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

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            
            FormTambahDeposito formTambahDeposito = new FormTambahDeposito();
            formTambahDeposito.Owner = this;
            formTambahDeposito.ShowDialog();
        }
    }
}
