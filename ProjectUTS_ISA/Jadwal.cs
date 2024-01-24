using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Security.Cryptography;
using System.IO;
using System.Drawing;

namespace ProjectUTS_ISA
{
    public class Jadwal
    {
        #region data members
        private string id;
        private Artis artis;
        private string namaAcara;
        private DateTime tglMulai;
        private DateTime tglSelesai;
        #endregion

        #region constructors
        public Jadwal()
        {

        }

        public Jadwal(string id, DateTime tglMulai, DateTime tglSelesai)
        {
            this.Id = id;
            this.TglMulai = tglMulai;
            this.TglSelesai = tglSelesai;
        }

        public Jadwal(string id, Artis artis, string namaAcara, DateTime tglMulai, DateTime tglSelesai)
        {
            this.Id = id;
            this.Artis = artis;
            this.NamaAcara = namaAcara;
            this.TglMulai = tglMulai;
            this.TglSelesai = tglSelesai;
        }
        #endregion

        #region properties
        public string Id { get => id; set => id = value; }
        public Artis Artis { get => artis; set => artis = value; }
        public string NamaAcara { get => namaAcara; set => namaAcara = value; }
        public DateTime TglMulai { get => tglMulai; set => tglMulai = value; }
        public DateTime TglSelesai { get => tglSelesai; set => tglSelesai = value; }
        #endregion

        #region methods
        public static void TambahData(Jadwal j)
        {
            DateTime tanggalMulai = j.TglMulai;
            string tglMulai = tanggalMulai.ToString("dd/MM/yyyy").Replace('/', '-');

            DateTime tanggalSelesai = j.TglSelesai;
            string tglSelesai = tanggalSelesai.ToString("dd/MM/yyyy").Replace('/', '-');

            string sql = "INSERT INTO jadwal (id_jadwal, artis_id_artis, nama_acara, tanggal_mulai, tanggal_selesai)" +
                " VALUES ('" + j.Id + "','" + j.Artis.Id + "','" + j.NamaAcara + "', STR_TO_DATE('" + tglMulai + "','%d-%m-%Y'), STR_TO_DATE('" + tglSelesai + "','%d-%m-%Y'))";

            Koneksi.JalankanPerintahDML(sql);
        }

        public static void UbahData(Jadwal j)
        {
            DateTime tanggalMulai = j.TglMulai;
            string tglMulai = tanggalMulai.ToString("dd/MM/yyyy").Replace('/', '-');

            DateTime tanggalSelesai = j.TglSelesai;
            string tglSelesai = tanggalSelesai.ToString("dd/MM/yyyy").Replace('/', '-');

            string sql = "UPDATE jadwal" +
                " SET tanggal_mulai = STR_TO_DATE('" + tglMulai + "','%d-%m-%Y'), tanggal_selesai = STR_TO_DATE('" + tglSelesai + "','%d-%m-%Y')" +
                " WHERE id_jadwal = '" + j.Id + "';";

            Koneksi.JalankanPerintahDML(sql);
        }

        public static Jadwal AmbilDataByID(string id)
        {
            string sql = "SELECT * FROM jadwal WHERE id_jadwal = '" + id + "';";

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            Jadwal j = new Jadwal();

            while (hasil.Read() == true)
            {
                string sql2 = "SELECT id_artis, nama, email, no_telp, foto, manajer_id_manajer FROM artis WHERE id_artis LIKE '%" + hasil.GetValue(1).ToString() + "%'";
                MySqlDataReader hasil2 = Koneksi.JalankanPerintahQuery(sql2);

                while (hasil2.Read() == true)
                {
                    string sql3 = "SELECT id_manajer, nama, email, alamat, no_telp FROM manajer WHERE id_manajer LIKE'%" + hasil2.GetValue(5).ToString() + "%'";
                    MySqlDataReader hasil3 = Koneksi.JalankanPerintahQuery(sql3);

                    while (hasil3.Read() == true)
                    {
                        Manajer manajer = new Manajer(hasil3.GetValue(0).ToString(), hasil3.GetValue(1).ToString(), hasil3.GetValue(2).ToString(), hasil3.GetValue(3).ToString(), hasil3.GetValue(4).ToString());

                        Artis artis = new Artis(hasil2.GetValue(0).ToString(), hasil2.GetValue(1).ToString(), hasil2.GetValue(2).ToString(), hasil2.GetValue(3).ToString(), manajer);

                        j = new Jadwal(hasil.GetValue(0).ToString(), artis, hasil.GetValue(2).ToString(), DateTime.Parse(hasil.GetValue(3).ToString()), DateTime.Parse(hasil.GetValue(4).ToString()));
                    }
                }
            }

            return j;
        }

