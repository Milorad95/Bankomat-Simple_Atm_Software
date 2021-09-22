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

        private void btnNazad_Click(object sender, EventArgs e)
        {
            var nalogKorisnika = new Nalog_korisnika();
            this.Hide();
            nalogKorisnika.Show();
        }

        private void btnPotvrdi_Click(object sender, EventArgs e)
        {
            var nalogKorisnika = new Nalog_korisnika();
            var transakcije = new Transakcije();
            decimal iznos = decimal.Parse(txtDrugiIznos.Text);
            if (StanjeRacuna - iznos >= 0)
            {
                transakcije.podizanjeGotovine(iznos, PIN);
                transakcije.dodajTransakcije(iznos, ID);
            }
            else { MessageBox.Show("Nedovoljno sredstava na racunu!", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            this.Hide();
            nalogKorisnika.ID = ID;
            nalogKorisnika.PIN = PIN;
            nalogKorisnika.StanjeRacuna = StanjeRacuna;
            nalogKorisnika.Show();
        }
    }
}
