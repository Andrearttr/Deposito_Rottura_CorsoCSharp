using System;
using System.Data;

using MySql.Data;
using MySql.Data.MySqlClient;

public class Program
{
    public static void Main()
    {   
        Console.Write("Inserire password database: ");
        string databasePassword = Console.ReadLine();
        string connStr = $"server=localhost;user=root;database=world;port=3306;password={databasePassword}";
        MySqlConnection conn = new MySqlConnection(connStr);
        try
        {
            Console.WriteLine("Connecting to MySQL...");
            conn.Open();
            // Perform database operations
            string sql = "SELECT Name, HeadOfState FROM Country WHERE Continent='Oceania'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Console.WriteLine(rdr[0]+" -- "+rdr[1]);
            }
            rdr.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        conn.Close();
        Console.WriteLine("Done.");
    }
}