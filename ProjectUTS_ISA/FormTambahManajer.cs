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
    public partial class FormTambahManajer : Form
    {
        public FormTambahManajer()
        {
            InitializeComponent();
        }

        private void tambahButton_Click(object sender, EventArgs e)
        {
            Manajer mnj = new Manajer(idTextBox.Text, namaTextBox.Text, emailTextBox.Text, alamatTextBox.Text , telpTextBox.Text ,passwordTextBox.Text);

            Manajer.TambahData(mnj);

            MessageBox.Show("Pendaftaran berhasil!", "Informasi");

            this.Close();
        }

        private void kosongiButton_Click(object sender, EventArgs e)
        {
            namaTextBox.Clear();
            emailTextBox.Clear();
            alamatTextBox.Clear();
            telpTextBox.Clear();
            passwordTextBox.Clear();
        }

        private void keluarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormTambahManajer_Load(object sender, EventArgs e)
        {
            string kodeBaru = Manajer.GenerateId();

            idTextBox.Text = kodeBaru;
        }
    }
}
