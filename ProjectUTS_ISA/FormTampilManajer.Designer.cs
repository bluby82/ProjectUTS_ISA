
namespace ProjectUTS_ISA
{
    partial class FormTampilManajer
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
            this.dataGridViewManajer = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewManajer)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewManajer
            // 
            this.dataGridViewManajer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewManajer.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewManajer.Name = "dataGridViewManajer";
            this.dataGridViewManajer.Size = new System.Drawing.Size(837, 425);
            this.dataGridViewManajer.TabIndex = 0;
            // 
            // FormTampilManajer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 449);
            this.Controls.Add(this.dataGridViewManajer);
            this.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormTampilManajer";
            this.Text = "Manajer";
            this.Load += new System.EventHandler(this.FormTampilManajer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewManajer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewManajer;
    }
}