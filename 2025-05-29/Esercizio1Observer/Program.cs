public interface IObserver
{
    void Aggiorna(string messaggio);
}

public interface ISoggetto
{
    void Registra(IObserver observer);
    void Rimuovi(IObserver observer);
    void Notifica(string messaggio);
}

public class CentroMeteo : ISoggetto
{
    private readonly List<IObserver> observers = new List<IObserver>();
    public void Registra(IObserver observer)
    {
        observers.Add(observer);
    }

    public void Rimuovi(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void Notifica(string messaggio)
    {
        foreach (var o in observers)
        {
            o.Aggiorna(messaggio);
        }
    }

    public void AggiornaMeteo(string dati)
    {
        Console.WriteLine("Dati aggiornati.");
        Notifica(dati);
    }
}

public class DisplayConsole : IObserver
{
    public void Aggiorna(string messaggio)
    {
        Console.WriteLine($"DisplayConsole: {messaggio}");
    }
}

public class DisplayMobile : IObserver
{
    public void Aggiorna(string messaggio)
    {
        Console.WriteLine($"DisplayMobile: {messaggio}");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var centroMeteo = new CentroMeteo();
        var displayConsole = new DisplayConsole();
        var displayMobile = new DisplayMobile();

        centroMeteo.Registra(displayConsole);
        centroMeteo.Registra(displayMobile);

        bool exit = false;
        
        while (!exit)
        {
            Console.WriteLine("\nMenù");
            Console.WriteLine("[1] Aggiorna meteo");
            Console.WriteLine("[0] Esci");
            Console.Write("Scelta: ");
            int menuAction = Input.Int(0, 1);
        
            switch (menuAction)
            {
                case 1:
                    Console.Write("\nInserire nuovi dati meteo: ");
                    string dati = Input.String();
                    centroMeteo.AggiornaMeteo(dati);
                    break;
        
                case 0:
                    exit = true;
                    break;
            }
        }
    }
}