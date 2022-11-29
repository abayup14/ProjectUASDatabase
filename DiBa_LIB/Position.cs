using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DiBa_LIB
{
    public class Position
    {
        #region DATA MEMBERS
        private int positionID;
        private string nama;
        private string keterangan;
        #endregion

        #region CONSTRUCTORS
        public Position(int positionID)
        {
            PositionID = positionID;
        }

        public Position(int positionID, string nama, string keterangan)
        {
            PositionID = positionID;
            Nama = nama;
            Keterangan = keterangan;
        }
        #endregion

        #region PROPERTIES
        public int PositionID { get => positionID; set => positionID = value; }
        public string Nama { get => nama; set => nama = value; }
        public string Keterangan { get => keterangan; set => keterangan = value; }
        #endregion

        #region METHODS
        public static List<Position> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql = "";

            if (kriteria == "")
            {
                sql = "select * from position";
            }
            else
            {
                sql = "select * from position where " + kriteria + " like '%" + nilaiKriteria + "%'";
            }

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            //buat list untuk menampung data
            List<Position> listPosition = new List<Position>();
            while (hasil.Read() == true) //selama masih ada data atau masih bisa membaca data
            {
                //baca data dari MySqlDataReader dan simpan di objek
                Position p = new Position(int.Parse(hasil.GetValue(0).ToString()), hasil.GetValue(1).ToString(), hasil.GetValue(2).ToString());
                listPosition.Add(p);
            }
            return listPosition;
        }

        public static void TambahData(Position p)
        {
            string sql = "insert into position (id, nama, keterangan) values (" + 
                p.PositionID + ", '" + p.Nama.Replace("'", "\\'") + "', '" + p.Keterangan + "')";

            Koneksi.JalankanPerintahDML(sql);
        }

        public static Position AmbilDataByCode(string kode)
        {
            string sql = "select * from position where id = " + kode + "";

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            if (hasil.Read() == true)
            {
                //masukan hasil pengambilan data ke object kategori
                Position p = new Position(int.Parse(hasil.GetValue(0).ToString()), hasil.GetValue(1).ToString(), hasil.GetValue(2).ToString());
                return p;
            }
            else
            {
                return null;
            }
        }

        public static void UbahData(Position p)
        {
            string sql = "update position set Nama='" + p.Nama.Replace("'", "\\'") + ", Keterangan = '" + p.Keterangan + "' where id='" + p.PositionID + "'";

            Koneksi.JalankanPerintahDML(sql);
        }

        public static void HapusData(Position p)
        {
            string perintah = "delete from position where id='" + p.PositionID + "'";

            Koneksi.JalankanPerintahDML(perintah);
        }
        #endregion
    }
}
