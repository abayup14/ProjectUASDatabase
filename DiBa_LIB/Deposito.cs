﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;
using MySql.Data.MySqlClient;

namespace DiBa_LIB
{
    public class Deposito
    {
        #region FIELDS
        private string id_deposito;
        private Tabungan no_rekening;
        private int jatuh_tempo;
        private double nominal;
        private double bunga;
        private string status;
        private DateTime tgl_buat;
        private DateTime tgl_perubahan;
        private Employee verifikator_buka;
        private Employee verifikator_cair;
        #endregion

        #region CONSTRUCTOR
        public Deposito(string id_deposito, Tabungan no_rekening, int jatuh_tempo, double nominal, 
            double bunga, string status, DateTime tgl_buat, DateTime tgl_perubahan, Employee verifikator_buka, Employee verifikator_cair)
        {
            Id_deposito = id_deposito;
            No_rekening = no_rekening;
            Jatuh_tempo = jatuh_tempo;
            Nominal = nominal;
            Bunga = bunga;
            Status = status;
            Tgl_buat = tgl_buat;
            Tgl_perubahan = tgl_perubahan;
            Verifikator_buka = verifikator_buka;
            Verifikator_cair = verifikator_cair;
        }

        public Deposito(string id_deposito)
        {
            Id_deposito = id_deposito;
        }
        #endregion

        #region PROPERTIES
        public string Id_deposito { get => id_deposito; set => id_deposito = value; }
        public Tabungan No_rekening { get => no_rekening; set => no_rekening = value; }
        public int Jatuh_tempo { get => jatuh_tempo; set => jatuh_tempo = value; }
        public double Nominal { get => nominal; set => nominal = value; }
        public double Bunga { get => bunga; set => bunga = value; }
        public string Status { get => status; set => status = value; }
        public DateTime Tgl_buat { get => tgl_buat; set => tgl_buat = value; }
        public DateTime Tgl_perubahan { get => tgl_perubahan; set => tgl_perubahan = value; }
        public Employee Verifikator_buka { get => verifikator_buka; set => verifikator_buka = value; }
        public Employee Verifikator_cair { get => verifikator_cair; set => verifikator_cair = value; }
        #endregion

        #region METHODS
        public static List<Deposito> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql = "";

            if(kriteria == "")
            {
                sql = "SELECT d.id_deposito, t.no_rekening, d.jatuh_tempo, d.nominal, d.bunga, d.status, d.tgl_buat, d.tgl_perubahan, d.verifikator_buka, d.verifikator_cair " +
                    "FROM deposito d INNER JOIN employee e ON d.verifikator_buka = e.id " +
                    "INNER JOIN employee em ON d.verifikator_cair = em.id " +
                    "INNER JOIN tabungan t ON d.no_rekening = t.no_rekening";
            }
            else
            {
                sql = "SELECT d.id_deposito, t.no_rekening, d.jatuh_tempo, d.nominal, d.bunga, d.status, d.tgl_buat, d.tgl_perubahan, d.verifikator_buka, d.verifikator_cair " +
                    "FROM deposito d INNER JOIN employee e ON d.verifikator_buka = e.id " +
                    "INNER JOIN employee em ON d.verifikator_cair = em.id " +
                    "INNER JOIN tabungan t ON d.no_rekening = t.no_rekening " +
                    "WHERE " + kriteria + " LIKE '%" + nilaiKriteria + "%'";
            }

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            List<Deposito> listDeposito = new List<Deposito>();
            while(hasil.Read() == true)
            {
                Tabungan t = new Tabungan(hasil.GetString(1));

                Employee verifikatorBuka = new Employee(int.Parse(hasil.GetString(8)));

                Employee verifikatorCair = new Employee(int.Parse(hasil.GetString(9)));

                Deposito d = new Deposito(hasil.GetString("id_deposito").ToString(), 
                                          t, 
                                          int.Parse(hasil.GetString("jatuh_tempo")), 
                                          double.Parse(hasil.GetString("nominal")), 
                                          double.Parse(hasil.GetString("bunga")), 
                                          hasil.GetString("status").ToString(), 
                                          DateTime.Parse(hasil.GetString("tgl_buat")), 
                                          DateTime.Parse(hasil.GetString("tgl_perubahan")), 
                                          verifikatorBuka, 
                                          verifikatorCair);

                listDeposito.Add(d);
            }
            return listDeposito;
        }

        public static void HapusData(Deposito d, Koneksi k)
        {
            string sql = "DELETE FROM deposito where id_deposito = '" + d.Id_deposito + "'";

            Koneksi.JalankanPerintahDML(sql, k);
        }

        public static void TambahData(Deposito d, Koneksi k)
        {
            string sql = "INSERT INTO deposito (id_deposito, no_rekening, jatuh_tempo, nominal, bunga, status, tgl_buat, tgl_perubahan, verifikator_buka, verifikator_cair) " +
                "VALUES ('" + d.Id_deposito + "', '" + d.No_rekening + "', '" + d.Jatuh_tempo + "', '" + d.Nominal + "', '" + d.Bunga.ToString().Replace(',', '.') + "', '" + d.Status + "', '" + d.Tgl_buat.ToString("yyyy-MM-dd HH:mm:ss") +
                "', '" + d.Tgl_perubahan.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + d.Verifikator_buka + "', '" + d.Verifikator_cair + "')";

            Koneksi.JalankanPerintahDML(sql, k);
        }

