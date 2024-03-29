﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiBa_LIB
{
    public class Employee
    {
        #region DATA MEMBERS
        private int id;
        private string nama_depan;
        private string nama_keluarga;
        private string nik;
        private Position position;
        private string email;
        private string password;
        private DateTime tgl_buat;
        private DateTime tgl_perubahan;
        #endregion

        #region CONSTRUCTORS
        public Employee()
        {
            Id = 0;
        }
        public Employee(int id, string nama_depan, string nama_keluarga, Position position, string nik, string email, string password, 
                        DateTime tgl_buat, DateTime tgl_perubahan)
        {
            Id = id;
            Nama_depan = nama_depan;
            Nama_keluarga = nama_keluarga;
            Nik = nik;
            Email = email;
            Password = password;
            Tgl_buat = tgl_buat;
            Tgl_perubahan = tgl_perubahan;
            Position = position;
        }
        public Employee(int id)
        {
            Id = id;
        }
        #endregion

        #region PROPERTIES
        public int Id { get => id; set => id = value; }
        public string Nama_depan { get => nama_depan; set => nama_depan = value; }
        public string Nama_keluarga { get => nama_keluarga; set => nama_keluarga = value; }
        public Position Position { get => position; set => position = value; }
        public string Nik { get => nik; set => nik = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public DateTime Tgl_buat { get => tgl_buat; set => tgl_buat = value; }
        public DateTime Tgl_perubahan { get => tgl_perubahan; set => tgl_perubahan = value; }
        #endregion

        #region METHODS
        public static List<Employee> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql = "";

            if (kriteria == "")
            {
                sql = "SELECT e.id, e.nama_depan, e.nama_keluarga, p.nama as nama_position, e.nik, e.email, e.password, e.tgl_buat, e.tgl_perubahan " +
                      "FROM employee e INNER JOIN position p ON e.position = p.id";
            }
            else
            {
                sql = "SELECT e.id, e.nama_depan, e.nama_keluarga, p.nama as nama_position, e.nik, e.email, e.password, e.tgl_buat, e.tgl_perubahan " +
                      "FROM employee e INNER JOIN position p ON e.position = p.id " + 
                      "WHERE " + kriteria + " LIKE '%" + nilaiKriteria + "%'";
            }

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            List<Employee> listEmployee = new List<Employee>();

            while (hasil.Read() == true)
            {
                Position p = new Position(hasil.GetValue(3).ToString());

                Employee em = new Employee(int.Parse(hasil.GetValue(0).ToString()), 
                                           hasil.GetValue(1).ToString(), 
                                           hasil.GetString(2), 
                                           p, 
                                           hasil.GetString(4),
                                           hasil.GetString(5), 
                                           hasil.GetString(6), 
                                           DateTime.Parse(hasil.GetString(7)), 
                                           DateTime.Parse(hasil.GetString(8)));

                listEmployee.Add(em);
            }

            return listEmployee;
        }
        public static void TambahData(Employee em, Koneksi k)
        {
            string sql = "INSERT into employee (id, nama_depan, nama_keluarga, position, nik, email, password, tgl_buat, tgl_perubahan) " +
                         "values ('" + em.Id + "', '" + em.Nama_depan + "', '" + em.Nama_keluarga + "', '" + em.Position.PositionID + "', '" + em.Nik +
                         "', '" + em.Email + "', SHA2('" + em.Password + "', 512), '" + em.Tgl_buat.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + em.Tgl_perubahan.ToString("yyyy-MM-dd HH:mm:ss") + "')";

            Koneksi.JalankanPerintahDML(sql, k);
        }
        public static void UbahData(Employee em, Koneksi k)
        {
            string sql = "UPDATE employee set nama_depan = '" + em.Nama_depan + "', nama_keluarga = '" + em.Nama_keluarga + "', position = " +
                         em.Position.PositionID + ", email = '" + em.Email + "', tgl_buat = '" + em.Tgl_buat.ToString("yyyy-MM-dd HH:mm:ss") + "', " +
                         "tgl_perubahan = '" + em.Tgl_perubahan.ToString("yyyy-MM-dd HH:mm:ss") + "' where id = " + em.Id;

            Koneksi.JalankanPerintahDML(sql, k);
        }
        public static void UbahPassword(Employee em, string passwordLama, string passwordBaru, Koneksi k)
        {
            string sql = "UPDATE employee SET password = SHA2('" + passwordBaru + "', 512), tgl_perubahan = '" + 
                         em.Tgl_perubahan.ToString("yyyy-MM-dd HH:mm:ss") +
                         "' WHERE nik = '" + em.Nik + "' AND password = SHA2('" + passwordLama + "', 512)";
 
            Koneksi.JalankanPerintahDML(sql, k);
        }
        public static void HapusData(Employee em, Koneksi k)
        {
            string sql = "DELETE from employee where id = " + em.id;

            Koneksi.JalankanPerintahDML(sql, k);
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
        public static Employee CekLogin(string email, string password)
        {
            string sql = "SELECT * from employee WHERE email = '" + email + "' AND password = SHA2('" + password + "', 512)";

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            while (hasil.Read() == true)
            {
                Position p = new Position(hasil.GetValue(3).ToString());

                Employee em = new Employee(int.Parse(hasil.GetValue(0).ToString()), hasil.GetString(1), hasil.GetString(2), p,
                                           hasil.GetString(4), hasil.GetString(5), hasil.GetString(6), DateTime.Parse(hasil.GetString(7)),
                                           DateTime.Parse(hasil.GetString(8)));

                return em;
            }

            return null;
        }
        public static string AmbilNamaLengkap(string id)
        {
            string sql = "SELECT nama_depan, nama_keluarga from employee where id = '" + id + "'";

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            string hasilAmbil = "";

            if (hasil.Read() == true)
            {
                hasilAmbil = hasil.GetString(0) + " " + hasil.GetString(1);

                return hasilAmbil;
            }
            else
            {
                return null;
            }
        }
        public static Employee AmbilDataByKode(int id)
        {
            string sql = "SELECT e.id, e.nama_depan, e.nama_keluarga, p.nama as nama_position, e.nik, e.email, e.password, e.tgl_buat, e.tgl_perubahan " +
                         "FROM employee e INNER JOIN position p ON e.position = p.id " +
                         "where e.id = " + id;

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            if (hasil.Read() == true)
            {
                Position p = new Position(hasil.GetValue(3).ToString());

                Employee em = new Employee(int.Parse(hasil.GetValue(0).ToString()), hasil.GetValue(1).ToString(), hasil.GetString(2), p, hasil.GetString(4),
                                          hasil.GetString(5), hasil.GetString(6), DateTime.Parse(hasil.GetString(7)), DateTime.Parse(hasil.GetString(8)));

                return em;
            }
            else
            {
                return null;
            }
        }

        public override string ToString()
        {
            return Id.ToString();
        }
        #endregion
    }
}
