using System;
using System.Data;
using System.Data.OleDb;
using System.Windows;

namespace v8z4
{
    public class DB
    {
        // public SqlConnection connection;
        // public SqlCommand command;
        public OleDbConnection connection = new OleDbConnection();
        public OleDbCommand command;
        public DB()
        {
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data source=baza.accdb; Persist security info=false";
            command = connection.CreateCommand();
        }
        public void snimanjePodataka(Person Person)
        {
            try
            {
                connection.Open();
                command.CommandText =
                    $"INSERT INTO Person VALUES ('{Person.FirstName}','{Person.LastName}','{Person.PhoneNumber}','{Person.Email}')";
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Uspesno dodavanje podataka u bazu");
            }
            catch (OleDbException ex)
            {
                if (connection != null)
                    connection.Close();
                MessageBox.Show(ex.Message);
            }
        }
        public void azuriranjePodataka(Person Person)
        {
            try
            {
                connection.Open();
                command.CommandText =
$"UPDATE Person SET LastName='{Person.LastName}',PhoneNumber='{Person.PhoneNumber}',Email='{Person.Email}' WHERE FirstName='{Person.FirstName}'";
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Uspesna izmena podataka u bazu");
            }
            catch (OleDbException ex)
            {
                if (connection != null)
                    connection.Close();
                MessageBox.Show(ex.Message);
            }
        }
        public void brisanjePodataka(Person Person)
        {
            try
            {
                if (MessageBox.Show($"Da li ste sigurni da hocete da obrisete {Person.FirstName}?", "Potvrda", MessageBoxButton.YesNo)
                    == MessageBoxResult.Yes)
                {
                    connection.Open();
                    command.CommandText =
                    $"DELETE FROM Person WHERE FirstName='{Person.FirstName}'";
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Uspesno brisanje podataka iz baze");
                }
            }
            catch (OleDbException ex)
            {
                if (connection != null)
                    connection.Close();
                MessageBox.Show(ex.Message);
            }
        }
        public DataTable citanjePodataka()
        {
            DataTable dt = new DataTable();
            try
            {
                connection.Open();
                command.CommandText = "SELECT * FROM Person";
                OleDbDataAdapter da = new OleDbDataAdapter(command);
                da.Fill(dt);

                connection.Close();
            }
            catch (OleDbException ex)
            {
                if (connection != null)
                    connection.Close();
                MessageBox.Show(ex.Message);
            }
            return dt;
        }
    }
}