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
            lblStatus.Hide();   /* ova labela se prikazuje ukoliko PIN nije ispravan pri logovanju */
        }

        private void btnPotvrdi_Click(object sender, EventArgs e)
        {
            Verifikacija(txtPIN.Text);      /* proveravanje PIN-a u bazi korisnika */
            txtPIN.Text = string.Empty;     /* brisanje PIN-a iz textboxa */
        }

        /* ova metoda sakriva status PIN-a ukoliko nije ispravan, i brise unos iz textboxa */
        private void btnPonisti_Click(object sender, EventArgs e)
        {
            lblStatus.Hide();
            txtPIN.Text = string.Empty;
        }

        /* verifikacija PIN-a u bazi sa prosledjenim PIN-om sa forme */
        public void Verifikacija(string pin)
        {
            var connectionString = "Data Source=DESKTOP-ELB063I\\SQLEXPRESS01;Initial Catalog=Banka;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            var nalogKorisnika = new Nalog_korisnika(); /* kreiranje instance nalogKorisnika */
            int validator = 0;  /* validator predstavlja tacnost PIN-a, pocetna vrednost je postavljena je na 0 i promenice se na 1 ako je unos PIN-a jednaka 4 broja i ukoliko je PIN tacan */
            try
            {
                if (pin.Length == 4)    /* provera da li je duzina PIN-a jednaka unosu 4 broja */
                {
                    con.Open();
                    var command = new SqlCommand($"SELECT ID, StanjeRacuna, PIN FROM Racun WHERE PIN = {int.Parse(pin)}", con); /* selektuj iz baze PIN */
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (int.Parse(reader["PIN"].ToString()) == int.Parse(pin))  /* proveri da li je PIN tacan */
                        {
                            lblStatus.Hide();   /* labela Status ostaje sakrivena ukoliko je PIN validan */
                            validator = 1;      /* PIN je ispravan i dodeljena je vrednost 1 */
                            this.Hide();        /* sakrivnje forme za unos PIN-a */
                            nalogKorisnika.ID = int.Parse(reader.GetValue("ID").ToString());          /* prosledjivanje ID, StanjeRacuna i PIN korisnika iz baze */
                            nalogKorisnika.StanjeRacuna = decimal.Parse(reader.GetValue("StanjeRacuna").ToString());
                            nalogKorisnika.PIN = int.Parse(reader.GetValue("PIN").ToString());
                            nalogKorisnika.Show();  /* prikazi formu gde korisnik podize novac, pregleda transakcija, ili zahteva stanje racuna */
                            break;  /* prekidanje petlje da program ne bi i dalje radio ukoliko je pronasao korisnika u bazi */
                        }
                    }
                    reader.Close();
                }
                else
                {
                    /* ako je usnos PIN-a razlicit od unosa 4 broja */
                    MessageBox.Show($"PIN zahteva unos 4 broja!\nPokusajte ponovo.", "Unos PIN-a", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex) { MessageBox.Show("Greska: " + ex.Message); }
            finally
            {
                con.Close();
                if (validator == 0)     /* ako je validator == 0 pokazace da je PIN pogresan */
                {
                    lblStatus.Show();
                }
            }
        }
    }
}
