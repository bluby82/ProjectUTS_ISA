using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectUTS_ISA
{
    public class CustomPrint
    {
        private Font tipeFont; //tipe font yang digunakan dalam hasil cetak
        private StreamReader filePrint; //file yang akan dicetak
        private float marginKanan, marginKiri, marginAtas, marginBawah;
        //margin untuk batas kanan kiri atas bawah

        public Font TipeFont { get => tipeFont; set => tipeFont = value; }
        public StreamReader FilePrint { get => filePrint; set => filePrint = value; }
        public float MarginKanan { get => marginKanan; set => marginKanan = value; }
        public float MarginKiri { get => marginKiri; set => marginKiri = value; }
        public float MarginAtas { get => marginAtas; set => marginAtas = value; }
        public float MarginBawah { get => marginBawah; set => marginBawah = value; }

        public CustomPrint(Font pFont, string pAlamatFile, float pKanan, float pKiri, float pAtas, float pBawah)
        {
            TipeFont = pFont;
            FilePrint = new StreamReader(pAlamatFile);
            MarginKanan = pKanan;
            MarginKiri = pKiri;
            MarginAtas = pAtas;
            MarginBawah = pBawah;
        }

        private void Cetak(object sender, PrintPageEventArgs e)
        {
            //e.MarginBounds.Height panjang kertas
            //TipeFont.Height tinggi font
            int maxBaris = (int)((e.MarginBounds.Height - MarginAtas - MarginBawah) / TipeFont.GetHeight(e.Graphics));
            float Y = MarginAtas;
            float X = MarginKiri;
            int jumBaris = 0; //untuk menghitung jumbaris yang sdh ditulis di kertas

            //baca 1 baris dari filetext
            string teksTulis = FilePrint.ReadLine();

            //selama kertas masih cukup dan di filetext masih ada yang bisa dibaca
            while (jumBaris < maxBaris && teksTulis != null)
            {
                //hitung koordinat Y 
                Y = MarginAtas + (jumBaris * TipeFont.GetHeight(e.Graphics));
                //tulis ke kertas
                e.Graphics.DrawString(teksTulis, TipeFont, Brushes.BlueViolet, X, Y);
                //baca kembali isi filetext
                teksTulis = FilePrint.ReadLine();
                //jumbaris ditambah, agar tulisan berikutnya ditulis di bawahnya
                jumBaris++;
            }

            if (teksTulis == null)
                e.HasMorePages = false;
            else
                e.HasMorePages = true; //jika dalam filetext masih ada tulisan yang perlu dicetak, namun jumbaris sdh sama dengan maxbaris, artinya kertas tidak cukup. Jadi ditulis di halaman berikutnya

        }

        public void SentToPrinter()
        {
            PrintDocument p = new PrintDocument();
            //setting default ke pdf
            p.PrinterSettings.PrinterName = "Microsoft Print to PDF";

            //menjalankan method cetak
            //+= untuk mengatur jika butuh lebih dari 1 halaman
            p.PrintPage += new PrintPageEventHandler(Cetak);
            //cetak ke printer
            p.Print();

            //tutup filetext yg dijadikan sumber tulisan
            FilePrint.Close();
        }
    }
}
