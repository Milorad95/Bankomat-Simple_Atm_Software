using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Bankomat
{
    public class Transakcije
    {
        public Transakcije()
        {

        }
        public void podizanjeGotovine(decimal iznos, int pin)       /* prilikom podizanja gotovine umanji stanje korisnika sa prosledjenim ID-jem za zeljeni iznos */
        {
            var connectionString = "Data Source=DESKTOP-ELB063I\\SQLEXPRESS01;Initial Catalog=Banka;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                con.Open();
                var command = new SqlCommand($"RacunUpdate", con);          /* naziv procedure i konekcioni string */
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Iznos", iznos);
                command.Parameters.AddWithValue("@PIN", pin);
                var reader = command.ExecuteReader();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
            finally
            {
                con.Close();
                MessageBox.Show($"Uspesno podizanje gotovine!\nIznos: {iznos} RSD", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void dodajTransakcije(decimal iznos, int ID)         /* upisi podatke Iznos i ID korisnika u tabelu Transakcije */
        {
            var connectionString = "Data Source=DESKTOP-ELB063I\\SQLEXPRESS01;Initial Catalog=Banka;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);

            try
            {
                con.Open();
                var command = new SqlCommand($"Transakcije_Insert", con);       /* naziv procedure i konekcioni string */
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@RacunID", ID);                /* parametri */
                command.Parameters.AddWithValue("@Uplata", 0.00);               /* upisano je 0.00 jer se uplata ne moze izvrsiti preko forme u ovom slucaju */
                command.Parameters.AddWithValue("@Isplata", iznos);
                command.Parameters.AddWithValue("@DatumTransakcije", DateTime.Parse(DateTime.Now.Date.ToString("d")));      /* "d" prosledjuje samo kratki format datuma */
                var reader = command.ExecuteReader();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
            finally { con.Close(); }
        }
    }
}
