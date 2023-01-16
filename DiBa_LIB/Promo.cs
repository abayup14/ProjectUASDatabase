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
        private int nominal_diskon;
        private DateTime tglAwal;
        private DateTime tglAkhir;
        private string keterangan;

        public Promo()
        {
            IdPromo = 0;
        }
        public Promo(int idPromo, string namaPromo, int nominal_diskon, DateTime tglAwal, DateTime tglAkhir, string keterangan)
        {
            IdPromo = idPromo;
            NamaPromo = namaPromo;
            Nominal_diskon = nominal_diskon;
            TglAwal = tglAwal;
            TglAkhir = tglAkhir;
            Keterangan = keterangan;
        }
        
        public Promo (int id)
        {
            IdPromo = id;
        }

        public int IdPromo { get => idPromo; set => idPromo = value; }
        public string NamaPromo { get => namaPromo; set => namaPromo = value; }
        public DateTime TglAwal { get => tglAwal; set => tglAwal = value; }
        public DateTime TglAkhir { get => tglAkhir; set => tglAkhir = value; }
        public string Keterangan { get => keterangan; set => keterangan = value; }
        public int Nominal_diskon { get => nominal_diskon; set => nominal_diskon = value; }

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
                                          int.Parse(hasil.GetString(2)),
                                          DateTime.Parse(hasil.GetValue(3).ToString()),
                                          DateTime.Parse(hasil.GetValue(4).ToString()),
                                          hasil.GetValue(5).ToString()); ;

                listPromo.Add(p);
            }

            return listPromo;
        }

        public static void TambahData(Promo p, Koneksi k)
        {
            string sql = "insert into promo(id,nama, nominal_diskon,tgl_awal,tgl_akhir,keterangan) " + "values ('" + p.IdPromo + "', '" + p.NamaPromo + "', '"+p.Nominal_diskon+"','" + p.TglAwal.ToString("yyyy-MM-dd HH:mm:ss") + "','" + p.TglAkhir.ToString("yyyy-MM-dd HH:mm:ss") + "','" + p.Keterangan + "')";

            Koneksi.JalankanPerintahDML(sql, k);
        }

        public static void UbahData(Promo p, Koneksi k)
        {
            string sql = "UPDATE promo set nama = '" + p.NamaPromo + "', tgl_akhir = '" + p.TglAkhir.ToString("yyyy-MM-dd HH:mm:ss")+"' where id = '" + p.IdPromo + "'";
            Koneksi.JalankanPerintahDML(sql, k);
        }

        public static void HapusData(Promo p, Koneksi k)
        {
            string sql = "Delete from promo where id = '" + p.IdPromo + "'";
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
        public override string ToString()
        {
            return IdPromo.ToString();
        }
    }
}
