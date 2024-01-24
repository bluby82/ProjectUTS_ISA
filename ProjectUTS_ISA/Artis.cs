using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;

namespace ProjectUTS_ISA
{
    public class Artis
    {
        #region data members
        private Image foto;
        private string id;
        private string nama;
        private string email;
        private string noTelp;
        private string password;
        private Manajer manajer;
        #endregion

        #region constructors
        public Artis(string id, string nama)
        {
            this.Id = id;
            this.Nama = nama;
        }

        public Artis(string id, string nama, string email, string noTelp, Manajer manajer)
        {
            this.Id = id;
            this.Nama = nama;
            this.Email = email;
            this.NoTelp = noTelp;
            this.Manajer = manajer;
        }

        public Artis(Image foto, string id, string nama, string email, string noTelp, Manajer manajer)
        {
            this.Foto = foto;
            this.Id = id;
            this.Nama = nama;
            this.Email = email;
            this.NoTelp = noTelp;
            this.Manajer = manajer;
        }

        public Artis(Image foto, string id, string nama, string email, string noTelp, string password, Manajer manajer)
        {
            this.Foto = foto;
            this.Id = id;
            this.Nama = nama;
            this.Email = email;
            this.NoTelp = noTelp;
            this.Password = password;
            this.Manajer = manajer;
        }
        #endregion

        #region properties
        public Image Foto { get => foto; set => foto = value; }
        public string Id { get => id; set => id = value; }
        public string Nama { get => nama; set => nama = value; }
        public string Email { get => email; set => email = value; }
        public string NoTelp { get => noTelp; set => noTelp = value; }
        public string Password { get => password; set => password = value; }
        public Manajer Manajer { get => manajer; set => manajer = value; }
        #endregion

        #region methods
        public static void TambahData(Artis a)
        {
            byte[] IV = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            AES aes = new AES();
            string encrypted = aes.Encrypt(a.Password, "1111111111111111", IV);

            string sql = "insert into artis (id_artis, nama, email, no_telp, password, foto, manajer_id_manajer) "
                + " values ('" + a.Id + "','" + a.Nama + "','" + a.Email + "','" + a.NoTelp + "',"
                + "SHA2('" + encrypted + @"', 512), LOAD_FILE('C:\\\.wkwk\\\.UBAYA\\\.PELAJARAN\\\SEMESTER 4\\\Information Security and Assurance\\\PROJECT UTS\\\export image\\\" + a.Nama + " fotowoy.png'), '" + a.Manajer.Id + "');";


            Koneksi.JalankanPerintahDML(sql);
        }

        public static string GenerateId()
        {
            string sql = "SELECT id_artis FROM artis ORDER BY id_artis DESC LIMIT 1";

            string hasilKode = "";

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            if (hasil.Read() == true)
            {
                string kode = hasil.GetValue(0).ToString();
                int kodeDalamInt = int.Parse(kode.Substring(kode.Length - 4));

                int angkaKodeTerbaru = kodeDalamInt + 1;
                hasilKode = "A" + angkaKodeTerbaru.ToString("D4");
            }
            else
            {
                hasilKode = "A0001";
            }
            return hasilKode;
        }

        public static List<Artis> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql = "";
            if (kriteria == "")
            {
                sql = "SELECT id_artis, nama, email, no_telp, foto, manajer_id_manajer FROM artis; ";
            }
            else
            {
                sql = "SELECT id_artis, nama, email, no_telp, foto, manajer_id_manajer FROM artis WHERE " + kriteria + " LIKE '%" + nilaiKriteria + "%'";
            }

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            List<Artis> listArtis = new List<Artis>();

            while (hasil.Read() == true)
            {
                string sql2 = "SELECT id_manajer, nama, email, alamat, no_telp FROM manajer WHERE id_manajer LIKE '%" + hasil.GetValue(5).ToString() + "%'";
                MySqlDataReader hasil2 = Koneksi.JalankanPerintahQuery(sql2);

                while (hasil2.Read() == true)
                {
                    Manajer manajer = new Manajer(hasil2.GetValue(0).ToString(), hasil2.GetValue(1).ToString(), hasil2.GetValue(2).ToString(), hasil2.GetValue(3).ToString(), hasil2.GetValue(4).ToString());

                    byte[] imageBytes = (byte[])hasil.GetValue(4);
                    MemoryStream ms = new MemoryStream(imageBytes);
                    Image foto = System.Drawing.Image.FromStream(ms);

                    Artis a = new Artis(foto, hasil.GetValue(0).ToString(), hasil.GetValue(1).ToString(), hasil.GetValue(2).ToString(), hasil.GetValue(3).ToString(), manajer);

                    listArtis.Add(a);
                }
            }

            return listArtis;
        }

        public static Artis CekLogin(string email, string password)
        {
            byte[] IV = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            AES aes = new AES();
            string decrypted = aes.Encrypt(password, "1111111111111111", IV);

            string sql = "";
            sql = "SELECT * FROM artis WHERE email ='" + email + "' AND password = SHA2('" + decrypted + "', 512); ";

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            while (hasil.Read() == true)
            {
                string sql2 = "SELECT id_manajer, nama, email, alamat, no_telp FROM manajer WHERE id_manajer LIKE '%" + hasil.GetValue(6).ToString() + "%'";
                MySqlDataReader hasil2 = Koneksi.JalankanPerintahQuery(sql2);

                while (hasil2.Read() == true)
                {
                    Manajer manajer = new Manajer(hasil2.GetValue(0).ToString(), hasil2.GetValue(1).ToString(), hasil2.GetValue(2).ToString(), hasil2.GetValue(3).ToString(), hasil2.GetValue(4).ToString());

                    byte[] imageBytes = (byte[])hasil.GetValue(5);
                    MemoryStream ms = new MemoryStream(imageBytes);
                    Image foto = System.Drawing.Image.FromStream(ms);

                    Artis a = new Artis(foto, hasil.GetValue(0).ToString(), hasil.GetValue(1).ToString(), hasil.GetValue(2).ToString(), hasil.GetValue(3).ToString(), hasil.GetValue(4).ToString(), manajer);

                    return a;
                }
            }
            return null;
        }
        #endregion
    }
}
