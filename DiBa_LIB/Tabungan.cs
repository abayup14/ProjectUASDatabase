using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiBa_LIB;
using MySql.Data.MySqlClient;

namespace DiBa_LIB
{
    public class Tabungan
    {
        private string rekening;
        private Pengguna pengguna;
        private double saldo;
        private string status;
        private string keterangan;
        private DateTime tgl_buat;
        private DateTime tgl_perubahan;
        private Employee verifikator;

        public Tabungan(string rekening, Pengguna pengguna, double saldo, string status, string keterangan, DateTime tgl_buat, DateTime tgl_perubahan, Employee verifikator)
        {
            this.Rekening = rekening;
            this.Pengguna = pengguna;
            this.Saldo = saldo;
            this.Status = status;
            this.Keterangan = keterangan;
            this.Tgl_buat = tgl_buat;
            this.Tgl_perubahan = tgl_perubahan;
            this.Verifikator = verifikator;
        }
        public Tabungan(string rekening)
        {
            this.Rekening = rekening;
        }

        public string Rekening { get => rekening; set => rekening = value; }
        public Pengguna Pengguna { get => pengguna; set => pengguna = value; }
        public double Saldo { get => saldo; set => saldo = value; }
        public string Status { get => status; set => status = value; }
        public string Keterangan { get => keterangan; set => keterangan = value; }
        public DateTime Tgl_buat { get => tgl_buat; set => tgl_buat = value; }
        public DateTime Tgl_perubahan { get => tgl_perubahan; set => tgl_perubahan = value; }
        public Employee Verifikator { get => verifikator; set => verifikator = value; }

        public static List<Tabungan> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql = "";

            if (kriteria == "")
            {
                sql = "SELECT t.no_rekening, t.id_pengguna, t.saldo, t.status, t.keterangan, t.tgl_buat, t.tgl_perubahan, t.verifikator " +
                      "FROM tabungan t INNER JOIN pengguna p on t.id_pengguna = p.nik " +
                      "INNER JOIN employee e on t.verifikator = e.id";
            }
            else
            {
                sql = "SELECT t.no_rekening, t.id_pengguna, t.saldo, t.status, t.keterangan, t.tgl_buat, t.tgl_perubahan, t.verifikator " +
                      "FROM tabungan t INNER JOIN pengguna p on t.id_pengguna = p.nik " +
                      "INNER JOIN employee e on t.verifikator = e.id " +
                      "WHERE " + kriteria + " LIKE '%" + nilaiKriteria + "%'";
            }

            MySqlDataReader hasil =  Koneksi.JalankanPerintahQuery(sql);

            List<Tabungan> listTabungan = new List<Tabungan>();

            while (hasil.Read() == true)
            {
                Pengguna p = new Pengguna(hasil.GetValue(1).ToString());

                Employee e = new Employee(int.Parse(hasil.GetValue(7).ToString()));

                Tabungan t = new Tabungan(hasil.GetValue(0).ToString(),
                                          p,
                                          double.Parse(hasil.GetValue(2).ToString()),
                                          hasil.GetValue(3).ToString(),
                                          hasil.GetValue(4).ToString(),
                                          DateTime.Parse(hasil.GetString(5)),
                                          DateTime.Parse(hasil.GetString(6)),
                                          e);

                listTabungan.Add(t);
            }

            return listTabungan;
        }
        public static void UbahData(Tabungan t, Employee e, Koneksi k)
        {
            string sql = "UPDATE tabungan set status = 'Aktif', verifikator = " + e.Id + ", tgl_perubahan = '" + t.tgl_perubahan + "' " +
                         "WHERE no_rekening = '" + t.Rekening + "'";

            Koneksi.JalankanPerintahDML(sql, k);
        }
        public static void HapusData(Tabungan t, Koneksi k)
        {
            string sql = "DELETE from tabungan where id = " + t.Rekening;

            Koneksi.JalankanPerintahDML(sql, k);
        }
        public static void TambahData(Tabungan t, Koneksi k)
        {
            string sql = "INSERT into tabungan (no_rekening, id_pengguna, saldo, status, keterangan, tgl_buat, tgl_perubahan, verifikator) " +
                         "VALUES ('" + t.Rekening + "', '" + t.Pengguna.Nik + "', " + t.Saldo + ", '" + t.Status + "', '" + t.Keterangan +
                         "', '" + t.Tgl_buat.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + t.Tgl_perubahan.ToString("yyyy-MM-dd HH:mm:ss") +
                         "', " + t.Verifikator.Id + ")";

            Koneksi.JalankanPerintahDML(sql, k);
        }
        public static string GenerateNomorRekening()
        {
            string sql = "SELECT max(no_rekening) FROM tabungan";

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            string hasilGenerate = "";

            if (hasil.Read() == true)
            {
                if (hasil.GetValue(0).ToString() != "")
                {
                    int hasilKode = int.Parse(hasil.GetValue(0).ToString()) + 1;
                    hasilGenerate = hasilKode.ToString();
                }
                else
                {
                    hasilGenerate = "0000000001";
                }
            }

            return hasilGenerate;
        }
    }
}
