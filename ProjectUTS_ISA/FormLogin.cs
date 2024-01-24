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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void registerAdminLabel_Click(object sender, EventArgs e)
        {
            registerAdminLabel.ForeColor = Color.Blue;

            FormTambahAdmin formDaftarAdmin = new FormTambahAdmin();
            formDaftarAdmin.Owner = this;
            formDaftarAdmin.ShowDialog();
        }

        private void registerAdminLabel_MouseHover(object sender, EventArgs e)
        {
            registerAdminLabel.ForeColor = Color.Blue;
        }

        private void registerAdminLabel_MouseLeave(object sender, EventArgs e)
        {
            registerAdminLabel.ForeColor = Color.Black;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi koneksi = new Koneksi();

                Admin ad = Admin.CekLogin(emailTextBox.Text, passwordTextBox.Text);
                Manajer m = Manajer.CekLogin(emailTextBox.Text, passwordTextBox.Text);
                Artis a = Artis.CekLogin(emailTextBox.Text, passwordTextBox.Text);

                if (!(ad is null))
                {
                    FormUtama formUtama = (FormUtama)this.Owner;
                    formUtama.admin = ad;

                    MessageBox.Show("Koneksi berhasil. Masuk sebagai ADMIN.", "Informasi");

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else if (!(m is null))
                {
                    FormUtama formUtama = (FormUtama)this.Owner;
                    formUtama.manajer = m;

                    MessageBox.Show("Koneksi berhasil. Masuk sebagai MANAJER.", "Informasi");

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else if (!(a is null))
                {
                    FormUtama formUtama = (FormUtama)this.Owner;
                    formUtama.artis = a;

                    MessageBox.Show("Koneksi berhasil. Masuk sebagai ARTIS.", "Informasi");

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(this, "Username tidak ditemukan atau password salah");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Koneksi gagal. Pesan kesalahan : " + ex.Message, "Kesalahan");
            }
        }
    }
}
