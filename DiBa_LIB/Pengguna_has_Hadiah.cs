﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DiBa_LIB
{
    public class Pengguna_has_Hadiah
    {
        private Pengguna pengguna;
        private Hadiah hadiah;

        public Pengguna_has_Hadiah(Pengguna pengguna, Hadiah hadiah)
        {
            Pengguna = pengguna;
            Hadiah = hadiah;
        }

        public Pengguna Pengguna { get => pengguna; set => pengguna = value; }
        public Hadiah Hadiah { get => hadiah; set => hadiah = value; }

        public static void TambahData(Pengguna_has_Hadiah phh, Koneksi k)
        {
            string sql = "insert into pengguna_has_hadiah(pengguna_nik, hadiah_id) values ('"+
                phh.Pengguna.Nik+"', '"+phh.Hadiah.Id+"')";
            Koneksi.JalankanPerintahDML(sql, k);
        }
        public static List<Pengguna_has_Hadiah> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql = "";
            if (kriteria == null)
            {
                sql = "select * from pengguna p inner join pengguna_has_hadiah ph on " +
                      "p.nik = ph.pengguna_nik inner join hadiah h on ph.hadiah_id = h.id";
            }
            else
            {
                sql = "select * " +
                      "from pengguna p " +
                      "inner join pengguna_has_hadiah ph on p.nik = ph.pengguna_nik " +
                      "inner join hadiah h on ph.hadiah_id = h.id " +
                      "where " + kriteria + " like '%" + nilaiKriteria + "%'";
            }
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            List<Pengguna_has_Hadiah> listofPenggunaHasHadiah = new List<Pengguna_has_Hadiah>();
            while (hasil.Read() == true)
            {
                Pengguna p = new Pengguna(hasil.GetString(0),
                                          hasil.GetString(1),
                                          hasil.GetString(2),
                                          hasil.GetString(3),
                                          hasil.GetString(4),
                                          hasil.GetString(5),
                                          hasil.GetString(6),
                                          hasil.GetString(7),
                                          DateTime.Parse(hasil.GetString(8)),
                                          DateTime.Parse(hasil.GetString(9)));
                Hadiah h = new Hadiah(int.Parse(hasil.GetString(12)), hasil.GetString(13), hasil.GetString(14));
                Pengguna_has_Hadiah ph = new Pengguna_has_Hadiah(p, h);
                listofPenggunaHasHadiah.Add(ph);
            }
            return listofPenggunaHasHadiah;
        }
        public static void HapusData(Pengguna_has_Hadiah ph, Koneksi k)
        {
            string sql = "delete from pengguna_has_hadiah where pengguna_nik = '" + ph.Pengguna +"'";
            Koneksi.JalankanPerintahDML(sql, k);
        }
    }
}
