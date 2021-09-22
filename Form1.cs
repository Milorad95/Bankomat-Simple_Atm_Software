using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Bankomat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblStatus.Hide();
        }

        private void btnPotvrdi_Click(object sender, EventArgs e)
        {
            Verifikacija(txtPIN.Text);
            txtPIN.Text = string.Empty;
        }

        private void btnPonisti_Click(object sender, EventArgs e)
        {
            lblStatus.Hide();
            txtPIN.Text = string.Empty;
        }
        public void Verifikacija(string pin)
        {
            var connectionString = "Data Source=DESKTOP-ELB063I\\SQLEXPRESS01;Initial Catalog=Banka;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            var nalogKorisnika = new Nalog_korisnika();
            int validator = 0;
            try
            {
                if (pin.Length == 4)
                {
                    con.Open();
                    var command = new SqlCommand($"SELECT ID, StanjeRacuna, PIN FROM Racun WHERE PIN = {int.Parse(pin)}", con);
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (int.Parse(reader["PIN"].ToString()) == int.Parse(pin))
                        {
                            lblStatus.Hide();
                            validator = 1;
                            this.Hide();
                            nalogKorisnika.ID = int.Parse(reader.GetValue("ID").ToString());
                            nalogKorisnika.StanjeRacuna = decimal.Parse(reader.GetValue("StanjeRacuna").ToString());
                            nalogKorisnika.PIN = int.Parse(reader.GetValue("PIN").ToString());
                            nalogKorisnika.Show();
                            break;
                        }
                    }
                    reader.Close();
                }
                else
                {
                    MessageBox.Show($"PIN zahteva unos 4 broja!\nPokusajte ponovo.", "Unos PIN-a", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex) { MessageBox.Show("Greska: " + ex.Message); }
            finally
            {
                con.Close();
                if (validator == 0)
                {
                    lblStatus.Show();
                }
            }
        }
    }
}
