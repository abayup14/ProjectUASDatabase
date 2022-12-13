using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DiBa_LIB
{
    public class Pengguna
    {
        #region DATA MEMBERS
        private string nik;
        private string nama_depan;
        private string nama_keluarga;
        private string alamat;
        private string email;
        private string no_telepon;
        private string password;
        private string pin;
        private DateTime tgl_buat;
        private DateTime tgl_perubahan;
        private List<AddressBook> listAdressBook;
        #endregion

        #region CONSTRUCTORS
        public Pengguna(string nik, string nama_depan, string nama_keluarga, string alamat, string email, string no_telepon, 
                        string password, string pin, DateTime tgl_buat, DateTime tgl_perubahan )
        {
            Nik = nik;
            Nama_depan = nama_depan;
            Nama_keluarga = nama_keluarga;
            Alamat = alamat;
            Email = email;
            No_telepon = no_telepon;
            Password = password;
            Pin = pin;
            Tgl_buat = tgl_buat;
            Tgl_perubahan = tgl_perubahan;
            ListAdressBook = new List<AddressBook>();
        }
        public Pengguna(string nik)
        {
            Nik = nik;
        }
        #endregion

        #region PROPERTIES
        public string Nik { get => nik; set => nik = value; }
        public string Nama_depan { get => nama_depan; set => nama_depan = value; }
        public string Nama_keluarga { get => nama_keluarga; set => nama_keluarga = value; }
        public string Alamat { get => alamat; set => alamat = value; }
        public string Email { get => email; set => email = value; }
        public string No_telepon { get => no_telepon; set => no_telepon = value; }
        public string Password { get => password; set => password = value; }
        public string Pin { get => pin; set => pin = value; }
        public DateTime Tgl_buat { get => tgl_buat; set => tgl_buat = value; }
        public DateTime Tgl_perubahan { get => tgl_perubahan; set => tgl_perubahan = value; }
        public List<AddressBook> ListAdressBook { get => listAdressBook; private set => listAdressBook = value; }
        #endregion

        #region METHODS
        public static void TambahData(Pengguna p, Koneksi k)
        {

            string sql = "INSERT into pengguna(nik, nama_depan, nama_keluarga, alamat, email, no_telepon, password, pin, tgl_buat, tgl_perubahan) " +
                                 "values ('" + p.Nik + "', '" + p.Nama_depan + "', '" + p.Nama_keluarga + "', '" + p.Alamat + "', '" + p.Email + "', '" + p.No_telepon + "', SHA2('" + p.Password + "', 512), SHA2('" + p.Pin + "', 512), '" + p.Tgl_buat.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + p.Tgl_perubahan.ToString("yyyy-MM-dd HH:mm:ss") + "')";

            Koneksi.JalankanPerintahDML(sql, k);
        }
        public static void UbahData(Pengguna p, Koneksi k)
        {
            string sql = "UPDATE pengguna set nama_depan = '" + p.Nama_depan + "', nama_keluarga = '" + p.Nama_keluarga + "', alamat = '" + p.Alamat + "', email = '" + p.Email + "', no_telepon = '" + p.No_telepon + "', tgl_perubahan = '" + p.Tgl_perubahan.ToString("yyyy-MM-dd HH:mm:ss") + "' where nik = '" + p.Nik + "'";
            Koneksi.JalankanPerintahDML(sql, k);
        }
        public static void UbahPassword(Pengguna p, string passwordLama, string passwordBaru, Koneksi k)
        {
            string sql = "UPDATE pengguna set password = SHA2('" + passwordBaru + "', 512), tgl_perubahan = '" + 
                         p.Tgl_perubahan.ToString("yyyy-MM-dd HH:mm:ss") + "' where nik = '" + p.Nik + 
                         "' AND password = SHA2('" + passwordLama + "', 512)";

            Koneksi.JalankanPerintahDML(sql, k);
        }
        public static void HapusData(Pengguna p, Koneksi k)
        {
            string sql = "DELETE from pengguna where nik = '" + p.Nik + "'";
            Koneksi.JalankanPerintahDML(sql, k);
        }
        public static List<Pengguna> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql = "";

            if (kriteria == "")
            {
                sql = "SELECT * from pengguna";
            }
            else
            {
                sql = "SELECT * from pengguna where " + kriteria + " LIKE '%" + nilaiKriteria + "%'";
            }

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            List<Pengguna> listPengguna = new List<Pengguna>();

            while (hasil.Read() == true)
            {
                Pengguna p = new Pengguna(hasil.GetValue(0).ToString(), 
                                          hasil.GetValue(1).ToString(), 
                                          hasil.GetValue(2).ToString(),
                                          hasil.GetValue(3).ToString(), 
                                          hasil.GetValue(4).ToString(), 
                                          hasil.GetValue(5).ToString(),
                                          hasil.GetValue(6).ToString(), 
                                          hasil.GetValue(7).ToString(), 
                                          DateTime.Parse(hasil.GetValue(8).ToString()),
                                          DateTime.Parse(hasil.GetValue(9).ToString()));

                listPengguna.Add(p);
            }

            return listPengguna;
        }
        public static Pengguna CekLogin(string emailAtauNoTelepon, string password)
        {
            string sql = "SELECT * from pengguna where (email = '" + emailAtauNoTelepon + "' OR no_telepon = '" + emailAtauNoTelepon +
                         "') AND password = SHA2('" + password + "', 512)";

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            while (hasil.Read() == true)
            {
                Pengguna p = new Pengguna(hasil.GetString(0), hasil.GetString(1), hasil.GetString(2), hasil.GetString(3), hasil.GetString(4),
                                          hasil.GetString(5), hasil.GetString(6), hasil.GetString(7), DateTime.Parse(hasil.GetString(8)),
                                          DateTime.Parse(hasil.GetString(9)));

                return p;
            }

            return null;
        }
        public static string AmbilNamaLengkap(string nik)
        {
            string sql = "SELECT nama_depan, nama_keluarga from pengguna where nik = '" + nik + "'";

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
        public override string ToString()
        {
            return Nik;
        }
        public void TambahAdressBook(Pengguna p, Tabungan t, string keterangan)
        {
            AddressBook adress = new AddressBook(p, t, keterangan);
            ListAdressBook.Add(adress);
        }
        public static Pengguna AmbilDataByKode(string id)
        {
            string sql = "SELECT  p.nik, p.nama_depan, p.nama_keluarga, p.alamat, p.email, p.no_telepon " +
                "p.password, p.pin, p.tgl_buat, p.tgl_perubahan " +
                         "FROM pengguna " +
                         "where p.nik = '" + id +"'";

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            if (hasil.Read() == true)
            {
                Pengguna p = new Pengguna(hasil.GetString(0), hasil.GetString(1), hasil.GetString(2), 
                    hasil.GetString(3), hasil.GetString(4), hasil.GetString(5), hasil.GetString(6), 
                    hasil.GetString(7), DateTime.Parse(hasil.GetString(8)), DateTime.Parse(hasil.GetString(9)));

                return p;
            }
            else
            {
                return null;
            }

        }
        #endregion
    }
}
