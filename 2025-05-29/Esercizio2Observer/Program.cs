public interface IObserver
{
    void Update(string notizia);
}

public interface ISubject
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void Notify(string notizia);
}

public sealed class NewsAgency : ISubject
{
    private NewsAgency() { }

    private static NewsAgency _instance;

    public static NewsAgency Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new NewsAgency();
            }
            return _instance;
        }
    }

    private readonly List<IObserver> observers = new List<IObserver>();
    public void Attach(IObserver observer)
    {
        observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void Notify(string notizia)
    {
        foreach (var observer in observers)
        {
            observer.Update(notizia);
        }
    }

    public void InviaNotizia(string notizia)
    {
        Console.WriteLine("\nNotizia inviata.");
        Notify(notizia);
    }
}

public class MobileApp : IObserver
{
    public void Update(string notizia)
    {
        Console.WriteLine("Notification on mobile: " + notizia);
    }
}

public class EmailClient : IObserver
{
    public void Update(string notizia)
    {
        Console.WriteLine("Email sent: " + notizia);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var newsAgency = NewsAgency.Instance;
        var newsAgency2 = NewsAgency.Instance;

        var mobileApp = new MobileApp();
        var emailClient = new EmailClient();

        newsAgency.Attach(mobileApp);
        newsAgency.Attach(emailClient);

        Console.WriteLine(newsAgency.GetHashCode());
        Console.WriteLine(newsAgency2.GetHashCode());

        bool exit = false;
        
        while (!exit)
        {
            Console.WriteLine("\nMenù");
            Console.WriteLine("[1] Invia notizia");
            Console.WriteLine("[0] Esci");
            Console.Write("Scelta: ");
            int menuAction = Input.Int(0, 1);
        
            switch (menuAction)
            {
                case 1:
                    Console.Write("\nScrivi notizia: ");
                    string notizia = Input.String();
                    newsAgency.InviaNotizia(notizia);
                    break;

                case 0:
                    exit = true;
                    break;
            }
        }
    }
}