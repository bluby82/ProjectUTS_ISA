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
    public partial class FormTampilArtisSaya : Form
    {
        public FormTampilArtisSaya()
        {
            InitializeComponent();
        }

        List<Artis> listArtis = new List<Artis>();

        private void FormTampilArtisSaya_Load(object sender, EventArgs e)
        {
            FormatDataGrid();

            FormUtama formUtama = (FormUtama)this.MdiParent;

            listArtis = Artis.BacaData("manajer_id_manajer", formUtama.manajer.Id);

            TampilDataGrid();

            DataGridViewButtonColumn bcol = new DataGridViewButtonColumn();
            bcol.HeaderText = "Foto";
            bcol.Text = "Simpan Foto";
            bcol.Name = "btnSaveGrid";
            bcol.UseColumnTextForButtonValue = true;
            dataGridViewArtis.Columns.Add(bcol);
        }

        private void FormatDataGrid()
        {
            dataGridViewArtis.Columns.Clear();

            dataGridViewArtis.Columns.Add("id", "ID");
            dataGridViewArtis.Columns.Add("nama", "Nama");
            dataGridViewArtis.Columns.Add("email", "Email");
            dataGridViewArtis.Columns.Add("noTelp", "Nomor Telepon");

            dataGridViewArtis.Columns["id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewArtis.Columns["nama"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewArtis.Columns["email"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewArtis.Columns["noTelp"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridViewArtis.AllowUserToAddRows = false;
            dataGridViewArtis.ReadOnly = true;
        }

        private void TampilDataGrid()
        {
            dataGridViewArtis.Rows.Clear();

            if (listArtis.Count > 0)
            {
                foreach (Artis a in listArtis)
                {
                    dataGridViewArtis.Rows.Add(a.Id, a.Nama, a.Email, a.NoTelp);
                }
            }
            else
            {
                dataGridViewArtis.DataSource = null;
            }
        }

        private void dataGridViewArtis_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string kodeArtis = dataGridViewArtis.CurrentRow.Cells["id"].Value.ToString();

            List<Artis> artisDipilih = new List<Artis>();

            artisDipilih = Artis.BacaData("id_artis", kodeArtis);

            Artis artis = null;

            foreach (Artis a in artisDipilih)
            {
                artis = a;
            }

            Image img = artis.Foto;

            try
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "JPG(*.JPG|*.jpg";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    img.Save(dialog.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
