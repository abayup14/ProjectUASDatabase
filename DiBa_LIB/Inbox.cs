using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DiBa_LIB
{
    public class Inbox
    {
        #region Data Members
        private Pengguna pengguna;
        private int id;
        private string pesan;
        private DateTime tanggal_kirim;
        private string status;
        private DateTime tanggal_perubahan;
        #endregion

        #region Constructors
        public Inbox(Pengguna pengguna, int id, string pesan, DateTime tanggal_kirim, string status, DateTime tanggal_perubahan)
        {
            Pengguna = pengguna;
            Id = id;
            Pesan = pesan;
            Tanggal_kirim = tanggal_kirim;
            Status = status;
            Tanggal_perubahan = tanggal_perubahan;
        }
        public Inbox(int id)
        {
            Id = id;
        }
        #endregion

        #region Properties
        public Pengguna Pengguna { get => pengguna; set => pengguna = value; }
        public int Id { get => id; set => id = value; }
        public string Pesan { get => pesan; set => pesan = value; }
        public DateTime Tanggal_kirim { get => tanggal_kirim; set => tanggal_kirim = value; }
        public string Status { get => status; set => status = value; }
        public DateTime Tanggal_perubahan { get => tanggal_perubahan; set => tanggal_perubahan = value; }
        #endregion

        #region Methods
        public static List<Inbox> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql = "";
            if (kriteria == "")
            {
                sql = "select i.id_pengguna, i.id_pesan, i.pesan, i.tanggal_kirim, i.status, i.tgl_perubahan " +
                      "from inbox i inner join pengguna p on i.id_pengguna = p.nik";
            }
            else
            { 
                sql = "select i.id_pengguna, i.id_pesan, i.pesan, i.tanggal_kirim, i.status, i.tgl_perubahan " +
                      "from inbox i inner join pengguna p on i.id_pengguna = p.nik " +
                      "where " + kriteria+" LIKE '%"+nilaiKriteria+"%'";
            }
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            List<Inbox> listInbox = new List<Inbox>();
            while (hasil.Read() == true)
            {
                Pengguna p = new Pengguna(hasil.GetValue(0).ToString());
                Inbox i = new Inbox(p, 
                                    int.Parse(hasil.GetString(1)), 
                                    hasil.GetString(2), 
                                    DateTime.Parse(hasil.GetString(3)),
                                    hasil.GetString(4), 
                                    DateTime.Parse(hasil.GetString(5)));
                listInbox.Add(i);
            }
            return listInbox;
        }

        public static void TambahData(Inbox i, Koneksi k)
        {
            string sql = "insert into inbox (id_pengguna, id_pesan, pesan, tanggal_kirim, status, tgl_perubahan) " +
                         "values ('" + i.Pengguna.Nik + "', " + i.Id + ", '" + i.Pesan + "', '" + i.Tanggal_kirim.ToString("yyyy-MM-dd HH:mm:ss") +
                         "', '" + i.Status + "', '" + i.Tanggal_perubahan.ToString("yyyy-MM-dd HH:mm:ss") + "')";

            Koneksi.JalankanPerintahDML(sql, k);
        }

        public static void UbahData(Inbox i, Koneksi k)
        {
            string sql = "update inbox set id_pengguna = '" + i.Pengguna.Nik + "', pesan = '" + i.Pesan + "', tanggal_kirim = '" +
                         i.Tanggal_kirim.ToString("yyyy-MM-dd HH:mm:ss") + "', status = '" + i.Status+ "', tgl_perubahan = '" + 
                         i.Tanggal_perubahan.ToString("yyyy-MM-dd HH:mm:ss") + "' where id_pesan = " + i.Id;
            Koneksi.JalankanPerintahDML(sql, k);
        }

        public static void UbahStatusPesan(Inbox i, Koneksi k)
        {
            string sql = "update inbox set status = 'Terbaca', tgl_perubahan = '" + i.Tanggal_perubahan.ToString("yyyy-MM-dd HH:mm:ss") + "' " +
                         "where id_pengguna = '" + i.Pengguna.Nik + "' and id_pesan = '" + i.Id + "'";
            Koneksi.JalankanPerintahDML(sql, k);
        }

        public static void HapusData(Inbox i, Koneksi k)
        {
            string sql = "DELETE from inbox where id_pesan = " + i.Id;
            Koneksi.JalankanPerintahDML(sql, k);
        }

        public static int GenerateKode()
        {
            string sql = "select max(id_pesan) from inbox";

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            int hasilKode = 0;

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
        #endregion
    }
}
