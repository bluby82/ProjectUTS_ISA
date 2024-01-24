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
    public partial class FormUbahJadwal : Form
    {
        public FormUbahJadwal()
        {
            InitializeComponent();
        }

        public void FormUbahJadwal_Load(object sender, EventArgs e)
        {
            idTextBox.ReadOnly = true;
            namaArtisTextBox.ReadOnly = true;
            namaTextBox.ReadOnly = true;
        }

        public void keluarButton_Click(object sender, EventArgs e)
        {
            FormTampilJadwalArtisSaya formTampilJadwalArtisSaya = (FormTampilJadwalArtisSaya)this.Owner;
            formTampilJadwalArtisSaya.FormTampilJadwalArtisSaya_Load(keluarButton, e);

            this.Close();
        }

        public void ubahButton_Click(object sender, EventArgs e)
        {
            Jadwal j = new Jadwal(idTextBox.Text, mulaiDateTimePicker.Value, selesaiDateTimePicker.Value);
            Jadwal.UbahData(j);
            MessageBox.Show("Data telah diubah.", "Informasi");
            this.Close();
        }
    }
}