        public static string GenerateId()
        {
            string sql = "SELECT id_jadwal FROM jadwal ORDER BY id_jadwal DESC LIMIT 1";

            string hasilKode = "";

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            if (hasil.Read() == true)
            {
                string kode = hasil.GetValue(0).ToString();
                int kodeDalamInt = int.Parse(kode.Substring(kode.Length - 4));

                int angkaKodeTerbaru = kodeDalamInt + 1;
                hasilKode = "J" + angkaKodeTerbaru.ToString("D4");
            }
            else
            {
                hasilKode = "J0001";
            }
            return hasilKode;
        }

        public static List<Jadwal> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql = "";
            if (kriteria == "")
            {
                sql = "SELECT id_jadwal, artis_id_artis, nama_acara, tanggal_mulai, tanggal_selesai FROM jadwal;";
            }
            else
            {
                sql = "SELECT id_jadwal, artis_id_artis, nama_acara, tanggal_mulai, tanggal_selesai FROM jadwal WHERE " + kriteria + " LIKE '%" + nilaiKriteria + "%'";
            }

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            List<Jadwal> listJadwal = new List<Jadwal>();

            while (hasil.Read() == true)
            {
                string sql2 = "SELECT id_artis, nama, email, no_telp, foto, manajer_id_manajer FROM artis WHERE id_artis LIKE '%" + hasil.GetValue(1).ToString() + "%'";
                MySqlDataReader hasil2 = Koneksi.JalankanPerintahQuery(sql2);

                while (hasil2.Read() == true)
                {
                    string sql3 = "SELECT id_manajer, nama, email, alamat, no_telp FROM manajer WHERE id_manajer LIKE'%" + hasil2.GetValue(5).ToString() + "%'";
                    MySqlDataReader hasil3 = Koneksi.JalankanPerintahQuery(sql3);

                    while (hasil3.Read() == true)
                    {
                        Manajer manajer = new Manajer(hasil3.GetValue(0).ToString(), hasil3.GetValue(1).ToString(), hasil3.GetValue(2).ToString(), hasil3.GetValue(3).ToString(), hasil3.GetValue(4).ToString());

                        Artis artis = new Artis(hasil2.GetValue(0).ToString(), hasil2.GetValue(1).ToString(), hasil2.GetValue(2).ToString(), hasil2.GetValue(3).ToString(),  manajer);

                        Jadwal j = new Jadwal(hasil.GetValue(0).ToString(), artis, hasil.GetValue(2).ToString(), DateTime.Parse(hasil.GetValue(3).ToString()), DateTime.Parse(hasil.GetValue(4).ToString()));

                        listJadwal.Add(j);
                    }
                }
            }

            return listJadwal;
        }

        public static void CetakKontrak (Jadwal j, string alamatFile, Font tipeFont)
        {
            StreamWriter fileCetak = new StreamWriter(alamatFile);

            fileCetak.WriteLine("===============================================");
            fileCetak.WriteLine("---------------- KONTRAK " + j.Id + " ----------------");
            fileCetak.WriteLine("===============================================");
            fileCetak.WriteLine("");
            fileCetak.WriteLine("-------------------- ARTIS --------------------");
            fileCetak.WriteLine("Nama: " + j.Artis.Nama);
            fileCetak.WriteLine("Email: " + j.Artis.Email);
            fileCetak.WriteLine("Nomor Telepon: " + j.Artis.NoTelp);
            fileCetak.WriteLine("");
            fileCetak.WriteLine("===============================================");
            fileCetak.WriteLine("------------------- MANAJER -------------------");
            fileCetak.WriteLine("Nama: " + j.Artis.Manajer.Nama);
            fileCetak.WriteLine("Email: " + j.Artis.Manajer.Email);
            fileCetak.WriteLine("Nomor Telepon: " + j.Artis.Manajer.NoTelp);
            fileCetak.WriteLine("");
            fileCetak.WriteLine("===============================================");
            fileCetak.WriteLine("-------------------- ACARA --------------------");
            fileCetak.WriteLine("Nama: " + j.NamaAcara);
            fileCetak.WriteLine("Tanggal Mulai: " + j.TglMulai.ToShortDateString());
            fileCetak.WriteLine("Tanggal Selesai: " + j.TglSelesai.ToShortDateString());
            fileCetak.Close();

            CustomPrint p = new CustomPrint(tipeFont, alamatFile, 20, 10, 10, 10);
            p.SentToPrinter();
        }
        #endregion
    }
}
