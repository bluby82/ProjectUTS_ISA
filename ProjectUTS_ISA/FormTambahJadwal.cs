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
    public partial class FormTambahJadwal : Form
    {
        public FormTambahJadwal()
        {
            InitializeComponent();
        }

        List<Artis> listArtis = new List<Artis>();

        private void FormTambahJadwal_Load(object sender, EventArgs e)
        {
            string kodeBaru = Jadwal.GenerateId();

            FormUtama formUtama = (FormUtama)this.MdiParent;

            idTextBox.Text = kodeBaru;

            listArtis = Artis.BacaData("manajer_id_manajer", formUtama.manajer.Id);

            artisComboBox.DataSource = listArtis;
            artisComboBox.DisplayMember = "Nama";
        }

        private void tambahButton_Click(object sender, EventArgs e)
        {
            Jadwal j = new Jadwal(idTextBox.Text, (Artis)artisComboBox.SelectedItem, namaTextBox.Text, mulaiDateTimePicker.Value, selesaiDateTimePicker.Value);

            Jadwal.TambahData(j);

            MessageBox.Show("Berhasil ditambahkan!", "Informasi");

            this.Close();
        }

        private void kosongiButton_Click(object sender, EventArgs e)
        {
            namaTextBox.Clear();
        }

        private void keluarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
