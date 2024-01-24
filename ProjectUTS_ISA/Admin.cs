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
    public class Admin
    {
        #region data members
        private string id;
        private string nama;
        private string email;
        private string password;
        #endregion

        #region constructors
        public Admin(string id, string nama)
        {
            this.Id = id;
            this.Nama = nama;
        }
        public Admin(string id, string nama, string email, string password)
        {
            this.Id = id;
            this.Nama = nama;
            this.Email = email;
            this.Password = password;
        }
        #endregion

        #region properties
        public string Id { get => id; set => id = value; }
        public string Nama { get => nama; set => nama = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        #endregion

        #region methods
        public static void TambahData(Admin ad)
        {
            byte[] IV = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            AES aes = new AES();
            string encrypted = aes.Encrypt(ad.Password, "1111111111111111", IV);

            string sql = "insert into admin (id_admin, nama, email, password) " 
                + " values ('" + ad.Id + "','" + ad.Nama + "','" + ad.Email + "'," 
                + "SHA2('" + encrypted + "', 512))";

            Koneksi.JalankanPerintahDML(sql);
        }

        public static string GenerateId()
        {
            string sql = "SELECT id_admin FROM admin ORDER BY id_admin DESC LIMIT 1";

            string hasilKode = "";

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            if (hasil.Read() == true)
            {
                string kode = hasil.GetValue(0).ToString();
                int kodeDalamInt = int.Parse(kode.Substring(kode.Length - 3));

                int angkaKodeTerbaru = kodeDalamInt + 1;
                hasilKode = "AD" + angkaKodeTerbaru.ToString("D3");
            }
            else
            {
                hasilKode = "AD001";
            }
            return hasilKode;
        }

        public static Admin CekLogin(string email, string password)
        {
            byte[] IV = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            AES aes = new AES();
            string decrypted = aes.Encrypt(password, "1111111111111111", IV);

            string sql = "";
            sql = "SELECT * FROM admin WHERE email ='" + email + "' AND password = SHA2('" + decrypted + "', 512); ";

            byte[] key = new byte[] { };


            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            while (hasil.Read() == true)
            {
                Admin ad = new Admin(hasil.GetValue(0).ToString(), hasil.GetValue(1).ToString(), hasil.GetValue(2).ToString(), hasil.GetValue(3).ToString());

                return ad;
            }
            return null;
        }
        #endregion
    }
}
