using System;

public class Soldato
{
    private string nome;
    private string grado;
    private int anniServizio;

    public string Nome { get; set; }
    public string Grado { get; set; }
    public int AnniServizio
    {
        get
        {
            return anniServizio;
        }
        set
        {
            if (value >= 0)
            {
                anniServizio = value;
            }
        }
    }

    public Soldato(string nome, string grado, int anniServizio)
    {
        Nome = nome;
        Grado = grado;
        AnniServizio = anniServizio;
    }

    public virtual void Descrizione()
    {
        Console.WriteLine($"Soldato nome: {Nome}, grado: {Grado}, anni di servizio: {AnniServizio}");
    }
}

public class Fante : Soldato
{
    private string arma;
    public string Arma { get; set; }

    public Fante(string nome, string grado, int anniServizio, string arma) : base(nome, grado, anniServizio)
    {
        Arma = arma;
    }

    public override void Descrizione()
    {
        Console.WriteLine($"{Grado} {Nome}, anni di servizio: {AnniServizio}, arma: {Arma}");
    }
}

public class Artigliere : Soldato
{
    private int calibro;
    public int Calibro { get; set; }

    public Artigliere(string nome, string grado, int anniServizio, int calibro) : base(nome, grado, anniServizio)
    {
        Calibro = calibro;
    }

    public override void Descrizione()
    {
        Console.WriteLine($"{Grado} {Nome}, anni di servizio: {AnniServizio}, calibro: {Calibro}");
    }
}


public class Program
{
    public static void Main(string[] args)
    {
        bool exit = false;
        List<Soldato> soldati = new List<Soldato>();

        while (!exit)
        {
            Console.WriteLine("\nGestione soldati:\n[1] Aggiungi fante\n[2] Aggiungi artigliere\n[3] Visualizza soldati\n[0] Esci\n");
            int menuAction = Input.Int(0, 3);

            switch (menuAction)
            {
                case 0:
                    exit = true;
                    break;

                case 1:
                    AggiungiFante(soldati);
                    break;

                case 2:
                    AggiungiArtigliere(soldati);
                    break;

                case 3:
                    Console.WriteLine("\nLista dei soldati:\n");

                    foreach (Soldato s in soldati)
                    {
                        s.Descrizione();
                    }
                    break;

            }
        }
    }

    public static void AggiungiFante(List<Soldato> soldati)
    {
        Console.Write("\nInserire il nome: ");
        string nome = Input.String();
        Console.Write("\nInserire il grado: ");
        string grado = Input.String();
        Console.Write("\nInserire gli anni di servizio: ");
        int anniServizio = Input.Int();
        Console.Write("\nInserire l'arma: ");
        string arma = Input.String();

        soldati.Add(new Fante(nome, grado, anniServizio, arma));
        Console.WriteLine("\nFante aggiunto con successo.");
    }
    
    public static void AggiungiArtigliere(List<Soldato> soldati)
    {
        Console.Write("\nInserire il nome: ");
        string nome = Input.String();
        Console.Write("\nInserire il grado: ");
        string grado = Input.String();
        Console.Write("\nInserire gli anni di servizio: ");
        int anniServizio = Input.Int();
        Console.Write("\nInserire il calibro: ");
        int calibro = Input.Int();

        soldati.Add(new Artigliere(nome, grado, anniServizio, calibro));
        Console.WriteLine("\nFante aggiunto con successo.");
    }
}