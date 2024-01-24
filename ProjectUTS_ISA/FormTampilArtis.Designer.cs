
namespace ProjectUTS_ISA
{
    partial class FormTampilArtis
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewArtis = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewArtis)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewArtis
            // 
            this.dataGridViewArtis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewArtis.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewArtis.Name = "dataGridViewArtis";
            this.dataGridViewArtis.Size = new System.Drawing.Size(837, 425);
            this.dataGridViewArtis.TabIndex = 1;
            this.dataGridViewArtis.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewArtis_CellContentClick);
            // 
            // FormTampilArtis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 449);
            this.Controls.Add(this.dataGridViewArtis);
            this.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormTampilArtis";
            this.Text = "Artis";
            this.Load += new System.EventHandler(this.FormTampilArtis_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewArtis)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewArtis;
    }
}