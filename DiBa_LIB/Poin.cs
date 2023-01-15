using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DiBa_LIB
{
    public class Poin
    {
        private Pengguna pengguna;
        private int jumlah;

        public Poin(Pengguna pengguna, int jumlah)
        {
            Pengguna = pengguna;
            Jumlah = jumlah;
        }

        public Pengguna Pengguna { get => pengguna; set => pengguna = value; }
        public int Jumlah { get => jumlah; set => jumlah = value; }

        public static List<Poin> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql = "";
            if (kriteria == "")
            {
                sql = "select * from poin p inner join pengguna pe on p.id_pengguna = pe.nik";
            }
            else
            {
                sql = "select * from poin p inner join pengguna pe on p.id_pengguna = pe.nik " +
                    "where "+kriteria+" like '%"+nilaiKriteria+"%'";
            }
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            List<Poin> listPoin = new List<Poin>();
            while (hasil.Read() == true)
            {
                Pengguna p = new Pengguna(hasil.GetString(0));
                Poin po = new Poin(p, int.Parse(hasil.GetString(1)));
                listPoin.Add(po);
            }
            return listPoin;
        }
        public static void TambahData(Poin p, Koneksi k)
        {
            string sql = "insert into poin(id_pengguna, jumlah_poin) values ('"+p.Pengguna+"', '"+p.Jumlah+"')";
            Koneksi.JalankanPerintahDML(sql, k);
        }
        //public static void UpdatePoin(Poin p, Koneksi k)
        //{
        //    string sql = "UPDATE poin set jumlah_poin = jumlah_poin + " + p
        //    Koneksi.JalankanPerintahDML(sql, k);
        //}
        public static void HapusData(Poin p, Koneksi k)
        {
            string sql = "delete from poin where = id_pengguna = '"+p.Pengguna+"'";
            Koneksi.JalankanPerintahDML(sql, k);
        }
        public static int CekPoin(Pengguna p)
        {
            string sql = "select jumlah_poin from poin p inner join " +
                "pengguna pe on p.id_pengguna = pe.nik where p.id_pengguna = '" + p.Nik+ "'";
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            int jumlah = 0;
            if (hasil.Read() == true)
            {
                jumlah = int.Parse(hasil.GetString(0));
            }
            return jumlah;
        }
    }
}
