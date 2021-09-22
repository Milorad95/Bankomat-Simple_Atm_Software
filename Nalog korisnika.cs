using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bankomat
{
    public partial class Nalog_korisnika : Form
    {
        public int ID { get; set; }
        public decimal StanjeRacuna { get; set; }
        public int PIN { get; set; }
        public Nalog_korisnika()
        {
            InitializeComponent();
        }

        private void Nalog_korisnika_Load(object sender, EventArgs e)
        {
            lblDatum.Text += DateTime.Now.Date.ToShortDateString();
            lblVreme.Text += DateTime.Now.ToString("t");
            hideLoad();
        }

        private void btnPonisti_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPodizanjeGotovine_Click(object sender, EventArgs e)
        {
            hidePodizanjeGotovine();
        }

        private void Nalog_korisnika_FormClosing(object sender, FormClosingEventArgs e)
        {
            var f1 = new Form1();
            f1.Show();
        }

        private void btn1000_Click(object sender, EventArgs e)
        {
            var transakcije = new Transakcije();
            if(StanjeRacuna - 1000 >= 0)
            {
                transakcije.podizanjeGotovine(1000, PIN);
                transakcije.dodajTransakcije(1000, ID);
            }
            else { MessageBox.Show("Nedovoljno sredstava na racunu!", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void btn5000_Click(object sender, EventArgs e)
        {
            var transakcije = new Transakcije();
            if (StanjeRacuna - 5000 >= 0)
            {
                transakcije.podizanjeGotovine(5000, PIN);
                transakcije.dodajTransakcije(5000, ID);
            }
            else { MessageBox.Show("Nedovoljno sredstava na racunu!", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void btn10000_Click(object sender, EventArgs e)
        {
            var transakcije = new Transakcije();
            if (StanjeRacuna - 10000 >= 0)
            {
                transakcije.podizanjeGotovine(10000, PIN);
                transakcije.dodajTransakcije(10000, ID);
            }
            else { MessageBox.Show("Nedovoljno sredstava na racunu!", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void btnDrugiIznos_Click(object sender, EventArgs e)
        {
            var drugiIznos = new DrugiIznos();
            this.Hide();
            drugiIznos.PIN = PIN;
            drugiIznos.ID = ID;
            drugiIznos.StanjeRacuna = StanjeRacuna;
            drugiIznos.Show();
        }

        private void btnProveraStanja_Click(object sender, EventArgs e)
        {
            hideProveraStanja();
        }

        private void btnNazad_Click(object sender, EventArgs e)
        {
            hideLoad();
        }
        public void hideLoad()
        {
            lblNazad.Hide();
            lblNovac.Hide();
            lblProvera.Hide();
            lbl1000.Hide();
            lbl5000.Hide();
            lbl10000.Hide();
            lblDrugiIznos.Hide();
            btn1000.Hide();
            btn5000.Hide();
            btn10000.Hide();
            btnDrugiIznos.Hide();
            btnNazad.Hide();

            lblPodizanjeGotovine.Show();
            lblProveraStanja.Show();
            lblPregledTransakcjia.Show();
            btnPodizanjeGotovine.Show();
            btnProveraStanja.Show();
            btnPregledTransakcija.Show();
        }
        public void hidePodizanjeGotovine()
        {
            lblNovac.Hide();
            lblProveraStanja.Hide();
            lblPregledTransakcjia.Hide();
            lblPodizanjeGotovine.Hide();
            btnPodizanjeGotovine.Hide();
            btnPregledTransakcija.Hide();
            btnProveraStanja.Hide();

            lbl1000.Show();
            lbl5000.Show();
            lbl10000.Show();
            lblDrugiIznos.Show();
            btn1000.Show();
            btn5000.Show();
            btn10000.Show();
            btnDrugiIznos.Show();
            lblNazad.Show();
            btnNazad.Show();
        }
        public void hideProveraStanja()
        {
            lblProveraStanja.Hide();
            lblPregledTransakcjia.Hide();
            lblPodizanjeGotovine.Hide();
            btnPodizanjeGotovine.Hide();
            btnPregledTransakcija.Hide();
            btnProveraStanja.Hide();

            lblNovac.Text = StanjeRacuna.ToString() + " RSD";
            lblProvera.Show();
            lblNovac.Show();
            lblNazad.Show();
            btnNazad.Show();
        }

        private void btnPregledTransakcija_Click(object sender, EventArgs e)
        {
            this.Hide();
            var pregledTransakcija = new Pregled_Transakcija();
            pregledTransakcija.ID = ID;
            pregledTransakcija.Show();
        }
    }
}
