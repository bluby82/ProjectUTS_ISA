
namespace ProjectUTS_ISA
{
    partial class FormUbahJadwal
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
            this.selesaiDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.mulaiDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.keluarButton = new System.Windows.Forms.Button();
            this.ubahButton = new System.Windows.Forms.Button();
            this.namaTextBox = new System.Windows.Forms.TextBox();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.namaArtisTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // selesaiDateTimePicker
            // 
            this.selesaiDateTimePicker.AccessibleDescription = "";
            this.selesaiDateTimePicker.Location = new System.Drawing.Point(169, 235);
            this.selesaiDateTimePicker.Name = "selesaiDateTimePicker";
            this.selesaiDateTimePicker.Size = new System.Drawing.Size(181, 20);
            this.selesaiDateTimePicker.TabIndex = 49;
            // 
            // mulaiDateTimePicker
            // 
            this.mulaiDateTimePicker.AccessibleDescription = "";
            this.mulaiDateTimePicker.Location = new System.Drawing.Point(169, 196);
            this.mulaiDateTimePicker.Name = "mulaiDateTimePicker";
            this.mulaiDateTimePicker.Size = new System.Drawing.Size(181, 20);
            this.mulaiDateTimePicker.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 47;
            this.label5.Text = "Artis";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label7.Font = new System.Drawing.Font("Franklin Gothic Medium", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(25, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(325, 46);
            this.label7.TabIndex = 46;
            this.label7.Text = "UBAH JADWAL";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // keluarButton
            // 
            this.keluarButton.Location = new System.Drawing.Point(273, 287);
            this.keluarButton.Name = "keluarButton";
            this.keluarButton.Size = new System.Drawing.Size(75, 23);
            this.keluarButton.TabIndex = 45;
            this.keluarButton.Text = "Keluar";
            this.keluarButton.UseVisualStyleBackColor = true;
            this.keluarButton.Click += new System.EventHandler(this.keluarButton_Click);
            // 
            // ubahButton
            // 
            this.ubahButton.Location = new System.Drawing.Point(25, 287);
            this.ubahButton.Name = "ubahButton";
            this.ubahButton.Size = new System.Drawing.Size(75, 23);
            this.ubahButton.TabIndex = 43;
            this.ubahButton.Text = "Ubah";
            this.ubahButton.UseVisualStyleBackColor = true;
            this.ubahButton.Click += new System.EventHandler(this.ubahButton_Click);
            // 
            // namaTextBox
            // 
            this.namaTextBox.AccessibleDescription = "";
            this.namaTextBox.Location = new System.Drawing.Point(169, 162);
            this.namaTextBox.Name = "namaTextBox";
            this.namaTextBox.ReadOnly = true;
            this.namaTextBox.Size = new System.Drawing.Size(183, 20);
            this.namaTextBox.TabIndex = 42;
            // 
            // idTextBox
            // 
            this.idTextBox.AccessibleDescription = "";
            this.idTextBox.Enabled = false;
            this.idTextBox.Location = new System.Drawing.Point(169, 87);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.ReadOnly = true;
            this.idTextBox.Size = new System.Drawing.Size(183, 20);
            this.idTextBox.TabIndex = 41;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 241);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 40;
            this.label4.Text = "Tanggal Selesai";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 39;
            this.label3.Text = "Tanggal Mulai";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 38;
            this.label2.Text = "Nama";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "ID Jadwal";
            // 
            // namaArtisTextBox
            // 
            this.namaArtisTextBox.AccessibleDescription = "";
            this.namaArtisTextBox.Location = new System.Drawing.Point(169, 125);
            this.namaArtisTextBox.Name = "namaArtisTextBox";
            this.namaArtisTextBox.ReadOnly = true;
            this.namaArtisTextBox.Size = new System.Drawing.Size(183, 20);
            this.namaArtisTextBox.TabIndex = 50;
            // 
            // FormUbahJadwal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 328);
            this.Controls.Add(this.namaArtisTextBox);
            this.Controls.Add(this.selesaiDateTimePicker);
            this.Controls.Add(this.mulaiDateTimePicker);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.keluarButton);
            this.Controls.Add(this.ubahButton);
            this.Controls.Add(this.namaTextBox);
            this.Controls.Add(this.idTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormUbahJadwal";
            this.Text = "FormUbahJadwal";
            this.Load += new System.EventHandler(this.FormUbahJadwal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button keluarButton;
        private System.Windows.Forms.Button ubahButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.DateTimePicker selesaiDateTimePicker;
        public System.Windows.Forms.DateTimePicker mulaiDateTimePicker;
        public System.Windows.Forms.TextBox namaTextBox;
        public System.Windows.Forms.TextBox idTextBox;
        public System.Windows.Forms.TextBox namaArtisTextBox;
    }
}