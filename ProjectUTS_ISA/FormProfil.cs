using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectUTS_ISA
{
    public partial class FormProfil : Form
    {
        public FormProfil()
        {
            InitializeComponent();
        }

        private void FormProfil_Load(object sender, EventArgs e)
        {
            FormUtama form = (FormUtama)this.MdiParent;

            fotoPictureBox.Image = form.artis.Foto;
            idLbl.Text = "ID: " + form.artis.Id;
            namaLbl.Text = "Nama: " + form.artis.Nama;
            emailLbl.Text = "Email: " + form.artis.Email;
            telpLbl.Text = "Nomor Telepon: " + form.artis.NoTelp;
            namaManajerLbl.Text = "Nama Manajer: " + form.artis.Manajer.Nama;

            Bitmap bmp = (Bitmap)form.artis.Foto;
            string alamat = Steganography.extractText(bmp);

            alamatLbl.Text = "Alamat: " + alamat;
        }

        private void keluarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
