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
    public partial class FormTambahAdmin : Form
    {
        public FormTambahAdmin()
        {
            InitializeComponent();
        }

        private void daftarButton_Click(object sender, EventArgs e)
        {
            if(kodeTextBox.Text == "MAR10")
            {
                string kodeBaru = Admin.GenerateId();

                Admin adm = new Admin(kodeBaru, namaTextBox.Text, emailTextBox.Text, passwordTextBox.Text);

                Admin.TambahData(adm);

                MessageBox.Show("Pendaftaran berhasil!", "Informasi");

                namaTextBox.Clear();
                emailTextBox.Clear();
                passwordTextBox.Clear();
                kodeTextBox.Clear();
            }
            else
            {
                MessageBox.Show("Kode salah!", "Kesalahan");
                this.Close();
            }
        }

        private void kembaliButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void stegoPictureBox_Click(object sender, EventArgs e)
        {

        }

        private void FormTambahAdmin_Load(object sender, EventArgs e)
        {
            kodeTextBox.UseSystemPasswordChar = true;
        }
    }
}
