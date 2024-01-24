using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectUTS_ISA
{
    public partial class FormTambahArtis : Form
    {
        public FormTambahArtis()
        {
            InitializeComponent();
        }

        List<Manajer> listManajer = new List<Manajer>();

        private void FormTambahArtis_Load(object sender, EventArgs e)
        {
            fotoPictureBox.ImageLocation = @"C:\.wkwk\.UBAYA\.PELAJARAN\SEMESTER 4\Information Security and Assurance\PROJECT UTS\aset\placeholder.png";

            string kodeBaru = Artis.GenerateId();

            idTextBox.Text = kodeBaru;


            listManajer = Manajer.BacaData("", "");

            manajerComboBox.DataSource = listManajer;
            manajerComboBox.DisplayMember = "Nama";
        }

        private void uploadButton_Click(object sender, EventArgs e)
        {
            string imageLocation = "";

            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "PNG files(*.png)|*.png";

                if(dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    imageLocation = dialog.FileName;

                    fotoPictureBox.ImageLocation = imageLocation;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void tambahButton_Click(object sender, EventArgs e)
        {
            Bitmap bmp = Steganography.embedText(alamatTextBox.Text, (Bitmap)fotoPictureBox.Image);

            string location = @"C:\.wkwk\.UBAYA\.PELAJARAN\SEMESTER 4\Information Security and Assurance\PROJECT UTS\export image";
            string path = Path.Combine(location, namaTextBox.Text + " fotowoy.png");

            Image img = (Image)bmp;

            img.Save(path);

            Artis a = new Artis(img
                , idTextBox.Text, namaTextBox.Text, emailTextBox.Text, telpTextBox.Text, passwordTextBox.Text
                , (Manajer)manajerComboBox.SelectedItem);

            Artis.TambahData(a);

            MessageBox.Show("Pendaftaran berhasil!", "Informasi");

            this.Close();
        }

        private void kosongiButton_Click(object sender, EventArgs e)
        {
            fotoPictureBox.ImageLocation = @"C:\.wkwk\.UBAYA\.PELAJARAN\SEMESTER 4\Information Security and Assurance\PROJECT UTS\aset\placeholder.png";

            namaTextBox.Text = "";
            emailTextBox.Text = "";
            alamatTextBox.Text = "";
            telpTextBox.Text = "";
            passwordTextBox.Text = "";
        }

        private void keluarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
