using System;
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
                phh.Pengguna+"', '"+phh.Hadiah+"')";
            Koneksi.JalankanPerintahDML(sql, k);
        }
    }
}
