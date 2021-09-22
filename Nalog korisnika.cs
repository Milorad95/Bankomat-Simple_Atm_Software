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
            /* pri ucitavanju forme pokazace se trenutni datum i vreme  */
            lblDatum.Text += DateTime.Now.Date.ToShortDateString();
            lblVreme.Text += DateTime.Now.ToString("t");            /* t pokazuje trenutno vreme bez sekundi */
            hideLoad();                                             /* ova metoda sakriva labele i button-e koje korisniku nisu potrebne ukoliko ih on ne zahteva */
        }

        private void btnPonisti_Click(object sender, EventArgs e)
        {
            this.Close();       /* zatvaranje ove forme */
        }

        private void btnPodizanjeGotovine_Click(object sender, EventArgs e)
        {
            hidePodizanjeGotovine();        /* sakrivanje labela i button-a koje se ne odnose na podizanje gotovine */
        }

        private void Nalog_korisnika_FormClosing(object sender, FormClosingEventArgs e)
        {
            var f1 = new Form1();
            f1.Show();                      /* prikazuje se forma za unos PIN-a */
        }

        private void btn1000_Click(object sender, EventArgs e)
        {
            var transakcije = new Transakcije();
            if(StanjeRacuna - 1000 >= 0)        /* ako je stanje racuna umanjenog za zeljeni iznos veca ili jednaka 0 */
            {
                transakcije.podizanjeGotovine(1000, PIN);   /* prosledjivanje iznosa za podizanje i PIN-a koji ukazuje koji korisnik podize novac */
                transakcije.dodajTransakcije(1000, ID);     /* dodavanje transakcije u listu transakcija sa zeljenim iznosom i ID-jem korisnika koji je podigao gotovinu */
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
            drugiIznos.ID = ID;                     /* prosledjivanje parametara korisnika PIN, ID, StanjeRacuna */
            drugiIznos.StanjeRacuna = StanjeRacuna;
            drugiIznos.Show();                      /* prikazi formu za unos drugog iznosa */
        }

        private void btnProveraStanja_Click(object sender, EventArgs e)
        {
            hideProveraStanja();                    /* sakrij labele i button-e koje se ne odnose na proveru stanja */
        }

        private void btnNazad_Click(object sender, EventArgs e)
        {
            hideLoad();             /* sakriva sve labele i button-e i pokazuje pocetne labele i button-e sa izborom provera stanja, transakcija i podizanje gotovine */
        }
        public void hideLoad()      /* metoda koja uspostavlja pocetne vrednosti na formi kao i prilikom logovanja korisnika */
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
        public void hidePodizanjeGotovine()         /* metoda koja pri izboru "Podizanje gotovine" prikazuje iznose i opciju "Drugi iznos" sa button-ima za potvrdu i povratak na prethodi korak*/
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
        public void hideProveraStanja()         /* metoda koja pri izboru "Provera stanja" sakriva sve i pokazuje samo trenutno stanje na racunu i opciju "Nazad" za povratak na pocetni korak */
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
            pregledTransakcija.ID = ID; /* prosledi vrednost ID korisnika u klasu pregled transakcija */
            pregledTransakcija.Show();  /* prikazi formu za pregled transakcija */
        }
    }
}
