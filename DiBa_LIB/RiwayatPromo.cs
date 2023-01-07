using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DiBa_LIB
{
    internal class RiwayatPromo
    {
        private Promo id_promo;
        private Pengguna id_pengguna;

        public RiwayatPromo(Promo id_promo, Pengguna id_pengguna)
        {
            id_promo = Id_promo;
            id_pengguna = Id_pengguna;
        }

        public Promo Id_promo { get => id_promo; set => id_promo = value; }
        public Pengguna Id_pengguna { get => id_pengguna; set => id_pengguna = value; }

        public static List<RiwayatPromo> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql = "";

            if(kriteria == "")
            {
                sql = "SELECT * FROM riwayat_promo";
            }
            else
            {
                sql = "SELECT * FROM riwayat_promo WHERE " + kriteria + "' LIKE %'" + nilaiKriteria + "%'";
            }

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            List<RiwayatPromo> listOfRiwayat = new List<RiwayatPromo>();

            while (hasil.Read() == true)
            {
                Promo p = new Promo(hasil.GetString(0));
                Pengguna pe = new Pengguna(hasil.GetString(1));
                RiwayatPromo rp = new RiwayatPromo(p, pe);
                listOfRiwayat.Add(rp);
            }

            return listOfRiwayat;
        }
    }
}
