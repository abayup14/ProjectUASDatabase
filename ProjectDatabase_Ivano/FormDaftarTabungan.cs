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
    public partial class FormDaftarTabungan : Form
    {
        public List<Tabungan> listTabungan = new List<Tabungan>();

        FormUtama formUtama;

        Koneksi k;

        public Employee employee;

        public Pengguna pengguna;

        Tabungan tabungan;

        public FormDaftarTabungan()
        {
            InitializeComponent();
        }

        public void FormDaftarTabungan_Load(object sender, EventArgs e)
        {
            k = new Koneksi();

            formUtama = (FormUtama)this.MdiParent;

            pengguna = formUtama.pengguna;

            employee = formUtama.employee;

            if (employee != null)
            {
                listTabungan = Tabungan.BacaData("", "");
                buttonTambah.Visible = false;
            }
            else if (pengguna != null)
            {
                panel1.Visible = false;
                FormatDataGridTabungan();
                listTabungan = Tabungan.BacaData("p.nik", pengguna.Nik);
            }

            if (listTabungan.Count > 0)
            {
                
                if (pengguna != null)
                {
                    foreach (Tabungan tabungan in listTabungan)
                    {
                        dataGridViewTabungan.Rows.Add(tabungan.Rekening, tabungan.Saldo.ToString(), tabungan.Tgl_buat.ToShortDateString());
                    }
                }
                else
                {
                    dataGridViewTabungan.DataSource = listTabungan;
                }

                if (dataGridViewTabungan.ColumnCount < 20)
                {
                    if (pengguna != null)
                    {
                        if (!dataGridViewTabungan.Columns.Contains("buttonDetailGrid"))
                        {
                            DataGridViewButtonColumn bcol = new DataGridViewButtonColumn();
                            bcol.HeaderText = "Aksi";
                            bcol.Text = "Detail";
                            bcol.Name = "buttonDetailGrid";
                            bcol.UseColumnTextForButtonValue = true;
                            dataGridViewTabungan.Columns.Add(bcol);
                        }
                    }
                    else if (employee != null)
                    {
                        if (!dataGridViewTabungan.Columns.Contains("buttonUbahStatusGrid") && !dataGridViewTabungan.Columns.Contains("buttonHapusGrid"))
                        {
                            DataGridViewButtonColumn bcol1 = new DataGridViewButtonColumn();
                            bcol1.HeaderText = "Aksi";
                            bcol1.Text = "Ubah Status";
                            bcol1.Name = "buttonUbahStatusGrid";
                            bcol1.UseColumnTextForButtonValue = true;
                            dataGridViewTabungan.Columns.Add(bcol1);

                            DataGridViewButtonColumn bcol2 = new DataGridViewButtonColumn();
                            bcol2.HeaderText = "Aksi";
                            bcol2.Text = "Hapus Data";
                            bcol2.Name = "buttonHapusGrid";
                            bcol2.UseColumnTextForButtonValue = true;
                            dataGridViewTabungan.Columns.Add(bcol2);
                        }
                    }
                }
            }
            else
            {
                dataGridViewTabungan.DataSource = null;
            }
        }

        private void FormatDataGridTabungan()
        {
            dataGridViewTabungan.Rows.Clear();
            dataGridViewTabungan.Columns.Clear();
            dataGridViewTabungan.Columns.Add("NoRekening", "No. Rekening");
            dataGridViewTabungan.Columns.Add("Saldo", "Saldo");
            dataGridViewTabungan.Columns.Add("TanggalBuat", "Tanggal Pembuatan");

            dataGridViewTabungan.Columns["NoRekening"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewTabungan.Columns["Saldo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewTabungan.Columns["TanggalBuat"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void CekSudahGantiPIN(Tabungan t, Form form)
        {
            if (t.Status == "Aktif")
            {
                if (Pengguna.CekPIN(pengguna) == true)
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
                        formMasukkanPIN.buttonCekTopUp.Visible = false;
                        formMasukkanPIN.buttonCekTransaksi.Visible = false;

                        if (formMasukkanPIN.ShowDialog() == DialogResult.OK)
                        {
                            form.ShowDialog();
                        }
                    }
                }
            }
            else
            {
                form.ShowDialog();
            }
        }

        private void dataGridViewTabungan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (pengguna != null)
            {
                if (e.ColumnIndex == dataGridViewTabungan.Columns["buttonDetailGrid"].Index && e.RowIndex >= 0)
                {
                    tabungan = Tabungan.AmbilDataTabungan(dataGridViewTabungan.CurrentRow.Cells["NoRekening"].Value.ToString());
                    FormTabunganPengguna formTabunganPengguna = new FormTabunganPengguna();
                    formTabunganPengguna.Owner = this;
                    formTabunganPengguna.labelRekening.Text = tabungan.Rekening;
                    formTabunganPengguna.labelSaldo.Text = "Rp. " + tabungan.Saldo.ToString();
                    formTabunganPengguna.labelKeterangan.Text = tabungan.Keterangan;
                    formTabunganPengguna.labelTanggal.Text = tabungan.Tgl_buat.ToShortDateString();
                    formTabunganPengguna.labelStatus.Text = tabungan.Status;
                    formUtama.DisplayStatusPicture(tabungan.Status, formTabunganPengguna.panel1);
                    CekSudahGantiPIN(tabungan, formTabunganPengguna);
                }
            }
            else if (employee != null)
            {
                if (e.ColumnIndex == dataGridViewTabungan.Columns["buttonHapusGrid"].Index && e.RowIndex >= 0)
                {
                    string nik = dataGridViewTabungan.CurrentRow.Cells["pengguna"].Value.ToString();
                    string id_pengguna = Pengguna.AmbilNamaLengkap(nik);
                    string no_rekening = dataGridViewTabungan.CurrentRow.Cells["rekening"].Value.ToString();
                    double saldo = double.Parse(dataGridViewTabungan.CurrentRow.Cells["saldo"].Value.ToString());
                    string status = dataGridViewTabungan.CurrentRow.Cells["status"].Value.ToString();
                    string keterangan = dataGridViewTabungan.CurrentRow.Cells["keterangan"].Value.ToString();
                    DateTime tgl_buat = DateTime.Parse(dataGridViewTabungan.CurrentRow.Cells["tgl_buat"].Value.ToString());
                    DateTime tgl_perubahan = DateTime.Parse(dataGridViewTabungan.CurrentRow.Cells["tgl_perubahan"].Value.ToString());
                    string id = dataGridViewTabungan.CurrentRow.Cells["verifikator"].Value.ToString();
                    string verifikator = Employee.AmbilNamaLengkap(id);

                    DialogResult hasil = MessageBox.Show("Data yang akan dihapus adalah " +
                                                         "\nNo Rekening : " + no_rekening +
                                                         "\nNama Pengguna : " + id_pengguna +
                                                         "\nSaldo : " + saldo +
                                                         "\nStatus : " + status +
                                                         "\nKeterangan : " + keterangan +
                                                         "\ntgl_buat : " + tgl_buat +
                                                         "\ntgl_perubahan : " + tgl_perubahan +
                                                         "\nVerifikator : " + verifikator +
                                                         "\n\nApakah anda yakin ingin menghapus data di atas?",
                                                         "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (hasil == DialogResult.Yes)
                    {
                        Tabungan t = new Tabungan(no_rekening);
                        Tabungan.HapusData(t, k);
                        MessageBox.Show("Data Berhasil Dihapus.", "Informasi");
                    }

                    FormDaftarTabungan_Load(buttonKeluar, e);
                }
                else if (e.ColumnIndex == dataGridViewTabungan.Columns["buttonUbahStatusGrid"].Index && e.RowIndex >= 0)
                {
                    if (dataGridViewTabungan.CurrentRow.Cells["Status"].Value.ToString() == "Aktif")
                    {
                        MessageBox.Show("Tabungan sudah berstatus aktif. Anda tidak perlu mengaktifkannya lagi.");
                    }
                    else
                    {
                        DialogResult hasil = MessageBox.Show("Apakah anda ingin mengaktifkan deposito ini?", "Konfirmasi",
                                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (hasil == DialogResult.Yes)
                        {
                            tabungan = Tabungan.AmbilDataTabungan(dataGridViewTabungan.CurrentRow.Cells["Rekening"].Value.ToString());
                            Pengguna pengguna = Tabungan.AmbilDataPengguna(dataGridViewTabungan.CurrentRow.Cells["Rekening"].Value.ToString());
                            string no_rekening = dataGridViewTabungan.CurrentRow.Cells["Rekening"].Value.ToString();
                            double saldo = double.Parse(dataGridViewTabungan.CurrentRow.Cells["Saldo"].Value.ToString());
                            string status = tabungan.Status;
                            string keterangan = dataGridViewTabungan.CurrentRow.Cells["Keterangan"].Value.ToString();
                            DateTime tgl_buat = tabungan.Tgl_buat;
                            Employee verifikator = employee;

                            Tabungan t = new Tabungan(no_rekening, pengguna, saldo, status, keterangan, tgl_buat,
                                DateTime.Now, verifikator);
                            Tabungan.UbahStatusAktif(t, k);
                            MessageBox.Show("Tabungan berhasil diaktifkan.", "Informasi");
                        }
                    }

                    FormDaftarTabungan_Load(buttonKeluar, e);
                }
            }
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahTabungan formTambahTabungan = new FormTambahTabungan();
            formTambahTabungan.Owner = this;
            formTambahTabungan.textBoxNoRekening.Text = Tabungan.GenerateNomorRekening();
            formTambahTabungan.ShowDialog();
        }
    }
}
