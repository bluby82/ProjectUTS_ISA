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
    public partial class FormTampilManajer : Form
    {
        public FormTampilManajer()
        {
            InitializeComponent();
        }

        List<Manajer> listManajer = new List<Manajer>();

        private void FormTampilManajer_Load(object sender, EventArgs e)
        {
            listManajer = Manajer.BacaData("", "");

            if (listManajer.Count > 0)
            {
                dataGridViewManajer.DataSource = listManajer;
            }
            else
            {
                dataGridViewManajer.DataSource = null;
            }

            dataGridViewManajer.Columns["Password"].Visible = false;
        }
    }
}
