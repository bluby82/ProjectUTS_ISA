using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Security.Cryptography;

namespace ProjectUTS_ISA
{
    public class Manajer
    {
        #region data members
        private string id;
        private string nama;
        private string email;
        private string alamat;
        private string noTelp;
        private string password;
        #endregion

        #region constructors
        public Manajer(string id, string nama)
        {
            this.Id = id;
            this.Nama = nama;
        }

        public Manajer(string id, string nama, string email, string alamat, string noTelp)
        {
            this.Id = id;
            this.Nama = nama;
            this.Email = email;
            this.Alamat = alamat;
            this.NoTelp = noTelp;
        }

        public Manajer(string id, string nama, string email, string alamat, string noTelp, string password)
        {
            this.Id = id;
            this.Nama = nama;
            this.Email = email;
            this.Alamat = alamat;
            this.NoTelp = noTelp;
            this.Password = password;
        }
        #endregion

        #region properties
        public string Id { get => id; set => id = value; }
        public string Nama { get => nama; set => nama = value; }
        public string Email { get => email; set => email = value; }
        public string Alamat { get => alamat; set => alamat = value; }
        public string NoTelp { get => noTelp; set => noTelp = value; }
        public string Password { get => password; set => password = value; }
        #endregion

        #region methods
        public static void TambahData(Manajer m)
        {
            byte[] IV = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            AES aes = new AES();
            string encrypted = aes.Encrypt(m.Password, "1111111111111111", IV);

            string sql = "insert into manajer (id_manajer, nama, email, alamat, no_telp, password) "
                + " values ('" + m.Id + "','" + m.Nama + "','" + m.Email + "','" + m.Alamat + "','" + m.NoTelp + "',"
                + "SHA2('" + encrypted + "', 512))";

            Koneksi.JalankanPerintahDML(sql);
        }

        public static string GenerateId()
        {
            string sql = "SELECT id_manajer FROM manajer ORDER BY id_manajer DESC LIMIT 1";

            string hasilKode = "";

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            if (hasil.Read() == true)
            {
                string kode = hasil.GetValue(0).ToString();
                int kodeDalamInt = int.Parse(kode.Substring(kode.Length - 4));

                int angkaKodeTerbaru = kodeDalamInt + 1;
                hasilKode = "M" + angkaKodeTerbaru.ToString("D4");
            }
            else
            {
                hasilKode = "M0001";
            }
            return hasilKode;
        }

        public static List<Manajer> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql = "";
            if (kriteria == "")
            {
                sql = "SELECT id_manajer, nama, email, alamat, no_telp FROM manajer; ";
            }
            else
            {
                sql = "SELECT id_manajer, nama, email, alamat, no_telp FROM manajer WHERE " + kriteria + " LIKE '%" + nilaiKriteria + "%'";
            }

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            List<Manajer> listManajer = new List<Manajer>();

            while (hasil.Read() == true)
            {
                Manajer m = new Manajer(hasil.GetValue(0).ToString(), hasil.GetValue(1).ToString(), hasil.GetValue(2).ToString(), hasil.GetValue(3).ToString(), hasil.GetValue(4).ToString());

                listManajer.Add(m);
            }

            return listManajer;
        }

        public static Manajer CekLogin(string email, string password)
        {
            byte[] IV = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            AES aes = new AES();
            string decrypted = aes.Encrypt(password, "1111111111111111", IV);

            string sql = "";
            sql = "SELECT * FROM manajer WHERE email ='" + email + "' AND password = SHA2('" + decrypted + "', 512); ";

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            while (hasil.Read() == true)
            {
                Manajer m = new Manajer(hasil.GetValue(0).ToString(), hasil.GetValue(1).ToString(), hasil.GetValue(2).ToString(), hasil.GetValue(3).ToString(), hasil.GetValue(4).ToString(), hasil.GetValue(5).ToString());

                return m;
            }
            return null;
        }
        #endregion
    }
}
