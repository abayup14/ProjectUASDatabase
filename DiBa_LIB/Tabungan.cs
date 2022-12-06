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
                sql = "select t.no_rekening, t.id_pengguna, t.saldo, t.status, t.keterangan, t.tgl_buat, " +
                    "t.tgl_perubahan, t.verifikator from tabungan t inner join pengguna p on t.id_pengguna = p.nik " +
                    "inner join employee e on t.verifikator = e.id";
            }
            else
            {
                sql = "select t.no_rekening, t.id_pengguna, t.saldo, t.status, t.keterangan, t.tgl_buat, " +
                    "t.tgl_perubahan, t.verifikator from tabungan t inner join pengguna p on t.id_pengguna = p.nik " +
                    "inner join employee e on t.verifikator = e.id where '"+kriteria+"' LIKE '%"+nilaiKriteria+"'%";
            }

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            List<Tabungan> listOfTabunugan = new List<Tabungan>();

            while (hasil.Read() == true)
            {
                Employee em = new Employee(int.Parse(hasil.GetString(0)));
                Pengguna p = new Pengguna(hasil.GetString(0));
                Tabungan t = new Tabungan(hasil.GetString(0), p, double.Parse(hasil.GetString(2)), hasil.GetString(3),
                    hasil.GetString(4), DateTime.Parse(hasil.GetString(5)), DateTime.Parse(hasil.GetString(6)), em);
                listOfTabunugan.Add(t);
            }

            return listOfTabunugan;
        }
        public static void UbahData(Tabungan t)
        {
            string sql = "update tabungan set no_rekening = '"+t.Rekening+"', id_pengguna = '"+t.Pengguna.Nik+"', " +
                "saldo = '"+t.Saldo+"', status = '"+t.Status+"', keterangan = '"+t.Keterangan+"', tgl_buat = '"+t.Tgl_buat+"', " +
                "tgl_perubahan = '"+t.Tgl_perubahan+"', verifikator = '"+t.Verifikator.Id+"'";

            Koneksi.JalankanPerintahDML(sql);
        }
        public static void HapusData(Tabungan t)
        {
            string sql = "DELETE from tabungan where id = " + t.Rekening;

            Koneksi.JalankanPerintahDML(sql);
        }
        public static void TambahData(Tabungan t)
        {
            string sql = "insert into tabungan(no_rekening, id_pengguna, saldo, status, keterangan, tgl_buat, tgl_perubahan, " +
                "verifikator) values ('"+t.Rekening+"', '"+t.Pengguna.Nik+"', '"+t.Saldo+"', '"+t.Status+"', " +
                "'"+t.Keterangan+"', '"+t.Tgl_buat+"', '"+t.Tgl_perubahan+"', '"+t.Verifikator.Id+"')";

            Koneksi.JalankanPerintahDML(sql);
        }
    }
}
