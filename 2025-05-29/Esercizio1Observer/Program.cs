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

public class DisplayAuto : IObserver
{
    public void Aggiorna(string messaggio)
    {
        Console.WriteLine($"DisplayAuto: {messaggio}");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var centroMeteo = new CentroMeteo();
        var displayConsole = new DisplayConsole();
        var displayMobile = new DisplayMobile();
        var displayAuto = new DisplayAuto();

        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nMenù");
            Console.WriteLine("[1] Aggiorna meteo");
            Console.WriteLine("[2] Aggiungi display");
            Console.WriteLine("[3] Rimuovi display");
            Console.WriteLine("[0] Esci");
            Console.Write("Scelta: ");
            int menuAction = Input.Int(0, 3);

            switch (menuAction)
            {
                case 1:
                    Console.Write("\nInserire nuovi dati meteo: ");
                    string dati = Input.String();
                    centroMeteo.AggiornaMeteo(dati);
                    break;

                case 2:
                    Console.Write("\nScegli display da aggiungere (console, mobile, auto): ");
                    string tipo = Input.String();

                    switch (tipo)
                    {
                        case "console":
                            centroMeteo.Registra(displayConsole);
                            break;

                        case "mobile":
                            centroMeteo.Registra(displayMobile);
                            break;

                        case "auto":
                            centroMeteo.Registra(displayAuto);
                            break;

                        default:
                            Console.WriteLine("Display non valido.");
                            break;
                    }
                    break;

                case 3:
                    Console.Write("\nScegli display da rimuovere (console, mobile, auto): ");
                    tipo = Input.String();

                    switch (tipo)
                    {
                        case "console":
                            centroMeteo.Rimuovi(displayConsole);
                            break;

                        case "mobile":
                            centroMeteo.Rimuovi(displayMobile);
                            break;

                        case "auto":
                            centroMeteo.Rimuovi(displayAuto);
                            break;

                        default:
                            Console.WriteLine("Display non valido.");
                            break;
                    }
                    break;

                case 0:
                    exit = true;
                    break;
            }
        }
    }
}