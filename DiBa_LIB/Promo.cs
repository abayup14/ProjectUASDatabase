using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiBa_LIB
{
    public class Promo
    {
        private int idPromo;
        private string namaPromo;
        private DateTime tglAwal;
        private DateTime tglAkhir;
        private string keterangan;

        public Promo()
        {
            IdPromo = 0;
        }
        public Promo(int idPromo, string namaPromo, DateTime tglAwal, DateTime tglAkhir, string keterangan)
        {
            this.IdPromo = idPromo;
            this.NamaPromo = namaPromo;
            this.TglAwal = tglAwal;
            this.TglAkhir = tglAkhir;
            this.Keterangan = keterangan;
        }
        
        public Promo (string namaPromo)
        {
            NamaPromo = namaPromo;
        }

        public int IdPromo { get => idPromo; set => idPromo = value; }
        public string NamaPromo { get => namaPromo; set => namaPromo = value; }
        public DateTime TglAwal { get => tglAwal; set => tglAwal = value; }
        public DateTime TglAkhir { get => tglAkhir; set => tglAkhir = value; }
        public string Keterangan { get => keterangan; set => keterangan = value; }

        public static List<Promo> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql = "";

            if (kriteria == "")
            {
                sql = "SELECT * from promo";
            }
            else
            {
                sql = "SELECT * from promo where " + kriteria + " LIKE '%" + nilaiKriteria + "%'";
            }

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            List<Promo> listPromo = new List<Promo>();

            while (hasil.Read() == true)
            {
                Promo p = new Promo(int.Parse(hasil.GetValue(0).ToString()),
                                          hasil.GetValue(1).ToString(),
                                          DateTime.Parse(hasil.GetValue(2).ToString()),
                                          DateTime.Parse(hasil.GetValue(3).ToString()),
                                          hasil.GetValue(4).ToString());

                listPromo.Add(p);
            }

            return listPromo;
        }

        public static void TambahData(Promo p, Koneksi k)
        {
            string sql = "insert into promo(nama,tgl_awal,tgl_akhir,keterangan) " + "values ('" + p.NamaPromo + "," + p.TglAwal + "," + p.TglAkhir + "," + p.Keterangan + "')";

            Koneksi.JalankanPerintahDML(sql, k);
        }

        public static void UbahData(Promo p, Koneksi k)
        {
            string sql = "UPDATE promo set nama = '" + p.NamaPromo + ", tgl_akhir = '" + p.TglAkhir;
            Koneksi.JalankanPerintahDML(sql, k);
        }

        public static void HapusData(Promo p, Koneksi k)
        {
            string sql = "Delete from promo where nama = '" + p.NamaPromo + "'";
            Koneksi.JalankanPerintahDML(sql, k);
        }

        public static int GenerateKode()
        {
            string sql = "SELECT max(id) from promo";

            int hasilKode = 0;

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            if (hasil.Read() == true)
            {
                if (hasil.GetValue(0).ToString() != "")
                {
                    hasilKode = int.Parse(hasil.GetValue(0).ToString()) + 1;
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
