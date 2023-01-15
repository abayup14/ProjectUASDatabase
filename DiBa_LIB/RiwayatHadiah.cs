using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DiBa_LIB
{
    public class RiwayatHadiah
    {
        private int id;
        private Pengguna pengguna;
        private Hadiah hadiah;
        private DateTime tanggal_beli;

        public RiwayatHadiah(int id, Pengguna pengguna, Hadiah hadiah, DateTime tanggal_beli)
        {
            Id = id;
            Pengguna = pengguna;
            Hadiah = hadiah;
            Tanggal_beli = tanggal_beli;
        }

        public Pengguna Pengguna { get => pengguna; set => pengguna = value; }
        public Hadiah Hadiah { get => hadiah; set => hadiah = value; }
        public int Id { get => id; set => id = value; }
        public DateTime Tanggal_beli { get => tanggal_beli; set => tanggal_beli = value; }

        public static void TambahData(RiwayatHadiah phh, Koneksi k)
        {
            string sql = "insert into pengguna_has_hadiah(id, pengguna_nik, hadiah_id, tanggal_beli) values ('" + phh.Id + "', '" +
                phh.Pengguna.Nik + "', '" + phh.Hadiah.Id + "', '" + phh.Tanggal_beli.ToString("yyyy-MM-dd HH:mm:ss") + "')";
            Koneksi.JalankanPerintahDML(sql, k);
        }
        public static List<RiwayatHadiah> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql = "";
            if (kriteria == "")
            {
                sql = "select * from pengguna p inner join pengguna_has_hadiah ph on " +
                      "p.nik = ph.pengguna_nik inner join hadiah h on ph.hadiah_id = h.id";
            }
            else
            {
                sql = "select * " +
                      "from pengguna p " +
                      "inner join pengguna_has_hadiah ph on p.nik = ph.pengguna_nik " +
                      "inner join hadiah h on ph.hadiah_id = h.id " +
                      "where " + kriteria + " like '%" + nilaiKriteria + "%'";
            }
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            List<RiwayatHadiah> listofPenggunaHasHadiah = new List<RiwayatHadiah>();
            while (hasil.Read() == true)
            {
                Pengguna p = new Pengguna(hasil.GetString(0),
                                          hasil.GetString(1),
                                          hasil.GetString(2),
                                          hasil.GetString(3),
                                          hasil.GetString(4),
                                          hasil.GetString(5),
                                          hasil.GetString(6),
                                          hasil.GetString(7),
                                          DateTime.Parse(hasil.GetString(8)),
                                          DateTime.Parse(hasil.GetString(9)));
                Hadiah h = new Hadiah(int.Parse(hasil.GetString(14)), hasil.GetString(15), hasil.GetString(16));
                RiwayatHadiah ph = new RiwayatHadiah(int.Parse(hasil.GetString(10)), p, h, DateTime.Parse(hasil.GetString(13)));
                listofPenggunaHasHadiah.Add(ph);
            }
            return listofPenggunaHasHadiah;
        }
        public static void HapusData(RiwayatHadiah ph, Koneksi k)
        {
            string sql = "delete from pengguna_has_hadiah where id = '" + ph.Id +"'";
            Koneksi.JalankanPerintahDML(sql, k);
        }
        public static int GenerateKode()
        {
            string sql = "SELECT max(id) from pengguna_has_hadiah";

            int hasilKode = 0;

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            if (hasil.Read() == true)
            {
                if (hasil.GetValue(0).ToString() != "")
                {
                    int kodeBaru = int.Parse(hasil.GetValue(0).ToString()) + 1;

                    hasilKode = kodeBaru;
                }
                else
                {
                    hasilKode = 1;
                }
            }

            return hasilKode;
        }
    }
}
