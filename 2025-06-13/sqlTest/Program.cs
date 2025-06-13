using System;
using System.Data;

using MySql.Data;
using MySql.Data.MySqlClient;

public class Program
{
    public enum UserType
    {
        User,
        Admin,
        Invalid
    }
    public static void Main(string[] args)
    {
        //inizia la connessione la database
        string connStr = $"server=localhost;user=root;database=agenzia_viaggi;port=3306;password=1234";
        MySqlConnection conn = new MySqlConnection(connStr);
        try
        {
            Console.WriteLine("Connecting to MySQL...");
            conn.Open();

            
            bool exit = false;

            //menu registrazione/login
            while (!exit)
            {
                Console.WriteLine("\nMenù");
                Console.WriteLine("[1] Registrazione");
                Console.WriteLine("[2] Login");
                Console.WriteLine("[0] Esci");
                Console.Write("Scelta: ");
                int menuAction = int.Parse(Console.ReadLine());


                switch (menuAction)
                {
                    case 1:
                        Console.Write("Inserisci nome utente: ");
                        string username = Console.ReadLine();
                        Console.Write("Inserisci password: ");
                        string password = Console.ReadLine();
                        UserRegister(conn, username, password); //registra utente
                        break;

                    case 2:

                        Console.Write("Inserisci nome utente: ");
                        username = Console.ReadLine();
                        Console.Write("Inserisci password: ");
                        password = Console.ReadLine();
                        int? userId;
                        UserType userType = UserTypeCheck(conn, username, password, out userId); //controlla se le credenziali inserite esistono e se appartengono a un utente o a un admin

                        switch (userType)
                        {
                            case UserType.Admin:
                                Admin admin = new Admin();
                                AdminMenu(admin, conn); //avvia il menu dell'admin
                                break;

                            case UserType.User:

                                User user = new User((int)userId);
                                UserMenu(user, conn); //avvia il menu dell'utente
                                break;

                            case UserType.Invalid:
                                Console.WriteLine("Utente inesistente");
                                break;
                        }

                        break;

                    case 0:
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Scelta non valida.");
                        break;
                }
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        conn.Close();
        Console.WriteLine("Done.");
    }

    public static void UserRegister(MySqlConnection conn, string username, string password)
    {
        string sqlUser = "Select utente_id from utente where username = @username;"; // controlla se lo username inserito esiste gia
        MySqlCommand cmdUser = new MySqlCommand(sqlUser, conn);
        cmdUser.Parameters.AddWithValue("@username", username);
        MySqlDataReader rdrUser = cmdUser.ExecuteReader();

        if (rdrUser.Read())
        {
            rdrUser.Close();
            Console.WriteLine("Utente gia esistente.");
        }
        else
        {
            Console.Write("Inserisci nome: ");
            string nome = Console.ReadLine();
            Console.Write("Inserisci cognome: ");
            string cognome = Console.ReadLine();
            Console.Write("Inserisci email: ");
            string email = Console.ReadLine();

            rdrUser.Close();
            sqlUser = "Insert into utente (nome, cognome, email, username, password) values(@nome, @cognome, @email, @username, @password)";    // inserisce i dettagli del nuovo utente
            cmdUser = new MySqlCommand(sqlUser, conn);
            cmdUser.Parameters.AddWithValue("@nome", nome);
            cmdUser.Parameters.AddWithValue("@cognome", cognome);
            cmdUser.Parameters.AddWithValue("@email", email);
            cmdUser.Parameters.AddWithValue("@username", username);
            cmdUser.Parameters.AddWithValue("@password", password);
            cmdUser.ExecuteNonQuery();
            Console.WriteLine("Utente registrato con successo.");
        }
    }

    public static UserType UserTypeCheck(MySqlConnection conn, string username, string password, out int? userId)
    {
        string sql = "Select admin_id from admin where username = @username and password = @password;"; // controlla se le credenziali inserite corrispondono a un admin
        MySqlCommand cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@username", username);
        cmd.Parameters.AddWithValue("@password", password);
        MySqlDataReader rdr = cmd.ExecuteReader();

        if (rdr.Read())
        {
            rdr.Close();
            userId = null;
            return UserType.Admin;
        }
        else
        {
            rdr.Close();

            sql = "Select utente_id from utente where username = @username and password = @password;"; // controlla se le credenziali inserite corrispondono a un utente
            cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
                userId = (int)rdr[0];
                rdr.Close();
                return UserType.User;
            }
            else
            {
                rdr.Close();
                userId = null;
                return UserType.Invalid;
            }
        }
    }

    public static void AdminMenu(Admin admin, MySqlConnection conn)
    {

        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nMenù admin");
            Console.WriteLine("[1] Aggiungi luogo");
            Console.WriteLine("[2] Rimuovi luogo");
            Console.WriteLine("[3] Visualizza luoghi");
            Console.WriteLine("[4] Visualizza prenotazioni");
            Console.WriteLine("[0] Esci");
            Console.Write("Scelta: ");
            int menuAction = int.Parse(Console.ReadLine());

            switch (menuAction)
            {
                case 1:
                    admin.AggiungiLuogo(conn); //aggiunge un luogo al db
                    break;

                case 2:
                    admin.RimuoviLuogo(conn); //rimuove un luogo dal db
                    break;

                case 3:
                    admin.VisualizzaLuoghi(conn); //visualizza tutti i luoghi e dove si trovano
                    break;

                case 4:
                    admin.VisualizzaPrenotazioni(conn); //visualizza le prenotazioni di tutti gli utenti 
                    break;

                case 0:
                    exit = true;
                    break;

                default:
                    Console.WriteLine("Scelta non valida.");
                    break;
            }
        }

    }

    public static void UserMenu(User user, MySqlConnection conn)
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nMenù user");
            Console.WriteLine("[1] Aggiungi prenotazione");
            Console.WriteLine("[2] Rimuovi prenotazione");
            Console.WriteLine("[3] Visualizza prenotazioni");
            Console.WriteLine("[4] Visualizza luoghi");
            Console.WriteLine("[0] Esci");
            Console.Write("Scelta: ");
            int menuAction = int.Parse(Console.ReadLine());

            switch (menuAction)
            {
                case 1:
                    user.AggiungiPrenotazione(conn); //aggiunde una prenotazione a nome dell'utente corrente
                    break;

                case 2:
                    user.RimuoviPrenotazione(conn); //rimuove una prenotazione dell'utente corrente
                    break;

                case 3:
                    user.VisualizzaPrenotazioni(conn); //visualizza le prenotazioni dell'utente corrente
                    break;

                case 4:
                    user.VisualizzaLuoghi(conn);    //visualizza tutti i luoghi
                    break;

                case 0:
                    exit = true;
                    break;

                default:
                    Console.WriteLine("Scelta non valida.");
                    break;
            }
        }
    }

}