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
        public void podizanjeGotovine(decimal iznos, int pin)
        {
            var connectionString = "Data Source=DESKTOP-ELB063I\\SQLEXPRESS01;Initial Catalog=Banka;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                con.Open();
                var command = new SqlCommand($"RacunUpdate", con);
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
        public void dodajTransakcije(decimal iznos, int ID)
        {
            var connectionString = "Data Source=DESKTOP-ELB063I\\SQLEXPRESS01;Initial Catalog=Banka;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);

            try
            {
                con.Open();
                var command = new SqlCommand($"Transakcije_Insert", con);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@RacunID", ID);
                command.Parameters.AddWithValue("@Uplata", 0.00);
                command.Parameters.AddWithValue("@Isplata", iznos);
                command.Parameters.AddWithValue("@DatumTransakcije", DateTime.Parse(DateTime.Now.Date.ToString("d")));
                var reader = command.ExecuteReader();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
            finally { con.Close(); }
        }
    }
}
