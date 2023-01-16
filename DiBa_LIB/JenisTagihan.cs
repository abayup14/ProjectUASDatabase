using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DiBa_LIB
{
    public class JenisTagihan
    {
        private int id;
        private string nama;

        public JenisTagihan()
        {
            Id = 0;
        }
        public JenisTagihan(int id, string nama)
        {
            Id = id;
            Nama = nama;
        }
        public JenisTagihan(int id)
        {
            this.Id = id;
        }
        public JenisTagihan(string nama)
        {
            this.Nama = nama;
        }

        public int Id { get => id; set => id = value; }
        public string Nama { get => nama; set => nama = value; }

        public static List<JenisTagihan> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql = "";

            if (kriteria == "")
            {
                sql = "SELECT * from jenis_tagihan";
            }
            else
            {
                sql = "SELECT * from jenis_tagihan WHERE " + kriteria + " LIKE '%" + nilaiKriteria + "%'";
            }

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            List<JenisTagihan> listJenisTagihan = new List<JenisTagihan>();

            while (hasil.Read() == true)
            {
                JenisTagihan jt = new JenisTagihan(int.Parse(hasil.GetValue(0).ToString()), hasil.GetValue(1).ToString());

                listJenisTagihan.Add(jt);
            }

            return listJenisTagihan;
        }

        public static void TambahData(JenisTagihan jt, Koneksi k)
        {
            string sql = "INSERT into jenis_tagihan(id, nama) VALUES ('" + jt.Id + "', '" + jt.Nama + "')";

            Koneksi.JalankanPerintahDML(sql, k);
        }

        public static void UbahData(JenisTagihan jt, Koneksi k)
        {
            string sql = "UPDATE jenis_tagihan set nama = '" + jt.Nama + "' WHERE id = " + jt.Id;

            Koneksi.JalankanPerintahDML(sql, k);
        }

        public static void HapusData(JenisTagihan jt, Koneksi k)
        {
            string sql = "DELETE from jenis_tagihan where id = " + jt.Id;

            Koneksi.JalankanPerintahDML(sql, k);
        }

        public static int GenerateKode()
        {
            string sql = "SELECT max(id) from jenis_tagihan";

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
        public override string ToString()
        {
            return Id.ToString();
        }
    }
}
