using MySql.Data.MySqlClient;
using System;

public sealed class Admin
{
    private string _username = "admin";
    public string Username
    {
        get { return _username; }
    }

    private string _password = "admin";
    public string Password
    {
        get { return _password; }
    }

    public void AggiungiLibro(MySqlConnection conn)
    {

        Console.Write("Inserisi titolo: ");
        string titolo = Console.ReadLine();

        string sqlLibro = "select libro_id from libro where titolo = @titolo";
        MySqlCommand cmdLibro = new MySqlCommand(sqlLibro, conn);
        cmdLibro.Parameters.AddWithValue("@titolo", titolo);
        MySqlDataReader rdrLibro = cmdLibro.ExecuteReader();
        int libroId = 0;
        if (rdrLibro.Read())
        {
            libroId = (int)rdrLibro[0];
            rdrLibro.Close();
            sqlLibro = "Insert into inventario(inventario.libro_id) values (@libroId);";
            cmdLibro = new MySqlCommand(sqlLibro, conn);
            cmdLibro.Parameters.AddWithValue("@libroId", libroId);
            cmdLibro.ExecuteNonQuery();
            Console.WriteLine("Libro aggiunto con successo.");
            return;
        }
        rdrLibro.Close();

        Console.Write("Inserisi nome autore: ");
        string nomeAutore = Console.ReadLine();
        Console.Write("Inserisi cognome autore: ");
        string cognomeAutore = Console.ReadLine();
        Console.Write("Scegli genere: ");
        string genere = Console.ReadLine();
        Console.Write("Inserisi data uscita (anno, mese, giorno): ");
        DateTime dataUscita = DateTime.Parse(Console.ReadLine());
        Console.Write("Inserisci prezzo: ");
        float prezzo = float.Parse(Console.ReadLine());

        int autoreId = 0;
        do
        {
            string sqlAutore = "Select autore.autore_id from autore where autore.nome=@nomeAutore and autore.cognome=@cognomeAutore";
            MySqlCommand cmdAutore = new MySqlCommand(sqlAutore, conn);
            cmdAutore.Parameters.AddWithValue("@nomeAutore", nomeAutore);
            cmdAutore.Parameters.AddWithValue("@cognomeAutore", cognomeAutore);
            MySqlDataReader rdr = cmdAutore.ExecuteReader();

            if (rdr.Read())
            {
                autoreId = (int)rdr[0];
                rdr.Close();
                break;
            }
            else
            {
                rdr.Close();
                sqlAutore = "Insert into autore(nome,cognome) values (@nomeAutore,@cognomeAutore)";
                cmdAutore = new MySqlCommand(sqlAutore, conn);
                cmdAutore.Parameters.AddWithValue("@nomeAutore", nomeAutore);
                cmdAutore.Parameters.AddWithValue("@cognomeAutore", cognomeAutore);
                cmdAutore.ExecuteNonQuery();
            }
        } while (true);

        int genereId = 0;
        do
        {
            string sqlGenere = "Select genere.genere_id from genere where genere.nome=@genere;";
            MySqlCommand cmdGenere = new MySqlCommand(sqlGenere, conn);
            cmdGenere.Parameters.AddWithValue("@genere", genere);
            MySqlDataReader rdr = cmdGenere.ExecuteReader();

            if (rdr.Read())
            {
                genereId = (int)rdr[0];
                rdr.Close();
                break;
            }
            else
            {
                rdr.Close();
                sqlGenere = "Insert into genere(nome) values (@genere)";
                cmdGenere = new MySqlCommand(sqlGenere, conn);
                cmdGenere.Parameters.AddWithValue("@genere", genere);
                cmdGenere.ExecuteNonQuery();
            }
        } while (true);

        string sql = "Insert into libro(titolo, autore_id, genere_id, anno_uscita, prezzo) values (@titolo, @autore_id, @genere_id, @anno_uscita, @prezzo);";
        MySqlCommand cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@titolo", titolo);
        cmd.Parameters.AddWithValue("@anno_uscita", dataUscita);
        cmd.Parameters.AddWithValue("@prezzo", prezzo);
        cmd.Parameters.AddWithValue("@autore_id", autoreId);
        cmd.Parameters.AddWithValue("@genere_id", genereId);



        cmd.ExecuteNonQuery();
        cmdLibro = new MySqlCommand(sqlLibro, conn);
        cmdLibro.Parameters.AddWithValue("@titolo", titolo);
        rdrLibro = cmdLibro.ExecuteReader();
        if (rdrLibro.Read())
        {
            libroId = (int)rdrLibro[0];
            rdrLibro.Close();
            sqlLibro = "Insert into inventario(inventario.libro_id) values (@libroId);";
            cmdLibro = new MySqlCommand(sqlLibro, conn);
            cmdLibro.Parameters.AddWithValue("@libroId", libroId);
            cmdLibro.ExecuteNonQuery();
        }

        Console.WriteLine("Libro aggiunto con successo.");
    }

    public void RimuoviLibro(MySqlConnection conn)
    {
        Console.Write("Inserisi titolo: ");
        string titolo = Console.ReadLine();

        string sqlLibro = "select libro_id from libro where titolo = @titolo";
        MySqlCommand cmdLibro = new MySqlCommand(sqlLibro, conn);
        cmdLibro.Parameters.AddWithValue("@titolo", titolo);
        MySqlDataReader rdr = cmdLibro.ExecuteReader();
        int libroId = 0;
        if (!rdr.Read())
        {
            Console.WriteLine("Libro non trovato.");
            rdr.Close();
        }
        else
        {
            libroId = (int)rdr[0];
            rdr.Close();
            sqlLibro = "delete from inventario where libro_id = @libroId limit 1";
            cmdLibro = new MySqlCommand(sqlLibro, conn);
            cmdLibro.Parameters.AddWithValue("@libroId", libroId);
            cmdLibro.ExecuteNonQuery();
            Console.WriteLine("Libro eliminato.");
        }

    }

    public void StampaInv(MySqlConnection conn)
    {

        string sql = "Select titolo, count(inventario.libro_id) as Quantita from libro join inventario on inventario.libro_id=libro.libro_id group by inventario_id;";
        MySqlCommand cmd = new MySqlCommand(sql, conn);
        MySqlDataReader rdr = cmd.ExecuteReader();

        while (rdr.Read())
        {
            Console.WriteLine(rdr[1]+" -- "+rdr[0]);
        }
        rdr.Close();
    }

}