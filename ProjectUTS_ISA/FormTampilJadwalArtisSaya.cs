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
    public partial class FormTampilJadwalArtisSaya : Form
    {
        public FormTampilJadwalArtisSaya()
        {
            InitializeComponent();
        }

        List<Jadwal> listJadwal = new List<Jadwal>();
        List<Artis> listArtis = new List<Artis>();

        public void FormTampilJadwalArtisSaya_Load(object sender, EventArgs e)
        {
            FormatDataGrid();

            FormUtama formUtama = (FormUtama)this.MdiParent;

            listArtis = Artis.BacaData("manajer_id_manajer", formUtama.manajer.Id);

            foreach(Artis a in listArtis)
            {
                List<Jadwal> listJadwalArtisIni = Jadwal.BacaData("artis_id_artis", a.Id);

                foreach (Jadwal j in listJadwalArtisIni)
                {
                    listJadwal.Add(j);
                }
            }

            TampilDataGrid();

            DataGridViewButtonColumn bcol = new DataGridViewButtonColumn();
            bcol.HeaderText = "Ubah";
            bcol.Text = "Ubah Jadwal";
            bcol.Name = "btnUbahGrid";
            bcol.UseColumnTextForButtonValue = true;
            dataGridViewJadwal.Columns.Add(bcol);

            DataGridViewButtonColumn bcol2 = new DataGridViewButtonColumn();
            bcol2.HeaderText = "Print";
            bcol2.Text = "Print Kontrak";
            bcol2.Name = "btnPrintGrid";
            bcol2.UseColumnTextForButtonValue = true;
            dataGridViewJadwal.Columns.Add(bcol2);
        }

        private void dataGridViewJadwal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string idJadwal = dataGridViewJadwal.CurrentRow.Cells["id"].Value.ToString();

            Jadwal j = Jadwal.AmbilDataByID(idJadwal); 

            if (e.ColumnIndex == dataGridViewJadwal.Columns["btnUbahGrid"].Index && e.RowIndex >= 0)
            {
                if (j != null)
                {
                    FormUbahJadwal frm = new FormUbahJadwal();
                    frm.Owner = this;
                    frm.idTextBox.Text = dataGridViewJadwal.CurrentRow.Cells["id"].Value.ToString();
                    frm.namaArtisTextBox.Text = dataGridViewJadwal.CurrentRow.Cells["namaArtis"].Value.ToString();
                    frm.namaTextBox.Text = dataGridViewJadwal.CurrentRow.Cells["nama"].Value.ToString();
                    frm.mulaiDateTimePicker.Value = DateTime.Parse(dataGridViewJadwal.CurrentRow.Cells["tglMulai"].Value.ToString());
                    frm.selesaiDateTimePicker.Value = DateTime.Parse(dataGridViewJadwal.CurrentRow.Cells["tglSelesai"].Value.ToString());
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Terdapat kesalahan pada data");
                }
            }
            else if(e.ColumnIndex == dataGridViewJadwal.Columns["btnPrintGrid"].Index && e.RowIndex >= 0)
            {
                if (j != null)
                {
                    string namaFile = "Kontrak " + j.Id;
                    Jadwal.CetakKontrak(j, namaFile, new Font("Courier New", 14));
                }
                else
                {
                    MessageBox.Show("Terdapat kesalahan pada data");
                }
            }
        }

        private void FormatDataGrid()
        {
            dataGridViewJadwal.Columns.Clear();

            dataGridViewJadwal.Columns.Add("id", "ID");
            dataGridViewJadwal.Columns.Add("namaArtis", "Nama Artis");
            dataGridViewJadwal.Columns.Add("nama", "Nama");
            dataGridViewJadwal.Columns.Add("tglMulai", "Tanggal Mulai");
            dataGridViewJadwal.Columns.Add("tglSelesai", "Tanggal Selesai");

            dataGridViewJadwal.Columns["id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewJadwal.Columns["namaArtis"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewJadwal.Columns["nama"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewJadwal.Columns["tglMulai"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewJadwal.Columns["tglSelesai"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridViewJadwal.AllowUserToAddRows = false;
            dataGridViewJadwal.ReadOnly = true;
        }

        private void TampilDataGrid()
        {
            dataGridViewJadwal.Rows.Clear();

            if (listJadwal.Count > 0)
            {
                foreach (Jadwal j in listJadwal)
                {
                    dataGridViewJadwal.Rows.Add(j.Id, j.Artis.Nama, j.NamaAcara, j.TglMulai.ToShortDateString(), j.TglSelesai.ToShortDateString());
                }
            }
            else
            {
                dataGridViewJadwal.DataSource = null;
            }
        }
    }
}
