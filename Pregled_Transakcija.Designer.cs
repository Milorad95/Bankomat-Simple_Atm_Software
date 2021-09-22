
namespace Bankomat
{
    partial class Pregled_Transakcija
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.RacunID = new System.Windows.Forms.ColumnHeader();
            this.Uplata = new System.Windows.Forms.ColumnHeader();
            this.Isplata = new System.Windows.Forms.ColumnHeader();
            this.Datum_transakcije = new System.Windows.Forms.ColumnHeader();
            this.lblIme = new System.Windows.Forms.Label();
            this.lblPrezime = new System.Windows.Forms.Label();
            this.lblTip = new System.Windows.Forms.Label();
            this.lblDatum = new System.Windows.Forms.Label();
            this.lblVreme = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.RacunID,
            this.Uplata,
            this.Isplata,
            this.Datum_transakcije});
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(3, 149);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(420, 254);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // RacunID
            // 
            this.RacunID.Text = "RacunID";
            // 
            // Uplata
            // 
            this.Uplata.Text = "Uplata";
            this.Uplata.Width = 120;
            // 
            // Isplata
            // 
            this.Isplata.Text = "Isplata";
            this.Isplata.Width = 120;
            // 
            // Datum_transakcije
            // 
            this.Datum_transakcije.Text = "Datum transakcije";
            this.Datum_transakcije.Width = 120;
            // 
            // lblIme
            // 
            this.lblIme.AutoSize = true;
            this.lblIme.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lblIme.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblIme.Location = new System.Drawing.Point(13, 13);
            this.lblIme.Name = "lblIme";
            this.lblIme.Size = new System.Drawing.Size(46, 21);
            this.lblIme.TabIndex = 1;
            this.lblIme.Text = "Ime: ";
            // 
            // lblPrezime
            // 
            this.lblPrezime.AutoSize = true;
            this.lblPrezime.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lblPrezime.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPrezime.Location = new System.Drawing.Point(13, 55);
            this.lblPrezime.Name = "lblPrezime";
            this.lblPrezime.Size = new System.Drawing.Size(76, 21);
            this.lblPrezime.TabIndex = 2;
            this.lblPrezime.Text = "Prezime: ";
            // 
            // lblTip
            // 
            this.lblTip.AutoSize = true;
            this.lblTip.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lblTip.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTip.Location = new System.Drawing.Point(13, 99);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(109, 21);
            this.lblTip.TabIndex = 3;
            this.lblTip.Text = "Tip korisnika: ";
            // 
            // lblDatum
            // 
            this.lblDatum.AutoSize = true;
            this.lblDatum.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lblDatum.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDatum.Location = new System.Drawing.Point(13, 411);
            this.lblDatum.Name = "lblDatum";
            this.lblDatum.Size = new System.Drawing.Size(66, 21);
            this.lblDatum.TabIndex = 4;
            this.lblDatum.Text = "Datum: ";
            // 
            // lblVreme
            // 
            this.lblVreme.AutoSize = true;
            this.lblVreme.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lblVreme.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblVreme.Location = new System.Drawing.Point(13, 449);
            this.lblVreme.Name = "lblVreme";
            this.lblVreme.Size = new System.Drawing.Size(65, 21);
            this.lblVreme.TabIndex = 5;
            this.lblVreme.Text = "Vreme: ";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(330, 439);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 31);
            this.button1.TabIndex = 6;
            this.button1.Text = "Nazad";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Pregled_Transakcija
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(425, 479);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblVreme);
            this.Controls.Add(this.lblDatum);
            this.Controls.Add(this.lblTip);
            this.Controls.Add(this.lblPrezime);
            this.Controls.Add(this.lblIme);
            this.Controls.Add(this.listView1);
            this.Name = "Pregled_Transakcija";
            this.Text = "Pregled_Transakcija";
            this.Load += new System.EventHandler(this.Pregled_Transakcija_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        public System.Windows.Forms.ColumnHeader RacunID;
        public System.Windows.Forms.ColumnHeader Uplata;
        public System.Windows.Forms.ColumnHeader Isplata;
        public System.Windows.Forms.ColumnHeader Datum_transakcije;
        private System.Windows.Forms.Label lblIme;
        private System.Windows.Forms.Label lblPrezime;
        private System.Windows.Forms.Label lblTip;
        private System.Windows.Forms.Label lblDatum;
        private System.Windows.Forms.Label lblVreme;
        private System.Windows.Forms.Button button1;
    }
}