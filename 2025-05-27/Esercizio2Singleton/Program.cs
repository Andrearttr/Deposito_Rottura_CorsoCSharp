using System;

public sealed class Singleton_Logger
{
    private static Singleton_Logger _instance;
    private Singleton_Logger() { }

    private List<string> Logs = new List<string>();

    public static Singleton_Logger Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Singleton_Logger();
            }
            return _instance;
        }
    }

    public void Log(string message)
    {
        Logs.Add(message);
    }

    public void PrintLogs()
    {
        foreach (string log in Logs)
        {
            Console.WriteLine(log);
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Singleton_Logger logger1 = Singleton_Logger.Instance;
        Singleton_Logger logger2 = Singleton_Logger.Instance;


        bool exit = false;
        
        while (!exit)
        {
            Console.WriteLine("\nMenù");
            Console.WriteLine("[1] Usa logger 1");
            Console.WriteLine("[2] Usa logger 2");
            Console.WriteLine("[3] Visualizza log");
            Console.WriteLine("[0] Esci");
            Console.Write("Scelta: ");
            int menuAction = Input.Int(0, 3);
        
            switch (menuAction)
            {
                case 1:
                    Console.Write("\nInserisci messaggio log: ");
                    string messaggio = Input.String();
                    logger1.Log(messaggio);
                    break;
        
                case 2:
                    Console.Write("\nInserisci messaggio log: ");
                    messaggio = Input.String();
                    logger2.Log(messaggio);
                    break;
        
                case 3:
                    Console.WriteLine("\nLogs:");
                    Singleton_Logger.Instance.PrintLogs();
                    break;
        
                case 0:
                    exit = true;
                    break;
            }
        }
    }
}