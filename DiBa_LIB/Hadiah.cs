using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DiBa_LIB
{
    
    public class Hadiah
    {
        private int id;
        private string nama_hadiah;
        private string harga_hadiah;

        public Hadiah(int id, string nama_hadiah, string harga_hadiah)
        {
            Id = id;
            Nama_hadiah = nama_hadiah;
            Harga_hadiah = harga_hadiah;
        }

        public int Id { get => id; set => id = value; }
        public string Nama_hadiah { get => nama_hadiah; set => nama_hadiah = value; }
        public string Harga_hadiah { get => harga_hadiah; set => harga_hadiah = value; }

        public static List<Hadiah> BacaData(string kriteria, string nilaiKriterian)
        {
            string sql = "";
            if (kriteria == "")
            {
                sql = "select * from hadiah h inner join pengguna p on h.id = p.nik";
            }
            else
            {
                sql = "select * from hadiah h inner join pengguna p on h.id = p.nik " +
                    "where "+kriteria+" like '%"+nilaiKriterian+"%'";
            }
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            List<Hadiah> listHadiah = new List<Hadiah>();
            while (hasil.Read() == true)
            {
                Hadiah h = new Hadiah(int.Parse(hasil.GetString(0)), hasil.GetString(1), hasil.GetString(2));
                listHadiah.Add(h);
            }
            return listHadiah;
        }
        public static void TambahData(Hadiah h, Koneksi k)
        {
            string sql = "insert into hadiah(id, nama_hadiah, harga_hadiah) values ('"+h.Id+"', '"+h.Nama_hadiah
                +"', '"+h.Harga_hadiah+"')";
            Koneksi.JalankanPerintahDML(sql, k);
        }
        public static void UbahData(Hadiah h, Koneksi k)
        {
            string sql = "update hadiah set nama_hadiah = '"+h.Nama_hadiah+"', harga_hadiah = '"+h.Harga_hadiah
                +"' where id = '"+h.Id+"'";
            Koneksi.JalankanPerintahDML(sql, k);
        }
        public static void HapusData(Hadiah h, Koneksi k)
        {
            string sql = "delete from hadiah where id = "+h.Id+"";
        }
        public static int GenerateKode()
        {
            string sql = "SELECT max(id) from employee";

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
