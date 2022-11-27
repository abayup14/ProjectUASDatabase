using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;
using DiBa_LIB;

namespace DiBa_LIB
{
    public class Koneksi
    {

        #region DataMember
        private MySqlConnection koneksiDB;
        #endregion

        #region Properties
        public MySqlConnection KoneksiDB
        {
            get => koneksiDB;
            private set => koneksiDB = value;
        }
        #endregion
        public Koneksi(string pServer, string pDatabase, string pUsername, string pPassword)
        {
            string strCon = "server=" + pServer + ";database=" + pDatabase + ";uid=" + pUsername + ";password=" + pPassword;
            KoneksiDB = new MySqlConnection();
            KoneksiDB.ConnectionString = strCon;
            Connect();
        }
        public Koneksi()
        {
            Configuration myconf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ConfigurationSectionGroup userSettings = myconf.SectionGroups["userSettings"];
            var settingsSection = userSettings.Sections["ProjectDatabase_Ivano.db"] as ClientSettingsSection;

            string dbServer = settingsSection.Settings.Get("DbServer").Value.ValueXml.InnerText;
            string dbName = settingsSection.Settings.Get("DbName").Value.ValueXml.InnerText;
            string dbUsername = settingsSection.Settings.Get("DbUsername").Value.ValueXml.InnerText;
            string dbPassword = settingsSection.Settings.Get("DbPassword").Value.ValueXml.InnerText;

            string strcon = "server=" + dbServer + ";database=" + dbName + ";uid=" + dbUsername + ";password=" + dbPassword;
            KoneksiDB = new MySqlConnection();

            KoneksiDB.ConnectionString = strcon;
            Connect();
        }
        
        #region Method
        public void Connect()
        {
            if (KoneksiDB.State == System.Data.ConnectionState.Open)
            {
                KoneksiDB.Close();
            }
            KoneksiDB.Open();
        }
        public static int JalankanPerintahDML(string sql)
        {
            Koneksi k = new Koneksi();
            MySqlCommand c = new MySqlCommand(sql, k.KoneksiDB);
            int hasil = c.ExecuteNonQuery();
            return hasil;
        }
        public static MySqlDataReader JalankanPerintahQuery(string sql)
        {
            Koneksi k = new Koneksi();
            MySqlCommand c = new MySqlCommand(sql, k.KoneksiDB);
            MySqlDataReader hasil = c.ExecuteReader();

            return hasil;
        }
        #endregion
    }
}
