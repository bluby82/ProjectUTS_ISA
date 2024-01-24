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
    public partial class FormUtama : Form
    {
        public FormUtama()
        {
            InitializeComponent();
        }

        public Artis artis = null;
        public Manajer manajer = null;
        public Admin admin = null;

        private void FormUtama_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;

            Koneksi koneksi = new Koneksi(db.Default.DbServer, db.Default.DbName, db.Default.DbUsername, db.Default.DbPassword);

            FormLogin formLogin = new FormLogin();
            formLogin.Owner = this;

            if(formLogin.ShowDialog() == DialogResult.OK)
            {
                this.WindowState = FormWindowState.Maximized;

                if (!(artis is null))
                {
                    tampilkanJadwalSayaToolStripMenuItem.Visible = true;
                    tampilkanProfilSayaToolStripMenuItem.Visible = true;

                    jadwalToolStripMenuItem.Visible = true;
                    artisToolStripMenuItem.Visible = true;

                    idLabel.Text = artis.Id;
                    namaLabel.Text = artis.Nama;
                }
                else if(!(manajer is null))
                {
                    tampilkanArtisSayaToolStripMenuItem.Visible = true;
                    tampilkanJadwalArtisSayaToolStripMenuItem.Visible = true;
                    tambahkanJadwalToolStripMenuItem.Visible = true;

                    jadwalToolStripMenuItem.Visible = true;
                    artisToolStripMenuItem.Visible = true;

                    idLabel.Text = manajer.Id;
                    namaLabel.Text = manajer.Nama;
                }
                else if (!(admin is null))
                {
                    jadwalToolStripMenuItem.Visible = true;
                    tampilkanSemuaJadwalToolStripMenuItem.Visible = true;

                    artisToolStripMenuItem.Visible = true;
                    tambahkanArtisToolStripMenuItem.Visible = true;
                    tampilkanArtisToolStripMenuItem.Visible = true;

                    manajerToolStripMenuItem.Visible = true;
                    tambahkanManajerToolStripMenuItem.Visible = true;
                    tampilkanManajerToolStripMenuItem.Visible = true;

                    idLabel.Text = admin.Id;
                    namaLabel.Text = admin.Nama;
                }
            }
            else
            {
                Application.Exit();
            }
        }

        private void tambahkanArtisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormTambahArtis"];

            if (form == null)
            {
                FormTambahArtis formTambahArtis = new FormTambahArtis();
                formTambahArtis.MdiParent = this;
                formTambahArtis.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void tambahkanManajerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormTambahManajer"];

            if (form == null)
            {
                FormTambahManajer formTambahManajer = new FormTambahManajer();
                formTambahManajer.MdiParent = this;
                formTambahManajer.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void keluarAplikasiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tampilkanArtisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormTampilArtis"];

            if (form == null)
            {
                FormTampilArtis formTampilArtis = new FormTampilArtis();
                formTampilArtis.MdiParent = this;
                formTampilArtis.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void tampilkanManajerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormTampilManajer"];

            if (form == null)
            {
                FormTampilManajer formTampilManajer = new FormTampilManajer();
                formTampilManajer.MdiParent = this;
                formTampilManajer.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void tampilkanArtisSayaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormTampilArtisSaya"];

            if (form == null)
            {
                FormTampilArtisSaya formTampilArtisSaya = new FormTampilArtisSaya();
                formTampilArtisSaya.MdiParent = this;
                formTampilArtisSaya.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void tampilkanJadwalArtisSayaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormTampilJadwalArtisSaya"];

            if (form == null)
            {
                FormTampilJadwalArtisSaya formTampilJadwalArtisSaya = new FormTampilJadwalArtisSaya();
                formTampilJadwalArtisSaya.MdiParent = this;
                formTampilJadwalArtisSaya.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void tampilkanJadwalSayaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormTampilJadwalSaya"];

            if (form == null)
            {
                FormTampilJadwalSaya formTampilJadwalSaya = new FormTampilJadwalSaya();
                formTampilJadwalSaya.MdiParent = this;
                formTampilJadwalSaya.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void tambahkanJadwalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormTambahJadwal"];

            if (form == null)
            {
                FormTambahJadwal formTambahJadwal = new FormTambahJadwal();
                formTambahJadwal.MdiParent = this;
                formTambahJadwal.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void tampilkanProfilSayaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormProfil"];

            if (form == null)
            {
                FormProfil formProfil = new FormProfil();
                formProfil.MdiParent = this;
                formProfil.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void tampilkanSemuaJadwalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormTampilJadwal"];

            if (form == null)
            {
                FormTampilJadwal formTampilJadwal = new FormTampilJadwal();
                formTampilJadwal.MdiParent = this;
                formTampilJadwal.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }
    }
}
