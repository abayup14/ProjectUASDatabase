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
                sql = "SELECT * " +
                      "FROM tabungan t INNER JOIN pengguna p on t.id_pengguna = p.nik " +
                      "INNER JOIN employee e on t.verifikator = e.id";
            }
            else
            {
                sql = "SELECT * " +
                      "FROM tabungan t INNER JOIN pengguna p on t.id_pengguna = p.nik " +
                      "INNER JOIN employee e on t.verifikator = e.id " +
                      "WHERE " + kriteria + " LIKE '%" + nilaiKriteria + "%'";
            }

            MySqlDataReader hasil =  Koneksi.JalankanPerintahQuery(sql);

            List<Tabungan> listTabungan = new List<Tabungan>();

            while (hasil.Read() == true)
            {
                Pengguna p = new Pengguna(hasil.GetValue(8).ToString(),
                                          hasil.GetString(9),
                                          hasil.GetString(10),
                                          hasil.GetString(11),
                                          hasil.GetString(12),
                                          hasil.GetString(13),
                                          hasil.GetString(14),
                                          hasil.GetString(15),
                                          DateTime.Parse(hasil.GetString(16)),
                                          DateTime.Parse(hasil.GetString(17)));

                Employee e = new Employee(int.Parse(hasil.GetValue(7).ToString()));

                Tabungan t = new Tabungan(hasil.GetValue(0).ToString(),
                                          p,
                                          double.Parse(hasil.GetValue(2).ToString()),
                                          hasil.GetValue(3).ToString(),
                                          hasil.GetValue(4).ToString(),
                                          DateTime.Parse(hasil.GetValue(5).ToString()),
                                          DateTime.Parse(hasil.GetValue(6).ToString()),
                                          e);

                listTabungan.Add(t);
            }

            return listTabungan;
        }
        public static void UbahStatusAktif(Tabungan t, Employee e, Koneksi k)
        {
            string sql = "UPDATE tabungan set status = 'Aktif', verifikator = " + e.Id + ", tgl_perubahan = '" 
                + t.Tgl_perubahan.ToString("yyyy-MM-dd HH:mm:ss") + "' " +
                         "WHERE no_rekening = '" + t.Rekening + "'";

            Koneksi.JalankanPerintahDML(sql, k);
        }
        public static void UbahStatusSuspend(Tabungan t, Koneksi k)
        {
            string sql = "UPDATE tabungan set status = 'Suspend', tgl_perubahan = '" + t.Tgl_perubahan.ToString("yyyy-MM-dd HH:mm:ss") + "' " +
                         "WHERE no_rekening = '" + t.Rekening + "'";

            Koneksi.JalankanPerintahDML(sql, k);
        }
        public static void UbahKeterangan(Tabungan t, Koneksi k)
        {
            string sql = "UPDATE tabungan set keterangan = '" + t.Keterangan + "', tgl_perubahan = '" + t.Tgl_perubahan.ToString("yyyy-MM-dd HH:mm:ss") +
                         "' WHERE no_rekening = '" + t.Rekening + "'";
            Koneksi.JalankanPerintahDML(sql, k);
        }
        public static void HapusData(Tabungan t, Koneksi k)
        {
            string sql = "DELETE from tabungan where id = " + t.Rekening;

            Koneksi.JalankanPerintahDML(sql, k);
        }
        public static void TambahData(Tabungan t, Koneksi k)
        {
            string sql = "INSERT into tabungan (no_rekening, id_pengguna, saldo, status, keterangan, tgl_buat, tgl_perubahan) " +
                         "VALUES ('" + t.Rekening + "', '" + t.Pengguna.Nik + "', " + t.Saldo + ", '" + t.Status + "', '" + t.Keterangan +
                         "', '" + t.Tgl_buat.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + t.Tgl_perubahan.ToString("yyyy-MM-dd HH:mm:ss") + "')";

            Koneksi.JalankanPerintahDML(sql, k);
        }

        public static void UbahSaldo(Tabungan t, double saldo, Koneksi k)
        {
            string sql = "UPDATE tabungan set saldo = saldo + " + saldo + " WHERE no_rekening = " + t.Rekening;

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
                    string hasilKode = (int.Parse(hasil.GetValue(0).ToString()) + 1).ToString();

                    if (hasilKode.Length == 10)
                    {
                        hasilGenerate = hasilKode;
                    }
                    else if (hasilKode.Length < 10)
                    {
                        hasilGenerate = hasilKode.PadLeft(11 - hasilKode.Length, '0');
                    }
                }
                else
                {
                    hasilGenerate = 1.ToString().PadLeft(10, '0');
                }
            }

            return hasilGenerate;
        }
        public static string AmbilDataNoRekening(string nik)
        {
            string sql = "SELECT t.no_rekening FROM tabungan t INNER JOIN pengguna p on t.id_pengguna = p.nik " +
                         "where p.nik = '" + nik + "'";

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            string hasilKode = "";

            if (hasil.Read() == true)
            {
                hasilKode = hasil.GetValue(0).ToString();
            }

            return hasilKode;
        }
        public static Tabungan AmbilDataTabungan(Pengguna p)
        {
            string sql = "SELECT * from tabungan t inner join pengguna p on t.id_pengguna = p.nik where p.nik = '" + p.Nik + "'";

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            if (hasil.Read() == true)
            {
                Pengguna pe = new Pengguna(hasil.GetValue(1).ToString());
                Employee em = new Employee(int.Parse(hasil.GetValue(7).ToString()));
                Tabungan t = new Tabungan(hasil.GetValue(0).ToString(), 
                                          pe, 
                                          double.Parse(hasil.GetValue(2).ToString()), 
                                          hasil.GetValue(3).ToString(), 
                                          hasil.GetValue(4).ToString(), 
                                          DateTime.Parse(hasil.GetValue(5).ToString()), 
                                          DateTime.Parse(hasil.GetValue(6).ToString()),
                                          em);

                return t;
            }
            else
            {
                return null;
            }
        }
        public static Tabungan AmbilDataTabungan(string no_rekening)
        {
            string sql = "SELECT * from tabungan t inner join pengguna p on t.id_pengguna = p.nik where t.no_rekening = '" + no_rekening + "'";

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            if (hasil.Read() == true)
            {
                Pengguna pe = new Pengguna(hasil.GetValue(1).ToString());
                Employee em = new Employee(int.Parse(hasil.GetValue(7).ToString()));
                Tabungan t = new Tabungan(hasil.GetValue(0).ToString(),
                                          pe,
                                          double.Parse(hasil.GetValue(2).ToString()),
                                          hasil.GetValue(3).ToString(),
                                          hasil.GetValue(4).ToString(),
                                          DateTime.Parse(hasil.GetValue(5).ToString()),
                                          DateTime.Parse(hasil.GetValue(6).ToString()),
                                          em);

                return t;
            }
            else
            {
                return null;
            }
        }
        public static Pengguna AmbilDataPengguna(string no_rekening)
        {
            string sql = "SELECT * FROM tabungan t inner join pengguna p on p.nik = t.id_pengguna " +
                         "where t.no_rekening = '" + no_rekening + "'";

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            if (hasil.Read() == true)
            {
                Pengguna p = new Pengguna(hasil.GetString(8),
                                          hasil.GetString(9),
                                          hasil.GetString(10),
                                          hasil.GetString(11),
                                          hasil.GetString(12),
                                          hasil.GetString(13),
                                          hasil.GetString(14),
                                          hasil.GetString(15),
                                          DateTime.Parse(hasil.GetString(16)),
                                          DateTime.Parse(hasil.GetString(17)));

                return p;
            }
            else
            {
                return null;
            }
        }
        public override string ToString()
        {
            return Rekening;
        }
    }
}
