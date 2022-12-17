using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiBa_LIB;
using MySql.Data.MySqlClient;

namespace DiBa_LIB
{

    public class AddressBook
    {
        private Pengguna pengguna;
        private Tabungan no_rekening;
        private string keterangan;

        public AddressBook(Pengguna pengguna, Tabungan no_rekening, string keterangan)
        {
            this.Pengguna = pengguna;
            this.No_rekening = no_rekening;
            this.Keterangan = keterangan;
        }

        public Pengguna Pengguna { get => pengguna; set => pengguna = value; }
        public Tabungan No_rekening { get => no_rekening; set => no_rekening = value; }
        public string Keterangan { get => keterangan; set => keterangan = value; }

        public static List<AddressBook> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql = "";

            if (kriteria == "")
            {
                sql = "select * from address_book";
            }
            else
            {
                sql = "select * from address_book where '" + kriteria + "' LIKE '%" + nilaiKriteria + "%'";
            }

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            List<AddressBook> listOfAdressBook = new List<AddressBook>();

            while (hasil.Read() == true)
            {
                Pengguna p = new Pengguna(hasil.GetString(0));
                Tabungan t = new Tabungan(hasil.GetValue(1).ToString());
                AddressBook ab = new AddressBook(p, t, hasil.GetString(2));
                listOfAdressBook.Add(ab);
            }

            return listOfAdressBook;
        }
        public static void UbahData(AddressBook ab, Koneksi k)
        {
            string sql = "update address_book set id_pengguna = '" + ab.Pengguna.Nik + "', " +
                "no_rekening = '" + ab.No_rekening.Rekening + "', " +
                "keterangan = '" + ab.Keterangan + "'";

            Koneksi.JalankanPerintahDML(sql, k);
        }
        public static void HapusData(AddressBook ab, Koneksi k)
        {
            string sql = "DELETE from address_book where id = " + ab.Pengguna.Nik;

            Koneksi.JalankanPerintahDML(sql, k);
        }
        public static void TambahData(AddressBook ab, Koneksi k)
        {
            string sql = "insert into address_book(id_pengguna, no_rekening, keterangan) values ('"+ab.Pengguna.Nik
                +"', '"+ab.No_rekening.Rekening+"', '"+ab.Keterangan+"')";

            Koneksi.JalankanPerintahDML(sql, k);
        }
    }
}
