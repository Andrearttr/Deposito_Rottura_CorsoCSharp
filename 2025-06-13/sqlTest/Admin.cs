using MySql.Data.MySqlClient;
using System;

public sealed class Admin
{
    public void AggiungiLuogo(MySqlConnection conn)
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
                    where luogo.luogo = @luogo and citta.citta = @citta and paese.paese = @paese;"; // controlla se il luogo esiste gia
        MySqlCommand cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@luogo", luogo);
        cmd.Parameters.AddWithValue("@citta", citta);
        cmd.Parameters.AddWithValue("@paese", paese);
        MySqlDataReader rdr = cmd.ExecuteReader();
        bool esisteLuogo = rdr.Read();
        rdr.Close();

        if (esisteLuogo)
        {
            Console.WriteLine("Luogo gia presente nel database");
            return;
        }
        else
        {
            sql = "select paese_id from paese where paese = @paese;"; // controlla se il paese esiste nel db
            cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@paese", paese);
            rdr = cmd.ExecuteReader();
            bool esistePaese = rdr.Read();
            rdr.Close();

            if (!esistePaese)
            {
                sql = "Insert into paese(paese) values (@paese);";  // se non esiste lo inserisce
                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@paese", paese);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Paese aggiunto.");
            }

            sql = "select citta_id from citta where citta = @citta;"; // controlla se la città esiste nel db
            cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@citta", citta);
            rdr = cmd.ExecuteReader();
            bool esisteCitta = rdr.Read();
            rdr.Close();

            sql = "select paese_id from paese where paese = @paese;"; // prende l'id del paese
            cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@paese", paese);
            rdr = cmd.ExecuteReader();
            rdr.Read();
            int paeseId = (int)rdr[0];
            rdr.Close();

            if (!esisteCitta)
            {
                sql = "Insert into citta(citta, paese_id) values (@citta, @paese_id);"; // se non esiste la inserisce
                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@citta", citta);
                cmd.Parameters.AddWithValue("@paese_id", paeseId);
                cmd.ExecuteNonQuery();
                Console.WriteLine("città aggiunta.");
            }

            sql = "select citta_id from citta where citta = @citta;"; // prende l'id della città
            cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@citta", citta);
            rdr = cmd.ExecuteReader();
            rdr.Read();
            int cittaId = (int)rdr[0];
            rdr.Close();

            sql = "Insert into luogo(luogo, citta_id) values (@luogo, @citta_id);";
            cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@luogo", luogo);
            cmd.Parameters.AddWithValue("@citta_id", cittaId);
            cmd.ExecuteNonQuery();
            Console.WriteLine("luogo aggiunto.");
        }

    }

    public void RimuoviLuogo(MySqlConnection conn)
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
            sql = "delete from luogo where luogo_id = @luogo_id"; //elimina il luogo
            cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@luogo_id", luogoId);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Luogo eliminato.");
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
                    join utente u on u.utente_id = pr.utente_id;";  // seleziona tutte le prenotazioni
        MySqlCommand cmd = new MySqlCommand(sql, conn);
        MySqlDataReader rdr = cmd.ExecuteReader();

        while (rdr.Read())
        {
            Console.WriteLine(rdr[0] + " -- " + rdr[1] + " -- " + rdr[2]+ " -- " + rdr[3]+ " -- " + rdr[4]+ " -- " + rdr[5]);
        }
        rdr.Close();
    }
}