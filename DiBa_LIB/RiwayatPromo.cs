using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DiBa_LIB
{
    public class RiwayatPromo
    {
        private int id;
        private Promo id_promo;
        private Pengguna id_pengguna;
        private DateTime tanggal_pakai;

        public RiwayatPromo(Promo id_promo, Pengguna id_pengguna)
        {
            Id_promo = id_promo;
            Id_pengguna = id_pengguna;
        }

        public RiwayatPromo(int id, Promo id_promo, Pengguna id_pengguna, DateTime tanggal_pakai)
        {
           Id = id;
            Id_promo = id_promo;
            Id_pengguna = id_pengguna;
            Tanggal_pakai = tanggal_pakai;
        }

        public int Id { get => id; set => id = value; }
        public Promo Id_promo { get => id_promo; set => id_promo = value; }
        public Pengguna Id_pengguna { get => id_pengguna; set => id_pengguna = value; }
        public DateTime Tanggal_pakai { get => tanggal_pakai; set => tanggal_pakai = value; }

        public static List<RiwayatPromo> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql = "";

            if(kriteria == "")
            {
                sql = "SELECT * FROM promo_has_pengguna";
            }
            else
            {
                sql = "SELECT * FROM promo_has_pengguna WHERE " + kriteria + "' LIKE %'" + nilaiKriteria + "%'";
            }

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            List<RiwayatPromo> listOfRiwayat = new List<RiwayatPromo>();

            while (hasil.Read() == true)
            {
                Promo p = new Promo(int.Parse(hasil.GetString(0)));
                Pengguna pe = new Pengguna(hasil.GetString(1));
                RiwayatPromo rp = new RiwayatPromo(int.Parse(hasil.GetString(0)), p, pe, DateTime.Parse(hasil.GetString(4)));
                listOfRiwayat.Add(rp);
            }

            return listOfRiwayat;
        }
        public static void TambahData(RiwayatPromo rp, Koneksi k)
        {
            string sql = "INSERT into promo_has_pengguna(id, promo_id, pengguna_nik, tanggal_pakai) " +
                         "VALUES('" + rp.Id + "', '" + rp.Id_promo + "', '" + rp.Id_pengguna + "', '" + 
                         rp.Tanggal_pakai.ToString("yyyy-MM-dd HH:mm:ss") + "')";

            Koneksi.JalankanPerintahDML(sql, k);
        }
        public static int GenerateKode()
        {
            string sql = "SELECT max(id) from promo_has_pengguna";

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
