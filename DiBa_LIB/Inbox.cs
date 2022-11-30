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
        private Pengguna pengguna;
        private int id;
        private string pesan;
        private DateTime tanggal_kirim;
        private string status;
        private DateTime tanggal_perubahan;

        public Inbox(Pengguna pengguna, int id, string pesan, DateTime tanggal_kirim, string status, DateTime tanggal_perubahan)
        {
            this.Pengguna = pengguna;
            this.Id = id;
            this.Pesan = pesan;
            this.Tanggal_kirim = tanggal_kirim;
            this.Status = status;
            this.Tanggal_perubahan = tanggal_perubahan;
        }

        public Pengguna Pengguna { get => pengguna; set => pengguna = value; }
        public int Id { get => id; set => id = value; }
        public string Pesan { get => pesan; set => pesan = value; }
        public DateTime Tanggal_kirim { get => tanggal_kirim; set => tanggal_kirim = value; }
        public string Status { get => status; set => status = value; }
        public DateTime Tanggal_perubahan { get => tanggal_perubahan; set => tanggal_perubahan = value; }

        public static List<Inbox> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql = "";
            if (kriteria == "")
            {
                sql = "select i.id_pengguna, i.id_pesan, i.pesan, i,tanggal_kirim, i.status, i.tgl_perubahan from " +
                    "pengguna p inner join inbox i on p.nik = i.id_pengguna";
            }
            else
            { 
                sql = "select i.id_pengguna, i.id_pesan, i.pesan, i,tanggal_kirim, i.status, i.tgl_perubahan from " +
                    "pengguna p inner join inbox i on p.nik = i.id_pengguna where "+kriteria+" LIKE '%"+nilaiKriteria+"%'";
            }
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            List<Inbox> listInbox = new List<Inbox>();
            while (hasil.Read() == true)
            {
                Pengguna p = new Pengguna(hasil.GetValue(0).ToString(), hasil.GetValue(1).ToString(), hasil.GetValue(2).ToString(),
                                          hasil.GetValue(3).ToString(), hasil.GetValue(4).ToString(), hasil.GetValue(5).ToString(),
                                          hasil.GetValue(6).ToString(), hasil.GetValue(7).ToString(), DateTime.Parse(hasil.GetValue(8).ToString()),
                                          DateTime.Parse(hasil.GetValue(9).ToString()));
                Inbox i = new Inbox(p, int.Parse(hasil.GetString(10)), hasil.GetString(11), DateTime.Parse(hasil.GetString(12)),
                    hasil.GetString(13), DateTime.Parse(hasil.GetString(14)));
                listInbox.Add(i);
            }
            return listInbox;
        }
    }
}
