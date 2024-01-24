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
    public partial class FormTampilJadwalSaya : Form
    {
        public FormTampilJadwalSaya()
        {
            InitializeComponent();
        }

        List<Jadwal> listJadwal = new List<Jadwal>();

        private void FormTampilJadwalSaya_Load(object sender, EventArgs e)
        {
            FormatDataGrid();

            FormUtama formUtama = (FormUtama)this.MdiParent;

            listJadwal = Jadwal.BacaData("artis_id_artis", formUtama.artis.Id);

            TampilDataGrid();

            DataGridViewButtonColumn bcol = new DataGridViewButtonColumn();
            bcol.HeaderText = "Print";
            bcol.Text = "Print Kontrak";
            bcol.Name = "btnPrintGrid";
            bcol.UseColumnTextForButtonValue = true;
            dataGridViewJadwal.Columns.Add(bcol);
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

        private void dataGridViewJadwal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string idJadwal = dataGridViewJadwal.CurrentRow.Cells["id"].Value.ToString();

            Jadwal j = Jadwal.AmbilDataByID(idJadwal);

            if (e.ColumnIndex == dataGridViewJadwal.Columns["btnPrintGrid"].Index && e.RowIndex >= 0)
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
    }
}
