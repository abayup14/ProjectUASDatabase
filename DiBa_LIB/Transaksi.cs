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
        private Promo id_promo;
        private JenisTagihan id_jenis_tagihan;

        public Transaksi(Tabungan rekening_sumber, string transaksiId, DateTime tgl_transaksi, JenisTransaksi id_jenis_transaksi, Tabungan rekening_tujuan, double nominal, string keterangan, Promo id_promo, JenisTagihan id_jenis_tagihan)
        {
            Rekening_sumber = rekening_sumber;
            TransaksiId = transaksiId;
            Tgl_transaksi = tgl_transaksi;
            Id_jenis_transaksi = id_jenis_transaksi;
            Rekening_tujuan = rekening_tujuan;
            Nominal = nominal;
            Keterangan = keterangan;
            Id_promo = id_promo;
            Id_jenis_tagihan = id_jenis_tagihan;
        }
        public Transaksi(Tabungan rekening_sumber, string transaksiId, DateTime tgl_transaksi, Tabungan rekening_tujuan, double nominal, string keterangan, Promo id_promo, JenisTagihan id_jenis_tagihan)
        {
            Rekening_sumber = rekening_sumber;
            TransaksiId = transaksiId;
            Tgl_transaksi = tgl_transaksi;
            Rekening_tujuan = rekening_tujuan;
            Nominal = nominal;
            Keterangan = keterangan;
            Id_promo = id_promo;
            Id_jenis_tagihan = id_jenis_tagihan;
        }
        public Tabungan Rekening_sumber { get => rekening_sumber; set => rekening_sumber = value; }
        public string TransaksiId { get => transaksiId; set => transaksiId = value; }
        public DateTime Tgl_transaksi { get => tgl_transaksi; set => tgl_transaksi = value; }
        public JenisTransaksi Id_jenis_transaksi { get => id_jenis_transaksi; set => id_jenis_transaksi = value; }
        public Tabungan Rekening_tujuan { get => rekening_tujuan; set => rekening_tujuan = value; }
        public double Nominal { get => nominal; set => nominal = value; }
        public string Keterangan { get => keterangan; set => keterangan = value; }
        public Promo Id_promo { get => id_promo; set => id_promo = value; }
        public JenisTagihan Id_jenis_tagihan { get => id_jenis_tagihan; set => id_jenis_tagihan = value; }

        public static List<Transaksi> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql = "";
            if (kriteria == "")
            {
                sql = "select t.rekening_sumber, t.id_transaksi, t.tgl_transaksi, t.id_jenis_transaksi, t.rekening_tujuan, t.nominal, t.keterangan, p.id, j.id " +
                      "from transaksi t inner join tabungan ta on t.rekening_sumber = ta.no_rekening " +
                      "inner join tabungan tb on t.rekening_tujuan = tb.no_rekening " +
                      "left join jenis_transaksi jt on t.id_jenis_transaksi = jt.id_jenis_transaksi " + 
                      "inner join promo p on t.promo_id = p.id " + 
                      "inner join jenis_tagihan j on t.jenis_tagihan_id = j.id";

            }
            else
            {
                sql = "select t.rekening_sumber, t.id_transaksi, t.tgl_transaksi, t.id_jenis_transaksi, t.rekening_tujuan, t.nominal, t.keterangan, p.id, j.id " +
                      "from transaksi t inner join tabungan ta on t.rekening_sumber = ta.no_rekening " +
                      "inner join tabungan tb on t.rekening_tujuan = tb.no_rekening " +
                      "left join jenis_transaksi jt on t.id_jenis_transaksi = jt.id_jenis_transaksi " +
                      "inner join promo p on t.promo_id = p.id " +
                      "inner join jenis_tagihan j on t.jenis_tagihan_id = j.id " +
                      "where " +kriteria + " like '%" + nilaiKriteria+"%'";
                
            }
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);


            List<Transaksi> listTransaksi = new List<Transaksi>();
            while(hasil.Read()== true)
            {
                Tabungan taSumber = new Tabungan(hasil.GetString(0));

                JenisTransaksi jt = new JenisTransaksi(int.Parse(hasil.GetString(3)));

                Tabungan taTujuan = new Tabungan(hasil.GetString(4));

                Promo p = new Promo(int.Parse(hasil.GetString(7)));

                JenisTagihan j = new JenisTagihan(hasil.GetString(8));

                Transaksi t = new Transaksi(taSumber, 
                                            hasil.GetString(1), 
                                            hasil.GetDateTime(2), 
                                            jt, 
                                            taTujuan, 
                                            double.Parse(hasil.GetString(5)), 
                                            hasil.GetString(6),
                                            p, 
                                            j);

                listTransaksi.Add(t);
            }

            return listTransaksi;
        }
        public static void TambahTransaksiTopUp(Transaksi t, Koneksi k)
        {
            string sql = "insert into transaksi (rekening_sumber, id_transaksi, tgl_transaksi, id_jenis_transaksi, rekening_tujuan, nominal, keterangan, promo_id, jenis_tagihan_id) " +
                         "values ('" + t.Rekening_sumber.Rekening + "', '" + t.TransaksiId + "', '" + t.Tgl_transaksi.ToString("yyyy-MM-dd HH:mm:ss") + "', '" +
                         t.Id_jenis_transaksi.Id_jenis_transaksi + "', '" + t.Rekening_tujuan.Rekening + "', '" + t.Nominal + "', '" + t.Keterangan + "', '" + t.Id_promo.IdPromo + "', '" + t.Id_jenis_tagihan.Id + "')";

            Koneksi.JalankanPerintahDML(sql, k);
        }
        public static void TambahTransaksiSumber(Transaksi t, Koneksi k)
        {
            string sql1 = "insert into transaksi (rekening_sumber, id_transaksi, tgl_transaksi, id_jenis_transaksi, rekening_tujuan, nominal, keterangan, promo_id, jenis_tagihan_id) " +
                         "values ('" + t.Rekening_sumber.Rekening + "', '" + t.TransaksiId + "', '" + t.Tgl_transaksi.ToString("yyyy-MM-dd HH:mm:ss") + "', '1', '" + t.Rekening_tujuan.Rekening + "', '" + t.Nominal + "', '" + t.Keterangan + "', '" + t.Id_promo.IdPromo + "', '" + t.Id_jenis_tagihan.Id + "')";
            Koneksi.JalankanPerintahDML(sql1, k);

            
        }
        public static void TambahTransaksiTujuan(Transaksi t, Koneksi k)
        {
            string sql2 = "insert into transaksi (rekening_sumber, id_transaksi, tgl_transaksi, id_jenis_transaksi, rekening_tujuan, nominal, keterangan, promo_id, jenis_tagihan_id) " +
                         "values ('" + t.Rekening_tujuan.Rekening + "', '" + t.TransaksiId + "', '" + t.Tgl_transaksi.ToString("yyyy-MM-dd HH:mm:ss") + "', '2', '" + t.Rekening_sumber.Rekening + "', '" + t.Nominal + "', '" + t.Keterangan + "', '" + t.Id_promo.IdPromo + "', '" + t.Id_jenis_tagihan.Id + "')";

            Koneksi.JalankanPerintahDML(sql2, k);
        }
        public static void UpdateSaldoTransaksi(Transaksi t, Koneksi k)
        {
            string sql1 = "update tabungan set saldo = saldo - " + t.Nominal + " where no_rekening = '" + t.Rekening_sumber.Rekening + "'";

            Koneksi.JalankanPerintahDML(sql1, k);

            string sql2 = "update tabungan set saldo = saldo + " + t.Nominal + " where no_rekening = '" + t.Rekening_tujuan.Rekening + "'";

            Koneksi.JalankanPerintahDML(sql2, k);
        }
        public static void UbahData(Transaksi t, Koneksi k)
        {
            string sql = "update transaksi set rekening_sumber = '" + t.Rekening_sumber.Rekening + "', id_jenis_transaksi = '" + t.Id_jenis_transaksi.Id_jenis_transaksi +
                         "', rekening_tujuan = '" + t.Rekening_tujuan.Rekening + "', nominal = '" + t.Nominal + "', keterangan = '" + t.Keterangan + "', promo_id = '" + t.Id_promo + "', jenis_tagihan_id = '" + t.Id_jenis_transaksi +
                         "where transaksi_id = '" + t.TransaksiId + "'";

            Koneksi.JalankanPerintahDML(sql, k);
        }
        public static void HapusData(Transaksi t, Koneksi k)
        {
            string sql = "delete from transaksi where transaksi_id = '" + t.TransaksiId + "'";
            Koneksi.JalankanPerintahDML(sql, k);
        }
        public static string GenerateKode()
        {
            string sql = "SELECT max(id_transaksi) from transaksi";

            string hasilKode = "";

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            if (hasil.Read() == true)
            {
                if (hasil.GetValue(0).ToString() != "")
                {
                    int kodeBaru = int.Parse(hasil.GetValue(0).ToString()) + 1;

                    string hasilBaru = kodeBaru.ToString().PadLeft(10, '0');

                    hasilKode = hasilBaru;
                }
                else
                {
                    hasilKode = "0000000001";
                }
            }

            return hasilKode;
        }
    }
}