        public static void UbahData(Deposito d, Koneksi k)
        {
            string sql = "UPDATE deposito set jatuh_tempo = '" + d.Jatuh_tempo + "', nominal = '" + d.Nominal + "', bunga = '" + d.Bunga +
                "', status = '" + d.Status + "', tgl_buat = '" + d.Tgl_buat + "', tgl_perubahan = '" + d.Tgl_perubahan + "', verifikator_buka = '" + d.Verifikator_buka +
                "', verifikator_cair = '" + d.Verifikator_cair + "' WHERE id_deposito = " + d.Id_deposito;

            Koneksi.JalankanPerintahDML(sql, k);
        }

        public static void UbahStatus(Deposito d, Employee e, Koneksi k)
        {
            string sql = "UPDATE deposito set status = 'Aktif', verifikator_buka = " + e.Id + ", tgl_perubahan = '" + d.Tgl_perubahan.ToString("yyyy-MM-dd HH:mm:ss") + "' " +  
                         "WHERE id_deposito = '" + d.Id_deposito + "'";

            Koneksi.JalankanPerintahDML(sql, k);
        }

        public static double BiayaPenalti(Deposito d)
        {
            //string sql = "UPDATE deposito set nominal = '" + d.Nominal * (95/100) + "'" + "WHERE id_deposito = " + d.Id_deposito;

            string sql = "SELECT nominal from deposito where id_deposito = '" + d.Id_deposito + "'";

            double penalti = 0;

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            if (hasil.Read() == true)
            {
                penalti = double.Parse(hasil.GetString(0)) * 5 / 100.0;

                return penalti;
            }
            else
            {
                return 0;
            }
            
        }

        public static double TambahBunga(Deposito d)
        {
            //string sql = "UPDATE deposito set nominal = '" + d.Nominal * (100+d.bunga/100) + "'" + "WHERE id_deposito = " + d.Id_deposito;
            string sql = "SELECT nominal from deposito where id_deposito = '" + d.Id_deposito + "'";

            double bunga = 0;

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            if (hasil.Read() == true)
            {
                bunga = double.Parse(hasil.GetString(0)) * d.bunga * d.jatuh_tempo / 12.0;

                return bunga;
            }
            else
            {
                return 0;
            }
        }

        public static string GenerateKode(string no_rekening)
        {
            string sql = "SELECT RIGHT(t.no_rekening, 4), MAX(RIGHT(d.id_deposito, 4)) " +
                         "FROM tabungan t INNER JOIN deposito d on t.no_rekening = d.no_rekening " +
                         "WHERE Date(d.tgl_buat) = Date(CURRENT_DATE) AND t.no_rekening = '" + no_rekening + "' " + 
                         "ORDER BY d.tgl_buat DESC limit 1";
            string hasilKode = "";

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            if(hasil.Read() == true)
            {
                if(hasil.GetValue(1).ToString() != "")
                {
                    int nextID = int.Parse(hasil.GetValue(1).ToString()) + 1;
                    hasilKode = DateTime.Now.Year + "/" + DateTime.Now.Month.ToString().PadLeft(2, '0') + "/" +
                                DateTime.Now.Day.ToString().PadLeft(2, '0') + "/" + hasil.GetValue(0).ToString() + "/" +
                                nextID.ToString().PadLeft(4, '0');
                }
                else
                {
                    hasilKode = DateTime.Now.Year + "/" + DateTime.Now.Month.ToString().PadLeft(2, '0') + "/" +
                                DateTime.Now.Day.ToString().PadLeft(2, '0') + "/" + hasil.GetValue(0).ToString() + "/" +
                                "0001";
                }
            }
            return hasilKode;
        }
        public static bool AmbilDataNoDeposito(string id_deposito)
        {
            string sql = "SELECT id_deposito from deposito where id_deposito = '" + id_deposito + "'";

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            if (hasil.Read() == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static Deposito AmbilDataDeposito(string id_deposito)
        {
            string sql = "SELECT * from deposito d " +
                         "inner join tabungan t on d.no_rekening = t.no_rekening " +
                         "inner join pengguna p on t.id_pengguna = p.nik " +
                         "where d.id_deposito = '" + id_deposito + "'";

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            if (hasil.Read() == true)
            {
                Tabungan t = new Tabungan(hasil.GetValue(1).ToString());
                Employee vBuka = new Employee(int.Parse(hasil.GetValue(8).ToString()));
                Employee vCair = new Employee(int.Parse(hasil.GetValue(9).ToString()));
                Deposito d = new Deposito(hasil.GetValue(0).ToString(),
                                          t,
                                          int.Parse(hasil.GetValue(2).ToString()),
                                          double.Parse(hasil.GetValue(3).ToString()),
                                          double.Parse(hasil.GetValue(4).ToString()),
                                          hasil.GetValue(5).ToString(),
                                          DateTime.Parse(hasil.GetValue(6).ToString()),
                                          DateTime.Parse(hasil.GetValue(7).ToString()),
                                          vBuka,
                                          vCair);

                return d;
            }
            else
            {
                return null;
            }
        }
        #endregion
    }
}
