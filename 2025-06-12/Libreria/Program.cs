using System;
using System.Data;

using MySql.Data;
using MySql.Data.MySqlClient;

public class Program
{
    public static void Main()
    {
        string connStr = $"server=localhost;user=root;database=libreria;port=3306;password=1234";
        MySqlConnection conn = new MySqlConnection(connStr);
        try
        {
            Console.WriteLine("Connecting to MySQL...");
            conn.Open();

            bool exit = false;

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
                        UserRegister(conn, username, password);
                        break;

                    case 2:

                        Console.Write("Inserisci nome utente: ");
                        username = Console.ReadLine();
                        Console.Write("Inserisci password: ");
                        password = Console.ReadLine();

                        Admin admin = new Admin();
                        User user = new User();
                        bool isAdmin = AdminLogin(admin, username, password);
                        bool isUser = UserLogin(conn, username, password);

                        if (isAdmin)
                        {
                            AdminMenu(admin, conn);
                        }
                        else if (isUser)
                        {

                            UserMenu(user, conn);
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

    public static void AdminMenu(Admin admin, MySqlConnection conn)
    {

        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nMenù admin");
            Console.WriteLine("[1] Aggiungi libro");
            Console.WriteLine("[2] Rimuovi libro");
            Console.WriteLine("[3] Visualizza inventario");
            Console.WriteLine("[0] Esci");
            Console.Write("Scelta: ");
            int menuAction = int.Parse(Console.ReadLine());

            switch (menuAction)
            {
                case 1:
                    admin.AggiungiLibro(conn);
                    break;

                case 2:
                    admin.RimuoviLibro(conn);
                    break;

                case 3:
                    admin.StampaInv(conn);
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
            Console.WriteLine("[1] Aggiungi al carrello");
            Console.WriteLine("[2] Rimuovi dal carrello");
            Console.WriteLine("[3] Concludi ordine");
            Console.WriteLine("[0] Esci");
            Console.Write("Scelta: ");
            int menuAction = int.Parse(Console.ReadLine());

            switch (menuAction)
            {
                case 1:
                    user.AggiungiAlCarrello(conn);
                    break;

                case 2:
                    user.RimuoviDalCarrello(conn);
                    break;

                case 3:
                    user.ConcludiOrdine(conn);
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

    public static bool AdminLogin(Admin admin, string username, string password)
    {
        if (username == admin.Username && password == admin.Password)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool UserLogin(MySqlConnection conn, string username, string password)
    {
        string sqlUser = "Select u.username, u.password_hash from utente_password u where u.username=@username and u.password_hash=@password_u;";
        MySqlCommand cmdUser = new MySqlCommand(sqlUser, conn);
        cmdUser.Parameters.AddWithValue("@username", username);
        cmdUser.Parameters.AddWithValue("@password_u", password);
        MySqlDataReader rdrUser = cmdUser.ExecuteReader();

        if (rdrUser.Read())
        {
            rdrUser.Close();
            return true;
        }
        else
        {
            rdrUser.Close();
            return false;
        }
    }

    public static void UserRegister(MySqlConnection conn, string username, string password)
    {
        Console.Write("Inserisci nome: ");
        string nome = Console.ReadLine();
        Console.Write("Inserisci cognome: ");
        string cognome = Console.ReadLine();
        Console.Write("Inserisci email: ");
        string email = Console.ReadLine();
        Console.Write("Inserisci telefono: ");
        string telefono = Console.ReadLine();
        Console.Write("Inserisci indirizzo: ");
        string indirizzo = Console.ReadLine();
        Console.Write("Inserisci codice postale: ");
        string postalCode = Console.ReadLine();
        Console.Write("Inserisci città: ");
        string citta = Console.ReadLine();

        string sqlUser = "Select utente_id from utente where email=@email and telefono=@telefono;";
        MySqlCommand cmdUser = new MySqlCommand(sqlUser, conn);
        cmdUser.Parameters.AddWithValue("@email", email);
        cmdUser.Parameters.AddWithValue("@telefono", telefono);
        MySqlDataReader rdrUser = cmdUser.ExecuteReader();

        int userId = 0;
        if (rdrUser.Read())
        {
            rdrUser.Close();
            Console.WriteLine("Utente gia esistente.");
            return;
        }

        rdrUser.Close();

        string sqlCitta = "Select citta_id from citta where citta=@citta;";
        MySqlCommand cmdCitta = new MySqlCommand(sqlCitta, conn);
        cmdCitta.Parameters.AddWithValue("@citta", citta);
        MySqlDataReader rdrCitta = cmdCitta.ExecuteReader();
        int cittaId = 0;
        if (!rdrCitta.Read())
        {

            rdrCitta.Close();
            string sqlCitta2 = "Insert into citta(citta) values (@citta)";
            MySqlCommand cmdCitta2 = new MySqlCommand(sqlCitta2, conn);
            cmdCitta2.Parameters.AddWithValue("@citta", citta);
            cmdCitta2.ExecuteNonQuery();
            rdrCitta = cmdCitta.ExecuteReader();
            rdrCitta.Read();
        }
        
        cittaId = (int)rdrCitta[0];

        rdrCitta.Close();

        string sqlInd = "Select indirizzo_id from indirizzo where indirizzo=@indirizzo";
        MySqlCommand cmdInd = new MySqlCommand(sqlInd, conn);
        cmdInd.Parameters.AddWithValue("@indirizzo", indirizzo);
        MySqlDataReader rdrInd = cmdCitta.ExecuteReader();
        int indId = 0;
        if (!rdrInd.Read())
        {
            rdrInd.Close();
            sqlInd = "Insert into indirizzo(indirizzo,postal_code, citta_id) values (@indirizzo,@postal_code,@citta_id)";
            cmdInd = new MySqlCommand(sqlInd, conn);
            cmdInd.Parameters.AddWithValue("@indirizzo", indirizzo);
            cmdInd.Parameters.AddWithValue("@postal_code", postalCode);
            cmdInd.Parameters.AddWithValue("@citta_id", cittaId);
            cmdInd.ExecuteNonQuery();
            
            rdrInd.Read();
        }

        indId = (int)rdrInd[0];

        rdrInd.Close();


        sqlUser = "Insert into utente (nome, cognome, email, telefono, indirizzo_id) values(@nome, @cognome, @email, @telefono, @indirizzo_id)";
        cmdUser = new MySqlCommand(sqlUser, conn);
        cmdUser.Parameters.AddWithValue("@nome", nome);
        cmdUser.Parameters.AddWithValue("@cognome", cognome);
        cmdUser.Parameters.AddWithValue("@email", email);
        cmdUser.Parameters.AddWithValue("@telefono", telefono);
        cmdUser.Parameters.AddWithValue("@indirizzo_id", indId);
        cmdUser.ExecuteNonQuery();

        rdrUser.Read();
        userId = (int)rdrUser[0];
        rdrUser.Close();

        sqlUser = "Insert into utente_password(utente_id,username,password_u) values (@utente_id,@username,@password_u)";
        cmdUser = new MySqlCommand(sqlUser, conn);
        cmdUser.Parameters.AddWithValue("@utente_id", userId);
        cmdUser.Parameters.AddWithValue("@username", username);
        cmdUser.Parameters.AddWithValue("@password_u", password);
        cmdUser.ExecuteNonQuery();
        
    }
}


