public interface IObserver
{
    void NotificaCreazione(string nomeUtente);
}

public interface ISoggetto
{
    void Registra(IObserver o);
    void Rimuovi(IObserver o);
    void Notifica(string nomeUtente);
}

public class GestoreCreazioneUtente : ISoggetto
{
    private List<IObserver> observers = new List<IObserver>();

    public void Registra(IObserver o)
    {
        observers.Add(o);
    }

    public void Rimuovi(IObserver o)
    {
        observers.Remove(o);
    }

    public void Notifica(string nome)
    {
        foreach (IObserver o in observers)
        {
            o.NotificaCreazione(nome);
        }
    }

    public void CreaUtente(string nome)
    {
        Utente utente = UserFactory.Crea(nome);
        Notifica(utente.Nome);
    }
}

public static class UserFactory
{
    public static Utente Crea(string nome)
    {
        return new Utente(nome);
    }
}

public class Utente
{
    private string _nome;
    public string Nome
    {
        get { return _nome; }
        set { _nome = value; }
    }

    public Utente(string nome)
    {
        Nome = nome;
    }

    public override string ToString()
    {
        return "Nome: " + Nome;
    }
}

public class ModuloLog : IObserver
{
    public void NotificaCreazione(string nome)
    {
        Console.WriteLine($"[Log]: Utente \"{nome}\" creato.");
    }
}

public class ModuloMarketing : IObserver
{
    public void NotificaCreazione(string nome)
    {
        Console.WriteLine($"Benvenuto {nome}.");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var gestore = new GestoreCreazioneUtente();
        var moduloLog = new ModuloLog();
        var moduloMarketing = new ModuloMarketing();

        gestore.Registra(moduloLog);
        gestore.Registra(moduloMarketing);

        bool exit = false;
        
        while (!exit)
        {
            Console.WriteLine("\nMenù");
            Console.WriteLine("[1] Crea utente");
            Console.WriteLine("[0] Esci");
            Console.Write("Scelta: ");
            int menuAction = Input.Int(0, 1);
        
            switch (menuAction)
            {
                case 1:
                    Console.Write("\nInserisci nome utente: ");
                    string nome = Input.String();
                    Console.WriteLine("");
                    gestore.CreaUtente(nome);
                    break;
        
                case 0:
                    exit = true;
                    break;
            }
        }
    }
}