using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Bankomat
{
    public partial class Pregled_Transakcija : Form
    {
        public int ID { get; set; }
        public Pregled_Transakcija()
        {
            InitializeComponent();
        }

        private void Pregled_Transakcija_Load(object sender, EventArgs e)
        {
            lblDatum.Text += DateTime.Now.ToString("d");
            lblVreme.Text += DateTime.Now.ToString("t");
            lblIme.Text = "Ime: ";
            lblPrezime.Text = "Prezime: ";
            lblTip.Text = "Tip korisnika: ";
            var connectionString = "Data Source=DESKTOP-ELB063I\\SQLEXPRESS01;Initial Catalog=Banka;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            var podaci = new List<string>();

            try
            {
                con.Open();
                var command = new SqlCommand($"SELECT o.Ime, o.Prezime, o.TipKorisnika, t.RacunID, t.Uplata, t.Isplata, t.DatumTransakcije FROM Osoba as o INNER JOIN Transakcije as t on o.RacunID = t.RacunID WHERE o.RacunID = {ID}", con);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if(int.Parse(reader["RacunID"].ToString()) == ID)
                    {
                        lblIme.Text ="Ime: " + reader["Ime"].ToString();
                        lblPrezime.Text = "Prezime: " + reader["Prezime"].ToString();
                        lblTip.Text = "Tip korisnika: " + reader["TipKorisnika"].ToString();
                        podaci.Add(reader["RacunID"].ToString());
                        podaci.Add(reader["Uplata"].ToString());
                        podaci.Add(reader["Isplata"].ToString());
                        podaci.Add(DateTime.Parse(reader["DatumTransakcije"].ToString()).ToShortDateString());
                    }
                }
                reader.Close();

                string[] p = new string[4];
                for (int i = 0; i < podaci.Count - 3; i++)
                {
                    if (i % 4 == 0)
                    {
                        p[0] = podaci[i].ToString();
                        p[1] = podaci[i + 1].ToString();
                        p[2] = podaci[i + 2].ToString();
                        p[3] = podaci[i + 3].ToString();

                        var item = new ListViewItem(p);
                        foreach (var podatak in p)
                        {
                            item.SubItems.Add(podatak);
                        }
                        listView1.Items.Add(item);
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Greska: " + ex.Message); }
            finally
            {
                con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var nalogKorisnika = new Nalog_korisnika();
            nalogKorisnika.Show();
            nalogKorisnika.ID = ID;
        }
    }
}
