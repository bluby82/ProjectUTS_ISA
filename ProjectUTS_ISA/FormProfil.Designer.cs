
namespace ProjectUTS_ISA
{
    partial class FormProfil
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
            this.fotoPictureBox = new System.Windows.Forms.PictureBox();
            this.keluarButton = new System.Windows.Forms.Button();
            this.idLbl = new System.Windows.Forms.Label();
            this.namaLbl = new System.Windows.Forms.Label();
            this.emailLbl = new System.Windows.Forms.Label();
            this.telpLbl = new System.Windows.Forms.Label();
            this.alamatLbl = new System.Windows.Forms.Label();
            this.namaManajerLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fotoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // fotoPictureBox
            // 
            this.fotoPictureBox.Location = new System.Drawing.Point(26, 26);
            this.fotoPictureBox.Name = "fotoPictureBox";
            this.fotoPictureBox.Size = new System.Drawing.Size(178, 232);
            this.fotoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.fotoPictureBox.TabIndex = 0;
            this.fotoPictureBox.TabStop = false;
            // 
            // keluarButton
            // 
            this.keluarButton.Location = new System.Drawing.Point(406, 277);
            this.keluarButton.Name = "keluarButton";
            this.keluarButton.Size = new System.Drawing.Size(75, 23);
            this.keluarButton.TabIndex = 1;
            this.keluarButton.Text = "Keluar";
            this.keluarButton.UseVisualStyleBackColor = true;
            this.keluarButton.Click += new System.EventHandler(this.keluarButton_Click);
            // 
            // idLbl
            // 
            this.idLbl.AutoSize = true;
            this.idLbl.Location = new System.Drawing.Point(242, 35);
            this.idLbl.Name = "idLbl";
            this.idLbl.Size = new System.Drawing.Size(21, 13);
            this.idLbl.TabIndex = 2;
            this.idLbl.Text = "ID:";
            // 
            // namaLbl
            // 
            this.namaLbl.AutoSize = true;
            this.namaLbl.Location = new System.Drawing.Point(242, 74);
            this.namaLbl.Name = "namaLbl";
            this.namaLbl.Size = new System.Drawing.Size(38, 13);
            this.namaLbl.TabIndex = 3;
            this.namaLbl.Text = "Nama:";
            // 
            // emailLbl
            // 
            this.emailLbl.AutoSize = true;
            this.emailLbl.Location = new System.Drawing.Point(242, 113);
            this.emailLbl.Name = "emailLbl";
            this.emailLbl.Size = new System.Drawing.Size(35, 13);
            this.emailLbl.TabIndex = 4;
            this.emailLbl.Text = "Email:";
            // 
            // telpLbl
            // 
            this.telpLbl.AutoSize = true;
            this.telpLbl.Location = new System.Drawing.Point(242, 154);
            this.telpLbl.Name = "telpLbl";
            this.telpLbl.Size = new System.Drawing.Size(83, 13);
            this.telpLbl.TabIndex = 5;
            this.telpLbl.Text = "Nomor Telepon:";
            // 
            // alamatLbl
            // 
            this.alamatLbl.AutoSize = true;
            this.alamatLbl.Location = new System.Drawing.Point(242, 196);
            this.alamatLbl.Name = "alamatLbl";
            this.alamatLbl.Size = new System.Drawing.Size(42, 13);
            this.alamatLbl.TabIndex = 6;
            this.alamatLbl.Text = "Alamat:";
            // 
            // namaManajerLbl
            // 
            this.namaManajerLbl.AutoSize = true;
            this.namaManajerLbl.Location = new System.Drawing.Point(242, 236);
            this.namaManajerLbl.Name = "namaManajerLbl";
            this.namaManajerLbl.Size = new System.Drawing.Size(79, 13);
            this.namaManajerLbl.TabIndex = 7;
            this.namaManajerLbl.Text = "Nama Manajer:";
            // 
            // FormProfil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 312);
            this.Controls.Add(this.namaManajerLbl);
            this.Controls.Add(this.alamatLbl);
            this.Controls.Add(this.telpLbl);
            this.Controls.Add(this.emailLbl);
            this.Controls.Add(this.namaLbl);
            this.Controls.Add(this.idLbl);
            this.Controls.Add(this.keluarButton);
            this.Controls.Add(this.fotoPictureBox);
            this.Name = "FormProfil";
            this.Text = "FormProfil";
            this.Load += new System.EventHandler(this.FormProfil_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fotoPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox fotoPictureBox;
        private System.Windows.Forms.Button keluarButton;
        private System.Windows.Forms.Label idLbl;
        private System.Windows.Forms.Label namaLbl;
        private System.Windows.Forms.Label emailLbl;
        private System.Windows.Forms.Label telpLbl;
        private System.Windows.Forms.Label alamatLbl;
        private System.Windows.Forms.Label namaManajerLbl;
    }
}