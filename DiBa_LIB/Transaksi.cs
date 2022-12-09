using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DiBa_LIB
{
    public class Transaksi
    {
        private Tabungan rekening_sumber;
        private string transaksiId;
        private DateTime tgl_transaksi;
        private JenisTransaksi id_jenis_transaksi;
        private Tabungan rekening_tujuan;
        private double nominal;
        private string keterangan;

        public Transaksi(Tabungan rekening_sumber, string transaksiId, DateTime tgl_transaksi, JenisTransaksi id_jenis_transaksi, Tabungan rekening_tujuan, double nominal, string keterangan)
        {
            Rekening_sumber = rekening_sumber;
            TransaksiId = transaksiId;
            Tgl_transaksi = tgl_transaksi;
            Id_jenis_transaksi = id_jenis_transaksi;
            Rekening_tujuan = rekening_tujuan;
            Nominal = nominal;
            Keterangan = keterangan;
        }

        public Tabungan Rekening_sumber { get => rekening_sumber; set => rekening_sumber = value; }
        public string TransaksiId { get => transaksiId; set => transaksiId = value; }
        public DateTime Tgl_transaksi { get => tgl_transaksi; set => tgl_transaksi = value; }
        public JenisTransaksi Id_jenis_transaksi { get => id_jenis_transaksi; set => id_jenis_transaksi = value; }
        public Tabungan Rekening_tujuan { get => rekening_tujuan; set => rekening_tujuan = value; }
        public double Nominal { get => nominal; set => nominal = value; }
        public string Keterangan { get => keterangan; set => keterangan = value; }


        public static List<Transaksi> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql = "";
            if (kriteria == "")
            {
                sql = "select t.rekening_sumber, t.id_transaksi, t.tgl_transaksi, t.id_jenis_transaksi, t.rekening_tujuan, t.nominal, t.keterangan " +
                      "from transaksi t inner join tabungan ta on t.rekening_sumber = ta.no_rekening " +
                      "inner join tabungan ta on t.rekening_tujuan = ta.no_rekening " +
                      "left join jenis_transaksi jt on t.id_jenis_transaksi = jt.id_jenis_transaksi";

            }
            else
            {
                sql = "select t.rekening_sumber, t.id_transaksi, t.tgl_transaksi, t.id_jenis_transaksi, t.rekening_tujuan, t.nominal, t.keterangan " +
                      "from transaksi t inner join tabungan ta on t.rekening_sumber = ta.no_rekening " +
                      "inner join tabungan ta on t.rekening_tujuan = ta.no_rekening " +
                      "left join jenis_transaksi jt on t.id_jenis_transaksi = jt.id_jenis_transaksi " +
                      "where " +kriteria + " like '%" + nilaiKriteria+"%'";
                
            }
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);


            List<Transaksi> listTransaksi = new List<Transaksi>();
            while(hasil.Read()== true)
            {
                Tabungan taSumber = new Tabungan(hasil.GetString(0));

                JenisTransaksi jt = new JenisTransaksi(int.Parse(hasil.GetString(3)));

                Tabungan taTujuan = new Tabungan(hasil.GetString(4));

                Transaksi t = new Transaksi(taSumber, hasil.GetString(1), hasil.GetDateTime(2), jt, taTujuan, double.Parse(hasil.GetString(5)), hasil.GetString(6));

                listTransaksi.Add(t);
            }

            return listTransaksi;
        }
        public static void TambahData(Transaksi t)
        {
            string sql = "insert into transaksi (rekening_sumber, transaksi_id, tgl_transaksi, id_jenis_transaksi, rekening_tujuan, nominal, keterangan) " +
                         "values ('" + t.Rekening_sumber.Rekening + "', '" + t.TransaksiId + "', '" + t.Tgl_transaksi.ToString("yyyy-MM-dd HH:mm:ss") + "', '" +
                         t.Id_jenis_transaksi.Id_jenis_transaksi + "', '" + t.Rekening_tujuan.Rekening + "', '" + t.Nominal + "', '" + t.Keterangan + "')";

            Koneksi.JalankanPerintahDML(sql);
        }
        public static void UbahData(Transaksi t)
        {
            string sql = "update transaksi set rekening_sumber = '" + t.Rekening_sumber.Rekening + "', id_jenis_transaksi = '" + t.Id_jenis_transaksi.Id_jenis_transaksi +
                         "', rekening_tujuan = '" + t.Rekening_tujuan.Rekening + "', nominal = '" + t.Nominal + "', keterangan = '" + t.Keterangan + "' " +
                         "where transaksi_id = '" + t.TransaksiId + "'";

            Koneksi.JalankanPerintahDML(sql);
        }
        public static void HapusData(Transaksi t)
        {
            string sql = "delete from transaksi where transaksi_id = '" + t.TransaksiId + "'";

            Koneksi.JalankanPerintahDML(sql);
        }

        public static int GenerateKode()
        {
            string sql = "SELECT max(id_Transaksi) from Transaksi";

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
