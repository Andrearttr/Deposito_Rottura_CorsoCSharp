using MySql.Data.MySqlClient;
using System;

public class User
{
    private int _userId;

    public int UserId
    {
        get { return _userId; }
    }

    public User(int userId)
    {
        _userId = userId;
    }

    public void AggiungiPrenotazione(MySqlConnection conn)
    {
        Console.Write("Inserisi paese: ");
        string paese = Console.ReadLine();
        Console.Write("Inserisi città: ");
        string citta = Console.ReadLine();
        Console.Write("Inserisi luogo: ");
        string luogo = Console.ReadLine();

        string sql = @"select luogo_id from luogo
                    join citta on citta.citta_id = luogo.citta_id
                    join paese on paese.paese_id = citta.paese_id
                    where luogo.luogo = @luogo and citta.citta = @citta and paese.paese = @paese;"; // controlla se il luogo esiste
        MySqlCommand cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@luogo", luogo);
        cmd.Parameters.AddWithValue("@citta", citta);
        cmd.Parameters.AddWithValue("@paese", paese);
        MySqlDataReader rdr = cmd.ExecuteReader();
        bool esisteLuogo = rdr.Read();


        if (esisteLuogo)
        {
            int luogoId = (int)rdr[0];
            rdr.Close();

            Console.WriteLine("Inserisci data (yyyy,mm,gg): ");
            DateTime data = DateTime.Parse(Console.ReadLine());

            sql = "Insert into prenotazione(utente_id, luogo_id, data) values (@utente_id, @luogo_id, @data);";
            cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@utente_id", _userId);
            cmd.Parameters.AddWithValue("@luogo_id", luogoId);
            cmd.Parameters.AddWithValue("@data", data);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Prenotazione aggiunta.");
        }
        else
        {
            Console.WriteLine("Luogo non trovato");
        }
    }

    public void RimuoviPrenotazione(MySqlConnection conn)
    {
        Console.Write("Inserisi paese: ");
        string paese = Console.ReadLine();
        Console.Write("Inserisi città: ");
        string citta = Console.ReadLine();
        Console.Write("Inserisi luogo: ");
        string luogo = Console.ReadLine();

        string sql = @"select luogo_id from luogo
                    join citta on citta.citta_id = luogo.citta_id
                    join paese on paese.paese_id = citta.paese_id
                    where luogo.luogo = @luogo and citta.citta = @citta and paese.paese = @paese;"; // controlla se il luogo esiste
        MySqlCommand cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@luogo", luogo);
        cmd.Parameters.AddWithValue("@citta", citta);
        cmd.Parameters.AddWithValue("@paese", paese);
        MySqlDataReader rdr = cmd.ExecuteReader();
        bool esisteLuogo = rdr.Read();

        if (esisteLuogo)
        {
            int luogoId = (int)rdr[0];
            rdr.Close();

            Console.WriteLine("Inserisci data (yyyy,mm,gg): ");
            DateTime data = DateTime.Parse(Console.ReadLine());

            sql = @"select prenotazione_id from prenotazione where luogo_id = @luogo_id and utente_id = @utente_id and data = @data;"; // controlla se la prenotazione esiste
            cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@luogo_id", luogoId);
            cmd.Parameters.AddWithValue("@utente_id", _userId);
            cmd.Parameters.AddWithValue("@data", data);
            rdr = cmd.ExecuteReader();
            bool esistePrenotazione = rdr.Read();

            if (esistePrenotazione)
            {
                int prenotazioneId = (int)rdr[0];
                rdr.Close();
                sql = "delete from prenotazione where prenotazione_id = @prenotazione_id"; //elimina la prenotazione
                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@prenotazione_id", prenotazioneId);
                cmd.ExecuteNonQuery();
                Console.WriteLine("prenotazione eliminata.");
            }
            else
            {
                rdr.Close();
                Console.WriteLine("Prenotaione non trovata.");
            }
        }
        else
        {
            rdr.Close();
            Console.WriteLine("Luogo non trovato.");
        }
    }

    public void VisualizzaLuoghi(MySqlConnection conn)
    {
        string sql = @"select p.paese, c.citta, l.luogo from paese p
                    join citta c on c.paese_id = p.paese_id
                    join luogo l on l.citta_id = c.citta_id;";
        MySqlCommand cmd = new MySqlCommand(sql, conn);
        MySqlDataReader rdr = cmd.ExecuteReader();

        while (rdr.Read())
        {
            Console.WriteLine(rdr[0] + " -- " + rdr[1] + " -- " + rdr[2]);
        }
        rdr.Close();
    }

    public void VisualizzaPrenotazioni(MySqlConnection conn)
    {
        string sql = @"select pr.prenotazione_id, pr.data, concat(u.nome, ' ', u.cognome) as nome_cognome, p.paese, c.citta, l.luogo
                    from paese p join citta c on c.paese_id = p.paese_id
                    join luogo l on l.citta_id = c.citta_id
                    join prenotazione pr on pr.luogo_id = l.luogo_id
                    join utente u on u.utente_id = pr.utente_id
                    where u.utente_id = @user_id;"; // seleziona le prenotazioni dell'utente corrente
        MySqlCommand cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@user_id", _userId);
        MySqlDataReader rdr = cmd.ExecuteReader();

        while (rdr.Read())
        {
            Console.WriteLine(rdr[0] + " -- " + rdr[1] + " -- " + rdr[2]+ " -- " + rdr[3]+ " -- " + rdr[4]+ " -- " + rdr[5]);
        }
        rdr.Close();
    }
}