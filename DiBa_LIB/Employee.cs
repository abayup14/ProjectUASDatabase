using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiBa_LIB
{
    public class Employee
    {
        private int id;
        private string nama_depan;
        private string nama_keluarga;
        private Position position;
        private string nik;
        private string email;
        private string password;
        private DateTime tgl_buat;
        private DateTime tgl_perubahan;

        public Employee(int id, string nama_depan, string nama_keluarga, Position position, string nik, string email, string password, 
                        DateTime tgl_buat, DateTime tgl_perubahan)
        {
            this.Id = id;
            this.Nama_depan = nama_depan;
            this.Nama_keluarga = nama_keluarga;
            this.Position = position;
            this.Nik = nik;
            this.Email = email;
            this.Password = password;
            this.Tgl_buat = tgl_buat;
            this.Tgl_perubahan = tgl_perubahan;
        }

        public int Id { get => id; set => id = value; }
        public string Nama_depan { get => nama_depan; set => nama_depan = value; }
        public string Nama_keluarga { get => nama_keluarga; set => nama_keluarga = value; }
        public Position Position { get => position; set => position = value; }
        public string Nik { get => nik; set => nik = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public DateTime Tgl_buat { get => tgl_buat; set => tgl_buat = value; }
        public DateTime Tgl_perubahan { get => tgl_perubahan; set => tgl_perubahan = value; }

        public static List<Employee> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql = "";

            if (kriteria == "")
            {
                sql = "SELECT e.id, e.nama_depan, e.nama_keluarga, e.position, e.nik, e.email, e.password, e.tgl_buat, e.tgl_perubahan " +
                      "from employee e INNER JOIN position p ON e.position = p.id";
            }
            else
            {
                sql = "SELECT e.id, e.nama_depan, e.nama_keluarga, e.position, e.nik, e.email, e.password, e.tgl_buat, e.tgl_perubahan " +
                      "FROM employee e INNER JOIN position p ON e.position = p.id " +
                      "WHERE " + kriteria + " LIKE '%" + nilaiKriteria + "%'";
            }

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            List<Employee> listEmployee = new List<Employee>();

            while (hasil.Read() == true)
            {
                Position p = new Position(int.Parse(hasil.GetString(3)), hasil.GetString(4), hasil.GetString(5));

                Employee e = new Employee(int.Parse(hasil.GetString(0)), hasil.GetString(1), hasil.GetString(2), p, hasil.GetString(6),
                                          hasil.GetString(7), hasil.GetString(8), DateTime.Parse(hasil.GetString(9)), DateTime.Parse(hasil.GetString(10)));

                listEmployee.Add(e);
            }

            return listEmployee;
        }
        public static void TambahData(Employee e)
        {
            string sql = "INSERT into employee (id, nama_depan, nama_keluarga, position, nik, email, password, tgl_buat, tgl_perubahan) " +
                         "values (" + e.Id + ", '" + e.Nama_depan + "', '" + e.Nama_keluarga + "', " + e.Position.PositionID + ", '" + e.Nik +
                         "', '" + e.Email + "', '" + e.Password + "', '" + e.Tgl_buat + "', '" + e.Tgl_perubahan + "')";

            Koneksi.JalankanPerintahDML(sql);
        }
        public static void UbahData(Employee e)
        {
            string sql = "UPDATE employee set nama_depan = '" + e.Nama_depan + "', nama_keluarga = '" + e.Nama_keluarga + "', position = " +
                         e.Position.PositionID + ", email = '" + e.Email + "', password = '" + e.Password + "', tgl_buat = '" + e.Tgl_buat + "', " +
                         "tgl_perubahan = '" + e.Tgl_perubahan + "' where id = " + e.Id;

            Koneksi.JalankanPerintahDML(sql);
        }
        public static void HapusData(Employee e)
        {
            string sql = "DELETE from employee where id = " + e.id;

            Koneksi.JalankanPerintahDML(sql);
        }
    }
}
