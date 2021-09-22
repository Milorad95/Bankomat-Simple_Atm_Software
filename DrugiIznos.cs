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
    public partial class DrugiIznos : Form
    {
        public decimal StanjeRacuna { get; set; }
        public int PIN { get; set; }
        public int ID { get; set; }
        public DrugiIznos()
        {
            InitializeComponent();
        }

        private void btnNazad_Click(object sender, EventArgs e)     /* prikazi formu Nalog_Korisnika sa pocetnim vrednostima */
        {
            var nalogKorisnika = new Nalog_korisnika();
            this.Hide();
            nalogKorisnika.Show();
        }

        private void btnPotvrdi_Click(object sender, EventArgs e)
        {
            var nalogKorisnika = new Nalog_korisnika();
            var transakcije = new Transakcije();
            decimal iznos = decimal.Parse(txtDrugiIznos.Text);      /* kovertuj uneseni string u decimal */
            if (StanjeRacuna - iznos >= 0)          /* ukoliko je uslov tacan umanji iznos korisnika u bazi i zabelezi transakciju u bazi */
            {
                transakcije.podizanjeGotovine(iznos, PIN);
                transakcije.dodajTransakcije(iznos, ID);
            }
            else { MessageBox.Show("Nedovoljno sredstava na racunu!", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information); }           /* ukoliko IF uslov nije ispunjen */
            this.Hide();            /* u svakom slucaju ce sakriti ovu formu i prikazati prethodnu formu, prosledice i podatke korisnika klasi Nalog_Korisnika */
            nalogKorisnika.ID = ID;
            nalogKorisnika.PIN = PIN;
            nalogKorisnika.StanjeRacuna = StanjeRacuna;
            nalogKorisnika.Show();
        }
    }
}
