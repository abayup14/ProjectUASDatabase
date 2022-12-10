using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DiBa_LIB
{
    public class JenisTransaksi
    {
        #region DATA MEMBERS
        private int id_jenis_transaksi;
        private string kode;
        private string nama;
        #endregion

        #region CONSTRUCTORS
        public JenisTransaksi(int id)
        {
            Id_jenis_transaksi = id;
        }
        public JenisTransaksi(int id_jenis_transaksi, string kode, string nama)
        {
            Id_jenis_transaksi = id_jenis_transaksi;
            Kode = kode;
            Nama = nama;
        }
        #endregion

        #region PROPERTIES
        public int Id_jenis_transaksi { get => id_jenis_transaksi; set => id_jenis_transaksi = value; }
        public string Kode { get => kode; set => kode = value; }
        public string Nama { get => nama; set => nama = value; }
        #endregion

        #region METHODS
        public static List<JenisTransaksi> ReadData(string kriteria, string nilai)
        {
            string sql = "";

            if (kriteria == "")
            {
                sql = "SELECT * FROM jenis_transaksi ";
            }
            else
            {
                sql = "SELECT * FROM jenis_transaksi WHERE " + kriteria + " LIKE '%" + nilai + "%'";
            }

            MySqlDataReader result = Koneksi.JalankanPerintahQuery(sql);

            List<JenisTransaksi> listHasil = new List<JenisTransaksi>();
            while (result.Read() == true)
            {
                JenisTransaksi tmp = new JenisTransaksi(int.Parse(result.GetValue(0).ToString()), result.GetValue(1).ToString(), result.GetValue(2).ToString());

                listHasil.Add(tmp);
            }

            return listHasil;
        }

        public static void TambahData(JenisTransaksi j, Koneksi k)
        {
            string sql = "INSERT INTO jenis_transaksi (Id_jenis_transaksi, Kode, Nama) VALUES (" + j.Id_jenis_transaksi + ", '" + j.Kode + "', '" + j.Nama + "')";
            
            Koneksi.JalankanPerintahDML(sql, k);
        }

        public static void UbahData(JenisTransaksi j, Koneksi k)
        {
            string sql = "UPDATE jenis_transaksi SET nama = '" + j.Nama.Replace("'", "\\'") + "', kode = '" + j.Kode + "' WHERE id_jenis_transaksi = " + j.Id_jenis_transaksi;
            Koneksi.JalankanPerintahDML(sql, k);
        }

        public static void HapusData(JenisTransaksi j, Koneksi k)
        {
            string sql = "DELETE FROM jenis_transaksi WHERE id_jenis_transaksi = " + j.Id_jenis_transaksi;
            Koneksi.JalankanPerintahDML(sql, k);
        }

        public static JenisTransaksi AmbilDataByKode(int id_jenis_transaksi)
        {
            string sql = "SELECT * FROM jenis_transaksi WHERE id_jenis_transaksi = " + id_jenis_transaksi;
            MySqlDataReader result = Koneksi.JalankanPerintahQuery(sql);

            if (result.Read() == true)
            {
                JenisTransaksi jenisTransaksi = new JenisTransaksi(int.Parse(result.GetValue(0).ToString()), result.GetValue(1).ToString(), result.GetValue(2).ToString());
                return jenisTransaksi;
            }
            else
            {
                return null;
            }
        }

        public static int GenerateKode()
        {
            string sql = "SELECT max(id_jenis_transaksi) from jenis_transaksi";

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
        #endregion
    }
}
